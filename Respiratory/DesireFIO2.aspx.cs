using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using SimpleMathExpression;

namespace Demo2015_1.Respiratory
{
    public partial class DesireFIO2 : System.Web.UI.Page
    {
        string desiredFIO2Equation = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAnalyze_Click(object sender, EventArgs e)
        {
            decimal desiredPAO2 = 0.000m;
            decimal knownFIO2 = 0.000m;
            decimal knownPAO2 = 0.000m;

            if (decimal.TryParse(txtDesiredPAO2.Text, out desiredPAO2) && desiredPAO2 > 0)
            {
                if (decimal.TryParse(txtKnownFIO2.Text, out knownFIO2) && knownFIO2 > 0)
                {
                    if (decimal.TryParse(txtKnownPAO2.Text, out knownPAO2) && knownPAO2 > 0)
                    {
                         string equationsFilePath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RespiratoryEquationsFilePath"]);

                         if (RetrieveEquation.RetrieveEquation.RetrieveMyEquation("DesiredFIO2", equationsFilePath, out desiredFIO2Equation))
                         {
                             string equationWithInputs = desiredFIO2Equation.Replace("Desired_PAO2", desiredPAO2.ToString()).Replace("Known_FIO2", knownFIO2.ToString()).Replace("Known_PAO2", knownPAO2.ToString());

                             SimpleExpressionParser mySimpleExpressionParser = new SimpleExpressionParser(equationWithInputs);
                             txtDesiredFIO2.Text = mySimpleExpressionParser.myAnswer;
                         }
                         else
                         {
                             txtDesiredFIO2.Text = desiredFIO2Equation;
                         }

                    }
                    else
                    {
                        txtDesiredFIO2.Text = "Invalid data in Known_PAO2 input.";
                    }
                }
                else
                {
                    txtDesiredFIO2.Text = "Invalid data in Known_FIO2 input.";
                }
            }
            else
            {
                txtDesiredFIO2.Text = "Invalid data in Desired_PAO2 input.";
            }

        }
    }
}