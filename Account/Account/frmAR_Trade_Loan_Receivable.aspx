<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="frmAR_Trade_Loan_Receivable.aspx.cs" Inherits="Account.Account.frmAR_Trade_Loan_Receivable" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
        $("[id$=txtContractCode]").autocomplete({
                source: function(request, response) {
                    $.ajax({
                    url: '<%=ResolveUrl("~/Account/frmAR_Trade_Loan_Receivable.aspx/GetSupplier") %>',
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
                                    Trade / Loan Receivable</h3>
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
                                                <label class="control-label" for="Product">
                                                    Product</label>
                                            </div>
                                            <div class="controls col-lg-8">
                                                <asp:DropDownList ID="cmbProduct" class="form-control" runat="server" 
                                                    AutoPostBack="true">
                                                    <asp:ListItem Value="1">RBF</asp:ListItem>
                                                    <asp:ListItem Value="2">PRB</asp:ListItem>
                                                    <asp:ListItem Value="3">MC</asp:ListItem>
                                                    <asp:ListItem Value="4"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="">                                                
                                                <asp:CheckBox ID="chbAllProduct" runat="server" 
                                                     AutoPostBack="true" oncheckedchanged="chbAllProduct_CheckedChanged" />
                                            </div> 
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Branch">
                                                    Branch/ Location</label>
                                            </div>
                                            <div class="controls col-lg-8">
                                                <asp:DropDownList ID="cmbBranch" class="form-control" runat="server" 
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="">                                                
                                                <asp:CheckBox ID="chbAllBranch" runat="server" 
                                                    oncheckedchanged="chbAllBranch_CheckedChanged" AutoPostBack="true" />
                                            </div> 
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-3">
                                                <label class="control-label" for="Date">
                                                    Contract Code</label>
                                            </div>
                                            <div class="controls col-lg-8">
                                                <asp:TextBox ID="txtContractCode" class="form-control" runat="server" requid></asp:TextBox>                                                
                                                <asp:HiddenField ID="hftxtContractCode" runat="server" />
                                            </div> 
                                            <div class="">                                                
                                                <asp:CheckBox ID="chbAll" runat="server" 
                                                    oncheckedchanged="chbAll_CheckedChanged" AutoPostBack="true" />
                                            </div>                                             
                                            <!-- /controls -->
                                        </div>
                                        <div class="form-group">
                                            <div class="controls col-lg-12">
                                                <asp:Button ID="btnPreview" class="btn btn-primary" runat="server" Text="Preview" 
                                                Width="200px" onclick="btnPreview_Click" />
                                                <asp:Button ID="btnCancel" class="btn" runat="server" Text="Cancel" 
                                                Width="200px" onclick="btnCancel_Click" />
                                            </div>                                            
                                            <!-- /controls -->
                                        </div>
                                    </fieldset>
                                    </form>
                                </div>
                                <!-- /col-lg-6 -->
                                <div class="col-lg-12 c-report">
                                    <h4></h4>
                                    <asp:GridView ID="gdvInvoice" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ContractCode" HeaderText="Contract Code" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CustomerName" HeaderText="Customer Name" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LoanGrantDate" HeaderText="Loan Grant Date"/>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CapitalOutstandind" HeaderText="Capital Outstandind" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="InterestOutstanding" HeaderText="Interest Outstanding" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="OverDue" HeaderText="Over Due" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TotalOutstanding" HeaderText="Total Outstanding" ItemStyle-HorizontalAlign="Right" />
                                        </Columns>
                                    </asp:GridView>
                                     <asp:GridView ID="gdvTotal" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" ShowHeader="False" Font-Bold="True"
                                        AllowPaging="true" PageSize="10">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ContractCode" HeaderText="Contract Code" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CustomerName" HeaderText="Customer Name" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Loan Grant Date" HeaderText="Loan Grant Date"/>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CapitalOutstandind" HeaderText="Capital Outstandind" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="InterestOutstanding" HeaderText="Interest Outstanding" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="OverDue" HeaderText="Over Due" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TotalOutstanding" HeaderText="Total Outstanding" ItemStyle-HorizontalAlign="Right" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Button ID="btnPrint" class="btn btn-primary" runat="server" Text="Print" 
                                                Width="100px" onclick="btnPrint_Click" />
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
