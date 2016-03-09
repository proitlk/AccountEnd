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
//==============================================================
//By            :   Thilanka
//Date          :   09-Mar-2016
//Description   :   Master Files Bank Branch Form
//==============================================================
namespace Account.Account
{
    public partial class frmM_BankBranch : System.Web.UI.Page
    {
        private ErrorLog error = new ErrorLog();
        clsM_BankBranch clsBankBranch = new clsM_BankBranch();

        private void LoadBranch()
        {            
            cmbBank.Items.Clear();
            MySqlDataReader dr = clsBankBranch.LoadBank();
            cmbBank.Items.Add("Select...");
            while (dr.Read())
            {
                cmbBank.Items.Add(dr.GetString("BNK_NO") + "-" + dr.GetString("BNK_NAME"));
            }
        }

        private void Reset()
        {
            cls_CommonFunctions.ClearTextBox(txtBranchNo, txtBranch);
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            cmbBank.Focus();
        }

        private void Save()
        {
            if (cls_CommonFunctions.IsCreate("M002") == true)
            {
                clsBankBranch = new clsM_BankBranch();

                try
                {
                    clsBankBranch.BankNo = Convert.ToInt32(Convert.ToInt32(cmbBank.SelectedValue));
                    clsBankBranch.BranchNo = Convert.ToInt32(txtBranchNo.Text.Trim());
                    clsBankBranch.Branch = txtBranch.Text.Trim();
                    clsBankBranch.Active = 1;
                    clsBankBranch.Createuser = cls_LoginInfo.getLoginUser();
                    clsBankBranch.Createdate = System.DateTime.Now;
                    clsBankBranch.Edituser = "";
                    clsBankBranch.Editdate = null;
                    clsBankBranch.Status = 1;

                    if (clsBankBranch.Save() == true)
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

        private void Update()
        {
            if (cls_CommonFunctions.IsEdit("M002") == true)
            {
                try
                {
                    clsBankBranch.BankNo = Convert.ToInt32(Convert.ToInt32(cmbBank.SelectedValue));
                    clsBankBranch.BranchNo = Convert.ToInt32(txtBranchNo.Text.Trim());
                    clsBankBranch.Branch = txtBranch.Text.Trim();
                    clsBankBranch.Active = 1;
                    clsBankBranch.Edituser = cls_LoginInfo.getLoginUser();
                    clsBankBranch.Editdate = System.DateTime.Now;
                    clsBankBranch.Status = 1;

                    if (clsBankBranch.Update() == true)
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
            DataColumn pBranchNo = new DataColumn("Branch No", Type.GetType("System.String"));
            DataColumn pName = new DataColumn("Branch Name", Type.GetType("System.String"));

            dt.Columns.Add(pCode);
            dt.Columns.Add(pName);
            DataSet ds = clsBankBranch.GetToGrid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["Bank No"] = ds.Tables[0].Rows[0]["Bank No"].ToString();
                dr["Branch No"] = ds.Tables[0].Rows[0]["Branch No"].ToString();
                dr["Branch Name"] = ds.Tables[0].Rows[0]["Branch Name"].ToString();

                gdvBankBranch.DataSource = ds.Tables[0];
                gdvBankBranch.DataBind();
                dt = ds.Tables[0];
            }
        }

        private void LoadTexboxes(int index)
        {
            int BankNo, BranchNo;
            // Retrieve the row that contains the button
            // from the Rows collection.
            DataSet ds = clsBankBranch.GetToGrid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clsBankBranch = new clsM_BankBranch();

                BankNo = Convert.ToInt32(ds.Tables[0].Rows[index]["Bank No"]);
                BranchNo = Convert.ToInt32(ds.Tables[0].Rows[index]["Bank No"]);
                if (clsBankBranch.GetDetails(BankNo, BranchNo) == true)
                {
                    cmbBank.SelectedValue = BankNo.ToString();
                    txtBranchNo.Text = clsBankBranch.BranchNo.ToString();
                    txtBranch.Text = clsBankBranch.Branch.ToString();

                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
            }
            //  to add the item to text boxes. 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadBranch();
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            cmbBank.Focus();
            viewData();
        }

        protected void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = (cmbBank.SelectedValue.Split(char.Parse("-"))[0]);
            txtBranchNo.Text = clsBankBranch.GetNextNo(Convert.ToInt32(item));
            txtBranch.Focus();
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
            gdvBankBranch.PageIndex = e.NewPageIndex;
            this.viewData();
        }

        protected void gdvBankBranch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            { // Retrieve the row index stored in the // CommandArgument property. 
                int index = Convert.ToInt32(e.CommandArgument);
                int x = gdvBankBranch.PageIndex;
                LoadTexboxes(x * 10 + index);
            }
        }
    }
}
