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
    public class clsM_Supplier
    {
        public int SupNo;
        public string Supplier;
        public string ContactPerson;
        public string Address;
        public string Telephone;
        public string Fax;
        public string EMail;
        public double VAT;
        public double NBT;
        public string Remark;
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
                String query = @"INSERT INTO tblm_supplier(`SUP_NO`,`SUP_NAME`,`SUP_CONTACTPERSON`,`SUP_ADDRESS`,`SUP_TELEPHONE`,`SUP_FAX`,`SUP_EMAIL`,`SUP_VAT`,`SUP_NBT`,`SUP_REMARK`,`SUP_ACTIVE`,`SUP_CREATEUSER`,`SUP_CREATEDATE`,`SUP_UPDATEUSER`,`SUP_UPDATEDATE`,`SUP_STATUS`) 
                                 VALUES ('" + SupNo + "','" + Supplier + "','" + ContactPerson + "','" + Address + "','" + Telephone + "','" + Fax + "','" + EMail + "','" + VAT + "','" + NBT + "','" + Remark + "','" + Active + "','" + Createuser + "','" + Createdate + "','" + Edituser + "','" + Editdate + "','" + Status + "');";
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
            String query = "SELECT IFNULL(MAX(SUP_NO),0) AS SUP_NO FROM tblm_supplier";
            DataSet ds = cls_Connection.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                NextNo = Convert.ToInt32(ds.Tables[0].Rows[0]["SUP_NO"]);
                NextNo++;
            }
            else
            {
                NextNo = 1;
            }
            Number = NextNo.ToString();
            return Number;
        }

        public DataSet GetSupplier()
        {
            String query = "SELECT SUP_NO AS `Supplier No`, SUP_NAME AS `Supplier Name` FROM tblm_supplier;";
            DataSet ds = cls_Connection.getDataSet(query);
            return ds;
        }
    }
}
