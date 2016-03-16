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

namespace Account.Account
{
    public partial class frmAP_PaymentVoucher : System.Web.UI.Page
    {
        clsAP_DuePayment DuePayment = new clsAP_DuePayment();

        private void viewData()
        {            
            DataTable dt = new DataTable();
            DataColumn pSupplier = new DataColumn("Supplier", Type.GetType("System.String"));
            DataColumn pInvoiceNo = new DataColumn("InvoiceNo", Type.GetType("System.String"));
            DataColumn pOutstanding = new DataColumn("Outstanding", Type.GetType("System.String"));

            dt.Columns.Add(pSupplier);
            dt.Columns.Add(pInvoiceNo);
            dt.Columns.Add(pOutstanding);

            DataSet ds = DuePayment.GetDuePayment("ALL");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["Supplier"] = ds.Tables[0].Rows[0]["Supplier"].ToString();
                dr["InvoiceNo"] = ds.Tables[0].Rows[0]["InvoiceNo"].ToString();
                dr["Outstanding"] = ds.Tables[0].Rows[0]["Outstanding"].ToString();

                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
                dt = ds.Tables[0];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            viewData();
        }
    }
}
