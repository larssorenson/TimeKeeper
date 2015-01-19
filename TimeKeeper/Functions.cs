using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper
{
	public class Functions
	{
		public static string fixTimeFormat(string text)
		{
			if (String.IsNullOrEmpty(text))
				return "00:00:00";
			int firstColon = text.IndexOf(':');
			while (firstColon < 2)
			{
				firstColon = text.IndexOf(":");
				if (firstColon == 2)
					break;
				text = "0" + text;
			}

			int secondColon = 0;
			while (secondColon != firstColon + 3)
			{
				secondColon = text.IndexOf(':', firstColon + 1);
				if (secondColon < firstColon + 3)
				{
					text = text.Insert(firstColon + 1, "0");
				}
				else if (secondColon > firstColon + 3)
				{
					text = text.Insert(secondColon + 1, "0");
				}

				else
					break;

			}

			while(text.Length < ((firstColon - 2) + 8))
			{
				text = text.Insert(secondColon + 1, "0");
			}

			return text;

		}
		public static string textTimeIncrement(string time)
		{
			var hours = int.Parse(time.Split(':')[0]);
			var minutes = int.Parse(time.Split(':')[1]);
			var seconds = int.Parse(time.Split(':')[2]);
			++seconds;
			if (seconds == 60)
			{
				++minutes;
				seconds = 0;
			}

			if (minutes == 60)
			{
				++hours;
				minutes = 0;
			}

			if (hours == 24)
			{
				hours = 0;
				minutes = 0;
				seconds = 0;
			}

			return (hours > 9 ? hours.ToString() : "0" + hours) + ":" + (minutes > 9 ? minutes.ToString() : "0" + minutes) + ":" + (seconds > 9 ? seconds.ToString() : "0" + seconds);
		}

		public static string addTimetoTime(string time, string add)
		{
			return timeFromInt(intFromTime(time) + intFromTime(add));
			/*
			var timeSplit = time.Split(':');
			var hours = int.Parse(timeSplit[0]);
			var minutes = int.Parse(timeSplit[1]);
			var seconds = int.Parse(timeSplit[2]);

			var addSplit = add.Split(':');
			var hours_to_add = int.Parse(addSplit[0]);
			var minutes_to_add = int.Parse(addSplit[1]);
			var seconds_to_add = int.Parse(addSplit[2]);

			seconds += seconds_to_add;
			if (seconds >= 60)
			{
				++minutes;
				seconds = seconds % 60;
			}

			minutes += minutes_to_add;
			if (minutes >= 60)
			{
				++hours;
				minutes = minutes % 60;
			}

			hours += hours_to_add;
			if (hours >= 24)
			{
				hours = hours % 24;
			}

			return (hours > 9 ? hours.ToString() : "0" + hours) + ":" + (minutes > 9 ? minutes.ToString() : "0" + minutes) + ":" + (seconds > 9 ? seconds.ToString() : "0" + seconds);*/
		}

		public static string subIntFromTime(string time, int sub)
		{
			return timeFromInt(intFromTime(time) - sub);
		}

		public static string addIntToTime(string time, int add)
		{
			return timeFromInt(intFromTime(time) + add);
		}

		public static string subTimeFromTime(string time, string sub)
		{
			return timeFromInt(intFromTime(time) - intFromTime(sub));
			/*var timeSplit = time.Split(':');
			var hours = int.Parse(timeSplit[0]);
			var minutes = int.Parse(timeSplit[1]);
			var seconds = int.Parse(timeSplit[2]);

			var addSplit = sub.Split(':');
			var hours_to_sub = int.Parse(addSplit[0]);
			var minutes_to_sub = int.Parse(addSplit[1]);
			var seconds_to_sub = int.Parse(addSplit[2]);

			seconds -= seconds_to_sub;
			if (seconds < 0)
			{
				--minutes;
				seconds = seconds + 60;
			}

			minutes -= minutes_to_sub;
			if (minutes < 0)
			{
				--hours;
				minutes = minutes + 60;
			}

			hours -= hours_to_sub;
			if (hours < 0)
			{
				hours = hours + 24;
			}

			return (hours > 9 ? hours.ToString() : "0" + hours) + ":" + (minutes > 9 ? minutes.ToString() : "0" + minutes) + ":" + (seconds > 9 ? seconds.ToString() : "0" + seconds);*/
		}

		public static void writeToFile(StreamWriter file, List<ChargeCode> lstChargeCodes, bool template)
		{
			foreach (ChargeCode c in lstChargeCodes)
			{
				file.WriteLine("{0},{1},{2}", c.selected.Text.Replace("&&", "&"), c.chargeCode, (template ? 0 : c.time));
			}
		}

		public static string timeFromInt(int time)
		{
			if (time < 0)
				return "00:00:00";
			int hours = 0;
			int minutes = 0;
			int seconds = 0;
			while (time >= 3600)
			{
				hours++;
				time -= 3600;
			}

			while (time >= 60)
			{
				minutes++;
				time -= 60;
			}

			seconds = time;
			return (hours > 9 ? hours.ToString() : "0" + hours) + ":" + (minutes > 9 ? minutes.ToString() : "0" + minutes) + ":" + (seconds > 9 ? seconds.ToString() : "0" + seconds);
		}

		public static int intFromTime(string time)
		{
			string[] hour_minute_second = time.Split(':');

			int hour = Int32.Parse(hour_minute_second[0]);
			int minute = Int32.Parse(hour_minute_second[1]);
			int second = Int32.Parse(hour_minute_second[2]);

			return (hour * 3600) + (minute * 60) + second;
		}

	}
}
