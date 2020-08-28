<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cambiarPassword.aspx.cs" Inherits="MPCP.user.cambiarPassword" %>

<!DOCTYPE html>

<html">
<head>
    <title>CAMBIAR PASSWORD</title>

     <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link type="text/css" rel="stylesheet" href="../css/materialize.min.css"  media="screen,projection"/>   
     
    <link type="text/css" rel="stylesheet" href="../css/style_user.css"/>

</head>
<body>
    <form id="form1" runat="server">

        
     <nav id="navMenu">
        <div class="row">

            <div class="col s4"><span data-target="slide-out" class="sidenav-trigger"><i class="material-icons" id="iconMenu" style="cursor:default;">menu</i></span></div>           
             <div class="col s4" id="divMPCP"><span class="flow-text"><p style="margin:0; font-size:2rem; cursor:default;">CAMBIAR CONTRASEÑA</p></span></div>
            <div class="col s4"></div>
               
    </div>     
  </nav>
        

  <ul id="slide-out" class="sidenav">
   <img class="responsive-img" id="logoMrea" src="../images/logo.png">    
     <li><a href="../?exit=1"  runat="server" id="sidenavExit"><i class="material-icons">power_settings_new</i>Cerrar Sesión</a></li>
      

  </ul>


      <div class="container">

            <div class="row">
                <div class="row col s1"></div>
    <div class="col s12 m10">
      <div class="card" style="margin-top:3%;">
        <div class="card-content white-text">
                   
            <div class="row" style="margin-left:20%;">
                <div class="input-field col s8">
          <i class="material-icons prefix">keyboard</i>
          <asp:TextBox runat="server" type="password" id="txtPass" class="validate" autocomplete="off"/>
          <label for="icon_prefix">Nueva Contraseña</label>
        </div>
            </div>          

            
                                                 


            <div class="row" style="margin-left:20%;"> 
                       <div class="input-field col s8">
          <i class="material-icons prefix">keyboard</i>
            <asp:TextBox runat="server" type="password" id="txtPassRepeat" class="validate" autocomplete="off"/>
          <label for="icon_prefix">Repite Contraseña </label>
        </div>
            </div>



                   <div class="row">
                     <div class="formulario">
			            <div class="radio">
                
				            <h5><strong id="lblDep">Selecciona tu departamento</strong></h5>

				            <input type="radio" name="chbx" id="Mantenimiento" runat="server" >
				            <label for="Mantenimiento">Mantenimiento</label>

		
				            <input type="radio" name="chbx" id="Tooling" runat="server">
				            <label for="Tooling">Tooling</label>


                            <input type="radio" name="chbx" id="Materiales" runat="server">
				            <label for="Materiales">Materiales</label>


                              <input type="radio" name="chbx" id="Sistemas" runat="server">
				            <label for="Sistemas">Sistemas</label>
		
                         </div>
                     </div>
                    </div>

              <div class="row">
                     <div class="formulario">
			            <div class="radio">
                
				         

				            <input type="radio" name="chbx" id="Calidad" runat="server" >
				            <label for="Calidad">Calidad</label>

		
				            <input type="radio" name="chbx" id="Ingienería" runat="server">
				            <label for="Ingienería">Ingienería</label>


                            <input type="radio" name="chbx" id="Producción" runat="server">
				            <label for="Producción">Producción</label>

		
                         </div>
                     </div>
                    </div>




       <div class="row">
           <div class="col s3"></div>
                <div class="col s6" style="text-align:center;">
             <asp:Button id="btnCambiaPass" Text="ACEPTAR" runat="server" OnClick="cambiaPassword" class="input-group-addon btn btn-primary" /> 
             <asp:Label id="lblMensaje" runat="server" />
      </div>
       </div>
            
 



        </div>
  
      </div>
    </div>
  </div>

          </div>
    </form>


  

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script type="text/javascript" src="../js/materialize.js"></script>
     <script type="text/javascript" src="../js/materialize.min.js"></script>
     <script type="text/javascript" src="../js/funciones.js"></script>



</body>
</html>
