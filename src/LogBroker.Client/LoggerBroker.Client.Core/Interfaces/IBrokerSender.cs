using LogBroker.Client.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBroker.Client.Core.Interfaces
{
    public interface IBrokerSender
    {
        public void sendMessage(string message, string routingKey);    
    }
}
