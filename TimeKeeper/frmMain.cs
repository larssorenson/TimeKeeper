using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace TimeKeeper
{
	public partial class frmMain : Form
	{
		bool clockedIn = false;
		bool saved = true;
		bool writing = false;
		
		int ticksSinceLastSave = 0;
		int autoSaveIncrement = 0;

		List<ChargeCode> chargeCodes;
		List<ChargeCode> template;
		ChargeCode currentChargeCode;

		string path;
		string fileName;
		string settingsFile;
		string templateFileName;

		public frmMain()
		{
			InitializeComponent();

			txtClockedIn.Text = "00:00:00";
			this.Height = this.Height - pnlTime.Location.Y;

			chargeCodes = new List<ChargeCode>();
			template = new List<ChargeCode>();
			currentChargeCode = null;

			path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");

			readChargeCodes();

			readSettingsFile();
			
			align();

			tmrSeconds.Start();
		}

		private void readChargeCodes()
		{

			templateFileName = (path + "\\template.csv");

			if (File.Exists(templateFileName))
			{
				writing = true;
				using (var fileReader = File.OpenRead(templateFileName))
				{
					readFile(fileReader, null, null);
					fileReader.Close();
				}

				writing = false;
			}

			fileName = (path + "\\" + DateTime.Today.ToString().Split(' ')[0].Replace('/', '_') + ".csv");
			txtFileName.Text = fileName;

			if (File.Exists(fileName))
			{
				writing = true;
				using (var fileReader = File.OpenRead(fileName))
				{
					readFile(fileReader, null, null);
					fileReader.Close();
				}

				writing = false;
			}
			else
			{
				foreach (var chargeCode in template)
				{
					txtNewChargeCode.Text = chargeCode.chargeCode;
					txtNewChargeCodeName.Text = chargeCode.name.Text;
					btnAddChargeCode_Click(null, null);
				}

				txtNewChargeCode.Text = "";
				txtNewChargeCodeName.Text = "";

			}

		}

		private void readSettingsFile()
		{

			// Settings file read
			settingsFile = (path + "\\settings.txt");
			var settingsFileStream = File.Open(settingsFile, FileMode.OpenOrCreate);

			// Auto Save is the first byte. Expecting a number, so we subtract the ASCII -> 0-index factor, which is 48. (ASCII for '0' is 48)
			onoffToolStripMenuItem.Checked = (settingsFileStream.ReadByte() - 48 == 0 ? false : true);

			// New line
			settingsFileStream.ReadByte();

			// Increment for auto saving is variable # of bytes, so we read until a new line or EOF
			int c;
			while ((c = settingsFileStream.ReadByte()) != (int)'\n' && c != -1)
			{
				autoSaveIncrement += int.Parse(((Char)c).ToString());
				autoSaveIncrement *= 10;
			}
			// Fix the increment
			autoSaveIncrement /= 10;

			// If we somehow read a negative number, default it
			if (autoSaveIncrement < 0)
				autoSaveIncrement = 300;

			txtAutoSaveTime.Text = autoSaveIncrement.ToString();

			// Same thing as autoSave
			chckChangeOnClick.Checked = (settingsFileStream.ReadByte() - 48 == 0 ? false : true);

			// New line
			settingsFileStream.ReadByte();

			// And same as Change On Click and Auto Save
			chckScrollable.Checked = (settingsFileStream.ReadByte() - 48 == 0 ? false : true);

			settingsFileStream.Close();
		}

		private void tmrSeconds_Tick(object sender, EventArgs e)
		{
			if (currentChargeCode == null)
			{
				clockedIn = false;
				btnClockIn.Enabled = false;
				btnClockOut.Enabled = false;
				btnChangeChargeCode.Enabled = false;
			}

			if (currentChargeCode != null && btnChangeChargeCode.Enabled == false)
			{
				btnClockIn.Enabled = true;
				btnClockOut.Enabled = true;
				btnChangeChargeCode.Enabled = true;
			}

			if (clockedIn)
			{
				txtClockedIn.Text = Functions.textTimeIncrement(txtClockedIn.Text);
				currentChargeCode.time++; 
				currentChargeCode.timeText.Text = Functions.timeFromInt(currentChargeCode.time);
				txtCurrentChargeCode.Text = currentChargeCode.selected.Text;
				saved = false;
			}

			ticksSinceLastSave++;
			if (onoffToolStripMenuItem.Checked && !saved)
			{
				if(txtAutoSaveTime.Text != "")
					autoSaveIncrement = int.Parse(txtAutoSaveTime.Text);
				if (ticksSinceLastSave >= autoSaveIncrement)
				{
					if (!writing)
					{
						writing = true;
						using (var fileWriter = new StreamWriter(fileName))
						{
							Functions.writeToFile(fileWriter, chargeCodes, false);
							fileWriter.Close();
							ticksSinceLastSave = 0;
							saved = true;
						}

						writing = false;
					}

				}

			}

		}

		private void btnClockIn_Click(object sender, EventArgs e)
		{
			clockedIn = true;
			btnClockIn.Enabled = false;
			btnClockOut.Enabled = true;
		}

		private void btnClockOut_Click(object sender, EventArgs e)
		{
			clockedIn = false;
			btnClockOut.Enabled = false;
			btnClockIn.Enabled = true;
		}

		public void changeChargeCode()
		{
			RadioButton current = pnlTime.Controls.OfType<RadioButton>().Where(x => x.Checked == true).FirstOrDefault();

			if (current == null)
			{
				currentChargeCode = null;
				return;
			}

			currentChargeCode = chargeCodes.Where(x => x.selected == current).FirstOrDefault();

			txtCurrentChargeCode.Text = currentChargeCode.selected.Text.Replace("&&", "&") ?? "No charge codes!";
		}

		private void btnChangeChargeCode_Click(object sender, EventArgs e)
		{
			changeChargeCode();
		}

		private void btnAddChargeCode_Click(object sender, EventArgs e)
		{

			if (!txtNewChargeCode.Text.Contains(' '))
			{
				txtNewChargeCode.Text = txtNewChargeCode.Text.Replace("-", " - ");
			}

			foreach (ChargeCode c in chargeCodes)
			{
				if (c.chargeCode.Equals(txtNewChargeCode.Text) || c.selected.Text.Equals(txtNewChargeCodeName.Text))
				{
					txtNewChargeCodeName.Text = "";
					txtNewChargeCode.Text = "";
					return;
				}

			}

			RadioButton chargeCodeRDO = new RadioButton();
			chargeCodeRDO.Text = txtNewChargeCodeName.Text.Replace("&", "&&");

			TextBox chargeCodeTimeTextBox = new TextBox();
			chargeCodeTimeTextBox.Text = "00:00:00";
			chargeCodeTimeTextBox.Width = TextRenderer.MeasureText(chargeCodeTimeTextBox.Text, chargeCodeTimeTextBox.Font).Width;
			chargeCodeTimeTextBox.Enter += txtChargeCodeTime_Enter;
			chargeCodeTimeTextBox.Leave += txtChargeCodeTime_Leave;

			Label chargeCodeNameLabel = new Label();
			chargeCodeNameLabel.Text = txtNewChargeCode.Text;
			chargeCodeNameLabel.Width = chargeCodeNameLabel.PreferredWidth;

			var last = chargeCodes.LastOrDefault<ChargeCode>();
			int lastX, lastY, lastTab;
			if (last == null)
			{
				lastX = 5;
				lastY = 5;
				lastTab = chckScrollable.TabIndex;
			}

			else
			{
				lastX = last.selected.Location.X;
				lastY = last.selected.Location.Y + last.selected.Size.Height;
				lastTab = last.removeMyself.TabIndex;
			}

			var y = lastY;

			chargeCodeRDO.Location = new Point(lastX, y);
			chargeCodeRDO.TabIndex = lastTab + 1;
			chargeCodeRDO.Width = chargeCodeRDO.PreferredSize.Width;
			chargeCodeRDO.Click += changeOnClickFunc;

			Button removeMyself = new Button();
			removeMyself.Text = "Remove";
			removeMyself.Name = txtNewChargeCode.Text;
			removeMyself.Click += removeChargeCode;

			chargeCodeTimeTextBox.Location = new Point(chargeCodeRDO.Location.X + chargeCodeRDO.Width + 5, y + 20);

			chargeCodeNameLabel.Location = new Point(chargeCodeTimeTextBox.Location.X + chargeCodeTimeTextBox.Width + 5, y + 20);

			removeMyself.Location = new Point(chargeCodeNameLabel.Location.X + chargeCodeNameLabel.Width + 5, y + 20);
			removeMyself.TabIndex = chargeCodeRDO.TabIndex + 1;

			ChargeCode newCode = new ChargeCode();
			newCode.selected = chargeCodeRDO;
			newCode.timeText = chargeCodeTimeTextBox;
			newCode.time = 0;
			newCode.chargeCode = txtNewChargeCode.Text;
			newCode.name = chargeCodeNameLabel;
			newCode.removeMyself = removeMyself;

			chargeCodes.Add(newCode);
			template.Add(newCode);

			if (last == null)
			{
				currentChargeCode = newCode;
				newCode.selected.Checked = true;
				btnClockIn.Enabled = true;
			}

			else
			{
				btnChangeChargeCode.Enabled = true;
			}

			pnlTime.Controls.Add(chargeCodeRDO);
			pnlTime.Controls.Add(chargeCodeTimeTextBox);
			pnlTime.Controls.Add(chargeCodeNameLabel);
			pnlTime.Controls.Add(removeMyself);

			txtNewChargeCode.Text = "";
			txtNewChargeCodeName.Text = "";

			this.Height += chargeCodeRDO.PreferredSize.Height + 16;
			this.Width = pnlTime.Width - chargeCodes[0].selected.PreferredSize.Width + TextRenderer.MeasureText(chargeCodes[0].timeText.Text, chargeCodes[0].timeText.Font).Width  + chargeCodes[0].name.PreferredWidth + 5;

			saved = false;


			align();
		}

		private void txtChargeCodeTime_Enter(object sender, EventArgs e)
		{
			TextBox txt = sender as TextBox;
			ChargeCode curr = null;
			foreach(ChargeCode c in chargeCodes)
			{
				if (c.timeText == txt)
				{
					curr = c;
					break;
				}
			}

			if (curr == null)
				return;

			curr.oldTime = Functions.intFromTime(txt.Text);
		}

		private void txtChargeCodeTime_Leave(object sender, EventArgs e)
		{
			TextBox txt = sender as TextBox;
			ChargeCode curr = null;
			foreach (ChargeCode c in chargeCodes)
			{
				if (c.timeText == txt)
				{
					curr = c;
					break;
				}
			}

			if (curr == null)
				return;

			txt.Text = Functions.fixTimeFormat(txt.Text);
			curr.time = Functions.intFromTime(txt.Text);
			txtClockedIn.Text = Functions.timeFromInt(Functions.intFromTime(txtClockedIn.Text) + (curr.time - curr.oldTime));

		}

		protected void removeChargeCode(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			ChargeCode curr = null;
			foreach (ChargeCode c in chargeCodes)
			{
				if (c.removeMyself == btn)
				{
					curr = c;
					break;
				}
			}

			if (curr == null)
				return;

			chargeCodes.Remove(curr);
			pnlTime.Controls.Remove(curr.timeText);
			pnlTime.Controls.Remove(curr.selected);
			pnlTime.Controls.Remove(curr.name);
			pnlTime.Controls.Remove(curr.removeMyself);
			txtClockedIn.Text = Functions.timeFromInt(Functions.intFromTime(txtClockedIn.Text) + curr.time);
			align();
		}

		private void chckScrollable_CheckedChanged(object sender, EventArgs e)
		{
			pnlTime.AutoSize = !chckScrollable.Checked;
			if (chckScrollable.Checked)
			{
				this.Height = pnlTime.Location.Y + pnlTime.Height + 50;
				pnlTime.Width = this.Width - 15;
			}

			else
			{
				this.Height = this.Height - pnlTime.Location.Y;
				foreach (ChargeCode c in chargeCodes)
				{
					this.Height += c.selected.PreferredSize.Height + 8;
				}

			}

		}

		private void readFile(Stream file, object sender, EventArgs e)
		{
			string code = "";
			string name = "";
			string time = "";
			int op = 0;
			int ch = -1;
			int lastch = -1;
			
			while ((ch = file.ReadByte()) != -1)
			{
				// Comma delimited
				if (ch == ',')
				{
					op++;
					lastch = ch;
					continue;
				}

				else if (ch == '\r')
				{
					lastch = ch;
					continue;
				}

				// We've finished a row
				else if ((ch == '\n' && lastch == '\r') || ch == '\n')
				{
					txtNewChargeCode.Text = code;
					txtNewChargeCodeName.Text = name;
					btnAddChargeCode_Click(sender, e);

					var last = chargeCodes.Where<ChargeCode>(x => x.chargeCode == code).FirstOrDefault();
					if (last.chargeCode == code)
					{
						bool success = false;
						try
						{
							success = Int32.TryParse(time, out last.time);
						}

						catch
						{
							last.time = 0;
						}

						if (!success)
						{
							last.time = 0;
						}

						last.timeText.Text = Functions.timeFromInt(last.time);
					}

					code = "";
					name = "";
					time = "";
					op = 0;
					lastch = ch;
					continue;
				}

				else
				{
					// Add the read character to the relevant string
					switch (op)
					{
						case 0:
							name += (char)ch;
							break;
						case 1:
							code += (char)ch;
							break;
						case 2:
							time += (char)ch;
							break;
					}

					lastch = ch;
				}

			}

			if (!String.IsNullOrEmpty(code) && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(time))
			{
				txtNewChargeCode.Text = code;
				txtNewChargeCodeName.Text = name;
				btnAddChargeCode_Click(sender, e);

				var lastOne = chargeCodes.Last<ChargeCode>();
				if (lastOne.chargeCode == code)
				{
					lastOne.time = Int32.Parse(time);
					lastOne.timeText.Text = Functions.timeFromInt(lastOne.time);
				}

			}

			time = "00:00:00";
			foreach (ChargeCode c in chargeCodes)
			{
				time = Functions.timeFromInt(Functions.intFromTime(time) + c.time);
			}

			txtClockedIn.Text = time;

		}

		private void importToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saved = false;
			var c = new OpenFileDialog();
			c.Filter += "Comma Separated Values (*.csv) | *.csv";

			c.ShowDialog();
			if (String.IsNullOrEmpty(c.FileName))
				return;

			if (!writing)
			{
				writing = true;
				using (var fileReader = c.OpenFile())
				{
					readFile(fileReader, sender, e);
					fileReader.Close();
				}

				writing = false;
			}

			align();
		}

		
		private void align()
		{
			int lblmax = 0;
			int txtmax = 0;
			int btnmax = 0;
			ChargeCode last = null;
			foreach (ChargeCode c in chargeCodes)
			{
				if (last == null)
				{
					c.timeText.Location = new Point(c.timeText.Location.X, 10);
					c.name.Location = new Point(c.name.Location.X, 10);
					c.selected.Location = new Point(c.selected.Location.X, 10);
					if (c.removeMyself != null)
						c.removeMyself.Location = new Point(c.removeMyself.Location.X, 10);
				}

				else
				{
					c.timeText.Location = new Point(c.timeText.Location.X, last.timeText.Location.Y + 30);
					c.name.Location = new Point(c.name.Location.X, last.name.Location.Y + 30);
					c.selected.Location = new Point(c.selected.Location.X, last.selected.Location.Y + 30);
					if (c.removeMyself != null)
					{
						if (last.removeMyself != null)
							c.removeMyself.Location = new Point(c.removeMyself.Location.X, last.removeMyself.Location.Y + 30);
						else
							c.removeMyself.Location = new Point(c.name.Location.X + c.name.PreferredWidth + 5, c.name.Location.Y);
					}

				}

				last = c;
				if (c.timeText.Location.X > lblmax)
					lblmax = c.timeText.Location.X;
				if (c.name.Location.X > txtmax)
					txtmax = c.name.Location.X;
				if(c.removeMyself != null)
					if (c.removeMyself.Location.X > btnmax)
						btnmax = c.removeMyself.Location.X;
			}

			foreach (ChargeCode c in chargeCodes)
			{
				c.timeText.Location = new Point(lblmax, c.timeText.Location.Y);
				c.name.Location = new Point(txtmax, c.name.Location.Y);
				if(c.removeMyself != null)
					c.removeMyself.Location = new Point(btnmax, c.removeMyself.Location.Y);
			}

		}

		private void changeOnClickFunc(object sender, EventArgs e)
		{
			if (chckChangeOnClick.Checked)
			{
				changeChargeCode();
			}

		}

		private void exportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!writing)
			{
				writing = true;
				var save = new SaveFileDialog();
				save.Filter += "Comma Separated Values (*.csv) | *.csv"; ;

				save.ShowDialog();
				if (String.IsNullOrEmpty(save.FileName))
				{
					if (String.IsNullOrEmpty(txtFileName.Text))
					{
						MessageBox.Show("No file name choosen or supplied!");
						return;
					}

					fileName = txtFileName.Text;
				}

				else
					fileName = save.FileName;

				using (var fileWriter = new StreamWriter(fileName))
				{
					Functions.writeToFile(fileWriter, chargeCodes, false);
					fileWriter.Close();
					ticksSinceLastSave = 0;
					writing = false;
					saved = true;
				}

			}

		}

		private void onToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (onoffToolStripMenuItem.Checked)
			{
				onoffToolStripMenuItem.Checked = false;
				txtAutoSaveTime.Text = "Auto Save Period In Seconds";
			}

			else
			{
				onoffToolStripMenuItem.Checked = true;
				txtAutoSaveTime.Text = autoSaveIncrement.ToString();
			}

		}

		private void txtAutoSaveTime_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.D1:
				case Keys.D2:
				case Keys.D3:
				case Keys.D4:
				case Keys.D5:
				case Keys.D6:
				case Keys.D7:
				case Keys.D8:
				case Keys.D9:
				case Keys.D0:
				case Keys.NumPad0:
				case Keys.NumPad1:
				case Keys.NumPad2:
				case Keys.NumPad3:
				case Keys.NumPad4:
				case Keys.NumPad5:
				case Keys.NumPad6:
				case Keys.NumPad7:
				case Keys.NumPad8:
				case Keys.NumPad9:
					e.SuppressKeyPress = false;
					break;
				default:
					e.SuppressKeyPress = true;
					break;
			}

		}

		private void txtAutoSaveTime_Click(object sender, EventArgs e)
		{
			txtAutoSaveTime.Text = "";
		}

		private void txtAutoSaveTime_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.D1:
				case Keys.D2:
				case Keys.D3:
				case Keys.D4:
				case Keys.D5:
				case Keys.D6:
				case Keys.D7:
				case Keys.D8:
				case Keys.D9:
				case Keys.D0:
				case Keys.NumPad0:
				case Keys.NumPad1:
				case Keys.NumPad2:
				case Keys.NumPad3:
				case Keys.NumPad4:
				case Keys.NumPad5:
				case Keys.NumPad6:
				case Keys.NumPad7:
				case Keys.NumPad8:
				case Keys.NumPad9:
					e.SuppressKeyPress = false;
					break;
				default:
					e.SuppressKeyPress = true;
					break;
			}

		}

		private void txtAutoSaveTime_Leave(object sender, EventArgs e)
		{
			autoSaveIncrement = int.Parse(txtAutoSaveTime.Text);
			ticksSinceLastSave = 0;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Created by: Lars Sorenson");
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			txtClockedIn.Text = "00:00:00";
			foreach (ChargeCode c in chargeCodes)
			{
				c.time = 0;
				c.timeText.Text = "00:00:00";
			}

			fileName = (path + "\\" + DateTime.Today.ToString().Split(' ')[0].Replace('/', '_') + ".csv");
			txtFileName.Text = fileName;
		}

		private void saveAndExitToolStripMenuItem_Click(object sender, EventArgs e)
		{

			if (!saved)
			{
				while (writing)
				{ }

				writing = true;
				using (var fileWriter = new StreamWriter(fileName))
				{
					Functions.writeToFile(fileWriter, chargeCodes, false);
					fileWriter.Close();
					saved = true;
				}

				using (var fileWriter = new StreamWriter(templateFileName))
				{
					Functions.writeToFile(fileWriter, template, true);
					fileWriter.Close();
					saved = true;
				}

				writing = false;

			}

			using (var settingsWriter = new StreamWriter(settingsFile))
			{
				settingsWriter.Write((onoffToolStripMenuItem.Checked ? 1 : 0));
				settingsWriter.Write('\n');
				settingsWriter.Write(autoSaveIncrement);
				settingsWriter.Write('\n');
				settingsWriter.Write((chckChangeOnClick.Checked ? 1 : 0));
				settingsWriter.Write('\n');
				settingsWriter.Write((chckScrollable.Checked ? 1 : 0));
				settingsWriter.Close();
			}

			this.Close();
		}

		private void frmMain_ResizeEnd(object sender, EventArgs e)
		{
			if (chckScrollable.Checked)
			{
				pnlTime.Height = this.Height - pnlTime.Location.Y - 45;
			}

		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!saved)
			{
				var response = MessageBox.Show("Are you sure you want to exit without saving?", "Warning!", MessageBoxButtons.YesNo);
				if (response == System.Windows.Forms.DialogResult.Yes)
					e.Cancel = false;
				if (response == System.Windows.Forms.DialogResult.No)
					e.Cancel = true;
			}

		}

	}

}
