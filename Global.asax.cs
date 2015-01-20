using MyTraceLogger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Demo2015_1
{
    public class Global : System.Web.HttpApplication
    {
        private static MyTraceSourceLogger myLogger;

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            //delete any leftover upload file for this session
            string filepath = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("Upload");
            if(Directory.Exists(filepath))
            {
                DirectoryInfo di = new DirectoryInfo(filepath);

                foreach (FileInfo fi in di.GetFiles())
                {
                    if (fi.Name.Contains(HttpContext.Current.Session.SessionID))
                    {
                        try
                        {
                            fi.Delete();
                        }
                        catch (System.IO.IOException ex)
                        {
                            myLogger.TraceEvent(TraceEventType.Error, 1, "IOException {0}.",ex.Message);
                        }
                        catch (System.Security.SecurityException ex)
                        {
                            myLogger.TraceEvent(TraceEventType.Error, 1, "SecurityException {0}.",ex.Message);
                        }
                        catch (System.UnauthorizedAccessException ex)
                        {
                            myLogger.TraceEvent(TraceEventType.Error, 1, "UnauthorizedAccessException {0}.",ex.Message);
                        }
                    }
                }
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}