using System;
using System.Collections.Generic;
using Microsoft.Practices.Prism.Logging;

namespace Fs.AdminCenter.Logging
{
    /// <summary>
    /// A logger that holds on to log entries until a callback delegate is set, then plays back log entries and sends new log entries.
    /// </summary>
    public class CallbackLogger : ILoggerFacade
    {
        private readonly Queue<Tuple<string, Category, Priority>> _savedLogs =
            new Queue<Tuple<string, Category, Priority>>();

        private Action<string, Category, Priority> _callback;

        /// <summary>
        /// Gets or sets the callback to receive logs.
        /// </summary>
        /// <value>An Action&lt;string, Category, Priority&gt; callback.</value>
        public Action<string, Category, Priority> Callback
        {
            get { return this._callback; }
            set { this._callback = value; }
        }

        /// <summary>
        /// Write a new log entry with the specified category and priority.
        /// </summary>
        /// <param name="message">Message body to log.</param>
        /// <param name="category">Category of the entry.</param>
        /// <param name="priority">The priority of the entry.</param>
        public void Log(string message, Category category, Priority priority)
        {
            if (this.Callback != null)
            {
                this.Callback(message, category, priority);
            }
            else
            {
                this._savedLogs.Enqueue(new Tuple<string, Category, Priority>(message, category, priority));
            }
        }

        /// <summary>
        /// Replays the saved logs if the Callback has been set.
        /// </summary>
        public void ReplaySavedLogs()
        {
            if (this.Callback != null)
            {
                while (this._savedLogs.Count > 0)
                {
                    var log = this._savedLogs.Dequeue();
                    this.Callback(log.Item1, log.Item2, log.Item3);
                }
            }
        }
    }
}
