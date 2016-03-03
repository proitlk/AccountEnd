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

namespace Account
{
    public class cls_Connection
    {
        private static ErrorLog error = new ErrorLog();
        private static MySqlConnection connect = null;

        private static MySqlConnection DBConnect()
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
                return con;
            }
            catch (MySqlException mye)
            {
                //error.createErrorLog(mye.Message, mye.Source, "MySQL Error");
                return null;
            }
            catch (Exception e)
            {
                //error.createErrorLog(e.Message, e.Source, "Data Connection Error");
                return null;
            }
        }
        public static void setData(String q)
        {
            MySqlCommand com;
            MySqlDataReader dr;
            connect = cls_Connection.DBConnect();
            try
            {
                connect.Open();
                com = new MySqlCommand(q);
                com.Connection = connect;
                dr = com.ExecuteReader();

                if (dr.RecordsAffected > 0)
                {
                    // MessageBox.Show("Record Successfuly Saved");
                }
                closeConnection();
            }
            catch (MySqlException mye)
            {
                //error.createErrorLog(mye.Message, mye.Source, "MySQL Error");
                closeConnection();
            }
            catch (Exception e)
            {
                //error.createErrorLog(e.Message, e.Source, "Data Sending Error");
                closeConnection();
            }
        }
        public static MySqlDataReader getData(String q)
        {
            MySqlCommand com;
            MySqlDataReader dr;
            connect = cls_Connection.DBConnect();
            try
            {
                connect.Open();
                com = new MySqlCommand(q);
                com.Connection = connect;
                dr = com.ExecuteReader();
                return dr;
            }
            catch (MySqlException mye)
            {
                //error.createErrorLog(mye.Message, mye.Source, "MySQL Error");
                closeConnection();
                return null;
            }
            catch (Exception e)
            {
                //error.createErrorLog(e.Message, e.Source, "Data Downloading Error");
                closeConnection();
                return null;
            }
        }

        public static DataSet getDataSet(String q)
        {
            MySqlCommand com;
            MySqlDataAdapter da;
            DataSet ds;
            connect = cls_Connection.DBConnect();
            try
            {
                connect.Open();
                com = new MySqlCommand(q);
                com.Connection = connect;
                da = new MySqlDataAdapter(com);
                ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (MySqlException mye)
            {
                //error.createErrorLog(mye.Message, mye.Source, "MySQL Error");
                closeConnection();
                return null;
            }
            catch (Exception e)
            {
                //error.createErrorLog(e.Message, e.Source, "Data Downloading Error");
                closeConnection();
                return null;
            }
        }

        public static void closeConnection()
        {
            if (connect.State == System.Data.ConnectionState.Open)
            {
                connect.Close();
                connect.Dispose();
            }
        }
    }
}
