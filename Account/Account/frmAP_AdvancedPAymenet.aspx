<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="frmAP_AdvancedPAymenet.aspx.cs" Inherits="Account.Account.frmAP_AdvancedPAymenet" %>
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
	      				<i class="icon-inbox"></i>
	      				<h3>Advanced Payment Details</h3>
	  				</div> <!-- /widget-header -->
					
					<div class="widget-content">
				
								<form id="edit-profile" class="form-horizontal">
									<fieldset>
										
										<div class="control-group">											
											<label class="control-label" for="Date">Date</label>
											<div class="controls">
												<input type="date" class="span2" name="dtpDate" id="dtpDate" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
										
										
										<div class="control-group">											
											<label class="control-label" for="AdvancePaymentNo">Advance Payment No</label>
											<div class="controls">
												<input type="text" class="span6" name="txtAdvancePaymentNo" id="txtAdvancePaymentNo" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
										
										
										<div class="control-group">											
											<label class="control-label" for="Supplier">Supplier</label>
											<div class="controls">
												<input type="text" class="span6" name="txtSupplier" id="txtSupplier" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
																				
										
										<div class="control-group">											
											<label class="control-label" for="InvoiceNo">Invoice No</label>
											<div class="controls">
												<input type="text" class="span6" name="txtInvoiceNo" id="Text1" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
										
										
										<div class="control-group">											
											<label class="control-label" for="Amount">Amount</label>
											<div class="controls">
												<input type="text" class="span6" name="txtAmount" id="txtAmount" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
												
																				
										<div class="control-group">											
											<label class="control-label" for="AdvancedAmount">Advanced Amount</label>
											<div class="controls">
												<input type="text" class="span6" name="txtAdvancedAmount" id="txtAdvancedAmount" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
																						
																				
										<div class="control-group">											
											<label class="control-label" for="BalanceAmount">Balance Amount</label>
											<div class="controls">
												<input type="text" class="span6" name="txtBalanceAmount" id="txtBalanceAmount" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
										
										
										<div class="control-group">											
											<label class="control-label" for="Remark">Remark</label>
											<div class="controls">
												<textarea rows="3" class="span6" cols="40" name="txtRemark" maxlength="255"></textarea>
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->										
										
										
										
										<div class="form-actions">
											<button type="submit" class="btn btn-primary">Save</button> 
											<button class="btn">Cancel</button>
										</div> <!-- /form-actions -->
									</fieldset>
								</form>
								</div>
								
								</div>
								
							</div>
						  
						</div>
						
					</div> <!-- /widget-content -->
						
				</div> <!-- /widget -->
	      		
		    </div> <!-- /span8 -->
	      	
	      </div> <!-- /row -->
	
	    </div> <!-- /container -->
	    
	</div> <!-- /main-inner -->
    
</div> <!-- /main -->
    
</asp:Content>
