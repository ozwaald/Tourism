using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Logic.Interfaces
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}
