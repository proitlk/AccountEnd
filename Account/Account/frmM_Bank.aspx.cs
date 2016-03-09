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
//==============================================================
//By            :   Thilanka
//Date          :   09-Mar-2016
//Description   :   Master Files Bank Form
//==============================================================

namespace Account.Account
{
    public partial class frmM_Bank : System.Web.UI.Page
    {
        private ErrorLog error = new ErrorLog();
        clsM_Bank clsBank = new clsM_Bank();

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtBankNo, txtBank);
            txtBankNo.Text = clsBank.GetNextNo();
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            txtBank.Focus();
        }

        private void Save()
        {
            if (cls_CommonFunctions.IsCreate("M001") == true)
            {
                clsBank = new clsM_Bank();
                if (clsBank.IsExist(txtBank.Text.Trim()) == true)
                {
                    try
                    {
                        clsBank.BankNo = Convert.ToInt32(clsBank.GetNextNo());
                        clsBank.Bank = txtBank.Text.Trim();
                        clsBank.Active = 1;
                        clsBank.Createuser = cls_LoginInfo.getLoginUser();
                        clsBank.Createdate = System.DateTime.Now;
                        clsBank.Edituser = "";
                        clsBank.Editdate = null;
                        clsBank.Status = 1;

                        if (clsBank.Save() == true)
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
                else
                {
                    lblMsg.InnerHtml = "Transaction fail..., This record is existing.";
                    lblMsg.Attributes.Add("class", "alert alert-danger");
                    lblMsg.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                }
            }
        }

        private void Update()
        {
            if (cls_CommonFunctions.IsEdit("M001") == true)
            {
                try
                {
                    clsBank.BankNo = Convert.ToInt32(txtBankNo.Text.Trim());
                    clsBank.Bank = txtBank.Text.Trim();
                    clsBank.Active = 1;
                    clsBank.Edituser = cls_LoginInfo.getLoginUser();
                    clsBank.Editdate = System.DateTime.Now;
                    clsBank.Status = 1;

                    if (clsBank.Update() == true)
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

        private void viewData()
        {
            DataTable dt = new DataTable();
            DataColumn pCode = new DataColumn("Bank No", Type.GetType("System.String"));
            DataColumn pName = new DataColumn("Bank Name", Type.GetType("System.String"));

            dt.Columns.Add(pCode);
            dt.Columns.Add(pName);
            DataSet ds = clsBank.GetToGrid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["Bank No"] = ds.Tables[0].Rows[0]["Bank No"].ToString();
                dr["Bank Name"] = ds.Tables[0].Rows[0]["Bank Name"].ToString();

                gdvBank.DataSource = ds.Tables[0];
                gdvBank.DataBind();
                dt = ds.Tables[0];
            }
        }

        private void LoadTexboxes(int index)
        {
            int No;
            // Retrieve the row that contains the button
            // from the Rows collection.
            DataSet ds = clsBank.GetToGrid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clsBank = new clsM_Bank();

                No = Convert.ToInt32(ds.Tables[0].Rows[index]["Bank No"]);
                if (clsBank.GetDetails(No) == true)
                {
                    txtBankNo.Text = No.ToString();
                    txtBank.Text = clsBank.Bank.ToString();

                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
            }
            //  to add the item to text boxes. 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtBankNo.Text == "")
            {
                txtBankNo.Text = clsBank.GetNextNo();
            }
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            txtBank.Focus();
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
            gdvBank.PageIndex = e.NewPageIndex;
            this.viewData();
        }

        protected void gdvBank_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            { // Retrieve the row index stored in the // CommandArgument property. 
                int index = Convert.ToInt32(e.CommandArgument);
                int x = gdvBank.PageIndex;
                LoadTexboxes(x * 10 + index);
            }
        }
    }
}
