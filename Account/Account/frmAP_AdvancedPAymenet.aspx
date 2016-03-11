<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true"
    CodeBehind="frmAP_AdvancedPAymenet.aspx.cs" Inherits="Account.Account.frmAP_AdvancedPAymenet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <div class="page-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="widget ">
                            <div class="widget-header">
                                <i class="icon-inbox"></i>
                                <h3>
                                    Advanced Payment Details</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <div class="col-lg-12 row" runat="server" id="lblMsg">
                                </div>
                                <div class="col-lg-6">
                                    <form id="frmAPAdvancedPayment" class="form-horizontal" action = "">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label" for="Date">
                                                Date</label>
                                            <div class="controls">
                                                <input type="date" class="span2" name="dtpDate" id="dtpDate" value="">
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="AdvancePaymentNo">
                                                Advance Payment No</label>
                                            <div class="controls">
                                                <input type="text" class="span6" name="txtAdvancePaymentNo" id="txtAdvancePaymentNo"
                                                    value="">
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="Supplier">
                                                Supplier</label>
                                            <div class="controls">
                                                <input type="text" class="span6" name="txtSupplier" id="txtSupplier" value="">
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="InvoiceNo">
                                                Invoice No</label>
                                            <div class="controls">
                                                <input type="text" class="span6" name="txtInvoiceNo" id="Text1" value="">
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="Amount">
                                                Amount</label>
                                            <div class="controls">
                                                <input type="text" class="span6" name="txtAmount" id="txtAmount" value="">
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="AdvancedAmount">
                                                Advanced Amount</label>
                                            <div class="controls">
                                                <input type="text" class="span6" name="txtAdvancedAmount" id="txtAdvancedAmount"
                                                    value="">
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="BalanceAmount">
                                                Balance Amount</label>
                                            <div class="controls">
                                                <input type="text" class="span6" name="txtBalanceAmount" id="txtBalanceAmount" value="">
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="Remark">
                                                Remark</label>
                                            <div class="controls">
                                                <textarea rows="3" class="span6" cols="40" name="txtRemark" maxlength="255"></textarea>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="form-actions">
                                            <button type="submit" class="btn btn-primary">
                                                Save</button>
                                            <button class="btn">
                                                Cancel</button>
                                        </div>
                                        <!-- /form-actions -->
                                    </fieldset>
                                    </form>
                                </div>
                            </div>
                            <!-- /widget-content -->
                        </div>
                        <!-- /widget -->
                    </div>
                    <!-- /col-lg-12 -->
                </div>
                <!-- /row -->
            </div>
            <!-- /container -->
        </div>
        <!-- /page-wrapper -->
    </div>
    <!-- /wrapper -->
</asp:Content>
