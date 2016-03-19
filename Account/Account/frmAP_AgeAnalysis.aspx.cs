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
            string Supplier;
            if (chbAll.Checked == true)
            {
                Supplier = "ALL";
            }
            else
            {
                Supplier = hftxtSupplier.Value;
            }

            DataSet ds = AgeAnalyst.GetAgeAnalyst(Supplier, Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text));

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
        }

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtSupplier);
            chbAll.Checked = false;
            viewData();
            txtFromDate.Text = "dd/mm/yyyy";
            txtToDate.Text = "dd/mm/yyyy";
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
    }
}
