using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABG;

namespace Demo2015_1.Respiratory
{
    public partial class ABG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAnalyzeABG_Click(object sender, EventArgs e)
        {
            decimal sendPH = 0m;
            short sendCo2 = 0;
            short sendHCO3 =0;
            short sendPO2 = 0;

            string Result = "";

            if( Decimal.TryParse(txtPH.Text,out sendPH) )
            {
                if (Int16.TryParse(txtCo2.Text, out sendCo2))
                {
                    if (Int16.TryParse(txtHco3.Text, out sendHCO3))
                    {
                        if (Int16.TryParse(txtPO2.Text, out sendPO2))
                        {
                            respABG myABG = new respABG(sendPH, sendCo2, sendHCO3, sendPO2);
                            if (myABG.ABGAnalysis())
                            {
                                Result = myABG.ToString();
                                txtABGResult.Text = Result;
                            }
                            else
                            {
                                //Did not Interpretation not success
                                Result = myABG.MyError;
                                txtABGResult.Text = Result;
                            }
                        }
                        else
                        {
                            Result += " Error Invalid PO2 value: ";
                            txtABGResult.Text = Result;
                        }
                    }
                    else
                    {
                        Result += " Error Invalid HCO3 value: ";
                        txtABGResult.Text = Result;
                    }

                }
                else
                {
                    Result += " Error Invalid CO2 value: ";
                    txtABGResult.Text = Result;
                }

            }
            else
            {
                Result += " Error Invalid PH value: ";
                txtABGResult.Text = Result;
            }
        }
    }
}