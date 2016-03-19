<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="frmAP_PaymentVoucher.aspx.cs" Inherits="Account.Account.frmAP_PaymentVoucher" %>
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
                                <i class="icon-user"></i>
                                <h3>
                                    Payment Voucher</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <div class="col-lg-12 row" runat="server" id="lblMsg">
                                    <label class="control-label" for="Date">
                                        </label>
                                </div>
                                <div class="col-lg-6">
                                    <form id="frmMBank" class="form-horizontal" action="">
                                    <fieldset>
                                        
                                    </fieldset>
                                    </form>
                                </div>
                                <!-- /col-lg-6 -->
                                <div class="col-lg-12">
                                    <h4>
                                    </h4>
                                    <asp:GridView ID="gdvInvoice" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10" onrowcommand="gdvInvoice_RowCommand">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="EXP_NO" HeaderText="Voucher No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="EXP_DATE" HeaderText="Date" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="SUP_NAME" HeaderText="Supplier Name" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="EXP_PAIDAMOUNT" HeaderText="Amount" ItemStyle-HorizontalAlign="Right" />
                                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="10px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="View" runat="server" CommandName="View" class="btn btn-info"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="View" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
