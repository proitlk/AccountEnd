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
//Date          :   15-Mar-2016
//Description   :   Account Payable Files Due Payment Form 
//                  to get the details from Supplier Payable
//==============================================================

namespace Account.Account
{
    public partial class frmAP_DuePayment : System.Web.UI.Page
    {
        clsAP_DuePayment DuePayment = new clsAP_DuePayment();

        private void viewData()
        {
            string Supplier;
            if (chbAll.Checked == true)
            {
                Supplier = "ALL";
            }
            else
            {
                Supplier = hftxtSupplier.Value;
            }

            DataTable dt = new DataTable();
            DataColumn pSupplier = new DataColumn("Supplier", Type.GetType("System.String"));
            DataColumn pInvoiceNo = new DataColumn("InvoiceNo", Type.GetType("System.String"));
            DataColumn pOutstanding = new DataColumn("Outstanding", Type.GetType("System.String"));
            DataColumn pAdvancePaid = new DataColumn("AdvancePaid", Type.GetType("System.String"));
            DataColumn pBalanceDue = new DataColumn("BalanceDue", Type.GetType("System.String"));

            dt.Columns.Add(pSupplier);
            dt.Columns.Add(pInvoiceNo);
            dt.Columns.Add(pOutstanding);
            dt.Columns.Add(pAdvancePaid);
            dt.Columns.Add(pBalanceDue);

            DataSet ds = DuePayment.GetDuePayment(Supplier);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["Supplier"] = ds.Tables[0].Rows[0]["Supplier"].ToString();
                dr["InvoiceNo"] = ds.Tables[0].Rows[0]["InvoiceNo"].ToString();
                dr["Outstanding"] = ds.Tables[0].Rows[0]["Outstanding"].ToString();
                dr["AdvancePaid"] = ds.Tables[0].Rows[0]["AdvancePaid"].ToString();
                dr["BalanceDue"] = ds.Tables[0].Rows[0]["BalanceDue"].ToString();

                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
                dt = ds.Tables[0];
            }
        }

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtSupplier);
            chbAll.Checked = false;
            viewData();

            DataTable dt = new DataTable();
            DataColumn pSupplier = new DataColumn("Supplier", Type.GetType("System.String"));
            DataColumn pInvoiceNo = new DataColumn("InvoiceNo", Type.GetType("System.String"));
            DataColumn pOutstanding = new DataColumn("Outstanding", Type.GetType("System.String"));
            DataColumn pAdvancePaid = new DataColumn("AdvancePaid", Type.GetType("System.String"));
            DataColumn pBalanceDue = new DataColumn("BalanceDue", Type.GetType("System.String"));

            dt.Columns.Add(pSupplier);
            dt.Columns.Add(pInvoiceNo);
            dt.Columns.Add(pOutstanding);
            dt.Columns.Add(pAdvancePaid);
            dt.Columns.Add(pBalanceDue);

            gdvInvoice.DataSource = dt;
            gdvInvoice.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

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
