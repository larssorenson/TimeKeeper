﻿using System;
using System.Collections.Generic;
using System.IO;

namespace TimeKeeper
{
	public class Functions
	{
		/// <summary>
		/// This function takes a text representing a time format of HH:MM:SS, or any mutilation, and will attempt to fix it. 
		/// It is robust and can handle most insidious inputs.
		/// </summary>
		/// <param name="text">The time string to be fixed</param>
		/// <returns>A string representing the input time string, whose format has been fixed</returns>
		public static string fixTimeFormat(string text)
		{
			// Base case of a Null or Empty string, we assume 0 time.
			if (String.IsNullOrEmpty(text))
				return "00:00:00";

			// We will begin by operating on the first colon, repairing the Hours if necessary
			int firstColon = text.IndexOf(':');

			// If we're lacking any colons, we assume we've been provided with a count of seconds
			// and will prepend two colons to trigger recovery below
			if(firstColon == -1)
			{
				text = "::" + text;
			}

			// Loop to catch either no colons or an hour count with less than 2 digits
			while (firstColon < 2)
			{
				firstColon = text.IndexOf(":");
				if (firstColon == 2)
					break;
				// We prepend 0's to the hour count, not changing the value
				// but restoring the format of 0H:MM:SS or 00:MM:SS
				text = "0" + text;
			}

			// Now we move to the second colon for the minutes
			int secondColon = 0;
			int hours = 0;
			do
			{
				secondColon = text.IndexOf(':', firstColon + 1);

				// If we have no colon, it means we got one before for the hours
				// but didn't have a second one. We assume we were given a count of
				// HH:MM and need to restore the :SS.
				if (secondColon == -1)
				{
					text += ":";
				}
				// If our colon is earlier than expected
				// we received HH:M:SS or HH::SS. This will restore to HH:0M:SS or HH:00:SS
				else if (secondColon < firstColon + 3)
				{
					text = text.Insert(firstColon + 1, "0");
				}
				// If our colon is farther than we expected
				// we received HH:(M*N):SS where N > 2. So we have to convert the minutes to numeric
				// and add them to the Hours.
				else if (secondColon > firstColon + 3)
				{
					// If we have HH:(M*N):SS, firstColon = 2, secondColon = firstColon+N+1. We want N, so we subtract firstColon - 1 from secondColon.
					string strMinutes = text.Substring(firstColon + 1, secondColon - firstColon - 1);
					int intMinutes;
					Int32.TryParse(strMinutes, out intMinutes);

					// Now we calculate how many hours we have.
					while (intMinutes >= 60)
					{
						hours++;
						intMinutes -= 60;
					}

					// Now we have to restore our minutes back
					strMinutes = (intMinutes > 9 ? intMinutes.ToString() : "0" + intMinutes.ToString());

					// Before we stitch it all back together, we have to do add our overflow to the hours.
					string strHours = text.Substring(0, firstColon);
					int intHours;
					Int32.TryParse(strHours, out intHours);
					intHours += hours;
					strHours = (intHours > 9 ? intHours.ToString() : "0" + intHours.ToString());

					// Now we patch it all back together.
					text = strHours + ":" + strMinutes + text.Substring(secondColon, text.Length - secondColon);

				}
				// Base case, our second colon is located exactly 3 places after the first one
				// meaning we have a format of HH:MM:
				else
					break;

			}
			while (secondColon != firstColon + 3);

			// The minimum length of the string is two colons plus 6 digits. If we're missing that
			// we assume the hours and minutes are correct, so we pad 0's for the seconds until we're at the right length.
			while(text.Length < ((firstColon - 2) + 8))
			{
				text = text.Insert(secondColon + 1, "0");
			}

			int minutes = 0;
			hours = 0;
			// If we have more than 2 digits worth of seconds
			// We have to calculate overflow seconds into minutes
			if(text.Length - (secondColon+1) != 2)
			{
				// If we have HH:MM:(S*N), secondColon = firstColon+3, and length is secondColon+N. We want N, so we subtract second colon from Length.
				string strSeconds = text.Substring(secondColon+1, text.Length - (secondColon+1));
				int intSeconds;
				Int32.TryParse(strSeconds, out intSeconds);

				// Now we calculate how many minutes we have.
				while (intSeconds >= 60)
				{
					minutes++;
					intSeconds -= 60;
				}

				// Now we have to restore our seconds back
				strSeconds = (intSeconds > 9 ? intSeconds.ToString() : "0" + intSeconds.ToString());

				// Before we stitch it all back together, we have to do add our overflow to the minutes.
				string strMinutes = text.Substring(firstColon+1, 2);
				int intMinutes;
				Int32.TryParse(strMinutes, out intMinutes);
				intMinutes += minutes;

				while(intMinutes >= 60)
				{
					hours++;
					intMinutes -= 60;
				}

				strMinutes = (intMinutes > 9 ? intMinutes.ToString() : "0" + intMinutes.ToString());

				// And unfortunately we also have to add any overflow hours.
				string strHours = text.Substring(0, firstColon);
				int intHours;
				Int32.TryParse(strHours, out intHours);
				intHours += hours;
				strHours = (intHours > 9 ? intHours.ToString() : "0" + intHours.ToString());

				// Now we patch it all back together.
				text = strHours + ":" + strMinutes + ":" + strSeconds;
			}

			return text;

		}
		/// <summary>
		/// This function will take a string representing a time format of HH:MM:SS and will increment it by 1, performing necessary wrapping of minutes and seconds.
		/// </summary>
		/// <param name="time">The time to increment</param>
		/// <returns>The time, incremented by 1</returns>
		public static string textTimeIncrement(string time)
		{
			return addIntToTime(time, 1);
		}
		/// <summary>
		/// This function will take two strings representing a time format of HH:MM:SS and will add them together.
		/// </summary>
		/// <param name="time">The time to be added to</param>
		/// <param name="add">The time to add</param>
		/// <returns>A string representing the time result from adding the two together</returns>
		public static string addTimetoTime(string time, string add)
		{
			return timeFromInt(intFromTime(time) + intFromTime(add));
		}

		/// <summary>
		/// This function will take two strings representing a time format of HH:MM:SS and will subtract the second parameter from the first.
		/// </summary>
		/// <param name="time">The time to be subtracted from</param>
		/// <param name="sub">The time to subtract</param>
		/// <returns>A string representing the time result from subtracting the second paramter from the first</returns>
		public static string subIntFromTime(string time, int sub)
		{
			return timeFromInt(intFromTime(time) - sub);
		}
		/// <summary>
		/// This function will take a string representing a time format of HH:MM:SS and will add an integer amount of seconds to it
		/// </summary>
		/// <param name="time">The time to be added to</param>
		/// <param name="add">An integer number of seconds to add</param>
		/// <returns>A string representing the time result from adding "add" number of seconds to "time".</returns>
		public static string addIntToTime(string time, int add)
		{
			return timeFromInt(intFromTime(time) + add);
		}
		/// <summary>
		/// This function will take two strings representing a time format of HH:MM:SS and will subtract the second time string from the first
		/// </summary>
		/// <param name="time">The time to be subtracted from</param>
		/// <param name="sub">The time to subtract</param>
		/// <returns>A string representing the time result from subtracting "sub" from "time".</returns>
		public static string subTimeFromTime(string time, string sub)
		{
			return timeFromInt(intFromTime(time) - intFromTime(sub));
		}

		/// <summary>
		/// Standardized function to write a list of charge codes to a file. It allows for template writing, which runs the list of all charge codes ever used.
		/// </summary>
		/// <param name="file">The StreamWriter representing the file to write to</param>
		/// <param name="lstChargeCodes">A list of Charge Codes to be written to a file</param>
		/// <param name="template">Whether or not to write the time of the charge codes. Used only if writing the Template List or if time recording isn't needed.</param>
		public static void writeToFile(StreamWriter file, List<ChargeCode> lstChargeCodes, bool template = false)
		{
			foreach (ChargeCode c in lstChargeCodes)
			{
				file.WriteLine("{0},{1},{2}", c.selected.Text.Replace("&&", "&"), c.chargeCode, (template ? 0 : c.time));
			}

		}

		/// <summary>
		/// This function will take a string for a file name, a list of charge codes, and an optional boolean indicating whether or not the list is a template.
		/// It will then write the list of charge codes to the file indicated. If the template boolean is provided, the times will be recorded as 0's.
		/// </summary>
		/// <param name="file">A string representing the path to the file.</param>
		/// <param name="lstChargeCodes">A list of Charge Codes to be written to a file</param>
		/// <param name="template">Whether or not to write the time of the charge codes. Used only if writing the Template List or if time recording isn't needed.</param>
		public static void writeToFile(string file, List<ChargeCode> lstChargeCodes, bool template = false)
		{
			using(var fileWriter = new StreamWriter(file))
			{
				writeToFile(fileWriter, lstChargeCodes, template);
			}

		}

		/// <summary>
		/// This function will take an integer number of seconds and produce a string representing the amount of time in HH:MM:SS.
		/// </summary>
		/// <param name="time">The integer number of seconds to be converted</param>
		/// <returns>A string representing the time format HH:MM:SS equal to the number of seconds provided</returns>
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

		/// <summary>
		/// This function will take a string representing the time format HH:MM:SS and will return the number of seconds it is equivalent to
		/// </summary>
		/// <param name="time">The time format to be parsed into seconds</param>
		/// <returns>An integer number of seconds represented by "time".</returns>
		public static int intFromTime(string time)
		{
			int hour = 0, minute = 0, second = 0;
			// If there are no colons, assume we've been given seconds
			if (!time.Contains(":"))
			{
				Int32.TryParse(time, out second);
				return second;
			}
			
			// Otherwise, we can split up the time format HH:MM:SS respectively.
			string[] hour_minute_second = time.Split(':');

			// We should AT LEAST have the number of hours if we have a colon.
			Int32.TryParse(hour_minute_second[0], out hour);

			// If we have more than one element, we assume we've been given minutes as well
			if (hour_minute_second.Length > 1)
			{
				Int32.TryParse(hour_minute_second[1], out minute);
			}

			// If we have yet another element, the last one is seconds.
			if (hour_minute_second.Length > 2)
			{
				Int32.TryParse(hour_minute_second[2], out second);
			}

			return (hour * 3600) + (minute * 60) + second;
		}

	}

}
