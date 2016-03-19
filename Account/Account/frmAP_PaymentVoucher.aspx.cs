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
using CrystalDecisions.CrystalReports.Engine;
using System.IO.Ports;
using System.IO;
//==============================================================
//By            :   Thilanka
//Date          :   18-Mar-2016
//Description   :   Account Payable Payment Voucher Form 
//                  to get the details from Account Payable
//==============================================================

namespace Account.Account
{
    public partial class frmAP_PaymentVoucher : System.Web.UI.Page
    {
        clsAP_PaymentVoucher PaymentVoucher = new clsAP_PaymentVoucher();

        private void viewData()
        {
            DataTable dt = new DataTable();
            DataColumn pExpNo = new DataColumn("EXP_NO", Type.GetType("System.String"));
            DataColumn pInvoiceDate = new DataColumn("EXP_DATE", Type.GetType("System.String"));
            DataColumn pSupName = new DataColumn("SUP_NAME", Type.GetType("System.String"));
            DataColumn pAmount = new DataColumn("EXP_PAIDAMOUNT", Type.GetType("System.String"));

            dt.Columns.Add(pExpNo);
            dt.Columns.Add(pInvoiceDate);
            dt.Columns.Add(pSupName);
            dt.Columns.Add(pAmount);

            DataSet ds = PaymentVoucher.GetPaymentVoucherSummery();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["EXP_NO"] = ds.Tables[0].Rows[0]["EXP_NO"].ToString();
                dr["EXP_DATE"] = ds.Tables[0].Rows[0]["EXP_DATE"].ToString();
                dr["SUP_NAME"] = ds.Tables[0].Rows[0]["SUP_NAME"].ToString();
                dr["EXP_PAIDAMOUNT"] = ds.Tables[0].Rows[0]["EXP_PAIDAMOUNT"].ToString();

                gdvInvoice.DataSource = ds.Tables[0];
                gdvInvoice.DataBind();
                dt = ds.Tables[0];
            }
        }

        private void LoadVoucher(int index)
        {
            string VoucherNo;
            cls_Setup Setup = new cls_Setup();
            // Retrieve the row that contains the button
            // from the Rows collection.
            DataSet ds = PaymentVoucher.GetPaymentVoucherSummery();
            if (ds.Tables[0].Rows.Count > 0)
            {
                PaymentVoucher = new clsAP_PaymentVoucher();

                VoucherNo = ds.Tables[0].Rows[index]["EXP_NO"].ToString();
                DataSet dsVoucher = PaymentVoucher.GetPaymentVoucherDtl(VoucherNo);
                if (dsVoucher.Tables[0].Rows.Count > 0)
                {
                    ReportDocument objReport = new ReportDocument();
                    objReport = new Report.rptAP_PaymentVoucher();

                    if (Setup.GetCompany("1") == true)
                    {
                        foreach (CrystalDecisions.CrystalReports.Engine.FormulaFieldDefinition FormulaName in objReport.DataDefinition.FormulaFields)
                        {
                            switch (FormulaName.Name)
                            {
                                case "Company":
                                    FormulaName.Text = "'" + Setup.ComName + "'";
                                    break;

                                case "Address":
                                    FormulaName.Text = "'" + Setup.Address + "'";
                                    break;

                                case "Telephone":
                                    FormulaName.Text = "'" + Setup.Telephone + "'";
                                    break;

                                case "Fax":
                                    FormulaName.Text = "'" + Setup.Fax + "'";
                                    break;

                                case "EMail":
                                    FormulaName.Text = "'" + Setup.EMail + "'";
                                    break;

                                case "Web":
                                    FormulaName.Text = "'" + Setup.Web + "'";
                                    break;
                            }
                        }
                    }
                    
                    objReport.SetDataSource(dsVoucher.Tables[0]);
                    try
                    {
                        int Copies = 1;
                        objReport.PrintToPrinter(Copies, false, 1, 99999);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            viewData();
        }

        protected void gdvInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (cls_CommonFunctions.IsCreate("AP06") == true)
            {
                if (e.CommandName == "View")
                { // Retrieve the row index stored in the // CommandArgument property. 
                    int index = Convert.ToInt32(e.CommandArgument);
                    int x = gdvInvoice.PageIndex;
                    LoadVoucher(x * 10 + index);
                } 
            }
        }
    }
}
