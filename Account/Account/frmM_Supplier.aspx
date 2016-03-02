<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="frmM_Supplier.aspx.cs" Inherits="Account.Account.frmM_Supplier" %>
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
	      				<i class="icon-user"></i>
	      				<h3>Supplier Master</h3>
	  				</div> <!-- /widget-header -->
					
					<div class="widget-content"><!---->
				
								<form id="edit-profile" class="form-horizontal">
									<fieldset>									
									    <div class="control-group">											
										        <label class="control-label" for="SupplierNo">Supplier No</label>

										    <div class="controls">
											    <input type="text" class="span6" name="txtSupNo" id="txtSupNo" value="">
										    </div> <!-- /controls -->				
									    </div> <!-- /control-group -->

										<div class="control-group">											
											<label class="control-label" for="SupplierName">Supplier Name</label>
											<div class="controls">
												<input type="text" class="span6" name="txtSupplier" id="txtSupplier" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
										
										
										<div class="control-group">											
											<label class="control-label" for="ContactPerson">Contact Person</label>
											<div class="controls">
												<input type="text" class="span6" name="txtContactPerson" id="txtContactPerson" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
										
										<div class="control-group">											
											<label class="control-label" for="Address">Address</label>
											<div class="controls">
												<input type="text" class="span6" name="txtAddress" id="txtAddress" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
										
										
										<div class="control-group">											
											<label class="control-label" for="Telephone">Telephone</label>
											<div class="controls">
												<input type="text" class="span6" name="txtTelephone" id="txtTelephone" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
										
										
										<div class="control-group">											
											<label class="control-label" for="Fax">Fax</label>
											<div class="controls">
												<input type="text" class="span6" name="txtFax" id="txtFax" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->										
																			
										
										<div class="control-group">											
											<label class="control-label" for="EMail">E-Mail</label>
											<div class="controls">
												<input type="text" class="span6" name="txtEMail" id="txtEMail" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->										
																													
										
										<div class="control-group">											
											<label class="control-label" for="VAT">VAT</label>
											<div class="controls">
												<input type="text" class="span6" name="txtVAT" id="txtVAT" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->										
																													
										
										<div class="control-group">											
											<label class="control-label" for="NBT">NBT</label>
											<div class="controls">
												<input type="text" class="span6" name="txtNBT" id="txtNBT" value="">
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
