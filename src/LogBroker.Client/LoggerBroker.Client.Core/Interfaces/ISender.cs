using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBroker.Client.Core.Interfaces
{
    public interface ISender
    {
        public void sendMessage(string message);    
    }
}
