using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Demo2015_1.SpendingAnalyzer
{
    public partial class SpendingAnyalyzerDisplay : System.Web.UI.Page
    {
        List<SpendingDataAccess.displayCategorizedTransaction> displayCategorizedTrasactionList = new List<SpendingDataAccess.displayCategorizedTransaction>();
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Test_GetData(); 
                //Intialize data with the latest month
                SpendingLogic.SpendingLogic spendingLogic = new SpendingLogic.SpendingLogic();
                displayCategorizedTrasactionList = spendingLogic.GetDisplayCategorizedTransactionLatest();

                if(displayCategorizedTrasactionList.Count>0)
                {
                    MultiView1.ActiveViewIndex = 1;
                    ShowLatestMonthTransaction(displayCategorizedTrasactionList);

                    //save current transaction list in session
                    Session["displayCategorizedTrasactionList"] = displayCategorizedTrasactionList;
                }
                else
                {
                    //There are no transaction
                    MultiView1.ActiveViewIndex = 0;
                }
            }
            
        }

        private void ShowLatestMonthTransaction(List<SpendingDataAccess.displayCategorizedTransaction>  displayCategorizedTrasactionList)
        {
            GridView1.DataSource = displayCategorizedTrasactionList.ToList();
            GridView1.DataBind();

            Series series = Chart1.Series["Series1"];
            // Set series and legend tooltips
            series.ToolTip = "#VALX: #VAL{C} dong";
            series.LegendToolTip = "#PERCENT";
            series.PostBackValue = "#INDEX";
            series.LegendPostBackValue = "#INDEX";


            // Set series visual attributes
            series.ChartType = SeriesChartType.Pie;
            series.ShadowOffset = 2;
            //series.BorderColor = Color.DarkGray;
            //series.CustomAttributes = "LabelStyle=Outside";

            foreach (SpendingDataAccess.displayCategorizedTransaction transaction in displayCategorizedTrasactionList)
            {
                series.Points.AddXY(transaction.myDate.ToShortDateString(), transaction.Amt);
            }
        }
        void Test_GetData()
        {
            XElement doc = XElement.Load(Server.MapPath(@"~/SpendingAnalyzer/TestData.xml"));
            Series series = Chart1.Series["Series1"];
            // Set series and legend tooltips
            series.ToolTip = "#VALX: #VAL{C} dong";
            series.LegendToolTip = "#PERCENT";
            series.PostBackValue = "#INDEX";
            series.LegendPostBackValue = "#INDEX";


            // Set series visual attributes
            series.ChartType = SeriesChartType.Pie;
            series.ShadowOffset = 2;
            //series.BorderColor = Color.DarkGray;
            //series.CustomAttributes = "LabelStyle=Outside";

            //Series series2 = Chart2.Series["Series1"];
            var query = from d in doc.Descendants("Transaction")
                        select new { Date = d.Element("Date").Value,Amount = d.Element("Amount").Value };

            int i = 1;
            foreach(var transaction in query)
            {
                i++;
                string date = i.ToString();
                decimal amount = 0.00m;
                if(decimal.TryParse(transaction.Amount,out amount))
                {
                    series.Points.AddXY(date, amount);
                    //series2.Points.AddXY(date, amount);
                }                
            }
            GridView1.DataSource = query.ToList();
            GridView1.DataBind();
        }

        protected void Chart1_Click(object sender, ImageMapEventArgs e)
        {
            int pointIndex = int.Parse(e.PostBackValue);
            Series series = Chart1.Series["Series1"];
            if (pointIndex >= 0 && pointIndex <= series.Points.Count)
            {
                series.Points[pointIndex].CustomProperties += "Exploded=true";
            }
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {

            //going to upload 1 file at a time
            //was looking for multiple files upload but that feature exist in .net 4.5
            //can ask user to zip up multiple files
            //or add file individually
            //To change size limit, you make some changes in either the machine.config or web.config file.<httpRuntime>
            //can asynchronous upload using Ajax may implement in future

            //string filepath = @"~/Spending/Uploads/";
            string filepath = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("Upload");

            HttpFileCollection uploadedFiles = HttpContext.Current.Request.Files;

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
                            //LabelMsg.ForeColor = System.Drawing.Color.Green;
                            //LabelMsg.Text += filename + " uploaded." + "<br />";
                        }
                        catch (Exception Ex)
                        {
                            //LabelMsg.ForeColor = System.Drawing.Color.Red;
                            //LabelMsg.Text += "Error: " + Ex.Message + "<br />";
                        }
                    }
                    else
                    {
                        //LabelMsg.ForeColor = System.Drawing.Color.Red;
                        //LabelMsg.Text += "A file not with extension .csv detected." + "<br />";
                    }
                }
            }
        }

        protected void btnAddData_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadFile.aspx");
        }
    }
}