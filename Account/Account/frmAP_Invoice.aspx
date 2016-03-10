<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true"
    CodeBehind="frmAP_Invoice.aspx.cs" Inherits="Account.Account.frmAP_Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        //Calender - Datetimepicker
        $(function() {
            $("[id$=txtDate]").datepicker({
                dateFormat: "dd/mm/yy"
                //                showOn: 'button',
                //                buttonImageOnly: true,
                //                buttonImage: '../Images/calendar.png'
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <div class="page-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="widget ">
                            <div class="widget-header">
                                <i class="icon-columns"></i>
                                <h3>
                                    Invoice Details</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <div class="col-lg-12 row" runat="server" id="lblMsg">
                                </div>
                                <div class="col-lg-6">
                                    <form id="edit-profile" class="form-horizontal" action="">
                                    <fieldset>
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Date">
                                                    Date</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtDate" runat="server" class="form-control" MaxLength="25"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="BankNo">
                                                    Branch/ Location</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-9">
                                                <asp:DropDownList ID="cmbBank" runat="server" class="form-control" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="InvoiceNo">
                                                    Invoice No</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtInvoiceNo" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->                                        
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Supplier">
                                                    Supplier</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtSupplier" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Amount">
                                                    Amount</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtAmount" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->                                        
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Remark">
                                                    Remark</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtRemark" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group --> 
                                        
                                    </fieldset>
                                    </form>
                                </div>
                                <!-- /col-lg-6 -->
                                <div class="col-lg-6">
                                </div>
                                <!-- /col-lg-6 -->
                            </div>
                        </div>
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
