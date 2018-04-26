using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DemoSunriseCargoRest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var ci = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentCulture = ci;
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Error,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateFormatString = "yyyy-MM-ddTHH:mm:ssZ"
            };
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter{SerializerSettings = jsonSerializerSettings});

        }
    }
}
