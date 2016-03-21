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

        public DataSet GetGeneralLedger(string Branch)
        {
            connect = cls_Connection.DBConnect();
            connect.Open();
            string rtn = "USP_GL_GENERALLEDGER_SELECT";
            MySqlCommand cmd = new MySqlCommand(rtn, connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Expens", Branch);
            DataSet ds = conn.GetDataSet(cmd);
            return ds;
        }

        public MySqlDataReader LoadCategoty()
        {
            String query = "SELECT tblfr_tbcol, DESCRIPTION FROM tblfr_tb";
            MySqlDataReader drBranches = cls_Connection.getData(query);
            return drBranches;
        }
    }
}
