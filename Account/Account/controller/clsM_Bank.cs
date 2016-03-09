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

namespace Account.Account
{
    public class clsM_Bank
    {
        public int BankNo;
        public string Bank;
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
                String query = @"INSERT INTO TBLM_BANK(`BNK_NO`,`BNK_NAME`,`BNK_ACTIVE`,`BNK_CREATEUSER`,`BNK_CREATEDATE`,`BNK_UPDATEUSER`,`BNK_UPDATEDATE`,`BNK_STATUS`) 
                                 VALUES ('" + BankNo + "','" + Bank + "','" + Active + "','" + Createuser + "','" + Createdate + "','" + Edituser + "','" + Editdate + "','" + Status + "');";
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
                String query = @"UPDATE TBLM_BANK SET `BNK_NAME` = '" + Bank + "',`BNK_UPDATEDATE` =  '" + Editdate + "', `BNK_UPDATEUSER`= '" + Edituser + "' WHERE `BNK_NO` = '" + BankNo + "'";
                cls_Connection.setData(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetNextNo()
        {
            int NextNo;
            String Number;
            try
            {
                String query = "SELECT IFNULL(MAX(BNK_NO),0) AS BNK_NO FROM TBLM_BANK";
                DataSet ds = cls_Connection.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    NextNo = Convert.ToInt32(ds.Tables[0].Rows[0]["BNK_NO"]);
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
            String query = "SELECT BNK_NO AS `Bank No`, BNK_NAME AS `Bank Name` FROM TBLM_BANK;";
            DataSet ds = cls_Connection.getDataSet(query);
            return ds;
        }

        public bool GetDetails(int No)
        {
            String query = "SELECT BNK_NO, BNK_NAME FROM TBLM_BANK WHERE BNK_NO = '" + No + "'";
            DataSet ds = cls_Connection.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                BankNo = Convert.ToInt32(ds.Tables[0].Rows[0]["BNK_NO"]);
                Bank = ds.Tables[0].Rows[0]["BNK_NAME"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExist(string Name)
        {
            String query = "SELECT BNK_NO, BNK_NAME FROM TBLM_BANK WHERE BNK_NAME = '" + Name + "'";
            DataSet ds = cls_Connection.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
