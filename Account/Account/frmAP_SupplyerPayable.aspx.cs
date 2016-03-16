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
        DataTable dt = new DataTable();

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtPayableNo, txtSupplier, txtAmount, txtRemark);
            cls_CommonFunctions.SetTextBoxToZero(txtAmount);
            LoadBranch();
            txtDate.Text = "dd/mm/yyyy";
            FormatTable();
        }

        private void FormatTable()
        {
            DataTable dtS = new DataTable();
            DataColumn pDate = new DataColumn("Date", Type.GetType("System.String"));
            DataColumn pInvoiceNo = new DataColumn("Invoice No", Type.GetType("System.String"));
            DataColumn pAmount = new DataColumn("Total Amount", Type.GetType("System.String"));
            DataColumn pRemark = new DataColumn("Remark", Type.GetType("System.String"));

            dtS.Columns.Add(pDate);
            dtS.Columns.Add(pInvoiceNo);
            dtS.Columns.Add(pAmount);
            dtS.Columns.Add(pRemark);
            gdvInvoice.DataSource = dtS;
            gdvInvoice.DataBind();
        }

        private void Save()
        {
            if (cls_CommonFunctions.IsCreate("AP004") == true)
            {
                if (ValidateSupplier() == true)
                {
                    try
                    {
                        String item = cmbBranch.SelectedValue.Split(char.Parse("-"))[0];
                        supplierPayable.No = Convert.ToInt32(txtPayableNo.Text.Trim());
                        supplierPayable.Date = Convert.ToDateTime(txtDate.Text);
                        supplierPayable.BranchNo = Convert.ToInt32(item);
                        supplierPayable.Sup_No = Convert.ToInt32(hftxtSupplier.Value);
                        supplierPayable.Bnk_brc_No = 1;
                        supplierPayable.Bnk_No = 1;
                        supplierPayable.Chequeno = "123456";
                        supplierPayable.Accountno = "124557";
                        supplierPayable.Totalamount = Convert.ToDouble(txtAmount.Text.Trim());
                        supplierPayable.Paidamount = Convert.ToDouble(txtPaidAmount.Text.Trim());
                        supplierPayable.Balanceamount = Convert.ToDouble(txtBalanceAmount.Text.Trim());
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

                        foreach (GridViewRow row in gdvInvoice.Rows)
                        {
                            DataRow dr;
                            dr = dt.NewRow();

                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                dr[i] = row.Cells[i].Text;
                            }
                            dt.Rows.Add(dr);
                        }
                        
                        supplierPayable.dtSupplierPayable = dt;

                        if (supplierPayable.Save() == true)
                        {
                            lblMsg.InnerHtml = "Transaction successfull...";
                            lblMsg.Attributes.Add("class", "alert alert-success");
                            lblMsg.Visible = true;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            Reset();
                        }
                        else
                        {
                            lblMsg.InnerHtml = "Transaction fail...";
                            lblMsg.Attributes.Add("class", "alert alert-danger");
                            lblMsg.Visible = true;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                        }
                    }
                    catch (Exception)
                    {
                        lblMsg.InnerHtml = "Transaction fail...";
                        lblMsg.Attributes.Add("class", "alert alert-danger");
                        lblMsg.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
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
            cmbBranch.Items.Add("Select...");
            while (dr.Read())
            {
                cmbBranch.Items.Add(dr.GetString("BRCH_BRANCHNO") + "- " + dr.GetString("BRCH_NAME"));
            }
            cmbBranch.SelectedIndex = -1;
        }

        private void LoadBank()
        {
            cmbBank.Items.Clear();
            MySqlDataReader dr = supplierPayable.LoadBank();
            cmbBank.Items.Add("Select...");
            while (dr.Read())
            {
                cmbBank.Items.Add(dr.GetString("BNK_NO") + "- " + dr.GetString("BNK_NAME"));
            }
            cmbBank.SelectedIndex = -1;
        }

        private void LoadBankBranch(int Bank)
        {
            cmbBankBranch.Items.Clear();
            MySqlDataReader dr = supplierPayable.LoadBankBranch(Bank);
            cmbBankBranch.Items.Add("Select...");
            while (dr.Read())
            {
                cmbBankBranch.Items.Add(dr.GetString("BRC_NO") + "- " + dr.GetString("BRC_BRANCHNAME"));
            }
            cmbBankBranch.SelectedIndex = -1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (cmbBranch.SelectedIndex == -1)
            {
                LoadBranch();
            }
            if (cmbBank.SelectedIndex == -1)
            {
                LoadBank();
            }
            if (txtDate.Text == "")
            {
                txtDate.Text = "dd/mm/yyyy";
            }
            if (txtAmount.Text == "")
            {
                cls_CommonFunctions.SetTextBoxToZero(txtAmount);
            }
            try
            {
                String item = cmbBranch.SelectedValue.Split(char.Parse("-"))[0];
                if (item != "Select...")
                {
                    txtPayableNo.Text = supplierPayable.GetNextNo(item);
                    txtSupplier.Focus();
                }
                else
                {
                    txtPayableNo.Text = "";
                }
            }
            catch (Exception)
            {
                cmbBranch.Focus();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String item = cmbBranch.SelectedValue.Split(char.Parse("-"))[0];
                if (item != "Select...")
                {
                    txtPayableNo.Text = supplierPayable.GetNextNo(item);
                    txtSupplier.Focus();
                }
                else
                {
                    txtPayableNo.Text = "";
                }
            }
            catch (Exception)
            {
            }
        }

        //AutoComplete Get Supplier
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

        private void viewData()
        {
            string Supplier = hftxtSupplier.Value;
            double TotalAmount = 0;

            DataColumn pDate = new DataColumn("Date", Type.GetType("System.String"));
            DataColumn pInvoiceNo = new DataColumn("Invoice No", Type.GetType("System.String"));
            DataColumn pAmount = new DataColumn("Total Amount", Type.GetType("System.String"));
            DataColumn pRemark = new DataColumn("Remark", Type.GetType("System.String"));

            dt.Columns.Add(pDate);
            dt.Columns.Add(pInvoiceNo);
            dt.Columns.Add(pAmount);
            dt.Columns.Add(pRemark);

            DataSet ds = supplierPayable.LoadSuplierInvoice(Supplier);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["Date"] = ds.Tables[0].Rows[0]["Date"].ToString();
                dr["Invoice No"] = ds.Tables[0].Rows[0]["Invoice No"].ToString();
                dr["Total Amount"] = ds.Tables[0].Rows[0]["Total Amount"].ToString();
                dr["Remark"] = ds.Tables[0].Rows[0]["Remark"].ToString();
                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TotalAmount = TotalAmount + Convert.ToDouble(dt.Rows[i]["Total Amount"]);
                }
                txtAmount.Text = TotalAmount.ToString("0.00");
            }
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            if (hftxtSupplier.Value != "")
            {
                viewData();
            }
        }

        protected void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            String item = cmbBank.SelectedValue.Split(char.Parse("-"))[0];
            if (item != "Select...")
            {
                LoadBankBranch(Convert.ToInt32(item));
            }
        }
    }
}
