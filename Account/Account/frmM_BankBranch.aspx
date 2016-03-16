<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true"
    CodeBehind="frmM_BankBranch.aspx.cs" Inherits="Account.Account.frmM_BankBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function HideLabel() {
            var seconds = 3;
            setTimeout(function() {
                var div = document.getElementById("<%=lblMsg.ClientID %>").style.display = "none";
            }, seconds * 1000);
        };
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
                                <i class="icon-sitemap"></i>
                                <h3>
                                    Bank Branch</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <div class="col-lg-12 row" runat="server" id="lblMsg">
                                </div>
                                <div class="col-lg-6">
                                    <fieldset>
                                        <form id="frmMBankBranch" class="form-horizontal" action="">
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="BankNo">
                                                    Bank</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-9">
                                                <asp:DropDownList ID="cmbBank" runat="server" class="form-control" OnSelectedIndexChanged="cmbBank_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="BranchNo">
                                                    Branch No</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtBranchNo" class="form-control" runat="server" Enabled="false"
                                                    MaxLength="11" required></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="BranchName">
                                                    Branch Name</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtBranch" class="form-control" runat="server" MaxLength="45" required></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-actions">
                                            <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save" Width="150px"
                                                OnClick="btnSave_Click" />
                                            <asp:Button ID="btnUpdate" class="btn btn-info" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                                Width="150px" />
                                            <asp:Button ID="btnCancel" class="btn" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                Width="150px" />
                                        </div>
                                        <!-- /form-actions -->
                                        </form>
                                    </fieldset>
                                </div>
                                <!-- /col-lg-6 -->
                                <div class="col-lg-6">
                                    <h4>
                                        Bank Branch Details</h4>
                                    <asp:GridView ID="gdvBankBranch" CssClass="table table-bordered pagi-table" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" OnRowCommand="gdvBankBranch_RowCommand">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Bank No" HeaderText="Bank No" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="Bank Name" HeaderText="Bank Name" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Branch No" HeaderText="Branch No" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="Branch Name" HeaderText="Branch Name" />
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
