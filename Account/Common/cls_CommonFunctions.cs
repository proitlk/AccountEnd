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

namespace Account
{
    public class cls_CommonFunctions
    {
        public static void ClearTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void SetTextBoxToZero(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.Text = "0.00";
            }
            catch (Exception ex)
            {
                
            }
        }
        public static void SetTextBoxToZeroInt(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.Text = "0";
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void LockTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.ReadOnly = true;
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void EnableTextBox(bool IsEnable, params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                {
                    TBox.Enabled = IsEnable;
                }
            }
            catch (Exception ex)
            {
                
            }
        }


        public static void UnLockTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.ReadOnly = false;
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void ClearLabel(params Label[] LabelArray)
        {
            try
            {
                foreach (Label label in LabelArray)
                    label.Text = string.Empty;
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void ZeroLabel(params Label[] LabelArray)
        {
            try
            {
                foreach (Label label in LabelArray)
                    label.Text = "0.00";
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void EnableCheckBox(bool IsEnable, params CheckBox[] CheckBoxArray)
        {
            try
            {
                foreach (CheckBox CBox in CheckBoxArray)
                {
                    CBox.Enabled = IsEnable;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void CheckBoxChked(bool IsChked, params CheckBox[] CheckBoxArray)
        {
            try
            {
                foreach (CheckBox CBox in CheckBoxArray)
                {
                    CBox.Checked = IsChked;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void EnableRadioButton(bool IsEnable, params RadioButton[] RadioButtonArray)
        {
            try
            {
                foreach (RadioButton RButton in RadioButtonArray)
                {
                    RButton.Enabled = IsEnable;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public static bool IsCreate(string MenuTag)
        {
            clsU_User cUser = new clsU_User();
            if (cUser.IsCreate(cls_LoginInfo.getLoginUser(), MenuTag) == true)
            {
                return true;
            }
            else
            {
                //MessageBox.Show("You have no permission to Create.....", Application.CompanyName + " " + Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }

        public static bool IsEdit(string MenuTag)
        {
            clsU_User cUser = new clsU_User();
            if (cUser.IsEdit(cls_LoginInfo.getLoginUser(), MenuTag) == true)
            {
                return true;
            }
            else
            {
                //MessageBox.Show("You have no permission to Modify.....", Application.CompanyName + " " + Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }

        public static bool IsDelate(string MenuTag)
        {
            clsU_User cUser = new clsU_User();
            if (cUser.IsDelete(cls_LoginInfo.getLoginUser(), MenuTag) == true)
            {
                return true;
            }
            else
            {
                //MessageBox.Show("You have no permission to Delate.....", Application.CompanyName + " " + Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }

        public static bool IsProcess(string MenuTag)
        {
            clsU_User cUser = new clsU_User();
            if (cUser.IsProcess(cls_LoginInfo.getLoginUser(), MenuTag) == true)
            {
                return true;
            }
            else
            {
                //MessageBox.Show("You have no permission to Process.....", Application.CompanyName + " " + Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }

    }
}
