using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.DataSource;

namespace Data
{
    public class WhatsMessageRepository
    {
        private readonly IServiceWhatsMessage _serviceWhatsMessage;

        public WhatsMessageRepository(IServiceWhatsMessage serviceWhatsMessage)
        {
            _serviceWhatsMessage = serviceWhatsMessage;
        }

        public Task<string> GetCode()
        {
            return _serviceWhatsMessage.GetCode();
        }
    }
}
