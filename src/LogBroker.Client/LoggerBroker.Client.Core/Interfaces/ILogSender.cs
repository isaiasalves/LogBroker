using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBroker.Client.Core.Interfaces
{
    public interface ILogSender : ILogger
    {
        public void LogTrace(string message);
        public void LogError(string message);
    }
}
