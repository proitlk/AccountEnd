<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true"
    CodeBehind="frmGL_GeneralLedger.aspx.cs" Inherits="Account.Account.frmGL_GeneralLedger" %>

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
                                <i class="icon-user"></i>
                                <h3>
                                    General Ledger</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <div class="col-lg-12 row" runat="server" id="lblMsg">
                                </div>
                                <div class="col-lg-6">
                                    <form id="frmGLGeneralLedger" class="form-horizontal" action="">
                                    <fieldset>
                                    <div class="form-group">
                                            <div class="controls col-lg-6">
                                                <label class="control-label" for="Description">
                                                    GL Category</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-6">
                                                <asp:DropDownList ID="cmbGeneralLedger" class="form-control" runat="server" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-6">
                                                <label class="control-label" for="Description">
                                                    Description</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-6">
                                                <asp:TextBox ID="txtDescription" class="form-control" runat="server" MaxLength="11"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-actions">
                                            <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save" Width="150px"
                                                OnClick="btnSave_Click" />
                                            <asp:Button ID="btnClear" class="btn" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                Width="150px" />
                                        </div>
                                        <!-- /form-actions -->
                                    </fieldset>
                                    </form>
                                </div>
                                <!-- /col-lg-6 -->
                                <div class="col-lg-6">
                                    <h4>
                                    </h4>
                                    <asp:GridView ID="gdvGL" CssClass="table table-bordered pagi-table" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10" OnPageIndexChanging="gdvInvoice_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="GLM_NO" HeaderText="No" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="GLM_NAME" HeaderText="Description" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="GLM_CATEGORY_VALUE" HeaderText="Category" />
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
