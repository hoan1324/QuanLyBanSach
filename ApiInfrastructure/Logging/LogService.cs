using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInfrastructure.Logging
{
	public class LogService
	{
		private readonly ILogger _logger;
		public LogService()
		{
			_logger = new LoggerConfiguration()
			.WriteTo.Console()
			.WriteTo.File("Logs/log.txt")
			.CreateLogger();
		}
		public void LogError(string message)
		{
			_logger.Error(message);
		}
		public void LogError(Exception ex, string message)
		{
			_logger.Error(ex, message);
		}
		public void LogError(Exception ex)
		{
			_logger.Error(ex.ToString());
		}
		public void LogWarning(string message)
		{
			_logger.Warning(message);
		}
		public void LogDebug(string message)
		{
			_logger.Debug(message);
		}
		public void LogInformation(string message)
		{
			_logger.Information(message);
		}
	}
}
