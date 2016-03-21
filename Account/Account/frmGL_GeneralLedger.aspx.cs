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
    public partial class frmGL_GeneralLedger : System.Web.UI.Page
    {
        clsGL_GeneralLedger GeneralLedger = new clsGL_GeneralLedger();

        private void viewData()
        {
            string Branch = "";
            Branch = cmbBranch.SelectedValue.Split(char.Parse("-"))[0];
            DataSet ds = GeneralLedger.GetGeneralLedger(Branch);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
            }
            DataTable dt = new DataTable();
            DataColumn pEdate = new DataColumn("Edate", Type.GetType("System.String"));
            DataColumn pdes = new DataColumn("des", Type.GetType("System.String"));
            DataColumn pAmount = new DataColumn("Amount", Type.GetType("System.String"));
            DataColumn pDr = new DataColumn("Dr", Type.GetType("System.String"));
            DataColumn pCr = new DataColumn("Cr", Type.GetType("System.String"));
            DataColumn pBalance = new DataColumn("Balance", Type.GetType("System.String"));
            dt.Columns.Add(pEdate);
            dt.Columns.Add(pdes);
            dt.Columns.Add(pAmount);
            dt.Columns.Add(pDr);
            dt.Columns.Add(pCr);
            dt.Columns.Add(pBalance);
            double amount = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                amount = amount + Convert.ToDouble(ds.Tables[0].Rows[i]["amount"]);
            }
            DataRow dr;
            dr = dt.NewRow();
            dr["Edate"] = "";
            dr["des"] = "";
            dr["Amount"] = amount.ToString("0.00");
            dr["Dr"] = amount.ToString("0.00");
            dr["Cr"] = amount.ToString("0.00");
            dr["Balance"] = amount.ToString("0.00");

            dt.Rows.Add(dr);
        }

        private void LoadCategoty()
        {
            cmbBranch.Items.Clear();
            MySqlDataReader dr = GeneralLedger.LoadCategoty();
            cmbBranch.Items.Add("Select...");
            while (dr.Read())
            {
                cmbBranch.Items.Add(dr.GetString("tblfr_tbcol") + "- " + dr.GetString("DESCRIPTION"));
            }
            cmbBranch.SelectedIndex = -1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (cmbBranch.SelectedIndex == -1)
            {
                LoadCategoty();
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            viewData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void gdvInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}
