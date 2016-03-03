<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="frmAP_SupplyerPayable.aspx.cs" Inherits="Account.Account.frmAP_SupplyerPayable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="main">	
    <div class="main-inner">
        <div class="container">	
            <div class="row">	      	
                <div class="span12">    
                    <div class="widget ">
                        <div class="widget-header">
                            <i class="icon-money"></i>
                            <h3>Supplier Payable Details</h3>
                        </div> <!-- /widget-header -->
					
                        <div class="widget-content">
							<fieldset>
								<div class="control-group">											
									<label class="control-label" for="Date">Date</label>
									<div class="controls">
										<input type="date" class="span2" name="dtpDate" id="dtpDate" value="">
									</div> <!-- /controls -->				
								</div> <!-- /control-group -->
								<div class="control-group">											
									<label class="control-label" for="Branch">Branch</label>
									<div class="controls">
										<asp:DropDownList class="form-control col-md-8" ID="cmbBranch" runat="server">
                                        </asp:DropDownList>
									</div> <!-- /controls -->				
								</div> <!-- /control-group -->
								<div class="control-group">											
									<label class="control-label" for="PayableNo">Payable No</label>
									<div class="controls">
										<asp:TextBox ID="txtPayableNo" runat="server"></asp:TextBox></div> <!-- /controls -->				
								</div> <!-- /control-group -->
								<div class="control-group">											
									<label class="control-label" for="Supplier">Supplier
									<div class="controls">
										<asp:TextBox ID="txtSupplier" runat="server"></asp:TextBox></div> <!-- /controls -->				
								</div> <!-- /control-group -->										
								<div class="control-group">											
				
								    <asp:Table ID="Table1" runat="server">
								        <asp:TableRow ID="TableRow1" runat="server" TableSection="TableHeader" class = "table-bordered th">
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
				
								</div> <!-- /control-group -->												
								<div class="control-group">											
									<label class="control-label" for="Amount">Amount</label>
									<div class="controls">										
									    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>										
									</div> <!-- /controls -->				
								</div> <!-- /control-group -->
								<div class="control-group">											
									<label class="control-label" for="Remark">Remark</label>
									<div class="controls">
										<asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></div> <!-- /controls -->				
								</div> <!-- /control-group -->		
								<div class="form-actions">    
                                    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" 
                                        Width="209px" />									
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                        onclick="btnCancel_Click" Width="207px" />	
								</div> <!-- /form-actions -->
							    </label>
							</fieldset>		
                        </div> <!-- /widget-content -->						
                    </div> <!-- /widget -->	      		
                </div> <!-- /span8 -->	      	
            </div> <!-- /row -->	
        </div> <!-- /container -->	    
    </div> <!-- /main-inner -->    
</div> <!-- /main -->
    
</asp:Content>
