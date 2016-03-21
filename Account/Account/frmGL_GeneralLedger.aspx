<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="frmGL_GeneralLedger.aspx.cs" Inherits="Account.Account.frmGL_GeneralLedger" %>
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
                                    General Ledger</h3>
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
                                            <div class="controls col-lg-4">
                                                <label class="control-label" for="Branch">
                                                    GL Master File</label>
                                            </div>
                                            <div class="controls col-lg-7">
                                                <asp:DropDownList ID="cmbBranch" class="form-control" runat="server" 
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
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
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Edate" HeaderText="Date" />                                            
                                            <asp:BoundField ItemStyle-Width="300px" DataField="des" HeaderText="Description" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Dr" HeaderText="Amount Dr" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Cr" HeaderText="Amount Cr" ItemStyle-HorizontalAlign="Right" />
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
