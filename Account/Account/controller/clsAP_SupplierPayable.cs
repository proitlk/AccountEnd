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
using System.Web.Services;
using System.Collections.Generic;

namespace Account.Account
{
    public class clsAP_SupplierPayable
    {
        public int No;
        public DateTime Date;
        public int BranchNo;
        public int Sup_No;
        public int Bnk_brc_No;
        public int Bnk_No;
        public string Chequeno;
        public string Accountno;
        public double Totalamount;
        public double Paidamount;
        public double Balanceamount;
        public string Remark;
        public int Is_fixasset;
        public int Dpr_cat_no;
        public double Depreciation;
        public string Memo;
        public int Expence_type;
        public int Isvoucherprint;
        public int Ischequeprint;
        public string Createuser;
        public DateTime Createdate;
        public int Status;

        public bool Save()
        {
            try
            {
                String query = @"INSERT INTO TBLAP_EXPENCES VALUES ('" + No + "','" + Date + "','" + BranchNo + "','" + Sup_No + "','" + Bnk_brc_No + "','" + Bnk_No + "','" + Chequeno + "','" + Accountno + "','" + Totalamount + "','" + Paidamount + "','" + Balanceamount + "','" + Remark + "','" + Is_fixasset + "','" + Dpr_cat_no + "','" + Depreciation + "','" + Memo + "','" + Expence_type + "','" + Isvoucherprint + "','" + Ischequeprint + "','" + Createuser + "','" + Createdate + "','" + Status + "');";
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
            String query = "SELECT BRCH_BRANCHNO, BRCH_NAME FROM TBLU_BRANCH";
            MySqlDataReader drBranches = cls_Connection.getData(query);
            return drBranches;
        }

        public MySqlDataReader LoadBank()
        {
            String query = "SELECT BNK_NO, BNK_NAME FROM TBLM_BANK";
            MySqlDataReader drBranches = cls_Connection.getData(query);
            return drBranches;
        }

        public MySqlDataReader LoadBankBranch(int BankNo)
        {
            String query = "SELECT BRC_NO, BRC_BRANCHNAME FROM TBLM_BANK_BRANCH WHERE BRC_BANK_BNK_NO = '" + BankNo + "'";
            MySqlDataReader drBranches = cls_Connection.getData(query); 
            return drBranches;
        }

        public string GetNextNo(string Branch)
        {
            int NextNo;
            String Number;
            String query = "SELECT IFNULL(MAX(RIGHT(EXP_NO,8)),0) AS EXP_NO FROM TBLAP_EXPENCES WHERE EXP_BRANCHNO = '" + Branch + "'; ";
            DataSet ds = cls_Connection.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                NextNo = Convert.ToInt32(ds.Tables[0].Rows[0]["EXP_NO"]);
                NextNo++;
            }
            else
            {
                NextNo = 1;
            }
            Number = Branch + NextNo.ToString("000000000");
            return Number;
        }

        public DataSet LoadSuplierInvoice(string Supplier)
        {
            String query = "SELECT INV_NO AS `Invoice No`, INV_DATE AS `Date`, INV_AMOUNT AS `Total Amount`, INV_REMARK AS `Remark`, 0 AS Status FROM TBLAP_INVOICE WHERE INV_SUP_NO = '" + Supplier + "'";
            DataSet ds = cls_Connection.getDataSet(query);
            return ds;
        } 
    }
}
