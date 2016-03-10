using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Account.Account
{
    public class clsAP_Invoice
    {
        public int InvoiceNo;
        public string InvDate;
        public int BranchNo;
        public int SupplierNo;
        public decimal Amount;
        public string Remark;
        public int IsCancel;
        public string Createuser;
        public DateTime Createdate;
        public int Status;
        
        public bool Save()
        {
            try
            {
                String query = @"INSERT INTO TBLAP_INVOICE(`INV_NO`,`INV_DATE`,`INV_BRANCHNO`,`INV_SUP_NO`,`INV_AMOUNT`,`INV_REMARK`,`INV_ISCANCEL`,`INV_CREATEUSER`,`INV_CREATEDATE`,`INV_STATUS`) 
                                 VALUES ('" + InvoiceNo + "','" + InvDate + "','" + BranchNo + "','" + SupplierNo + "','" + Amount + "','" + Remark + "','" + IsCancel + "','" + Createuser + "','" + Createdate + "','" + Status + "');";
                cls_Connection.setData(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MySqlDataReader LoadBranch()
        {
            String query = "SELECT `BRCH_BRANCHNO`,`BRCH_NAME` FROM `TBLU_BRANCH`;";
            MySqlDataReader drBranches = cls_Connection.getData(query);
            return drBranches;
        }

        public string GetNextNo(string Location)
        {
            int NextNo;
            String Number;
            try
            {
                String query = "SELECT IFNULL(MAX(INV_NO),0) AS INV_NO FROM TBLAP_INVOICE WHERE INV_BRANCHNO = '" + Location + "'";
                DataSet ds = cls_Connection.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    NextNo = Convert.ToInt32(ds.Tables[0].Rows[0]["INV_NO"]);
                    NextNo++;
                }
                else
                {
                    NextNo = 1;
                }
                Number = Location + NextNo.ToString("000000000");
            }
            catch (Exception)
            {
                Number = "";
            }
            return Number;
        }
    }
}
