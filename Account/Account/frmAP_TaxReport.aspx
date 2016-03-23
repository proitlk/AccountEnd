<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true"
    CodeBehind="frmAP_TaxReport.aspx.cs" Inherits="Account.Account.frmAP_TaxReport" %>

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
                                <i class="icon-user"></i>
                                <h3>
                                    Tax Report</h3>
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
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Date">
                                                    Supplier</label>
                                            </div>
                                            <div class="controls col-lg-8">
                                                <asp:TextBox ID="txtSupplier" class="form-control" runat="server" requid></asp:TextBox>
                                                <asp:HiddenField ID="hftxtSupplier" runat="server" />
                                            </div>
                                            <div class="">
                                                <asp:CheckBox ID="chbAll" runat="server" OnCheckedChanged="chbAll_CheckedChanged"
                                                    AutoPostBack="true" />
                                            </div>
                                            <!-- /controls -->
                                        </div>
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
                                    <asp:GridView ID="gdvInvoice" CssClass="table table-bordered pagi-table" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="Supplier" HeaderText="Supplier" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="InvoiceNo" HeaderText="Invoice No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="NetAmount" HeaderText="Net Amount"
                                                ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="VAT" HeaderText="VAT"
                                                ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="NBT" HeaderText="NBT" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="OtherTAX" HeaderText="Other TAX"
                                                ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="GrossAmount" HeaderText="Gross Amount"
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
