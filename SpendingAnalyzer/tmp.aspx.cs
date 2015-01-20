using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo2015_1.SpendingAnalyzer
{
    public partial class tmp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public class FileUploadHandler : IHttpHandler
        {

            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }

            public void ProcessRequest(HttpContext context)
            {
                if (context.Request.Files.Count > 0)
                {
                    HttpFileCollection fileCollection = context.Request.Files;
                    for (int i = 0; i < fileCollection.Count; i++)
                    {
                        HttpPostedFile postedFile = fileCollection[i];
                        string fName = context.Server.MapPath("/" + postedFile.FileName);
                        postedFile.SaveAs(fName);
                    }

                    context.Response.ContentType = "text/plain";
                    context.Response.Write("File(s) Uploaded Successfully!");
                }
            }
        }
    }
}