using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ExceptionGlobal: Exception
    {
        public override string Message { get; }

        public ExceptionGlobal(string message)
        {
            Message = message;
        }
    }
}
