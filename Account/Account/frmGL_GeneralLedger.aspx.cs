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

namespace Account.Account
{
    public partial class frmGL_GeneralLedger : System.Web.UI.Page
    {
        clsGL_GeneralLedger GeneralLedger = new clsGL_GeneralLedger();

        private void viewData()
        {
            try
            {
                DataSet ds = GeneralLedger.GetGeneralLedger();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gdvGL.DataSource = ds.Tables[0];
                    gdvGL.DataBind();
                }
            }
            catch (Exception)
            {
            }      
        }

        private void Reset()
        {
            txtDescription.Text = "";
            cmbGeneralLedger.Enabled = true;
            viewData();
        }

        private void LoadCategoty()
        {
            cmbGeneralLedger.Items.Clear();
            MySqlDataReader dr = GeneralLedger.LoadCategoty();
            cmbGeneralLedger.Items.Add("Select...");
            while (dr.Read())
            {
                cmbGeneralLedger.Items.Add(dr.GetString("GLC_NO") + "- " + dr.GetString("GLC_VALUE") + "- " + dr.GetString("GLC_DESCRIPTION"));
            }
            cmbGeneralLedger.SelectedIndex = -1;
        }

        private void Save()
        {
            if (cls_CommonFunctions.IsCreate("M001") == true)
            {
                GeneralLedger = new clsGL_GeneralLedger();

                try
                {
                    string CategoryNo = "", Category = "";
                    CategoryNo = cmbGeneralLedger.SelectedValue.Split(char.Parse("-"))[0];
                    Category = cmbGeneralLedger.SelectedValue.Split(char.Parse("-"))[1];
                    GeneralLedger.CategoryNo = Convert.ToInt32(CategoryNo);
                    GeneralLedger.Category = Category;
                    GeneralLedger.Description = txtDescription.Text;
                    GeneralLedger.CreateDate = System.DateTime.Now;
                    GeneralLedger.CreateUser = cls_LoginInfo.getLoginUser();
                    GeneralLedger.status = 1;

                    if (GeneralLedger.Save() == true)
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (cmbGeneralLedger.SelectedIndex == -1)
            {
                LoadCategoty();
            }
            viewData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void gdvInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvGL.PageIndex = e.NewPageIndex;
            this.viewData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
