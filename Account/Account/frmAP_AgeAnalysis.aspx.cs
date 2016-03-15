using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Services;
//==============================================================
//By            :   Thilanka
//Date          :   14-Mar-2016
//Description   :   Account Payable Files Age Analyst Form 
//                  to get the details from Supplier Payable
//==============================================================

namespace Account.Account
{
    public partial class frmAP_AgeAnalysis : System.Web.UI.Page
    {
        clsAP_AgeAnalyst AgeAnalyst = new clsAP_AgeAnalyst();

        private void viewData()
        {
            string Supplier;
            if (chbAll.Checked == true)
            {
                Supplier = "ALL";
            }
            else
            {
                Supplier = hftxtSupplier.Value;
            }

            DataTable dt = new DataTable();
            DataColumn pName = new DataColumn("SUP_NAME", Type.GetType("System.String"));
            DataColumn pCage1 = new DataColumn("CAGE_01", Type.GetType("System.String"));
            DataColumn pCage2 = new DataColumn("CAGE_02", Type.GetType("System.String"));
            DataColumn pCage3 = new DataColumn("CAGE_03", Type.GetType("System.String"));
            DataColumn pCage4 = new DataColumn("CAGE_04", Type.GetType("System.String"));
            DataColumn pCage5 = new DataColumn("CAGE_05", Type.GetType("System.String"));
            DataColumn pCage6 = new DataColumn("CAGE_06", Type.GetType("System.String"));
            DataColumn pAmount = new DataColumn("INV_AMOUNT", Type.GetType("System.String"));

            dt.Columns.Add(pName);
            dt.Columns.Add(pCage1);
            dt.Columns.Add(pCage2);
            dt.Columns.Add(pCage3);
            dt.Columns.Add(pCage4);
            dt.Columns.Add(pCage5);
            dt.Columns.Add(pCage6);
            dt.Columns.Add(pAmount);

            DataSet ds = AgeAnalyst.GetAgeAnalyst(Supplier,Convert.ToDateTime(txtFromDate.Text),Convert.ToDateTime(txtToDate.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["SUP_NAME"] = ds.Tables[0].Rows[0]["SUP_NAME"].ToString();
                dr["CAGE_01"] = ds.Tables[0].Rows[0]["CAGE_01"].ToString();
                dr["CAGE_02"] = ds.Tables[0].Rows[0]["CAGE_02"].ToString();
                dr["CAGE_03"] = ds.Tables[0].Rows[0]["CAGE_03"].ToString();
                dr["CAGE_04"] = ds.Tables[0].Rows[0]["CAGE_04"].ToString();
                dr["CAGE_05"] = ds.Tables[0].Rows[0]["CAGE_05"].ToString();
                dr["CAGE_06"] = ds.Tables[0].Rows[0]["CAGE_06"].ToString();
                dr["INV_AMOUNT"] = ds.Tables[0].Rows[0]["INV_AMOUNT"].ToString();

                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
                dt = ds.Tables[0];
            }
        }

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtSupplier);
            chbAll.Checked = false;
            viewData();
            txtFromDate.Text = "dd/mm/yyyy";
            txtToDate.Text = "dd/mm/yyyy";

            DataTable dt = new DataTable();
            DataColumn pName = new DataColumn("SUP_NAME", Type.GetType("System.String"));
            DataColumn pCage1 = new DataColumn("CAGE_01", Type.GetType("System.String"));
            DataColumn pCage2 = new DataColumn("CAGE_02", Type.GetType("System.String"));
            DataColumn pCage3 = new DataColumn("CAGE_03", Type.GetType("System.String"));
            DataColumn pCage4 = new DataColumn("CAGE_04", Type.GetType("System.String"));
            DataColumn pCage5 = new DataColumn("CAGE_05", Type.GetType("System.String"));
            DataColumn pCage6 = new DataColumn("CAGE_06", Type.GetType("System.String"));
            DataColumn pAmount = new DataColumn("INV_AMOUNT", Type.GetType("System.String"));

            dt.Columns.Add(pName);
            dt.Columns.Add(pCage1);
            dt.Columns.Add(pCage2);
            dt.Columns.Add(pCage3);
            dt.Columns.Add(pCage4);
            dt.Columns.Add(pCage5);
            dt.Columns.Add(pCage6);
            dt.Columns.Add(pAmount);

            gdvInvoice.DataSource = dt;
            gdvInvoice.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtFromDate.Text == "")
            {
                txtFromDate.Text = "dd/mm/yyyy";
            }
            if (txtToDate.Text == "")
            {
                txtToDate.Text = "dd/mm/yyyy";
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            viewData();
        }

        //AutoComplete  - Get Supplier
        [WebMethod]
        public static string[] GetSupplier(string prefix)
        {
            List<string> Supplier = new List<string>();

            String query = "SELECT SUP_NO, SUP_NAME FROM tblm_supplier WHERE SUP_NAME LIKE '" + prefix + "%'";
            MySqlDataReader dr = cls_Connection.getData(query);
            int i = 0;
            while (dr.Read())
            {
                Supplier.Add(string.Format("{0}-{1}", dr["SUP_NAME"], dr["SUP_NO"]));
                i++;
                if (i == 10)
                {
                    break;
                }
            }
            return Supplier.ToArray();
        }

        protected void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAll.Checked == true)
            {
                txtSupplier.Text = "";
                txtSupplier.Enabled = false;
            }
            if (chbAll.Checked == false)
            {
                txtSupplier.Enabled = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
