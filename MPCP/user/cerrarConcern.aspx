<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cerrarConcern.aspx.cs" Inherits="MPCP.user.cerrarConcern" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MPCP-SALTILLO</title>

     <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link type="text/css" rel="stylesheet" href="../css/materialize.min.css"  media="screen,projection"/>   
    <link type="text/css" rel="stylesheet" href="../css/style_user.css"/>


</head>
<body>


     <nav id="navMenu">
        <div class="row">

            <div class="col s4"><span data-target="slide-out" class="sidenav-trigger"><i class="material-icons" id="iconMenu" style="cursor:default;">menu</i></span></div>           
             <div class="col s4" id="divMPCP"><span class="flow-text"><p style="margin:0; font-size:2rem; cursor:default;">CERRAR CONCERN</p></span></div>
            <div class="col s4"></div>
                 
    </div>     
  </nav>
        

  <ul id="slide-out" class="sidenav">
   <img class="responsive-img" id="logoMrea" src="../images/logo.png">
    <li><a href="Default.aspx" runat="server"><i class="material-icons">home</i>Inicio</a></li>
    <li><a href="CONCERNS.aspx" runat="server"><i class="material-icons">timeline</i>Seguimiento</a></li>
     <li><a href="abrirConcern.aspx"><i class="material-icons">add_circle_outline</i>Asignar Concern</a></li>      
      <li><a href="reportes.aspx" runat="server"><i class="material-icons">content_paste</i>Reportes</a></li>

      <li><a href="../?exit=1"  runat="server" id="sidenavExit"><i class="material-icons">power_settings_new</i>Cerrar Sesión</a></li>
      

  </ul>


         <form runat="server">


      <div class="container">

      <%------------------------------------------- PRIMERA FILA-----------------------------------%>
    
    
       
            <div class="card">

             <div class="card-content">
                                   
  
                 
             <div class="row col s12" >
                   
                 <div class="col s4">

                 </div>
                 
                            <div class="input-field col s4"> 
                              <i class="material-icons prefix">search</i>    
                                
                                     <asp:DropDownList ID="selectConcern" runat="server" OnSelectedIndexChanged="selectConcern_SelectedIndexChanged" AutoPostBack="true">           
           
                                    </asp:DropDownList>
                                <label for="selectConcern">Número de Concern</label>

                            </div>   
                              
                           
      
         </div>

      

                 <div class="row col s12">
                     
                            <div class="col s5">
                                <div class="card">     
                                 <div class="card-content">                                 
                                      
                                     <div class="row" id="rowUb">
                                         <div class="col s3" id="divIconLoc">
                                             <i class="material-icons" id="iconLoc">person</i>
                                         </div>
                                          <div class="col s9">
                                             <p class="textPanel">Asignado a</p>
                                         </div>                                         
                                     </div>
                                         
                                     <div class="col s12" id="labelUb">
                                         <asp:Label id="lblResponsable" runat="server" />
                                     </div>
                                     
                                     
                                         
                                        <div class="row" id="rowHr">
                                         <div class="col s3" id="divIconHor">
                                             <i class="material-icons" id="iconHor">access_time</i>
                                         </div>
                                          <div class="col s9">
                                             <p class="textPanel">Hora de atención</p>
                                         </div>                                         
                                     </div>
                                         
                                     <div class="col s12" id="labelHor">
                                         <asp:Label id="lblHoraAtencion" runat="server" />
                                     </div>



                                      <div class="row" id="rowAp">
                                         <div class="col s3" id="divIconAp">
                                             <i class="material-icons" id="iconAp">alarm_on</i>
                                         </div>
                                          <div class="col s9">
                                             <p class="textPanel">Tiempo de atención</p>
                                         </div>                                         
                                     </div>
                                         
                                     <div class="col s12" id="labelAp">
                                         <asp:Label id="lblHoraCierre" runat="server" />
                                     </div>
                                     
                                     <div class="row"></div>



                            </div>      
                       
                             </div>
          
                         </div>
               
                        <div class="col s7">
                            <div class="card">     
                                 <div class="card-content">                                 
                                      
                                     <div class="row">
                                        
                                        <div class="col s5" id="text1">
                                            <h5>Causa raíz:</h5>
                                        </div>         
                                         
                                       <div class="col s6"> 
                                                                                
                                                 <asp:TextBox runat="server" type="text" TextMode="multiline" id="txtCausaRaiz" class="materialize-textarea" autocomplete="off"/>
                                                                                     
                                                                                                                         
                                        </div>   

                                     

                                     </div>
                                         
                                     
                                       <div class="row">
                                        
                                        <div class="col s5" id="text2">
                                            <h5 style="text-align:right">Acciones realizadas:</h5>
                                        </div>                                     

                                            <div class="col s6">                                         
                                             <asp:TextBox runat="server" type="text" TextMode="multiline" id="txtAcciones" class="materialize-textarea" autocomplete="off"/>                                          
                                        </div>  
                                     </div>


                                          <div class="row">
                                        
                                        <div class="col s5" id="text3">
                                            <h5>Comentarios:</h5>
                                        </div>    
                                              
                                      <div class="col s6">                                         
                                             <asp:TextBox runat="server" type="text" TextMode="multiline" id="txtComentarios" class="materialize-textarea" autocomplete="off"/>                                          
                                        </div>  

                                     </div>
                                                                                                                  

                                       <div class="row">
                                        
                                        <div class="col s5" id="text4">
                                           
                                        </div>    
                                           
                                            <div class="col s6"> 
                                               
                                              </div>

                                     </div>


                            </div>      
                       
                               
                          </div>
                     </div>
            
                 </div>
     
      
          <%------------------------------------------- SEGUNDA FILA-----------------------------------%>
  

          



                       <div class="card-title activator grey-text text-darken-4">
            <span class="card-title activator" id="tituloAltas">CONTINUAR<i class="material-icons right">arrow_forward</i></span>
       </div>



    </div>


                    <div class="card-reveal">

                          <div class="card-title activator grey-text text-darken-4"> 
                   <span class="card-title grey-text text-darken-4" id="tituloAltas2">VOLVER<i class="material-icons right">arrow_back</i></span>
      
                     </div>
                        
                        <div class="row col s12">

                        <div class="col s4">   
                             <div class="card">       
                                <div class="card-content">
                                 <h5><strong>¿Las acciones correctivas aseguran que el producto estará dentro de las especificaciones del cliente?</strong></h5>
                                        <div class="formulario">
                                    <div class="radio">               
				            

				                                    <input type="radio" name="especif" id="especifSi" runat="server" >
				                                    <label for="especifSi">SI</label>

		
				                                    <input type="radio" name="especif" id="especifNo" runat="server">
				                                    <label for="especifNo">NO</label>
		
                                        </div>
                                     </div>

                                        <h5><strong>De no ser así, ¿Los Gte./GUN/Superintendente de calidad han sido notificados?</strong></h5>
                                        <div class="formulario">
                                    <div class="radio">               
				            

				                                    <input type="radio" name="especifN" id="especifNSi" runat="server" >
				                                    <label for="especifNSi">SI</label>

		
				                                    <input type="radio" name="especifN" id="especifNNo" runat="server">
				                                    <label for="especifNNo">NO</label>
		
                                        </div>
                                     </div>

                                </div> 
                              </div>        

                        </div>


                        <div class="col s4">
                          
                                 <div class="card">       
        <div class="card-content">
         <h5><strong>¿Se requiere un proceso de desviación?</strong></h5>
               
                      <div class="formulario">
            <div class="radio">               
				            

				            <input type="radio" name="desv" id="desvSi" runat="server" >
				            <label for="desvSi">SI</label>

		
				            <input type="radio" name="desv" id="desvNo" runat="server">
				            <label for="desvNo">NO</label>
		
                            </div>
                         </div>
              

              <h5><strong>De ser así, ¿El gerente de calidad ha aprobado el proceso de desviación?</strong></h5>
               
                      <div class="formulario">
            <div class="radio">               
				            

				            <input type="radio" name="desvAp" id="desvApSi" runat="server" >
				            <label for="desvApSi">SI</label>

		
				            <input type="radio" name="desvAp" id="desvApNo" runat="server">
				            <label for="desvApNo">NO</label>
		
                            </div>
                         </div>



         
                    </div> 
                  </div>  


                        </div>




                              <div class="col s4">   
                             <div class="card">       
                                <div class="card-content">
                                 <h5><strong>¿Se requiere retrabajo?</strong></h5>
                                        <div class="formulario">
                                    <div class="radio">               
				            

				                                    <input type="radio" name="retrabajo" id="retrabajoSi" runat="server" >
				                                    <label for="retrabajoSi">SI</label>

		
				                                    <input type="radio" name="retrabajo" id="retrabajoNo" runat="server">
				                                    <label for="retrabajoNo">NO</label>
		
                                        </div>
                                     </div>

                                      <h5><strong>De ser así, ¿Los gerentes de calidad y producción han aprobado retrabajo?</strong></h5>
                                        <div class="formulario">
                                    <div class="radio">               
				            

				                                    <input type="radio" name="retrabajoAp" id="retrabajoApSi" runat="server" >
				                                    <label for="retrabajoApSi">SI</label>

		
				                                    <input type="radio" name="retrabajoAp" id="retrabajoApNo" runat="server">
				                                    <label for="retrabajoApNo">NO</label>
		
                                        </div>
                                     </div>
                                    <asp:Button id="botonGuardar" Text="CERRAR" runat="server" OnClick="cierraConcern" class="input-group-addon btn btn-primary" /> 
                          <asp:Label id="lblMensaje" runat="server" />
                                </div> 
                              </div>        

                        </div>



                            </div>

<%-- ------------------------------------------------- SEGUNDA FILA DE CARDS -----------------------------------------------------%>


                         <div class="row col s12">


                  </div>  


                        </div>


                            </div>





               <%------------------------------------------- QUINTA FILA-----------------------------------%>

    
       
           

</div>

    </form>



     <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script type="text/javascript" src="../js/materialize.js"></script>
     <script type="text/javascript" src="../js/materialize.min.js"></script>
     <script type="text/javascript" src="../js/funciones.js"></script>
</body>
</html>
