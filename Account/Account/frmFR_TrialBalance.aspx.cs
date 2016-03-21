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
using CrystalDecisions.CrystalReports.Engine;

namespace Account.Account
{
    public partial class frmFR_TrialBalance : System.Web.UI.Page
    {
        clsFR_TrialBalance TrialBalance = new clsFR_TrialBalance();

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

            DataSet ds = TrialBalance.GetTrialBalance(Branch, Convert.ToString(txtFromDate.Text), Convert.ToString(txtToDate.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
            }
            btnPrint.Visible = true;
        }

        private void PrintTrialBalance()
        {            
            cls_Setup Setup = new cls_Setup();
            // Retrieve the row that contains the button
            // from the Rows collection.
            DataSet ds = TrialBalance.GetTrialBalance("", Convert.ToString(txtFromDate.Text), Convert.ToString(txtToDate.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                TrialBalance = new clsFR_TrialBalance();
                ReportDocument objReport = new ReportDocument();
                objReport = new Report.rptFR_TrialBalance();

                if (Setup.GetCompany("1") == true)
                {
                    foreach (CrystalDecisions.CrystalReports.Engine.FormulaFieldDefinition FormulaName in objReport.DataDefinition.FormulaFields)
                    {
                        switch (FormulaName.Name)
                        {
                            case "Company":
                                FormulaName.Text = "'" + Setup.ComName + "'";
                                break;

                            case "Address":
                                FormulaName.Text = "'" + Setup.Address + "'";
                                break;

                            case "Telephone":
                                FormulaName.Text = "'" + Setup.Telephone + "'";
                                break;

                            case "Fax":
                                FormulaName.Text = "'" + Setup.Fax + "'";
                                break;

                            case "EMail":
                                FormulaName.Text = "'" + Setup.EMail + "'";
                                break;

                            case "Web":
                                FormulaName.Text = "'" + Setup.Web + "'";
                                break;
                        }
                    }
                }

                objReport.SetDataSource(ds.Tables[0]);
                try
                {
                    int Copies = 1;
                    objReport.PrintToPrinter(Copies, false, 1, 99999);
                }
                catch (Exception ex)
                {
                }
            }
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
            MySqlDataReader dr = TrialBalance.LoadBranch();
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
            txtToDate.Visible = false;
            txtFromDate.Text = "31/01/2016";
            txtFromDate.Enabled = false;
            cmbBranch.Enabled = false;
            chbAllBranch.Enabled = false;
            btnPrint.Visible = false;
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

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            PrintTrialBalance();
        }
    }
}
