using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Common;
using UI.Controllers;

namespace UI
{
    public partial class Default : WebUIRequest
    {
        private const string URI_TEST = "http://localhost:9000/v1/whatsapp/test";

        //private readonly DefaultController _defaultController;

        //public Default()
        //{
        //    _defaultController = new DefaultController();
        //}

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        protected string Test()
        {
            return new DefaultController(_getCodeApplicationInject).Generate();
        }
    }
}