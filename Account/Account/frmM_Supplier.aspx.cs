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
using System.Text.RegularExpressions;
using System.Globalization;

namespace Account.Account
{
    public partial class frmM_Supplier : System.Web.UI.Page
    {
        private ErrorLog error = new ErrorLog();
        clsM_Supplier supplier = new clsM_Supplier();
        bool invalid = false;

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtSupNo, txtSupplier, txtContactPerson, txtAddress, txtTelephone, txtFax, txtEMail, txtVAT, txtNBT, txtRemark);
            cls_CommonFunctions.SetTextBoxToZero(txtVAT, txtNBT);
            txtSupNo.Text = supplier.GetNextNo();
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            txtSupplier.Focus();
        }

        private void Save()
        {
            if (cls_CommonFunctions.IsCreate("AP004") == true)
            {
                if (ValidateSupplier() == true)
                {
                    supplier = new clsM_Supplier();

                    try
                    {
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
                            viewData();
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
                    }
                }
            }
        }

        private void Update()
        {
            if (cls_CommonFunctions.IsEdit("AP004") == true)
            {
                if (ValidateSupplier() == true)
                {
                    supplier = new clsM_Supplier();

                    try
                    {
                        supplier.SupNo = Convert.ToInt32(txtSupNo.Text.Trim());
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
                        supplier.Edituser = cls_LoginInfo.getLoginUser();
                        supplier.Editdate = System.DateTime.Now;
                        supplier.Status = 1;

                        if (supplier.Update() == true)
                        {
                            lblMsg.InnerHtml = "Transaction successfull...";
                            lblMsg.Attributes.Add("class", "alert alert-success");
                            lblMsg.Visible = true;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            Reset();
                            viewData();
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
                    }
                }
            }
        }

        private bool ValidateSupplier()
        {
            if (txtSupNo.Text == "")
            {
                txtSupNo.Focus();
                return false;
            }
            else if (txtSupplier.Text == "")
            {
                txtSupplier.Focus();
                return false;
            }
            else if (txtTelephone.Text.Length < 10 && txtTelephone.Text != "")
            {
                lblTelephone.InnerHtml = "<p style='color:red'>Please Enter Valid Phone Number</p>";
                lblTelephone.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                txtTelephone.Focus();
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

        private void LoadTexboxes(int index)
        {
            int SupNo;
            // Retrieve the row that contains the button
            // from the Rows collection.
            DataSet ds = supplier.GetSupplier();
            if (ds.Tables[0].Rows.Count > 0)
            {
                supplier = new clsM_Supplier();

                SupNo = Convert.ToInt32(ds.Tables[0].Rows[index]["Supplier No"]);
                if (supplier.GetSupplierDetails(SupNo) == true)
                {
                    txtSupNo.Text = SupNo.ToString();
                    txtSupplier.Text = supplier.Supplier.ToString();
                    txtContactPerson.Text = supplier.ContactPerson.ToString();
                    txtAddress.Text = supplier.Address.ToString();
                    txtTelephone.Text = supplier.Telephone.ToString();
                    txtFax.Text = supplier.Fax.ToString();
                    txtEMail.Text = supplier.EMail.ToString();
                    txtVAT.Text = supplier.VAT.ToString("0.00");
                    txtNBT.Text = supplier.NBT.ToString("0.00");
                    txtRemark.Text = supplier.Remark.ToString();

                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
            }
            //  to add the item to text boxes. 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtVAT.Text == "" || txtNBT.Text == "")
            {
                cls_CommonFunctions.SetTextBoxToZero(txtVAT, txtNBT);
            }
            if (txtSupNo.Text == "")
            {
                txtSupNo.Text = supplier.GetNextNo();
            }
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            txtSupplier.Focus();
            viewData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvSupplier.PageIndex = e.NewPageIndex;
            this.viewData();
        }

        protected void gdvSupplier_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            { // Retrieve the row index stored in the // CommandArgument property. 
                int index = Convert.ToInt32(e.CommandArgument);
                LoadTexboxes(index);
            }
        }
    }
}
