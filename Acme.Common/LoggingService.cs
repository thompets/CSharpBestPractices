using System;

namespace Acme.Common
{
	/// <summary>
	/// Provides logging.
	/// </summary>
	public class LoggingService
    {
        /// <summary>
        /// Logs actions.
        /// </summary>
        /// <param name="action">Action to log.</param>
        public string LogAction(string action)
        {
            var logText = "Action: " + action;
            Console.WriteLine(logText);

            return logText;
        }
    }
}
