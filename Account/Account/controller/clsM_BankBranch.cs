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
    public class clsM_BankBranch
    {
        public int BankNo;
        public int BranchNo;
        public string Branch;
        public int Active;
        public string Createuser;
        public DateTime Createdate;
        public string Edituser;
        public DateTime? Editdate;
        public int Status;

        public bool Save()
        {
            try
            {
                String query = @"INSERT INTO TBLM_BANK_BRANCH(`BRC_NO`,`BRC_BANK_BNK_NO`,`BRC_BRANCHNAME`,`BRC_ACTIVE`,`BRC_CREATEUSER`,`BRC_CREATEDATE`,`BRC_UPDATEUSER`,`BRC_UPDATEDATE`,`BRC_STATUS` ) 
                                 VALUES ('" + BranchNo + "','" + BankNo + "','" + Branch + "','" + Active + "','" + Createuser + "','" + Createdate + "','" + Edituser + "','" + Editdate + "','" + Status + "');";
                cls_Connection.setData(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                String query = @"UPDATE TBLM_BANK_BRANCH SET `BRC_BRANCHNAME` = '" + Branch + "',`BRC_UPDATEDATE` = '" + Editdate + "', `BRC_UPDATEUSER`= '" + Edituser + "' WHERE `BRC_NO` = '" + BranchNo + "' AND `BRC_BANK_BNK_NO` = '" + BankNo + "'";
                cls_Connection.setData(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetNextNo(int Bank)
        {
            int NextNo;
            String Number;
            try
            {
                String query = "SELECT IFNULL(MAX(BRC_NO),0) AS BRC_NO FROM TBLM_BANK_BRANCH WHERE BRC_BANK_BNK_NO = '" + Bank + "'";
                DataSet ds = cls_Connection.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    NextNo = Convert.ToInt32(ds.Tables[0].Rows[0]["BRC_NO"]);
                    NextNo++;
                }
                else
                {
                    NextNo = 1;
                }
                Number = NextNo.ToString();
            }
            catch (Exception)
            {
                Number = "";
            }
            return Number;
        }

        public DataSet GetToGrid()
        {
            String query = "SELECT BRC_BANK_BNK_NO AS `Bank No`, BNK_NAME AS 'Bank Name', BRC_NO AS `Branch No`, BRC_BRANCHNAME AS `Branch Name` FROM TBLM_BANK_BRANCH AS C INNER JOIN TBLM_BANK AS B ON C.BRC_BANK_BNK_NO = B.BNK_NO ORDER BY B.BNK_NO,BRC_NO;";
            DataSet ds = cls_Connection.getDataSet(query);
            return ds;
        }

        public bool GetDetails(int No, int BrNo)
        {
            String query = "SELECT BRC_NO, BRC_BANK_BNK_NO, BRC_BRANCHNAME FROM TBLM_BANK_BRANCH WHERE `BRC_NO` = '" + BrNo + "' AND `BRC_BANK_BNK_NO` = '" + No + "'";
            DataSet ds = cls_Connection.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                BankNo = Convert.ToInt32(ds.Tables[0].Rows[0]["BRC_BANK_BNK_NO"]);
                Branch = ds.Tables[0].Rows[0]["BRC_BRANCHNAME"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public MySqlDataReader LoadBank()
        {
            String query = "SELECT BNK_NO, BNK_NAME FROM TBLM_BANK";
            MySqlDataReader drBranches = cls_Connection.getData(query);
            return drBranches;
        }
    }
}
