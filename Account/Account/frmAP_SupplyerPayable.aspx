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
				
								<form id="edit-profile" class="form-horizontal">
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
												<select name="cmbBranch">
                                                    <option value='1'>Colombo</option>
                                                </select>
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
										
										
										<div class="control-group">											
											<label class="control-label" for="PayableNo">Payable No</label>
											<div class="controls">
												<input type="text" class="span6" name="txtPayableNo" id="txtPayableNo" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
										
										
										<div class="control-group">											
											<label class="control-label" for="Supplier">Supplier</label>
											<div class="controls">
												<input type="text" class="span6" name="txtSupplier" id="txtSupplier" value="">
											</div> <!-- /controls -->				
										</div> <!-- /control-group -->
										
										
										<div class="control-group">											
											<table class = "table-bordered th" width = "45%">
                                                <tr>
                                                    <th>Invoice No
                                                        </th>
                                                    <th>Date
                                                        </th>
                                                    <th>Total Amount
                                                        </th>     
                                                    <th>Status
                                                        </th>    
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>				
										</div> <!-- /control-group -->
										
																				
										<div class="control-group">											
											<label class="control-label" for="Amount">Amount</label>
											<div class="controls">
												<input type="text" class="span6" name="txtAmount" id="txtAmount" value="">
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
