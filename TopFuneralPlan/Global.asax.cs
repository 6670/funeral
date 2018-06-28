using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TopFuneralPlan
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            //Marketing
            Session["Source"] = "";
            Session["Keyword"] = "";
            Session["RemoteIPAddress"] = "";

            if (Request.QueryString["src"] != null)
                Session["Source"] = Request.QueryString["src"];

            if (Request.QueryString["kw"] != null)
                Session["Keyword"] = Request.QueryString["kw"];

            if (Request.QueryString["mch"] != null)
                Session["Match"] = Request.QueryString["mch"];

            if (Request.QueryString["thm"] != null)
                Session["Theme"] = Request.QueryString["thm"];
            else
                Session["Theme"] = "blue";

            ////Store client IP address
            //if (Request.ServerVariables["REMOTE_ADDR"] != null)
            //    Session["RemoteIPAddress"] = Request.ServerVariables["REMOTE_ADDR"];

            ////Store client IP address when operating in a clustered environment
            //if (Request.ServerVariables["HTTP_X_CLUSTER_CLIENT_IP"] != null)
            //    Session["RemoteIPAddress"] = Request.ServerVariables["HTTP_X_CLUSTER_CLIENT_IP"];

            Session["RemoteIPAddress"] = GetIpAddress();
        }
        public static string GetIpAddress()
        {
            var request = HttpContext.Current.Request;
            // Look for a proxy address first
            var ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            // If there is no proxy, get the standard remote address
            if (string.IsNullOrWhiteSpace(ip)
                || string.Equals(ip, "unknown", StringComparison.OrdinalIgnoreCase))
                ip = request.ServerVariables["REMOTE_ADDR"];
            else
            {
                //extract first IP
                var index = ip.IndexOf(',');
                if (index > 0)
                    ip = ip.Substring(0, index);

                //remove port
                index = ip.IndexOf(':');
                if (index > 0)
                    ip = ip.Substring(0, index);
            }

            return ip;
        }
    }
}
