using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleMathExpression;
using System.Xml.Linq;

namespace Demo2015_1.Respiratory
{
    public partial class DesiredMinuteVentilation : System.Web.UI.Page
    {
        string desiredMVEquation = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAnalyze_Click(object sender, EventArgs e)
        {
            decimal knownPCO2 = 0.000m;
            decimal knownMV = 0.000m;
            decimal desiredCO2 = 0.000m;

            if (decimal.TryParse(txtKnownPCO2.Text, out knownPCO2) && knownPCO2 > 0)
            {
                if (decimal.TryParse(txtKnownMV.Text, out knownMV) && knownMV > 0)
                {
                    if (decimal.TryParse(txtDesiredCo2.Text, out desiredCO2) && desiredCO2 > 0)
                    {
                        string equationsFilePath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RespiratoryEquationsFilePath"]);

                        if (RetrieveEquation.RetrieveEquation.RetrieveMyEquation("DesiredMinuteVentilation", equationsFilePath, out desiredMVEquation))
                        {
                            string equationWithInputs = desiredMVEquation.Replace("Known_PCO2", knownPCO2.ToString()).Replace("Known_Minute_Ventilation", knownMV.ToString()).Replace("Desired_CO2", desiredCO2.ToString());

                            SimpleExpressionParser mySimpleExpressionParser = new SimpleExpressionParser(equationWithInputs);
                            txtDesiredMV.Text = mySimpleExpressionParser.myAnswer + " (L)";
                        }
                        else
                        {
                            txtDesiredMV.Text = desiredMVEquation;
                        }
                    }
                    else
                    {
                        txtDesiredMV.Text = "Invalid data in Desired_CO2 input.";
                    }
                }
                else
                {
                    txtDesiredMV.Text = "Invalid data in Known_Minute_Ventilation input.";
                }
            }
            else
            {
                txtDesiredMV.Text = "Invalid data in Known_PCO2 input.";
            }
            
        }

       
    }
}