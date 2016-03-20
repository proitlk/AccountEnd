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
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
//==============================================================
//By            :   Thilanka
//Date          :   14-Mar-2016
//Description   :   Account Payable Files Age Analyst Form 
//                  to get the details from Supplier Payable
//==============================================================

namespace Account.Account
{
    public partial class frmAP_AgeAnalysis : System.Web.UI.Page
    {
        clsAP_AgeAnalyst AgeAnalyst = new clsAP_AgeAnalyst();

        private void viewData()
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
            DataSet ds = AgeAnalyst.GetAgeAnalyst(Supplier, Branch, Convert.ToString(txtFromDate.Text), Convert.ToString(txtToDate.Text));

            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
            }
            DataTable dt = new DataTable();
            double Cage01 = 0, Cage02 = 0, Cage03 = 0, Cage04 = 0, Cage05 = 0, Cage06 = 0, Amount = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Cage01 = Cage01 + Convert.ToDouble(ds.Tables[0].Rows[i]["CAGE_01"]);
                Cage02 = Cage02 + Convert.ToDouble(ds.Tables[0].Rows[i]["CAGE_02"]);
                Cage03 = Cage03 + Convert.ToDouble(ds.Tables[0].Rows[i]["CAGE_03"]);
                Cage04 = Cage04 + Convert.ToDouble(ds.Tables[0].Rows[i]["CAGE_04"]);
                Cage05 = Cage05 + Convert.ToDouble(ds.Tables[0].Rows[i]["CAGE_05"]);
                Cage06 = Cage06 + Convert.ToDouble(ds.Tables[0].Rows[i]["CAGE_06"]);
                Amount = Amount + Convert.ToDouble(ds.Tables[0].Rows[i]["INV_AMOUNT"]);
            }
            DataColumn pName = new DataColumn("SUP_NAME", Type.GetType("System.String"));
            DataColumn pCage1 = new DataColumn("CAGE_01", Type.GetType("System.String"));
            DataColumn pCage2 = new DataColumn("CAGE_02", Type.GetType("System.String"));
            DataColumn pCage3 = new DataColumn("CAGE_03", Type.GetType("System.String"));
            DataColumn pCage4 = new DataColumn("CAGE_04", Type.GetType("System.String"));
            DataColumn pCage5 = new DataColumn("CAGE_05", Type.GetType("System.String"));
            DataColumn pCage6 = new DataColumn("CAGE_06", Type.GetType("System.String"));
            DataColumn pAmount = new DataColumn("INV_AMOUNT", Type.GetType("System.String"));

            dt.Columns.Add(pName);
            dt.Columns.Add(pCage1);
            dt.Columns.Add(pCage2);
            dt.Columns.Add(pCage3);
            dt.Columns.Add(pCage4);
            dt.Columns.Add(pCage5);
            dt.Columns.Add(pCage6);
            dt.Columns.Add(pAmount);

            DataRow dr;
            dr = dt.NewRow();
            dr["SUP_NAME"] = "Total";
            dr["CAGE_01"] = Cage01.ToString("0.00");
            dr["CAGE_02"] = Cage02.ToString("0.00"); ;
            dr["CAGE_03"] = Cage03.ToString("0.00"); ;
            dr["CAGE_04"] = Cage04.ToString("0.00"); ;
            dr["CAGE_05"] = Cage05.ToString("0.00"); ;
            dr["CAGE_06"] = Cage06.ToString("0.00"); ;
            dr["INV_AMOUNT"] = Amount.ToString("0.00"); ;
            dt.Rows.Add(dr);
            gdvTotal.DataSource = dt;
            gdvTotal.DataBind();

            //ReportDocument objReport = new ReportDocument();
            //objReport = new Report.rptAP_AgeAnalyst();
            //objReport.SetDataSource(ds.Tables[0]);
            //crvAgeAnalyst.ReportSource = objReport;
            //crvAgeAnalyst.RefreshReport();

            //ReportDocument cryRpt = new ReportDocument();
            //cryRpt.Load(Server.MapPath("Report.rptAP_AgeAnalyst.rpt"));
            //crvAgeAnalyst.ReportSource = cryRpt;
            btnPrint.Visible = true;
        }

        private void PrintAgeAnalyst()
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
            DataSet ds = AgeAnalyst.GetAgeAnalyst(Supplier, Branch, Convert.ToString(txtFromDate.Text), Convert.ToString(txtToDate.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                AgeAnalyst = new clsAP_AgeAnalyst();
                ReportDocument objReport = new ReportDocument();
                objReport = new Report.rptAP_AgeAnalyst();

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
            viewData();
            txtFromDate.Text = "dd/mm/yyyy";
            txtToDate.Text = "dd/mm/yyyy";
            LoadBranch(); ;

            DataTable dt = new DataTable();
            DataColumn pName = new DataColumn("SUP_NAME", Type.GetType("System.String"));
            DataColumn pCage1 = new DataColumn("CAGE_01", Type.GetType("System.String"));
            DataColumn pCage2 = new DataColumn("CAGE_02", Type.GetType("System.String"));
            DataColumn pCage3 = new DataColumn("CAGE_03", Type.GetType("System.String"));
            DataColumn pCage4 = new DataColumn("CAGE_04", Type.GetType("System.String"));
            DataColumn pCage5 = new DataColumn("CAGE_05", Type.GetType("System.String"));
            DataColumn pCage6 = new DataColumn("CAGE_06", Type.GetType("System.String"));
            DataColumn pAmount = new DataColumn("INV_AMOUNT", Type.GetType("System.String"));

            dt.Columns.Add(pName);
            dt.Columns.Add(pCage1);
            dt.Columns.Add(pCage2);
            dt.Columns.Add(pCage3);
            dt.Columns.Add(pCage4);
            dt.Columns.Add(pCage5);
            dt.Columns.Add(pCage6);
            dt.Columns.Add(pAmount);

            gdvTotal.DataSource = dt;
            gdvTotal.DataBind();
            gdvInvoice.DataSource = dt;
            gdvInvoice.DataBind();
            btnPrint.Visible = false;
        }

        private void LoadBranch()
        {
            cmbBranch.Items.Clear();
            MySqlDataReader dr = AgeAnalyst.LoadBranch();
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
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
            PrintAgeAnalyst();
        }
    }
}
