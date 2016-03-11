<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true"
    CodeBehind="frmAP_SupplyerPayable.aspx.cs" Inherits="Account.Account.frmAP_SupplyerPayable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        //Calender - Datetimepicker
        $(function() {
            $("[id$=txtDate]").datepicker({
                dateFormat: "dd/mm/yy",
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: '../Images/calendar.png'
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
                                        <div class="control-group">
                                            <label class="control-label" for="Date">
                                                Date</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="Branch">
                                                Branch</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="cmbBranch" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="PayableNo">
                                                Payable No</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtPayableNo" runat="server"></asp:TextBox></div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="Supplier">
                                                Supplier</label>
                                            <div class="controls">
                                                <asp:HiddenField ID="hftxtSupplier" runat="server" />
                                                <asp:TextBox ID="txtSupplier" class="span4" runat="server"></asp:TextBox></div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <asp:Table ID="Table1" class="table-bordered th" Width="45%" runat="server">
                                                <asp:TableRow ID="TableRow1" runat="server" TableSection="TableHeader" class="table-bordered th">
                                                    <asp:TableCell ID="TableCell1" runat="server">Invoice No</asp:TableCell>
                                                    <asp:TableCell ID="TableCell2" runat="server">Date</asp:TableCell>
                                                    <asp:TableCell ID="TableCell3" runat="server">Total Amount</asp:TableCell>
                                                    <asp:TableCell ID="TableCell4" runat="server">Status </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow ID="TableRow2" runat="server">
                                                    <asp:TableCell ID="TableCell5" runat="server"><label class="control-label" for="Supplier"> </label></asp:TableCell>
                                                    <asp:TableCell ID="TableCell6" runat="server"><label class="control-label" for="Supplier"> </label></asp:TableCell>
                                                    <asp:TableCell ID="TableCell7" runat="server"><label class="control-label" for="Supplier"> </label></asp:TableCell>
                                                    <asp:TableCell ID="TableCell8" runat="server"><label class="control-label" for="Supplier"> </label></asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="Amount">
                                                Amount</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtAmount" runat="server" CssClass="required"></asp:TextBox>
                                            </div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
                                        <div class="control-group">
                                            <label class="control-label" for="Remark">
                                                Remark</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtRemark" class="span4" runat="server"></asp:TextBox></div>
                                            <!-- /controls -->
                                        </div>
                                        <!-- /control-group -->
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
