<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true"
    CodeBehind="frmCB_BankReconciliation.aspx.cs" Inherits="Account.Account.frmCB_BankReconciliation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        //Calender - Datetimepicker
        $(function() {
            $("[id$=txtFromDate]").datepicker({
                dateFormat: "dd/mm/yy"
            });
            $("[id$=txtToDate]").datepicker({
                dateFormat: "dd/mm/yy"
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
                                <i class="icon-user"></i>
                                <h3>
                                    Bank Reconciliation</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <div class="col-lg-12 row" runat="server" id="lblMsg">
                                    <label class="control-label" for="Date">
                                        Select Conditions..........</label>
                                </div>
                                <div class="col-lg-6">
                                    <form id="frmMBank" class="form-horizontal" action="">
                                    <fieldset>
                                        <div class="form-group">
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Date">
                                                    From Date</label>
                                            </div>
                                            <div class="controls col-lg-3">
                                                <asp:TextBox ID="txtFromDate" class="form-control" runat="server" requid></asp:TextBox>
                                            </div>
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Date">
                                                    To Date</label>
                                            </div>
                                            <div class="controls col-lg-3">
                                                <asp:TextBox ID="txtToDate" class="form-control" runat="server" requid></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Branch">
                                                    Branch/ Location</label>
                                            </div>
                                            <div class="controls col-lg-8">
                                                <asp:DropDownList ID="cmbBranch" class="form-control" runat="server" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="">
                                                <asp:CheckBox ID="chbAllBranch" runat="server" OnCheckedChanged="chbAllBranch_CheckedChanged"
                                                    AutoPostBack="true" />
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-12">
                                                <asp:Button ID="btnPreview" class="btn btn-primary" runat="server" Text="Preview"
                                                    Width="200px" OnClick="btnPreview_Click" />
                                                <asp:Button ID="btnCancel" class="btn" runat="server" Text="Cancel" Width="200px"
                                                    OnClick="btnCancel_Click" />
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                    </fieldset>
                                    </form>
                                </div>
                                <!-- /col-lg-6 -->
                                <div class="col-lg-12">
                                    <h4>
                                    </h4>
                                    <asp:GridView ID="gdvInvoice" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10" 
                                        onpageindexchanging="gdvInvoice_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ContractCode" HeaderText="Contract Code" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CustomerName" HeaderText="Customer Name" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="chequ_no" HeaderText="Cheque No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="chequ_amount" HeaderText="Cheque Amount"
                                                ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LoanGrantDate" HeaderText="LoanGrant Date"
                                                ItemStyle-HorizontalAlign="Right" />
                                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="10px">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="View" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gdvTotal" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false"
                                        ShowHeader="False" Font-Bold="True" AllowPaging="true" PageSize="10">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ContractCode" HeaderText="Contract Code" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CustomerName" HeaderText="Customer Name" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="chequ_no" HeaderText="Cheque No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="chequ_amount" HeaderText="Cheque Amount"
                                                ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LoanGrantDate" HeaderText="LoanGrant Date"
                                                ItemStyle-HorizontalAlign="Right" />
                                        </Columns>
                                    </asp:GridView>
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
