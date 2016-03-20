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
using CrystalDecisions.CrystalReports.Engine;
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
            DataColumn pOutstanding = new DataColumn("Outstanding", Type.GetType("System.String"));
            DataColumn pAdvancePaid = new DataColumn("AdvancePaid", Type.GetType("System.String"));
            DataColumn pBalanceDue = new DataColumn("BalanceDue", Type.GetType("System.String"));

            dt.Columns.Add(pSupplier);
            dt.Columns.Add(pInvoiceNo);
            dt.Columns.Add(pOutstanding);
            dt.Columns.Add(pAdvancePaid);
            dt.Columns.Add(pBalanceDue);

            DataSet ds = DuePayment.GetDuePayment(Supplier, Branch, Convert.ToString(txtFromDate.Text), Convert.ToString(txtToDate.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
            }
            double Outstanding = 0, AdvancePaid = 0, BalanceDue = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Outstanding = Outstanding + Convert.ToDouble(ds.Tables[0].Rows[i]["Outstanding"]);
                AdvancePaid = AdvancePaid + Convert.ToDouble(ds.Tables[0].Rows[i]["AdvancePaid"]);
                BalanceDue = BalanceDue + Convert.ToDouble(ds.Tables[0].Rows[i]["BalanceDue"]);
            }
            DataRow dr;
            dr = dt.NewRow();
            dr["Supplier"] = "Total";
            dr["InvoiceNo"] = "";
            dr["Outstanding"] = Outstanding.ToString("0.00");
            dr["AdvancePaid"] = AdvancePaid.ToString("0.00"); 
            dr["BalanceDue"] = BalanceDue.ToString("0.00"); 
            dt.Rows.Add(dr);
            gdvTotal.DataSource = dt;
            gdvTotal.DataBind();

            btnPrint.Visible = true;
        }

        private void PrintDuePayment()
        {
            string Supplier = "ALL", Branch = "ALL";
            if (chbAll.Checked == true)
            {
                Supplier = "ALL";
            }
            else if (chbAll.Checked == false)
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
            cls_Setup Setup = new cls_Setup();
            // Retrieve the row that contains the button
            // from the Rows collection.
            DataSet ds = DuePayment.GetDuePayment(Supplier, Branch, Convert.ToString(txtFromDate.Text), Convert.ToString(txtToDate.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                DuePayment = new clsAP_DuePayment();
                ReportDocument objReport = new ReportDocument();
                objReport = new Report.rptAP_DuePayment();

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
            gdvTotal.DataSource = dt;
            gdvTotal.DataBind();
            btnPrint.Visible = false;
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
            btnPrint.Visible = false;
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

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDuePayment();
        }
    }
}
