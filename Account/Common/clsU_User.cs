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
    public class clsU_User
    {
        public bool IsAccess(string User, string MenuTag)
        {
            return true;
        }
                
        public bool IsCreate(string User, string MenuTag)
        {
            return true;
        }

        public bool IsEdit(string User, string MenuTag)
        {
            return true;
        }

        public bool IsDelete(string User, string MenuTag)
        {
            return true;
        }

        public bool IsProcess(string User, string MenuTag)
        {
            return true;
        }
    }
}
