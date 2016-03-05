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
using MySql.Data.MySqlClient;
using System.Collections.Generic;

using System.Web.Services;


namespace Account.Account
{
    public partial class frmAP_SupplyerPayable : System.Web.UI.Page
    {
        private ErrorLog error = new ErrorLog();
        clsAP_SupplierPayable supplierPayable = new clsAP_SupplierPayable();

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtPayableNo, txtSupplier, txtAmount, txtRemark);
            cls_CommonFunctions.SetTextBoxToZero(txtAmount);
            txtPayableNo.Text = supplierPayable.GetNextNo();
            LoadBranch();
            txtDate.Text = "dd/mm/yyyy";
        }

        private void Save()
        {
            if (cls_CommonFunctions.IsCreate("AP004") == true)
            {
                if (ValidateSupplier() == true)
                {
                    supplierPayable.No = Convert.ToInt32(txtPayableNo.Text.Trim());
                    supplierPayable.Date = Convert.ToDateTime(txtDate.Text);
                    supplierPayable.BranchNo = Convert.ToInt32(cmbBranch.SelectedValue);
                    supplierPayable.Sup_No = Convert.ToInt32(txtSupplier.Text.Trim());
                    supplierPayable.Bnk_brc_No = 1;
                    supplierPayable.Bnk_No = 1;
                    supplierPayable.Chequeno = "123456";
                    supplierPayable.Accountno = "124557";
                    supplierPayable.Totalamount = Convert.ToInt32(txtAmount.Text.Trim());
                    supplierPayable.Paidamount = 0;
                    supplierPayable.Balanceamount = 0;
                    supplierPayable.Remark = txtRemark.Text.Trim();
                    supplierPayable.Is_fixasset = 1;
                    supplierPayable.Dpr_cat_no = 1;
                    supplierPayable.Depreciation = 0;
                    supplierPayable.Memo = "";
                    supplierPayable.Expence_type = 0;
                    supplierPayable.Isvoucherprint = 0;
                    supplierPayable.Ischequeprint = 0;
                    supplierPayable.Createuser = cls_LoginInfo.getLoginUser();
                    supplierPayable.Createdate = System.DateTime.Now;
                    supplierPayable.Status = 1;

                    if (supplierPayable.Save() == true)
                    {
                        Reset();
                    }
                }
            }
        }

        private bool ValidateSupplier()
        {
            if (txtPayableNo.Text == "")
            {
                return false;
            }
            else if (txtDate.Text == "dd/mm/yyyy")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LoadBranch()
        {
            cmbBranch.Items.Clear();
            MySqlDataReader dr = supplierPayable.LoadBranch();
            if (dr.FieldCount > 0)
            {
                cmbBranch.DataSource = dr;
                cmbBranch.DataTextField = "BRCH_NAME";
                cmbBranch.DataValueField = "BRCH_BRANCHNO";
                cmbBranch.DataBind();
            }
            cmbBranch.SelectedIndex = 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

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
    }
}
