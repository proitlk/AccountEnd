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
    public partial class frmCB_BankAccount : System.Web.UI.Page
    {
        clsCB_BankReconciliation BankReconciliation = new clsCB_BankReconciliation();

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
            DataTable dt = new DataTable();
            DataColumn pContractCode = new DataColumn("ContractCode", Type.GetType("System.String"));
            DataColumn pCustomerName = new DataColumn("CustomerName", Type.GetType("System.String"));
            DataColumn pchequ_no = new DataColumn("chequ_no", Type.GetType("System.String"));
            DataColumn pchequ_amount = new DataColumn("chequ_amount", Type.GetType("System.String"));
            DataColumn pLoanGrantDate = new DataColumn("LoanGrantDate", Type.GetType("System.String"));

            dt.Columns.Add(pContractCode);
            dt.Columns.Add(pCustomerName);
            dt.Columns.Add(pchequ_no);
            dt.Columns.Add(pchequ_amount);
            dt.Columns.Add(pLoanGrantDate);

            DataSet ds = BankReconciliation.GetBankReconciliation(Convert.ToString(txtFromDate.Text), Convert.ToString(txtToDate.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

            }
            gdvTotal.DataSource = dt;

        }

        private void Reset()
        {
            chbAllBranch.Checked = false;
            cmbBranch.Enabled = true;
            txtFromDate.Text = "dd/mm/yyyy";
            txtToDate.Text = "dd/mm/yyyy";
            viewData();
            LoadBranch();

            DataTable dt = new DataTable();
            DataColumn pContractCode = new DataColumn("ContractCode", Type.GetType("System.String"));
            DataColumn pCustomerName = new DataColumn("CustomerName", Type.GetType("System.String"));
            DataColumn pchequ_no = new DataColumn("chequ_no", Type.GetType("System.String"));
            DataColumn pchequ_amount = new DataColumn("chequ_amount", Type.GetType("System.String"));
            DataColumn pLoanGrantDate = new DataColumn("LoanGrantDate", Type.GetType("System.String"));

            dt.Columns.Add(pContractCode);
            dt.Columns.Add(pCustomerName);
            dt.Columns.Add(pchequ_no);
            dt.Columns.Add(pchequ_amount);
            dt.Columns.Add(pLoanGrantDate);

            gdvInvoice.DataSource = dt;
            gdvInvoice.DataBind();
            gdvTotal.DataSource = dt;
            gdvTotal.DataBind();
        }

        private void LoadBranch()
        {
            cmbBranch.Items.Clear();
            MySqlDataReader dr = BankReconciliation.LoadBranch();
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
