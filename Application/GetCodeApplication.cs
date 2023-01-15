using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GetCodeApplication
    {
        private readonly WhatsMessageRepository _whatsMessageRepository;

        public GetCodeApplication(WhatsMessageRepository whatsMessageRepo)
        {
            _whatsMessageRepository = whatsMessageRepo;
        }

        public async Task<string> Invoke()
        {
            return await _whatsMessageRepository.GetCode();
        }
    }
}
