using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UI.Controllers
{
    public class DefaultController
    {
        private readonly GetCodeApplication _getCodeUseCase;

        public DefaultController(GetCodeApplication getCodeUseCase)
        {
            _getCodeUseCase = getCodeUseCase;
        }

        public string Generate()
        {
            return Task.Run(() => _getCodeUseCase.Invoke()).GetAwaiter().GetResult();
        }
    }
}