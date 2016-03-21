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
    public partial class frmAP_Expences : System.Web.UI.Page
    {
        clsAP_Expence Expence = new clsAP_Expence();

        private void viewData()
        {
            string Branch = "";
            if (chbAllBranch.Checked == true)
            {
                Branch = "ALL";
            }
            else if (chbAllBranch.Checked == false)
            {
                Branch = cmbBranch.SelectedValue.Split(char.Parse("-"))[0];
            }

            DataSet ds = Expence.GetExpence(Branch, Convert.ToString(txtFromDate.Text), Convert.ToString(txtToDate.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
            }
            DataTable dt = new DataTable();
            DataColumn pEdate = new DataColumn("Edate", Type.GetType("System.String"));
            DataColumn pcatog_id = new DataColumn("catog_id", Type.GetType("System.String"));
            DataColumn pName = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn pchq = new DataColumn("chq", Type.GetType("System.String"));
            DataColumn ppay = new DataColumn("pay", Type.GetType("System.String"));
            DataColumn pdes = new DataColumn("des", Type.GetType("System.String"));
            DataColumn pamount = new DataColumn("amount", Type.GetType("System.String"));

            dt.Columns.Add(pEdate);
            dt.Columns.Add(pcatog_id);
            dt.Columns.Add(pName);
            dt.Columns.Add(pchq);
            dt.Columns.Add(ppay);
            dt.Columns.Add(pdes);
            dt.Columns.Add(pamount);
            double amount = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                amount = amount + Convert.ToDouble(ds.Tables[0].Rows[i]["amount"]);
            }
            DataRow dr;
            dr = dt.NewRow();
            dr["Edate"] = "";
            dr["catog_id"] = "";
            dr["Name"] = "";
            dr["pay"] = "";
            dr["chq"] = "";
            dr["des"] = "Total";
            dr["amount"] = amount.ToString("0.00");
            dt.Rows.Add(dr);
            gdvTotal.DataSource = dt;
            gdvTotal.DataBind();
        }

        private void Reset()
        {
            chbAllBranch.Checked = false;
            cmbBranch.Enabled = true;
            txtFromDate.Text = "dd/mm/yyyy";
            txtToDate.Text = "dd/mm/yyyy";
            txtToDate.Visible = false;
            viewData();
            LoadBranch();
            txtToDate.Visible = false;
            txtFromDate.Text = "31/01/2016";
            txtFromDate.Enabled = false;
            cmbBranch.Enabled = false;
            chbAllBranch.Enabled = false;
        }

        private void LoadBranch()
        {
            cmbBranch.Items.Clear();
            MySqlDataReader dr = Expence.LoadBranch();
            cmbBranch.Items.Add("Select...");
            while (dr.Read())
            {
                cmbBranch.Items.Add(dr.GetString("idexpen_type") + "- " + dr.GetString("Name"));
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
