﻿
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MPCP.Default" %>

<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MPCP-SALTILLO</title>

  

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/awesome-bootstrap-checkbox/0.3.7/awesome-bootstrap-checkbox.min.css">
    <link type="text/css" rel="stylesheet" href="css/style.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>

</head>

   <body>
	   	<form runat="server">
	<div class="container">
		<div class="login-container-wrapper clearfix" style="text-align:center;">
			<ul class="switcher clearfix">
				<li class="first logo active" data-tab="login">					
						<a>Asignar</a>			
				</li>
				<li class="second logo" data-tab="sign_up">
						<a runat="server" href="loginSoporte.aspx" style="width:100%;">Cerrar</a>	
				</li>
          
			</ul>
			<img src="images/logo.png" class="img-fluid" alt="Responsive image">
			<div class="tab-content">
				<div class="tab-pane active" id="login">
			
						<div class="row" style="margin-top:5%;" >
							<div class="form-group">								
								 <asp:TextBox runat="server" type="text" name="txtUsuario" id="txtUsuarioOp" placeholder="Usuario" class="form-control" autocomplete="off" value=""/>
               
								</div>
						</div>
						
					  <div class="row">
						   <asp:Label id="lblMessage" class="alert alert-danger"  runat="server" />
							 <asp:Button id="btnEntrarOp" Text="Entrar" runat="server" OnClick="Form" class="btn btn-success btn-block" />
						</div>				
						<hr>
						<div class="text-center">
							<asp:Label id="lblMrea" runat="server" />
						
						</div>					
				</div>



			</div>
		</div>
								
    </div>

			 

	</form>

    <script type="text/javascript" src="js/funcion_login.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script> 
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
  
  
</body>



</html>
