<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="frmM_Bank.aspx.cs" Inherits="Account.Account.frmM_Bank" %>
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
                                    Bank</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <div class="col-lg-12 row" runat="server" id="lblMsg">
                                </div>
                                <div class="col-lg-6">
                                    <form id="frmMBank" class="form-horizontal" action="">
                                    <fieldset>
                                    
                                    </fieldset>
                                    </form>
                                </div>
                                <!-- /col-lg-6 -->
                                <div class="col-lg-6">
                                    <h4>
                                        Bank Details</h4>
                                    <asp:GridView ID="gdvBank" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Bank No" HeaderText="Bank No" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="Bank Name" HeaderText="Bank Name" />
                                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="10px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="View" runat="server" CommandName="View" class="btn btn-info"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="View" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <!-- /col-lg-6 -->
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
