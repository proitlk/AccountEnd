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
using System.Collections.Generic;
using System.Web.Services;
//==============================================================
//By            :   Thilanka
//Date          :   20-Mar-2016
//Description   :   Account Payable Files Tax Report Form 
//                  to get the details from Supplier Payable
//==============================================================

namespace Account.Account
{
    public partial class frmAP_TaxReport : System.Web.UI.Page
    {
        clsAP_DuePayment DuePayment = new clsAP_DuePayment();
        private void viewData()
        {
            try
            {
                string Supplier = "", Branch = "";
                if (chbAll.Checked == true)
                {
                    Supplier = "ALL";
                }
                else
                {
                    Supplier = hftxtSupplier.Value;
                }
                if (chbAllBranch.Checked == true)
                {
                    Branch = "ALL";
                }
                else if (chbAllBranch.Checked == false)
                {
                    Branch = cmbBranch.SelectedValue.Split(char.Parse("-"))[0];
                }
                DataTable dt = new DataTable();
                DataColumn pSupplier = new DataColumn("Supplier", Type.GetType("System.String"));
                DataColumn pInvoiceNo = new DataColumn("InvoiceNo", Type.GetType("System.String"));
                DataColumn pNetAmount = new DataColumn("NetAmount", Type.GetType("System.String"));
                DataColumn pVAT = new DataColumn("VAT", Type.GetType("System.String"));
                DataColumn pNBT = new DataColumn("NBT", Type.GetType("System.String"));
                DataColumn pOtherTAX = new DataColumn("OtherTAX", Type.GetType("System.String"));
                DataColumn pGrossAmount = new DataColumn("GrossAmount", Type.GetType("System.String"));

                dt.Columns.Add(pSupplier);
                dt.Columns.Add(pInvoiceNo);
                dt.Columns.Add(pNetAmount);
                dt.Columns.Add(pVAT);
                dt.Columns.Add(pNBT);
                dt.Columns.Add(pOtherTAX);
                dt.Columns.Add(pGrossAmount);

                //DataSet ds = .(Supplier, Branch, Convert.ToString(txtFromDate.Text), Convert.ToString(txtToDate.Text));

                DataRow dr;
                dr = dt.NewRow();
                dr["Supplier"] = "";
                dr["InvoiceNo"] = "";
                dr["NetAmount"] = "0.00";
                dr["VAT"] = "0.00";
                dr["NBT"] = "0.00";
                dr["OtherTAX"] = "0.00";
                dr["GrossAmount"] = "0.00";
                dt.Rows.Add(dr);
                gdvInvoice.DataSource = dt;
                gdvInvoice.DataBind();
            }
            catch (Exception)
            {
            }
        }

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtSupplier);
            chbAll.Checked = false;
            chbAllBranch.Checked = false;
            txtSupplier.Enabled = true;
            cmbBranch.Enabled = true;
            txtFromDate.Text = "dd/mm/yyyy";
            txtToDate.Text = "dd/mm/yyyy";
            viewData();
            LoadBranch();

            DataTable dt = new DataTable();
            DataColumn pSupplier = new DataColumn("Supplier", Type.GetType("System.String"));
            DataColumn pInvoiceNo = new DataColumn("InvoiceNo", Type.GetType("System.String"));
            DataColumn pNetAmount = new DataColumn("NetAmount", Type.GetType("System.String"));
            DataColumn pVAT = new DataColumn("VAT", Type.GetType("System.String"));
            DataColumn pNBT = new DataColumn("NBT", Type.GetType("System.String"));
            DataColumn pOtherTAX = new DataColumn("OtherTAX", Type.GetType("System.String"));
            DataColumn pGrossAmount = new DataColumn("GrossAmount", Type.GetType("System.String"));

            dt.Columns.Add(pSupplier);
            dt.Columns.Add(pInvoiceNo);
            dt.Columns.Add(pNetAmount);
            dt.Columns.Add(pVAT);
            dt.Columns.Add(pNBT);
            dt.Columns.Add(pOtherTAX);
            dt.Columns.Add(pGrossAmount);

            gdvInvoice.DataSource = dt;
            gdvInvoice.DataBind();
        }

        private void LoadBranch()
        {
            cmbBranch.Items.Clear();
            MySqlDataReader dr = DuePayment.LoadBranch();
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
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            viewData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAll.Checked == true)
            {
                txtSupplier.Text = "";
                txtSupplier.Enabled = false;
            }
            if (chbAll.Checked == false)
            {
                txtSupplier.Enabled = true;
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
