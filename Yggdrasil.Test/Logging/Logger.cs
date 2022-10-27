﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;
using Yggdrasil.Logging;
using Yggdrasil.Logging.Targets;

namespace Yggdrasil.Test.Logging
{
	public class LoggerTests
	{
		[Fact]
		public void LogToStringWriter()
		{
			var logger = Logger.Get();

			var target = new StringWriterTarget();
			target.Filter = 0;
			logger.AddTarget(target);

			var sw = target.SW;
			var test = "";

			logger.Info("test 1");
			test += "[Info] - test 1" + sw.NewLine;
			Assert.Equal(test, sw.ToString());

			logger.Warning("test 2");
			test += "[Warning] - test 2" + sw.NewLine;
			Assert.Equal(test, sw.ToString());

			logger.Error("test 3");
			test += "[Error] - test 3" + sw.NewLine;
			Assert.Equal(test, sw.ToString());

			logger.Debug("test 4");
			test += "[Debug] - test 4" + sw.NewLine;
			Assert.Equal(test, sw.ToString());

			target.Filter = LogLevel.Debug;

			logger.Debug("test 5");
			Assert.Equal(test, sw.ToString());

			logger.Status("test 6");
			test += "[Status] - test 6" + sw.NewLine;
			Assert.Equal(test, sw.ToString());
		}

		[Fact]
		public void LogToFile()
		{
			var logger = Logger.Get();

			var target = new FileTarget("logs");
			target.Filter = 0;
			logger.AddTarget(target);

			var test = "";
			var dPre = "[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{2}:[0-9]{2}:[0-9]{2}.[0-9]{3} ";

			logger.Info("test 1");
			test += dPre + @"\[Info\] - test 1" + Environment.NewLine;
			Assert.Matches(test, File.ReadAllText(target.FilePath));

			logger.Warning("test 2");
			test += dPre + @"\[Warning\] - test 2" + Environment.NewLine;
			Assert.Matches(test, File.ReadAllText(target.FilePath));

			logger.Error("test 3");
			test += dPre + @"\[Error\] - test 3" + Environment.NewLine;
			Assert.Matches(test, File.ReadAllText(target.FilePath));

			logger.Debug("test 4");
			test += dPre + @"\[Debug\] - test 4" + Environment.NewLine;
			Assert.Matches(test, File.ReadAllText(target.FilePath));

			target.Filter = LogLevel.Debug;

			logger.Debug("test 5");
			Assert.Matches(test, File.ReadAllText(target.FilePath));

			logger.Status("test 6");
			test += dPre + @"\[Status\] - test 6" + Environment.NewLine;
			Assert.Matches(test, File.ReadAllText(target.FilePath));
		}

		private class StringWriterTarget : LoggerTarget
		{
			public StringWriter SW = new StringWriter();

			public override void Write(LogLevel level, string message, string messageRaw, string messageClean)
			{
				this.SW.Write(messageClean);
			}

			public override string GetFormat(LogLevel level)
			{
				return "[{0}] - {1}";
			}
		}

	}
}
