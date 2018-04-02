using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;

namespace Register_Web_App
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Upon loading the page, load in the XML document and set it to ignore comments
            /*XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;

            //XmlReader reader = XmlReader.Create("~\\Register_Web_App\\App_Data/Students.xml", settings);
            XmlReader reader = XmlReader.Create(HttpContext.Current.Server.MapPath("~/App_Data/Students.xml"), settings);

            XmlDocument doc = new XmlDocument();

            doc.Load(reader);*/
        }
    }
}