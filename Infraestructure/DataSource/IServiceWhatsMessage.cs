using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DataSource
{
    public interface IServiceWhatsMessage
    {
        Task<string> GetCode();
    }
}
