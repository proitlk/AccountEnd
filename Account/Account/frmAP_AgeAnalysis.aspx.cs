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
            ReportDocument objReport = new ReportDocument();
            objReport = new Report.rptAP_AgeAnalyst();
            objReport.SetDataSource(ds.Tables[0]);
            crvAgeAnalyst.ReportSource = objReport;
            crvAgeAnalyst.RefreshReport();

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
    }
}
