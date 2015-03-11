using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpendingLogic;
using SpendingDataAccess;
using MyTraceLogger;
using System.Diagnostics;

namespace Demo2015_1.SpendingAnalyzer
{
    public partial class CategorizeNewData : System.Web.UI.Page
    {
        List<aTransaction> unCategorizedTransactionList=null;
        aTransaction currentTransaction=null;
        Dictionary<string, int> filterCategoryList=null;
        List<CategorizedTransaction> categorizedTransactionList=null;
        Dictionary<string, int> categoryList = null;

        private static MyTraceSourceLogger myLogger;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!InitializeDatas())
            {
                myLogger.TraceEvent(TraceEventType.Error, 1, "Unable to Initialize Datas.");
                Server.Transfer("Error.aspx");
            }
            else
            {
                myLogger = new MyTraceSourceLogger("SpendingAnalyzerTrace");
            }

            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;

                LoadATransactionToCategorize();

                if (categoryList != null && categoryList.Count > 0)
                {
                    ListItem listItems = new ListItem();

                    foreach (KeyValuePair<string, int> li in categoryList)
                    {
                        CategoriesDropDownList.Items.Add(new ListItem(li.Key,li.Value.ToString() ));
                    }

                    CategoriesDropDownList.Items.Add(new ListItem("Select Category", "-1"));

                    if (CategoriesDropDownList.Items.FindByValue("-1") != null)
                    {
                        CategoriesDropDownList.SelectedIndex = CategoriesDropDownList.Items.IndexOf(CategoriesDropDownList.Items.FindByValue("-1"));
                    }
                }
                else
                {
                    myLogger.TraceEvent(TraceEventType.Warning, 2, "Filters category list is empty.");
                }
            }
            else
            {
                ///
            }
        }

        private void LoadATransactionToCategorize()
        {
            if (unCategorizedTransactionList != null && unCategorizedTransactionList.Count>0)
            {
                aTransaction tmpTransaction = unCategorizedTransactionList.First();
                lblDescription.Text = tmpTransaction.Description;
                inputFilterPhrase.Text = "";

                lblDescriptionSummary.Text = "";
                lblFilterPhraseSummary.Text = "";
                lblInputCategorySummary.Text = "";

                ResetInput();
                currentTransaction = tmpTransaction;
                Session["currentTransaction"] = tmpTransaction;
            }
            else if (categorizedTransactionList != null && categorizedTransactionList.Count>0)
            {
                //all un-categorize transaction has been categorized
                SpendingLogic.SpendingLogic spendingLogic = new SpendingLogic.SpendingLogic();
                if (spendingLogic.SaveDataToDB(categorizedTransactionList, filterCategoryList))
                {
                    //remove all session datas
                    Session.Remove("unCategorizedTransactionList");
                    Session.Remove("currentTransaction");
                    Session.Remove("filterCategoryList");
                    Session.Remove("categorizedTransactionList");
                    Session.Remove("categoryList");

                    Server.Transfer("SpendingDisplay.aspx");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Unexpected Logic Error!");
            }
        }

        private bool InitializeDatas()
        {
            bool bReturn = false;
            myLogger = new MyTraceSourceLogger("SpendingAnalyzerTrace");

            if (myLogger != null)
            {
                //if no unCategorizedTransactionList then no reason to be in this page
                if (Session["unCategorizedTransactionList"] != null)
                {
                    unCategorizedTransactionList = (List<aTransaction>)Session["unCategorizedTransactionList"];

                    //we have to have a list of category to work with
                    if( Session["categoryList"] != null)
                    {
                        categoryList = (Dictionary<string, int>)Session["categoryList"];

                        if (categoryList.Count <= 0)
                        {
                            myLogger.TraceEvent(TraceEventType.Error, 1, "Category list is empty.");
                            throw new ArgumentOutOfRangeException("Category list is empty.");
                        }
                        else
                        {
                            bReturn = true;
                        }
                    }
                    else
                    {
                        myLogger.TraceEvent(TraceEventType.Error, 1, "Category list is empty.");
                        throw new ArgumentOutOfRangeException("Category list is empty.");
                    }

                    if (Session["filterCategoryList"] != null)
                    {
                        filterCategoryList = (Dictionary<string, int>)Session["filterCategoryList"];

                        if (filterCategoryList.Count < 1)
                        {
                            myLogger.TraceEvent(TraceEventType.Information, 3, "Filter Category list is empty.");      
                        }
                    }

                    if (Session["categorizedTransactionList"] != null)
                    {
                        categorizedTransactionList = (List<CategorizedTransaction>)Session["categorizedTransactionList"];
                    }

                    if (Session["currentTransaction"] != null)
                    {
                        currentTransaction = (aTransaction)Session["currentTransaction"];
                    }
                    else
                    {
                        myLogger.TraceEvent(TraceEventType.Verbose, 4, "(InitializeDatas) Current transaction is null.");
                    }
                }
            }
            else
            {
                throw new NullReferenceException("Unable to initialize logger.");
            }
            return bReturn;
        }

        private void ResetInput()
        {
            InputCategoryDiv.Attributes["class"] = "form-group";
            InputFilterPhraseDiv.Attributes["class"] = "form-group";

            if (CategoriesDropDownList.Items.FindByValue("-1") != null)
            {
                CategoriesDropDownList.SelectedIndex = CategoriesDropDownList.Items.IndexOf(CategoriesDropDownList.Items.FindByValue("-1"));
            }
        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            int selectedValue = 0;
            bool bCategorySuccess = false;
            bool bFilterSuccess = false;

            if(int.TryParse(CategoriesDropDownList.SelectedValue, out selectedValue) )
            {
                if (selectedValue < 0)
                {
                    InputCategoryDiv.Attributes["class"] = "form-group has-error";
                }
                else
                {
                    InputCategoryDiv.Attributes["class"] = "form-group has-success";
                    bCategorySuccess = true;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Category list selectected value out of range.");
            }

            if (FilterPhraseValid())
            {
                InputFilterPhraseDiv.Attributes["class"] = "form-group has-success";
                bFilterSuccess = true;
            }
            else
            {
                InputFilterPhraseDiv.Attributes["class"] = "form-group has-error";
            }

            if (bFilterSuccess && bCategorySuccess )
            {
                MultiView1.ActiveViewIndex = 1;
                lblDescriptionSummary.Text = currentTransaction.Description;
                lblFilterPhraseSummary.Text = inputFilterPhrase.Text;
                lblInputCategorySummary.Text = CategoriesDropDownList.SelectedItem.Text;
            }
        }

        private bool FilterPhraseValid()
        {
            bool bReturn = false;

            if (currentTransaction != null && filterCategoryList != null)
            {
                //is the filter phrase part of the description
                if (inputFilterPhrase.Text.Length > 3 && currentTransaction.Description.ToLower().Contains(inputFilterPhrase.Text.ToLower()))
                {
                    //input filter phrase is unique to existing filter phrase
                    if (!filterCategoryList.ContainsKey(inputFilterPhrase.Text))
                    {
                        bReturn = true;
                    }
                    else
                    {
                        myLogger.TraceEvent(TraceEventType.Verbose, 4, "Filter phrase is unique in current filterCategoryList.");
                    }
                }
                else
                {
                    myLogger.TraceEvent(TraceEventType.Verbose, 4, "Filter phrase is not part of transaction's description.");
                }
            }
            else
            {
                myLogger.TraceEvent(TraceEventType.Error, 1, "Current transaction is null and filter category list is null.");
            }

            return bReturn;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            int selectedValue = 0;

            if( int.TryParse(CategoriesDropDownList.SelectedValue,out selectedValue) )
            {
                if( AddCurrentTransactionToCategorizedList(inputFilterPhrase.Text,selectedValue) )
                {
                    bool ableToCagetorizeWithUpdatedFilter = false;
                    LoadATransactionToCategorize();

                    //new transaction able to use current filter phrase to categorize?
                    SpendingLogic.SpendingLogic spendingLogic = new SpendingLogic.SpendingLogic();
                    do
                    {
                        ableToCagetorizeWithUpdatedFilter = false;
                        if (spendingLogic.CategorizeSingleTransactionWithExistingFilterPhrase(currentTransaction, filterCategoryList, categorizedTransactionList))
                        {
                            //need better logic flow
                            unCategorizedTransactionList.Remove(currentTransaction);
                            ableToCagetorizeWithUpdatedFilter = true;
                            LoadATransactionToCategorize();
                        }
                    } while (ableToCagetorizeWithUpdatedFilter);

                    MultiView1.ActiveViewIndex = 0;
                }
            }
            else
            {
                myLogger.TraceEvent(TraceEventType.Error, 1, string.Format("Unable to parse selected value of drop down list into int."));
                throw new System.FormatException();
            }
        }

        private bool AddCurrentTransactionToCategorizedList(string inputFilterPhrase, int intCategory)
        {
            bool bReturn = false;

            try 
            {
                CategorizedTransaction tmpCategorizedTransaction = new CategorizedTransaction(currentTransaction.myDate, currentTransaction.Description, currentTransaction.check, currentTransaction.Amt, intCategory, inputFilterPhrase);

                categorizedTransactionList.Add(tmpCategorizedTransaction);
                unCategorizedTransactionList.Remove(currentTransaction);
                //
                filterCategoryList.Add(lblFilterPhraseSummary.Text, int.Parse(CategoriesDropDownList.SelectedValue));


                Session["unCategorizedTransactionList"] = unCategorizedTransactionList;
                Session["categorizedTransactionList"] = categorizedTransactionList;
                Session["filterCategoryList"] = filterCategoryList;

                bReturn = true;
            }
            catch(Exception ex)
            {
                myLogger.TraceEvent(TraceEventType.Error, 1, string.Format("Unknow error trying to execute AddCurrentTransactionToCategorizedList(). {0}",ex.Message));
            }

            return bReturn;
        }
    }
}