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

namespace Account.Account
{
    public partial class frmM_Supplier : System.Web.UI.Page
    {
        private ErrorLog error = new ErrorLog();
        clsM_Supplier supplier = new clsM_Supplier();

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtSupNo, txtSupplier, txtContactPerson, txtAddress, txtTelephone, txtFax, txtEMail, txtVAT, txtNBT, txtRemark);
            cls_CommonFunctions.SetTextBoxToZero(txtVAT, txtNBT);
            txtSupNo.Text = supplier.GetNextNo();
            txtSupplier.Focus();
        }

        private void Save()
        {
            if (cls_CommonFunctions.IsCreate("AP004") == true)
            {
                if (ValidateSupplier() == true)
                {
                    supplier = new clsM_Supplier();

                    supplier.SupNo = Convert.ToInt32(supplier.GetNextNo());
                    supplier.Supplier = txtSupplier.Text.Trim();
                    supplier.ContactPerson = txtContactPerson.Text.Trim();
                    supplier.Address = txtAddress.Text.Trim();
                    supplier.Telephone = txtTelephone.Text.Trim();
                    supplier.Fax = txtFax.Text.Trim();
                    supplier.EMail = txtEMail.Text.Trim();
                    supplier.VAT = Convert.ToDouble(txtVAT.Text.Trim());
                    supplier.NBT = Convert.ToDouble(txtNBT.Text.Trim());
                    supplier.Remark = txtRemark.Text.Trim();
                    supplier.Active = 1;
                    supplier.Createuser = cls_LoginInfo.getLoginUser();
                    supplier.Createdate = System.DateTime.Now;
                    supplier.Edituser = "";
                    supplier.Editdate = null;
                    supplier.Status = 1;

                    if (supplier.Save() == true)
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
            }
        }

        private bool ValidateSupplier()
        {
            if (txtSupNo.Text == "")
            {
                return false;
            }
            else if (txtSupplier.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void viewData()
        {
            DataTable dt = new DataTable();
            DataColumn pCode = new DataColumn("Supplier No", Type.GetType("System.String"));
            DataColumn pSupplier = new DataColumn("Supplier Name", Type.GetType("System.String"));

            dt.Columns.Add(pCode);
            dt.Columns.Add(pSupplier);
            DataSet ds = supplier.GetSupplier();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["Supplier No"] = ds.Tables[0].Rows[0]["Supplier No"].ToString();
                dr["Supplier Name"] = ds.Tables[0].Rows[0]["Supplier Name"].ToString();
                
                gdvSupplier.DataSource = ds.Tables[0];
                gdvSupplier.DataBind();
                dt = ds.Tables[0];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtVAT.Text=="" || txtNBT.Text=="")
            {
                cls_CommonFunctions.SetTextBoxToZero(txtVAT, txtNBT); 
            }
            txtSupNo.Text = supplier.GetNextNo();
            txtSupplier.Focus();
            viewData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
