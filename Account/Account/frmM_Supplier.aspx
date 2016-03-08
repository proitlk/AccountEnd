<%@ Page Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="frmM_Supplier.aspx.cs" Inherits="Account.Account.frmM_Supplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
        function HideLabel() {
            var seconds = 5;
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
	      				    <h3>Supplier Master</h3>
	  				    </div> <!-- /widget-header -->
					    <div  class="widget-content">
					    <div class="col-lg-12 row" runat="server" ID="lblMsg"></div>
				            <div class="col-lg-6">   
                                <form id="frmMSupplier" class="form-horizontal" action = "">
							        <fieldset>									
							            <div class="form-group">											
								            <label class="control-label" for="SupplierNo">Supplier No</label>
								            <div class="controls">										    
								                <asp:TextBox ID="txtSupNo" class="form-control" runat="server" required></asp:TextBox>										    
								            </div> <!-- /controls -->				
							            </div> <!-- /form-group -->
								        <div class="form-group">											
									        <label class="control-label" for="SupplierName">Supplier Name</label>
									        <div class="controls">
										        <asp:TextBox ID="txtSupplier" class="form-control" runat="server" required></asp:TextBox>
									        </div> <!-- /controls -->				
								        </div> <!-- /form-group -->
								        <div class="form-group">											
									        <label class="control-label" for="ContactPerson">Contact Person</label>
									        <div class="controls">
										        <asp:TextBox ID="txtContactPerson" class="form-control" runat="server"></asp:TextBox>
									        </div> <!-- /controls -->				
								        </div> <!-- /form-group -->
								        <div class="form-group">											
									        <label class="control-label" for="Address">Address</label>
									        <div class="controls">
										        <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
									        </div> <!-- /controls -->				
								        </div> <!-- /form-group -->
								        <div class="form-group">											
									        <label class="control-label" for="Telephone">Telephone</label>
									        <div class="controls">
										        <asp:TextBox ID="txtTelephone" class="form-control" runat="server"></asp:TextBox>
									        </div> <!-- /controls -->				
								        </div> <!-- /form-group -->
								        <div class="form-group">											
									        <label class="control-label" for="Fax">Fax</label>
									        <div class="controls">
										        <asp:TextBox ID="txtFax" class="form-control" runat="server"></asp:TextBox>
									        </div> <!-- /controls -->				
								        </div> <!-- /form-group -->	
								        <div class="form-group">											
									        <label class="control-label" for="EMail">E-Mail</label>
									        <div class="controls">
										        <asp:TextBox ID="txtEMail" class="form-control" runat="server"></asp:TextBox>
									        </div> <!-- /controls -->				
								        </div> <!-- /form-group -->	
								        <div class="form-group">											
									        <label class="control-label" for="VAT">VAT</label>
									        <div class="controls">
										        <asp:TextBox ID="txtVAT" class="form-control" runat="server" required></asp:TextBox>
									        </div> <!-- /controls -->				
								        </div> <!-- /form-group -->
								        <div class="form-group">											
									        <label class="control-label" for="NBT">NBT</label>
									        <div class="controls">
										        <asp:TextBox ID="txtNBT" class="form-control" runat="server" required></asp:TextBox>
									        </div> <!-- /controls -->				
								        </div> <!-- /form-group -->	
								        <div class="form-group">											
									        <label class="control-label" for="Remark">Remark</label>
									        <div class="controls">
										        <asp:TextBox ID="txtRemark" class="form-control" runat="server"></asp:TextBox>
									        </div> <!-- /controls -->				
								        </div> <!-- /form-group -->	
								        <div class="form-actions">    
                                            <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save" 
                                                Width="150px" onclick="btnSave_Click" />									
                                            <asp:Button ID="btnCancel" class="btn" runat="server" Text="Cancel" 
                                                onclick="btnCancel_Click" Width="150px" />	
							            </div> <!-- /form-actions -->
							        </fieldset>
						        </form>
						    </div> <!-- /span7 -->	
						
						    <div class="col-lg-6"> 
						        <h4>Supplier Details</h4>
                                <asp:GridView ID="gdvSupplier" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="20">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="100px" DataField="Supplier No" HeaderText="Supplier No" />
                                        <asp:BoundField ItemStyle-Width="300px" DataField="Supplier Name" HeaderText="Supplier Name" />               
                                    </Columns>
                                </asp:GridView>    								
						    </div> <!-- /form-control col-md-3 -->			
                        </div> <!-- /widget-content -->						
                    </div> <!-- /widget -->	      		
                </div> <!-- /span12 -->	      	
            </div> <!-- /row -->	
        </div> <!-- /container -->	    
    </div> <!-- /main-inner -->    
</div> <!-- /main -->    
</asp:Content>
