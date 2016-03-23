<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true"
    CodeBehind="frmGL_JournalVoucher.aspx.cs" Inherits="Account.Account.frmGL_JournalVoucher" %>

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
                                    Journal Voucher</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <div class="col-lg-12 row" runat="server" id="lblMsg">
                                </div>
                                <div class="col-lg-12">
                                    <form id="frmGLJernalVoucher" class="form-horizontal" action="">
                                    <fieldset>
                                        <div class="form-group">
                                            <div class="controls col-lg-1">
                                                <label class="control-label" for="Date">
                                                    Date</label>
                                            </div>
                                            <div class="controls col-lg-2">
                                                <asp:TextBox ID="txtDate" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="controls col-lg-6">
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-1">
                                                <label class="control-label" for="Date">
                                                    Remark</label>
                                            </div>
                                            <div class="controls col-lg-6">
                                                <asp:TextBox ID="txtRemark" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-1">
                                                <label class="control-label" for="Entry">
                                                    1st Entry</label>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-1">
                                                <label class="control-label" for="Description">
                                                    Description</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-3">
                                                <asp:DropDownList ID="cmbGeneralLedger1" class="form-control" runat="server" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-1">
                                                <label class="control-label" for="AmountDr">
                                                    Dr</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-2">
                                                <asp:TextBox ID="txtAmountDr" class="form-control" runat="server" MaxLength="11"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-1">
                                                <label class="control-label" for="Amount Cr">
                                                    Cr</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-2">
                                                <asp:TextBox ID="txtAmountCr" class="form-control" runat="server" MaxLength="11"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-1">
                                                <label class="control-label" for="Date">
                                                    2nd Entry</label>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-1">
                                                <label class="control-label" for="Description">
                                                    Description</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-3">
                                                <asp:DropDownList ID="cmbGeneralLedger2" class="form-control" runat="server" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-1">
                                                <label class="control-label" for="Amount">
                                                    Dr</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-2">
                                                <asp:TextBox ID="txtAmountDr2" class="form-control" runat="server" MaxLength="11"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-1">
                                                <label class="control-label" for="Amount">
                                                    Cr</label>
                                            </div>
                                            <!-- /controls -->
                                            <div class="controls col-lg-2">
                                                <asp:TextBox ID="txtAmountCr2" class="form-control" runat="server" MaxLength="11"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-actions">
                                            <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save" Width="150px"
                                                OnClick="btnSave_Click" />
                                            <asp:Button ID="btnClear" class="btn" runat="server" Text="Cancel" Width="150px"
                                                OnClick="btnClear_Click" />
                                        </div>
                                        <!-- /form-actions -->
                                    </fieldset>
                                    </form>
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
