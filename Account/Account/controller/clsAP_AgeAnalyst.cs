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
    public class clsAP_AgeAnalyst
    {
        private static MySqlConnection connect = null;
        cls_Connection conn = new cls_Connection();

        public DataSet GetAgeAnalyst(string Supplier, string Branch, DateTime fromDate, DateTime toDate)
        {
            connect = cls_Connection.DBConnect();
            connect.Open();
            string rtn = "USP_AP_AGEANALYST";
            MySqlCommand cmd = new MySqlCommand(rtn, connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Supplier", Supplier);
            cmd.Parameters.AddWithValue("@Branch", Branch);
            cmd.Parameters.AddWithValue("@FromDate", fromDate);
            cmd.Parameters.AddWithValue("@ToDate", toDate);
            DataSet ds = conn.GetDataSet(cmd);
            return ds;
        }

        public MySqlDataReader LoadBranch()
        {
            String query = "SELECT BRCH_BRANCHNO, BRCH_NAME FROM TBLU_BRANCH";
            MySqlDataReader drBranches = cls_Connection.getData(query);
            return drBranches;
        }

    }
}
