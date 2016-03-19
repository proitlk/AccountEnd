<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true"
    CodeBehind="frmAP_SupplyerPayable.aspx.cs" Inherits="Account.Account.frmAP_SupplyerPayable" %>

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

        //AutoComplete
        $(function() {
            $("[id$=txtSupplier]").autocomplete({
                source: function(request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Account/frmAP_SupplyerPayable.aspx/GetSupplier") %>',
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
                                <i class="icon-money"></i>
                                <h3>
                                    Supplier Payable Details</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <div class="col-lg-12 row" runat="server" id="lblMsg">
                                </div>
                                <div class="col-lg-6">
                                    <fieldset>
                                        <form id="frmSupplierPayable" action="#">
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Date">
                                                    Date</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtDate" class="form-control" runat="server" requid></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Branch">
                                                    Branch/ Location</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:DropDownList ID="cmbBranch" class="form-control" runat="server" OnSelectedIndexChanged="cmbBranch_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="PayableNo">
                                                    Payable No</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtPayableNo" class="form-control" runat="server"></asp:TextBox></div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Supplier">
                                                    Supplier</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:HiddenField ID="hftxtSupplier" runat="server" />
                                                <asp:TextBox ID="txtSupplier" class="form-control" runat="server" AutoPostBack="true"></asp:TextBox>
                                                <asp:Button ID="btnLoad" class="btn" runat="server" Text="View" OnClick="btnLoad_Click" />
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->                                        
                                        <div class="form-group">
                                            <div class="col-lg-12">
                                                <asp:GridView ID="gdvInvoice" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False"
                                                    AllowPaging="True">
                                                    <Columns>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="Date" HeaderText="Date" />
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="Invoice No" HeaderText="Invoice No" />
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="Total Amount" HeaderText="Total Amount" />
                                                        <asp:BoundField ItemStyle-Width="200px" DataField="Remark" HeaderText="Remark" />
                                                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="10px">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="View" runat="server"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Bank">
                                                    Bank</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:DropDownList ID="cmbBank" class="form-control" runat="server"
                                                    AutoPostBack="true" onselectedindexchanged="cmbBank_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="BankBranch">
                                                    Branch</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:DropDownList ID="cmbBankBranch" class="form-control" runat="server" 
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Chequeno">
                                                    Cheque No</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtChequeno" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Accountno">
                                                    Account No</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtAccount_no" runat="server" class="form-control"></asp:TextBox>
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
                                                <asp:TextBox ID="txtAmount" runat="server" class="form-control" required></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="PaidAmount">
                                                    Paid Amount</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtPaidAmount" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="BalanceAmount">
                                                    Balance Amount</label>
                                            </div>
                                            <div class="controls col-lg-9">
                                                <asp:TextBox ID="txtBalanceAmount" runat="server" class="form-control" ></asp:TextBox>
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
                                                <asp:TextBox ID="txtRemark" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /form-group -->
                                        <div class="form-actions">
                                            <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click"
                                                Width="200px" />
                                            <asp:Button ID="btnCancel" class="btn" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                Width="200px" />
                                        </div>
                                        <!-- /form-actions -->
                                        </form>
                                    </fieldset>
                                </div>
                                <!-- /col-lg-6 -->
                                <div class="col-lg-6">
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
