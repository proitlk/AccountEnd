﻿using System;
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
    public class clsAP_PaymentVoucher
    {
        private static MySqlConnection connect = null;
        cls_Connection conn = new cls_Connection();

        public DataSet GetPaymentVoucherSummery(string Supplier)
        {
            connect = cls_Connection.DBConnect();
            connect.Open();
            string rtn = "";
            MySqlCommand cmd = new MySqlCommand(rtn, connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Supplier", Supplier);
            DataSet ds = conn.GetDataSet(cmd);
            return ds;
        }
        
        public DataSet GetPaymentVoucherSummery()
        {
            connect = cls_Connection.DBConnect();
            connect.Open();
            string rtn = "USP_AP_PAYMENTVOUCHER_SMRY";
            MySqlCommand cmd = new MySqlCommand(rtn, connect);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = conn.GetDataSet(cmd);
            return ds;
        }
    }
}