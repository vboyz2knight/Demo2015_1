using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpendingLogic;
using System.IO;

namespace Demo2015_1.SpendingAnalyzer
{
    public partial class UploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CheckBoxListUploadFiles.Items.Count > 0)
            {
                btnRemoveCheckFile.Visible = true;
            }
            else
            {
                btnRemoveCheckFile.Visible = false;
            }
        }

        protected void btnAnalyzeUploadData_Click(object sender, EventArgs e)
        {
            if(CheckBoxListUploadFiles.Items.Count > 0)
            {
                SpendingLogic.SpendingLogic logic = new SpendingLogic.SpendingLogic();
                List<FileInfo> fileList = new List<FileInfo>();
                string filepath = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("Upload");

                foreach (ListItem li in CheckBoxListUploadFiles.Items)
                {
                    FileInfo newFile = new FileInfo(Server.MapPath(filepath) + li.Value);
                    fileList.Add(newFile);
                }

                if(!logic.AnalyzeMyNewFiles(fileList) )
                {
                    //save unCategorizedTransactionList and categorizedTransactionList to use start categorizing with user inputs
                    Session["unCategorizedTransactionList"] = logic.unCategorizedTransactionList;
                    Session["categorizedTransactionList"] = logic.categorizedTransactionList;
                    Session["filterCategoryList"] = logic.filterCategoryList;
                    Session["categoryList"] = logic.categoryList;

                    Server.Transfer("CategorizeNewData.aspx");
                }
            }
            else
            {
                lblErrorAnalyze.Text = "There are no file to analyze.<br/>";
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filepath = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("Upload");

            HttpFileCollection uploadedFiles = HttpContext.Current.Request.Files;
            lblError.Text = "";
            lblSuccess.Text = "";

            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                HttpPostedFile userPostedFile = uploadedFiles[i];
                
                if (userPostedFile.ContentLength > 0)
                {
                    if ((userPostedFile.FileName.ToLower()).Contains(".csv"))
                    {
                        //multiple users files in one folder
                        //attach sessionID to file name to define the user's file
                        //using a SessionID so files are unique
                        string filename = HttpContext.Current.Session.SessionID + "_" + userPostedFile.FileName;
                        //what if filename already exist in the folder?
                        //attach datetime now
                        if (System.IO.File.Exists(Server.MapPath(filepath) + filename))
                        {
                            filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + filename;
                        }

                        try
                        {
                            userPostedFile.SaveAs(Server.MapPath(filepath) + filename);
                            CheckBoxListUploadFiles.Items.Add(new ListItem(filename));
                            btnRemoveCheckFile.Visible = true;

                            lblSuccess.ForeColor = System.Drawing.Color.Green;
                            lblSuccess.Text += userPostedFile.FileName + " renamed to " + filename + " uploaded." + "<br />";
                        }
                        catch (Exception Ex)
                        {
                            lblError.ForeColor = System.Drawing.Color.Red;
                            lblError.Text += "Error: " + Ex.Message + "<br />";
                        }
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text += userPostedFile.FileName+" does not have extension .csv detected." + "<br />";
                    }
                }
                else
                {
                    lblError.Text = "No file selected.<br/>";
                }
            }
        }

        private void DeleteFileFromUploadFolder(string fileName)
        {
            string filepath = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("Upload");

            if (System.IO.File.Exists(Server.MapPath(filepath) + fileName))
            {
                try
                {
                    System.IO.File.Delete(Server.MapPath(filepath) + fileName);
                }
                catch(UnauthorizedAccessException ex)
                {
                    lblErrorOfCheckBoxList.Text = "Unable to delete file due to permission issue.";
                }
            }
        }

        protected void btnRemoveCheckFile_Click(object sender, EventArgs e)
        {
            lblSuccessDeleteFile.Text = "";
            lblErrorOfCheckBoxList.Text = "";

            if (CheckBoxListUploadFiles.SelectedIndex != -1)
            {
                List<ListItem> tmpListItem = new List<ListItem>();
                foreach (ListItem li in CheckBoxListUploadFiles.Items)
                {
                    if (li.Selected)
                    {
                        DeleteFileFromUploadFolder(li.Value);
                        //CheckBoxListUploadFiles.Items.Remove(li);
                        lblSuccessDeleteFile.Text += "Succeed delete file " + li.Value + "<br/>";
                    }
                    else
                    {
                        tmpListItem.Add(li);
                    }
                }

                CheckBoxListUploadFiles.Items.Clear();

                foreach(ListItem li in tmpListItem)
                {
                    CheckBoxListUploadFiles.Items.Add(li);
                }

                if (CheckBoxListUploadFiles.Items.Count <= 0)
                {
                    btnRemoveCheckFile.Visible = false;
                }
            }
            else
            {
                lblErrorOfCheckBoxList.Text = "No selection checked<br/>";
            }
        }
    }
}