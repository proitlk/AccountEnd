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
        
        function HideLabel() {
            var seconds = 3;
            setTimeout(function() {
                var div = document.getElementById("<%=lblMsg.ClientID %>").style.display = "none";
            }, seconds * 1000);
        };

        //Validate Numeric
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        function IsNumeric(e) {
            var keyCode = e.which ? e.which : e.keyCode
            var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
            document.getElementById("error").style.display = ret ? "none" : "inline";
            return ret;
        }

        //AutoComplete
        $(function() {
            $("[id$=txtSupplier]").autocomplete({
                source: function(request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Account/frmAP_Invoice.aspx/GetSupplier") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function(data) {
                            response($.map(data.d, function(item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function(response) {
                            alert(response.responseText);
                        },
                        failure: function(response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function(e, i) {
                    $("[id$=hftxtSupplier]").val(i.item.val);
                },
                minLength: 1
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
                                                <asp:TextBox ID="txtDate" runat="server" class="form-control" MaxLength="25" required></asp:TextBox>
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
                                                <asp:DropDownList ID="cmbBranch" runat="server" class="form-control" AutoPostBack="true"
                                                    OnSelectedIndexChanged="cmbBranch_SelectedIndexChanged">
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
                                                <asp:TextBox ID="txtInvoiceNo" runat="server" class="form-control" MaxLength="11"
                                                    required></asp:TextBox>
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
                                                <asp:TextBox ID="txtSupplier" runat="server" class="form-control" required></asp:TextBox>
                                                <asp:HiddenField ID="hftxtSupplier" runat="server" />
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
                                                <asp:TextBox ID="txtAmount" runat="server" class="form-control" MaxLength="10" required
                                                    onkeypress="return IsNumeric(event);"></asp:TextBox>
                                                <span id="error" style="color: Red; display: none">Please Enter Valid Number</span>
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
                                                <asp:TextBox ID="txtRemark" runat="server" class="form-control" MaxLength="145"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-actions">
                                            <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save" Width="150px"
                                                OnClick="btnSave_Click" />
                                            <asp:Button ID="btnCancel" class="btn" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                Width="150px" />
                                        </div>
                                        <!-- /form-actions -->
                                    </fieldset>
                                    </form>
                                </div>
                                <!-- /col-lg-6 -->
                                <div class="col-lg-6">
                                </div>
                                <!-- /col-lg-6 -->
                                <div class="col-lg-12">
                                    <h4>
                                        Invoice Details</h4>
                                    <asp:GridView ID="gdvInvoice" CssClass="table table-bordered pagi-table" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Date" HeaderText="Date" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="Branch" HeaderText="Branch" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Invoice No" HeaderText="Invoice No" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="Supplier" HeaderText="Supplier" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Amount" HeaderText="Amount" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="Remark" HeaderText="Remark" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <!-- /col-lg-12 -->
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
