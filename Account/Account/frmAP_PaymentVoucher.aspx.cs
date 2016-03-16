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
        clsAP_PaymentVoucher PaymentVoucher = new clsAP_PaymentVoucher();

        private void viewData()
        {            
            DataTable dt = new DataTable();
            DataColumn pExpNo = new DataColumn("EXP_NO", Type.GetType("System.String"));
            DataColumn pInvoiceDate = new DataColumn("EXP_DATE", Type.GetType("System.String"));
            DataColumn pSupName = new DataColumn("SUP_NAME", Type.GetType("System.String"));
            DataColumn pAmount = new DataColumn("EXP_PAIDAMOUNT", Type.GetType("System.String"));

            dt.Columns.Add(pExpNo);
            dt.Columns.Add(pInvoiceDate);
            dt.Columns.Add(pSupName);
            dt.Columns.Add(pAmount);

            DataSet ds = PaymentVoucher.GetPaymentVoucherSummery();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["EXP_NO"] = ds.Tables[0].Rows[0]["EXP_NO"].ToString();
                dr["EXP_DATE"] = ds.Tables[0].Rows[0]["EXP_DATE"].ToString();
                dr["SUP_NAME"] = ds.Tables[0].Rows[0]["SUP_NAME"].ToString();
                dr["EXP_PAIDAMOUNT"] = ds.Tables[0].Rows[0]["EXP_PAIDAMOUNT"].ToString();

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
