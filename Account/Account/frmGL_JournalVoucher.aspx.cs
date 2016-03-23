using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Account.Account
{
    public partial class frmGL_JournalVoucher : System.Web.UI.Page
    {
        clsGL_GeneralLedger GeneralLedger = new clsGL_GeneralLedger();
        double amount = 0;

        private void Reset()
        {
            txtDate.Text = "dd/mm/yyyy";
            cls_CommonFunctions.ClearTextBox(txtRemark);
            cls_CommonFunctions.SetTextBoxToZero(txtAmountDr, txtAmountDr2, txtAmountCr, txtAmountCr2);
            LoadCategoty();
        }

        private void Save()
        {
            if (cls_CommonFunctions.IsCreate("M001") == true)
            {
                GeneralLedger = new clsGL_GeneralLedger();
                if (ValidateEntry() == true)
                {
                    try
                    {
                        string CategoryNo = "";
                        int No = 0;
                        No = Convert.ToInt32(GeneralLedger.GeJVNextNo());
                        CategoryNo = cmbGeneralLedger1.SelectedValue.Split(char.Parse("-"))[0];
                        GeneralLedger.No = No;
                        GeneralLedger.CategoryNo = Convert.ToInt32(CategoryNo);
                        GeneralLedger.JVDate = txtDate.Text.Trim();
                        GeneralLedger.Description = cmbGeneralLedger1.SelectedValue.Split(char.Parse("-"))[1];
                        GeneralLedger.Dr = Convert.ToDouble(txtAmountDr.Text);
                        GeneralLedger.Cr = Convert.ToDouble(txtAmountCr.Text);
                        GeneralLedger.CreateDate = System.DateTime.Now;
                        GeneralLedger.CreateUser = cls_LoginInfo.getLoginUser();
                        GeneralLedger.status = 1;
                        if (GeneralLedger.SaveJournalVoucher() == true) { }

                        CategoryNo = cmbGeneralLedger2.SelectedValue.Split(char.Parse("-"))[0];
                        GeneralLedger.No = No;
                        GeneralLedger.CategoryNo = Convert.ToInt32(CategoryNo);
                        GeneralLedger.JVDate = txtDate.Text.Trim();
                        GeneralLedger.Description = cmbGeneralLedger2.SelectedValue.Split(char.Parse("-"))[1];
                        GeneralLedger.Dr = Convert.ToDouble(txtAmountDr2.Text);
                        GeneralLedger.Cr = Convert.ToDouble(txtAmountCr2.Text);
                        GeneralLedger.CreateDate = System.DateTime.Now;
                        GeneralLedger.CreateUser = cls_LoginInfo.getLoginUser();
                        GeneralLedger.status = 1;

                        if (GeneralLedger.SaveJournalVoucher() == true)
                        {
                            lblMsg.InnerHtml = "Transaction successfull...";
                            lblMsg.Attributes.Add("class", "alert alert-success");
                            lblMsg.Visible = true;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            Reset();
                        }
                        else
                        {
                            lblMsg.InnerHtml = "Transaction fail...";
                            lblMsg.Attributes.Add("class", "alert alert-danger");
                            lblMsg.Visible = true;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                        }
                    }
                    catch (Exception)
                    {
                    } 
                }
                else
                {
                    lblMsg.InnerHtml = "Transaction fail...";
                    lblMsg.Attributes.Add("class", "alert alert-danger");
                    lblMsg.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                }
            }
        }

        private bool ValidateEntry()
        {
            if (cmbGeneralLedger1.Text == cmbGeneralLedger2.Text)
            {
                return false;
            }
            else if (txtAmountDr.Text == txtAmountCr.Text)
            {
                return false;
            }
            else if (txtAmountDr2.Text == txtAmountCr2.Text)
            {
                return false;
            }
            else if (txtAmountDr.Text != txtAmountCr2.Text)
            {
                return false;
            }
            else if (txtAmountCr.Text != txtAmountDr2.Text)
            {
                return false;
            }
            else if (txtDate.Text == "dd/mm/yyyy")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LoadCategoty()
        {
            cmbGeneralLedger1.Items.Clear();
            cmbGeneralLedger2.Items.Clear();
            MySqlDataReader dr = GeneralLedger.LoadGeneralLedger();
            cmbGeneralLedger1.Items.Add("Select...");
            cmbGeneralLedger2.Items.Add("Select...");
            while (dr.Read())
            {
                cmbGeneralLedger1.Items.Add(dr.GetString("GLM_NO") + "- " + dr.GetString("GLM_NAME"));
                cmbGeneralLedger2.Items.Add(dr.GetString("GLM_NO") + "- " + dr.GetString("GLM_NAME"));
            }
            cmbGeneralLedger1.SelectedIndex = -1;
            cmbGeneralLedger2.SelectedIndex = -1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (cmbGeneralLedger1.SelectedIndex == -1)
            {
                LoadCategoty();
            }
            if (txtDate.Text == "")
            {
                txtDate.Text = "dd/mm/yyyy";
            }
            if (txtAmountDr.Text == "")
            {
                cls_CommonFunctions.SetTextBoxToZero(txtAmountDr, txtAmountDr2, txtAmountCr, txtAmountCr2);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
