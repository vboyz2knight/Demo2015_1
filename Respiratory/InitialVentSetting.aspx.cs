using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RetrieveEquation;
using SimpleMathExpression;

namespace Demo2015_1.Respiratory
{
    public partial class InitialVentSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAnalyze_Click(object sender, EventArgs e)
        {
            PanelVentTable.Visible = false;
            LabelIBW.Text = "";
            LabelErrorMsg.Text = "";
            //Estimated ideal body weight in (kg)
            //Males: IBW = 50 kg + 2.3 kg for each inch over 5 feet.
            //Females: IBW = 45.5 kg + 2.3 kg for each inch over 5 feet.

            decimal heightValue = 0.00m;
            string equationID = string.Empty;
            decimal heightInches = 0.00m;
            decimal cmToInches = 2.54m; //1 inch = 2.54cm
            decimal minimalFtInInches = 60.00m; //minimal 5ft
            decimal IBW_kg = 0.00m;

            string theEquation;
            string theEquationWithInput = string.Empty;
            string equationsFilePath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RespiratoryEquationsFilePath"]);

            if (DropDownListM_F.SelectedValue == "Male")
            {
                equationID = "IBW_Male";
            }
            else
            {
                equationID = "IBW_Female";
            }

            if (RetrieveEquation.RetrieveEquation.RetrieveMyEquation("IBW_Male", equationsFilePath, out theEquation))
            {
                if (decimal.TryParse(TextBoxHeight.Text, out heightValue))
                {
                    if (DropDownListInchesOrCm.SelectedValue == "cm")
                    {
                        //5ft = 60 inches, 1 inch = 2.54 cm
                        heightInches = heightValue / cmToInches;
                    }
                    else
                    {
                        heightInches = heightValue;
                    }


                    if (heightInches >= minimalFtInInches)
                    {
                        heightInches = heightInches - minimalFtInInches;

                        theEquationWithInput = theEquation.Replace("Height_over_5ft", heightInches.ToString());

                        SimpleExpressionParser myParser = new SimpleExpressionParser(theEquationWithInput);
                        if (myParser.ParserError)
                        {
                            LabelErrorMsg.Text = myParser.myAnswer;
                        }
                        else
                        {
                            if (decimal.TryParse(myParser.myAnswer,out IBW_kg))
                            {
                                LabelIBW.Text = string.Format("{0:0.00}", IBW_kg);
                                fillVentTable(IBW_kg);
                            }
                            else
                            {
                                LabelErrorMsg.Text = "Unable to parse IBW as numeric.";
                            }
                        }
                    }
                    else
                    {
                        LabelErrorMsg.Text = "The value entered need to be at least 5ft or 152.4cm";
                    }
                }
                else
                {
                    LabelErrorMsg.Text = "The value entered need to be numeric.";
                }
            }
            else
            {
                LabelErrorMsg.Text = theEquation;
            }

        }

        private void fillVentTable(decimal myIBW_kg)
        {
            PanelVentTable.Visible = true;
            for (int i = 5; i < 11; i++)
            {
                Label lblResult = ((Label)PanelVentTable.FindControl("Label" +i+"ml"));
                if (lblResult != null)
                {
                    lblResult.Text = String.Format("{0:0.00}", (myIBW_kg * i) );
                }
                else
                {
                    LabelErrorMsg.Text = "Unable to label control.";
                    PanelVentTable.Visible = false;
                }
            }  
        }
    }
}