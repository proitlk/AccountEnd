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
    public class clsGL_GeneralLedger
    {
        private static MySqlConnection connect = null;
        cls_Connection conn = new cls_Connection();
        public int No;        
        public string Description;
        public string JVDate;
        public int CategoryNo;
        public string Category;
        public double Dr;
        public double Cr;
        public string CreateUser;
        public DateTime CreateDate;
        public int status;

        public DataSet GetGeneralLedger()
        {
            connect = cls_Connection.DBConnect();
            connect.Open();
            string rtn = "USP_GL_GENERALLEDGER_SELECT";
            MySqlCommand cmd = new MySqlCommand(rtn, connect);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = conn.GetDataSet(cmd);
            return ds;
        }

        public DataSet JournalVoucherReport(string FromDate, string ToDate)
        {
            connect = cls_Connection.DBConnect();
            connect.Open();
            string rtn = "USP_GL_GENERALLEDGER_REPORT";
            MySqlCommand cmd = new MySqlCommand(rtn, connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            DataSet ds = conn.GetDataSet(cmd);
            return ds;
        }

        public MySqlDataReader LoadCategoty()
        {
            String query = "SELECT GLC_NO, GLC_DESCRIPTION, GLC_VALUE FROM TBLM_GL_CATEGORY;";
            MySqlDataReader drGL = cls_Connection.getData(query);
            return drGL;
        }

        public MySqlDataReader LoadGeneralLedger()
        {
            String query = "SELECT GLM_NO, GLM_NAME FROM TBLM_GL_MASTER_FILLES;";
            MySqlDataReader drGL = cls_Connection.getData(query);
            return drGL;
        }

        public string GetNextNo()
        {
            int NextNo;
            String Number;
            try
            {
                String query = "SELECT IFNULL(MAX(GLM_NO),0) AS GL_NO FROM TBLM_GL_MASTER_FILLES";
                DataSet ds = cls_Connection.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    NextNo = Convert.ToInt32(ds.Tables[0].Rows[0]["GL_NO"]);
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

        public bool Save()
        {
            try
            {
                No = Convert.ToInt32(GetNextNo());
                String query = @"INSERT INTO TBLM_GL_MASTER_FILLES 
                                 VALUES ('" + No + "','" + Description + "','" + CategoryNo + "','" + Category + "','" + CreateUser + "','" + CreateDate + "','" + status + "');";
                cls_Connection.setData(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Journal Voucher---------------------------------------

        public string GeJVNextNo()
        {
            int NextNo;
            String Number;
            try
            {
                String query = "SELECT IFNULL(MAX(JV_NO),0) AS JV_NO FROM TBLGL_JOURNALVOUCHER";
                DataSet ds = cls_Connection.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    NextNo = Convert.ToInt32(ds.Tables[0].Rows[0]["JV_NO"]);
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

        public bool SaveJournalVoucher()
        {
            try
            {
                String query = @"INSERT INTO TBLGL_JOURNALVOUCHER 
                                 VALUES ('" + No + "','" + CategoryNo + "','" + JVDate + "','" + Description + "','" + Dr + "','" + Cr + "','" + CreateUser + "','" + CreateDate + "','" + status + "');";
                cls_Connection.setData(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
