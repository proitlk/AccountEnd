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
using CrystalDecisions.CrystalReports.Engine;
using System.Web.Services;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
//==============================================================
//By            :   Thilanka
//Date          :   17-Mar-2016
//Description   :   Account Payable Files Trade / Loan Receivable Form 
//                  to get the details from Account Receivable
//==============================================================

namespace Account.Account
{
    public partial class frmAR_Trade_Loan_Receivable : System.Web.UI.Page
    {
        clsAR_Trade_Loan_Receivable Receivable = new clsAR_Trade_Loan_Receivable();

        private void viewData()
        {
            string ContractCode;
            if (chbAll.Checked == true)
            {
                ContractCode = "ALL";
            }
            else
            {
                ContractCode = hftxtContractCode.Value;
            }

            DataSet ds = Receivable.GetLoanReceivable(ContractCode, Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text));
            ReportDocument objReport = new ReportDocument();
            objReport = new Report.rptAR_LoanReceivable();
            objReport.SetDataSource(ds.Tables[0]);
            crvLoanReceivable.ReportSource = objReport;
            crvLoanReceivable.RefreshReport();
        }

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtContractCode);
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

        protected void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAll.Checked == true)
            {
                txtContractCode.Text = "";
                txtContractCode.Enabled = false;
            }
            if (chbAll.Checked == false)
            {
                txtContractCode.Enabled = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            viewData();
        }

        //AutoComplete  - Get Contract Code
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

    }
}
