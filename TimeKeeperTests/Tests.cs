using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeKeeper;

namespace TimeKeeperTests
{
	[TestClass]
	public class Tests
	{
		[TestMethod]
		public void TestFixTimeFormat()
		{
			string test = "00:0:00";
			string expected = "00:00:00";
			string result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);

			test = "0:00:00";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);

			test = "00:00:0";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);

			test = "00:0:0";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);

			test = "0:0:0";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);

			test = "100:0:0";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual("100:00:00", result);

			test = "100:00:0";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual("100:00:00", result);

			test = ":00:00";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);

			test = "00::00";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);

			test = "00:00:";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);

			test = "00::";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);

			test = ":00:";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);

			test = "::00";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);

			test = "::";
			result = TimeKeeper.Functions.fixTimeFormat(test);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void TestTimeFromInt()
		{
			int testTime = 3600; // 1 hour
			string result = TimeKeeper.Functions.timeFromInt(testTime);
			Assert.AreEqual("01:00:00", result);

			testTime = 10400; // 2 hours, 53 minutes and 20 seconds
			result = TimeKeeper.Functions.timeFromInt(testTime);
			Assert.AreEqual("02:53:20", result);

			testTime = 53; // 53 seconds
			result = TimeKeeper.Functions.timeFromInt(testTime);
			Assert.AreEqual("00:00:53", result);

			testTime = 86399; // 23 hours, 59 minutes and 59 seconds
			result = TimeKeeper.Functions.timeFromInt(testTime);
			Assert.AreEqual("23:59:59", result);

			testTime = 86400; // 24 hours, 00 minutes and 00 seconds
			result = TimeKeeper.Functions.timeFromInt(testTime);
			Assert.AreEqual("24:00:00", result);

			testTime = 86401; // 24 hours, 00 minutes and 01 seconds
			result = TimeKeeper.Functions.timeFromInt(testTime);
			Assert.AreEqual("24:00:01", result);
		}

		[TestMethod]
		public void TestSubFromTime()
		{
			string subtraction = "00:30:00";
			string time = "00:30:00";
			string result = TimeKeeper.Functions.subTimeFromTime(time, subtraction);
			Assert.AreEqual("00:00:00", result);

			subtraction = "00:30:00";
			time = "00:00:00";
			result = TimeKeeper.Functions.subTimeFromTime(time, subtraction);
			Assert.AreEqual("00:00:00", result);

			subtraction = "00:30:00";
			time = "01:00:00";
			result = TimeKeeper.Functions.subTimeFromTime(time, subtraction);
			Assert.AreEqual("00:30:00", result);
		}

		[TestMethod]
		public void TestAddTimeToTime()
		{
			string addition = "00:30:00";
			string time = "00:30:00";
			string result = TimeKeeper.Functions.addTimetoTime(time, addition);
			Assert.AreEqual("01:00:00", result);

			addition = "00:30:00";
			time = "00:00:00";
			result = TimeKeeper.Functions.addTimetoTime(time, addition);
			Assert.AreEqual("00:30:00", result);

			addition = "00:30:00";
			time = "01:00:00";
			result = TimeKeeper.Functions.addTimetoTime(time, addition);
			Assert.AreEqual("01:30:00", result);

			addition = "04:30:00";
			time = "01:00:00";
			result = TimeKeeper.Functions.addTimetoTime(time, addition);
			Assert.AreEqual("05:30:00", result);
		}

		[TestMethod]
		public void TestTimeIncrement()
		{
			string time = "00:30:00";
			string result = TimeKeeper.Functions.textTimeIncrement(time);
			Assert.AreEqual("00:30:01", result);
		}

		[TestMethod]
		public void TestIntFromTime()
		{
			string testTime = "01:00:00"; // 1 hour
			int result = TimeKeeper.Functions.intFromTime(testTime);
			Assert.AreEqual(3600, result);

			testTime = "02:53:20"; // 2 hours, 53 minutes and 20 seconds
			result = TimeKeeper.Functions.intFromTime(testTime);
			Assert.AreEqual(10400, result);

			testTime = "00:00:53"; // 53 seconds
			result = TimeKeeper.Functions.intFromTime(testTime);
			Assert.AreEqual(53, result);

			testTime = "23:59:59"; // 23 hours, 59 minutes and 59 seconds
			result = TimeKeeper.Functions.intFromTime(testTime);
			Assert.AreEqual(86399, result);

			testTime = "24:00:00"; // 24 hours, 00 minutes and 00 seconds
			result = TimeKeeper.Functions.intFromTime(testTime);
			Assert.AreEqual(86400, result);

			testTime = "24:00:01"; // 24 hours, 00 minutes and 01 seconds
			result = TimeKeeper.Functions.intFromTime(testTime);
			Assert.AreEqual(86401, result);
		}

	}
}
