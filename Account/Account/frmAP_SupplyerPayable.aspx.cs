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
    public partial class frmAP_SupplyerPayable : System.Web.UI.Page
    {
        private ErrorLog error = new ErrorLog();

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtPayableNo, txtSupplier, txtAmount, txtRemark);
        }

        private void Save()
        {
            int No = Convert.ToInt32(txtPayableNo.Text.Trim());
            DateTime Date = System.DateTime.Now;
            int BranchNo = 1;//Convert.ToInt32(cmbBranch.Selectedvalue);
            int Sup_No = Convert.ToInt32(txtSupplier.Text.Trim());
            int Bnk_brc_No = 1;
            int Bnk_No = 1;
            string Chequeno = "123456";
            string Accountno = "124557";
            double Totalamount = Convert.ToInt32(txtAmount.Text.Trim());
            double Paidamount = 0;
            double Balanceamount = 0;
            string Remark = "Remark 1";
            int Is_fixasset = 1;
            int Dpr_cat_no = 1;
            double Depreciation = 0;
            string Memo = "";
            int Expence_type = 0;
            int Isvoucherprint = 0;
            int Ischequeprint = 0;
            string Createuser = "Admin";
            DateTime Createdate = System.DateTime.Now;
            int Status = 1;

            String query = @"INSERT INTO TBLAP_EXPENCES VALUES ('" + No + "','" + Date + "','" + BranchNo + "','" + Sup_No + "','" + Bnk_brc_No + "','" + Bnk_No + "','" + Chequeno + "','" + Accountno + "','" + Totalamount + "','" + Paidamount + "','" + Balanceamount + "','" + Remark + "','" + Is_fixasset + "','" + Dpr_cat_no + "','" + Depreciation + "','" + Memo + "','" + Expence_type + "','" + Isvoucherprint + "','" + Ischequeprint + "','" + Createuser + "','" + Createdate + "','" + Status + "');";
            cls_Connection.setData(query);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
