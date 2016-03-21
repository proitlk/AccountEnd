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
using CrystalDecisions.CrystalReports.Engine;
using System.Web.Services;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
//==============================================================
//By            :   Thilanka
//Date          :   17-Mar-2016
//Description   :   Account Payable Files Trade / Loan Receivable Form 
//                  to get the details from Account Receivable
//==============================================================

namespace Account.Account
{
    public partial class frmAR_Trade_Loan_Receivable : System.Web.UI.Page
    {
        clsAR_Trade_Loan_Receivable Receivable = new clsAR_Trade_Loan_Receivable();

        private void viewData()
        {
            DataSet ds = new DataSet();
            string ContractCode = "", Branch = "", Product = "";
            if (chbAll.Checked == true)
            {
                ContractCode = "ALL";
            }
            else if (chbAll.Checked == false)
            {
                ContractCode = hftxtContractCode.Value;
            }
            if (chbAllBranch.Checked == true)
            {
                Branch = "ALL";
            }
            else if (chbAllBranch.Checked == false)
            {
                Branch = cmbBranch.SelectedValue.Split(char.Parse("-"))[0];
            }
            if (chbAllProduct.Checked == true)
            {
                Product = "ALL";
            }
            else if (chbAllProduct.Checked == false)
            {
                Product = cmbProduct.SelectedValue;
                if (Product == "1")
                {
                    ds = Receivable.GetLoanReceivable(ContractCode, Branch, Convert.ToString(txtFromDate.Text), Convert.ToString(txtToDate.Text));
                }
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
            }
        }

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtContractCode);
            chbAll.Checked = false;
            chbAllBranch.Checked = false;
            chbAllProduct.Checked = false;
            txtContractCode.Enabled = true;
            cmbBranch.Enabled = true;
            cmbProduct.Enabled = true;
            viewData();
            txtFromDate.Text = "dd/mm/yyyy";
            txtToDate.Text = "dd/mm/yyyy";
        }

        private void LoadBranch()
        {
            cmbBranch.Items.Clear();
            MySqlDataReader dr = Receivable.LoadBranch();
            cmbBranch.Items.Add("Select...");
            while (dr.Read())
            {
                cmbBranch.Items.Add(dr.GetString("BRCH_BRANCHNO") + "- " + dr.GetString("BRCH_NAME"));
            }
            cmbBranch.SelectedIndex = -1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtFromDate.Text == "")
            {
                txtFromDate.Text = "dd/mm/yyyy";
            }
            if (txtToDate.Text == "")
            {
                txtToDate.Text = "dd/mm/yyyy";
            }
            if (cmbBranch.SelectedIndex == -1)
            {
                LoadBranch();
            }
            btnPrint.Visible = false;
        }

        protected void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAll.Checked == true)
            {
                txtContractCode.Text = "";
                txtContractCode.Enabled = false;
            }
            if (chbAll.Checked == false)
            {
                txtContractCode.Enabled = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            viewData();
        }

        //AutoComplete  - Get Contract Code
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

        protected void chbAllProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAllProduct.Checked == true)
            {
                cmbProduct.SelectedIndex = 0;
                cmbProduct.Enabled = false;
            }
            if (chbAllProduct.Checked == false)
            {
                cmbProduct.Enabled = true;
            }
        }

        protected void chbAllBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAllBranch.Checked == true)
            {
                cmbBranch.SelectedIndex = 0;
                cmbBranch.Enabled = false;
            }
            if (chbAllBranch.Checked == false)
            {
                cmbBranch.Enabled = true;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }

    }
}
