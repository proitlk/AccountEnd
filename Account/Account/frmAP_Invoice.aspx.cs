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
using System.Web.Services;
using System.Collections.Generic;
//==============================================================
//By            :   Thilanka
//Date          :   10-Mar-2016
//Description   :   Account Payable Files Invoice Form 
//                  to get the details for Supplier Payable
//==============================================================

namespace Account.Account
{
    public partial class frmAP_Invoice : System.Web.UI.Page
    {
        private ErrorLog error = new ErrorLog();
        clsAP_Invoice clsInvoice = new clsAP_Invoice();

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtInvoiceNo, txtDate, txtSupplier, txtAmount, txtRemark);
            cls_CommonFunctions.SetTextBoxToZero(txtAmount);
            txtDate.Text = "dd/mm/yyyy";
            cmbBranch.Focus();
            cmbBranch.SelectedIndex = -1;
            viewData();
        }

        private void LoadBranch()
        {
            cmbBranch.Items.Clear();
            MySqlDataReader dr = clsInvoice.LoadBranch();
            cmbBranch.Items.Add("Select...");
            while (dr.Read())
            {
                cmbBranch.Items.Add(dr.GetString("BRCH_BRANCHNO") + "- " + dr.GetString("BRCH_NAME"));
            }
            cmbBranch.SelectedIndex = -1;
        }

        private void Save()
        {
            if (cls_CommonFunctions.IsCreate("AP01") == true)
            {
                clsInvoice = new clsAP_Invoice();
                if (ValidateInvoice() == true)
                {
                    try
                    {
                        String item = cmbBranch.SelectedValue.Split(char.Parse("-"))[0];
                        clsInvoice.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text.Trim());
                        clsInvoice.InvDate = txtDate.Text.Trim();
                        clsInvoice.BranchNo = Convert.ToInt32(item);
                        clsInvoice.SupplierNo = Convert.ToInt32(hftxtSupplier.Value);
                        clsInvoice.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
                        clsInvoice.Remark = txtRemark.Text.Trim();
                        clsInvoice.IsCancel = 0;
                        clsInvoice.Createuser = cls_LoginInfo.getLoginUser();
                        clsInvoice.Createdate = System.DateTime.Now;
                        clsInvoice.Status = 1;

                        if (clsInvoice.Save() == true)
                        {
                            lblMsg.InnerHtml = "Transaction successfull...";
                            lblMsg.Attributes.Add("class", "alert alert-success");
                            lblMsg.Visible = true;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            Reset();
                            viewData();
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

        private bool ValidateInvoice()
        {
            if (txtDate.Text == "dd/mm/yyyy")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void viewData()
        {
            DataTable dt = new DataTable();
            DataColumn pDate = new DataColumn("Date", Type.GetType("System.String"));
            DataColumn pBranch = new DataColumn("Branch", Type.GetType("System.String"));
            DataColumn pCode = new DataColumn("Invoice No", Type.GetType("System.String"));
            DataColumn pSupplier = new DataColumn("Supplier", Type.GetType("System.String"));
            DataColumn pAmount = new DataColumn("Amount", Type.GetType("System.String"));
            DataColumn pRemark = new DataColumn("Remark", Type.GetType("System.String"));

            dt.Columns.Add(pDate);
            dt.Columns.Add(pBranch);
            dt.Columns.Add(pCode);
            dt.Columns.Add(pSupplier);
            dt.Columns.Add(pAmount);
            dt.Columns.Add(pRemark);

            DataSet ds = clsInvoice.GetToGrid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["Date"] = ds.Tables[0].Rows[0]["Date"].ToString();
                dr["Branch"] = ds.Tables[0].Rows[0]["Branch"].ToString();
                dr["Invoice No"] = ds.Tables[0].Rows[0]["Invoice No"].ToString();
                dr["Supplier"] = ds.Tables[0].Rows[0]["Supplier"].ToString();
                dr["Amount"] = ds.Tables[0].Rows[0]["Amount"].ToString();
                dr["Remark"] = ds.Tables[0].Rows[0]["Remark"].ToString();

                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
                dt = ds.Tables[0];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (cmbBranch.SelectedIndex == -1)
            {
                LoadBranch();
            }
            if (txtDate.Text == "")
            {
                txtDate.Text = "dd/mm/yyyy";
            }
            if (txtAmount.Text == "")
            {
                cls_CommonFunctions.SetTextBoxToZero(txtAmount);
            }
            try
            {
                String item = cmbBranch.SelectedValue.Split(char.Parse("-"))[0];
                if (item != "Select...")
                {
                    txtInvoiceNo.Text = clsInvoice.GetNextNo(item);
                    txtSupplier.Focus();
                }
                else
                {
                    txtInvoiceNo.Text = "";
                }
            }
            catch (Exception)
            {
                txtInvoiceNo.Focus();
            }
            viewData();
            cmbBranch.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String item = cmbBranch.SelectedValue.Split(char.Parse("-"))[0];
                if (item != "Select...")
                {
                    txtInvoiceNo.Text = clsInvoice.GetNextNo(item);
                    txtSupplier.Focus();
                }
                else
                {
                    txtInvoiceNo.Text = "";
                }
            }
            catch (Exception)
            {
                txtInvoiceNo.Focus();
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvInvoice.PageIndex = e.NewPageIndex;
            this.viewData();
        }

        //AutoComplete  - Get Supplier
        [WebMethod]
        public static string[] GetSupplier(string prefix)
        {
            List<string> Supplier = new List<string>();

            String query = "SELECT SUP_NO, SUP_NAME FROM tblm_supplier WHERE SUP_NAME LIKE '" + prefix + "%'";
            MySqlDataReader dr = cls_Connection.getData(query);
            int i = 0;
            while (dr.Read())
            {
                Supplier.Add(string.Format("{0}-{1}", dr["SUP_NAME"], dr["SUP_NO"]));
                i++;
                if (i == 10)
                {
                    break;
                }
            }
            return Supplier.ToArray();
        }
    }
}
