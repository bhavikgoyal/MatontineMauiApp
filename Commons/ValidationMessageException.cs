using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons
{
    
    public class ValidationMessageException : Exception
    {
        public ValidationMessageException(string msg) : base(msg)
        {
        }
    }
}
