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

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
