using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Demo2015_1.SpendingAnalyzer
{
    /// <summary>
    /// Summary description for FileUploadHandler
    /// </summary>
    public class FileUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection fileCollection = context.Request.Files;
                string filepath = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("Upload");
                int uploadFiles = 0;
                int rejectFiles = 0;

                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile postedFile = fileCollection[i];                    
                    //string fName = context.Server.MapPath("/" + postedFile.FileName);
                    string file = (postedFile.FileName).ToLower();

                    if (Path.GetExtension(file) == ".csv")
                    {
                        string fName = context.Server.MapPath(filepath + postedFile.FileName);
                        postedFile.SaveAs(fName);

                        uploadFiles++;
                    }
                    else
                    {
                        rejectFiles++;
                    }
                }

                if(uploadFiles>0)
                {                    
                    context.Server.Transfer("CategorizeNewData.aspx");                    
                }

                if(rejectFiles>0)
                {
                    context.Response.ContentType = "text/plain";
                    string msg = string.Format("{0}:File(s) Did Not Uploaded Successfully!", rejectFiles);
                    context.Response.Write(msg);
                }
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("No file detected!");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}