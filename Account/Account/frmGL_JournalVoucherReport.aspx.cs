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
    public partial class frmGL_JournalVoucherReport : System.Web.UI.Page
    {
        clsGL_GeneralLedger GeneralLedger = new clsGL_GeneralLedger();

        private void viewData()
        {
            try
            {
                DataSet ds = GeneralLedger.JournalVoucherReport(Convert.ToString(txtFromDate.Text), Convert.ToString(txtToDate.Text));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gdvInvoice.DataSource = ds.Tables[0];
                    gdvInvoice.DataBind();
                }
            }
            catch (Exception)
            {
            }
        }

        private void Reset()
        {
            txtFromDate.Text = "dd/mm/yyyy";
            txtToDate.Text = "dd/mm/yyyy";
            viewData();
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
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            viewData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void gdvInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvInvoice.PageIndex = e.NewPageIndex;
            this.viewData();
        }
    }
}
