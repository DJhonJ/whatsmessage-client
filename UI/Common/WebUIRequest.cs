using Application;
using Data;
using Domain;
using Infraestructure;
using Infraestructure.DataSource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using UI.Models;

//cosas que tienen que ver con ui
namespace UI.Common
{
    public partial class WebUIRequest : Page
    {
        protected NameValueCollection FormWebUI { get; set; }
        private readonly ResponseClient _responseClient;
        protected string RedirectClient { get; set; }

        private readonly IServiceWhatsMessage _serviceWhatsMessageInject;
        private readonly WhatsMessageRepository _whatsMessageRepositoryInject;
        protected readonly GetCodeApplication _getCodeApplicationInject;

        public WebUIRequest()
        {
            _serviceWhatsMessageInject = new GeneratorCodeService();
            _whatsMessageRepositoryInject = new WhatsMessageRepository(_serviceWhatsMessageInject);
            _getCodeApplicationInject = new GetCodeApplication(_whatsMessageRepositoryInject);
            
            _responseClient = new ResponseClient();
        }

        protected override void OnPreLoad(EventArgs e)
        {
            FormWebUI = Request.Form;
        }
        
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (Request.Form != null && !string.IsNullOrEmpty(FormWebUI["action"]))
                {
                    //TODO: Problemas cuando hay un metodo sobrecargado.
                    //TODO: Objeto response para retornar las respuestas del sistema.
                    MethodInfo methodInfo = GetType().GetMethod(FormWebUI["action"], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

                    if (methodInfo != null)
                    {
                        object methodResult = methodInfo.Invoke(this, GetValueParameters(FormWebUI));

                        if (methodResult != null)
                        {
                            var s = methodResult.GetType();
                        }

                        _responseClient.result = methodResult;
                        _responseClient.status = "ok";
                        _responseClient.redirect = RedirectClient;

                        ResponseClient(JsonConvert.SerializeObject(_responseClient));
                    }
                    else
                    {
                        CatchError(new ExceptionGlobal("Method not found."));
                    }
                }
                else
                {
                    base.OnLoad(e); //normal load page.
                }
            }
            catch (Exception ex)
            {
                CatchError(ex);
            }
        }

        protected void ResponseClient(string response)
        {
            HttpContext.Current.Response.Write(response);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.SuppressContent = true;
            Context.ApplicationInstance.CompleteRequest();
        }

        private object[] GetValueParameters(NameValueCollection form)
        {
            IEnumerable<string> keyParams = form.AllKeys.Where(x => x.EndsWith("_param"));
            if (keyParams != null && keyParams.Count() > 0)
            {
                return keyParams.Select(key => form.Get(key)).Cast<string>().ToArray();
            }

            return new object[] { };
        }

        private void CatchError(Exception ex)
        {
            _responseClient.status = "error";

            //if (ex.InnerException != null)
            //{
            //    _responseClient.message = ex.InnerException.Message;
            //}
            //else
            //{
            //    _responseClient.message = ex.Message;
            //}

            //TODO: Guardar en un log (archivo, db) los mensajes de error.
            //TODO: mensaje generico a mostrar para los errores: Problems with the request. You can contact the support team and try again later.

            _responseClient.message = "Problems with the request. You can contact the support team and try again later.";

            ResponseClient(JsonConvert.SerializeObject(_responseClient));
        }
    }
}