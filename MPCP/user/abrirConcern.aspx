<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abrirConcern.aspx.cs" Inherits="MPCP.user.abrirConcern" %>

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
             <div class="col s4" id="divMPCP"><span class="flow-text"><p style="margin:0; font-size:2rem; cursor:default;">ASIGNAR CONCERN</p></span></div>
            <div class="col s4"></div>
               
    </div>     
  </nav>
        

  <ul id="slide-out" class="sidenav">
   <img class="responsive-img" id="logoMrea" src="../images/logo.png">    
     <li><a href="../?exit=1"  runat="server" id="sidenavExit"><i class="material-icons">power_settings_new</i>Cerrar Sesión</a></li>
      

  </ul>

   
    <form runat="server">


      <div class="container">


                

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
                                             <i class="material-icons" id="iconLoc">location_on</i>
                                         </div>
                                          <div class="col s9">
                                             <p class="textPanel">Ubicación Andon</p>
                                         </div>                                         
                                     </div>
                                         
                                     <div class="col s12" id="labelUb">
                                         <asp:Label id="lblUbicacion" runat="server" />
                                     </div>
                                     
                                     
                                         
                                        <div class="row" id="rowHr">
                                         <div class="col s3" id="divIconHor">
                                             <i class="material-icons" id="iconHor">schedule</i>
                                         </div>
                                          <div class="col s9">
                                             <p class="textPanel">Hora de Falla</p>
                                         </div>                                         
                                     </div>
                                         
                                     <div class="col s12" id="labelHor">
                                         <asp:Label id="lblHora" runat="server" />
                                     </div>



                                      <div class="row" id="rowAp">
                                         <div class="col s3" id="divIconAp">
                                             <i class="material-icons" id="iconAp">settings</i>
                                         </div>
                                          <div class="col s9">
                                             <p class="textPanel">Apoyo Requerido</p>
                                         </div>                                         
                                     </div>
                                         
                                     <div class="col s12" id="labelAp">
                                         <asp:Label id="lblApoyo" runat="server" />
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
                                            <h5>Número de máquina:</h5>
                                        </div>         
                                         
                                       <div class="col s6"> 
                                                                                
                                                 <asp:TextBox runat="server" type="text" id="NumMaquina" class="validate" autocomplete="off"/>
                                                                                     
                                                                                                                         
                                        </div>   

                                     

                                     </div>
                                         
                                     
                                       <div class="row">
                                        
                                        <div class="col s5" id="text2">
                                            <h5>Número de parte:</h5>
                                        </div>                                     

                                            <div class="col s6">                                         
                                             <asp:TextBox runat="server" type="text" id="NumParte" class="validate" autocomplete="off"/>                                          
                                        </div>  
                                     </div>


                                          <div class="row">
                                        
                                        <div class="col s5" id="text3">
                                            <h5>Cliente:</h5>
                                        </div>    
                                              
                                              <div class="col s6"> 

                                                   <asp:DropDownList ID="selectCliente" runat="server">
                                                       <asp:ListItem>CHRYSLER</asp:ListItem>
                                                       <asp:ListItem>FORD</asp:ListItem>
                                                       <asp:ListItem>GM</asp:ListItem>
                                                  
                                                 
                                    </asp:DropDownList>

                                             


                                              </div>

                                     </div>
                                                                                                                  

                                       <div class="row">
                                        
                                        <div class="col s5" id="text4">
                                            <h5>Problema</h5>
                                        </div>    
                                           
                                            <div class="col s6"> 
                                                  <select id="selectProblema" runat="server">
                                                  <option value="" disabled selected>Elige una opción</option>
                                                  <option value="PROBLEMA 1">PROBLEMA 1</option>
                                                  <option value="PROBLEMA 2">PROBLEMA 2</option>
                                                  <option value="PROBLEMA 3">PROBLEMA 3</option>
                                                </select>
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
                                 <h5><strong>¿Es un problema recurrente?</strong></h5>
                                        <div class="formulario">
                                    <div class="radio">               
				            

				                                    <input type="radio" name="recurrente" id="recSi" runat="server" >
				                                    <label for="recSi">SI</label>

		
				                                    <input type="radio" name="recurrente" id="recNo" runat="server">
				                                    <label for="recNo">NO</label>
		
                                        </div>
                                     </div>
                                </div> 
                              </div>        

                        </div>


                        <div class="col s4">
                          
                                 <div class="card">       
        <div class="card-content">
         <h5><strong>¿Se hicieron partes mal?</strong></h5>
               
                      <div class="formulario">
            <div class="radio">               
				            

				            <input type="radio" name="partes" id="partesSi" runat="server" >
				            <label for="partesSi">SI</label>

		
				            <input type="radio" name="partes" id="partesNo" runat="server">
				            <label for="partesNo">NO</label>
		
                            </div>
                         </div>
              
         
                    </div> 
                  </div>  


                        </div>




                              <div class="col s4">   
                             <div class="card">       
                                <div class="card-content">
                                 <h5><strong>¿Has notificado al supervisor?</strong></h5>
                                        <div class="formulario">
                                    <div class="radio">               
				            

				                                    <input type="radio" name="sup" id="supSi" runat="server" >
				                                    <label for="supSi">SI</label>

		
				                                    <input type="radio" name="sup" id="supNo" runat="server">
				                                    <label for="supNo">NO</label>
		
                                        </div>
                                     </div>
                                </div> 
                              </div>        

                        </div>



                            </div>

<%-- ------------------------------------------------- SEGUNDA FILA DE CARDS -----------------------------------------------------%>


                         <div class="row col s12">

                      
                             
                                 <div class="col s4">
                          
                                 <div class="card">       
        <div class="card-content">
         <h5><strong>¿Se llenó formato de scrap o retrabajo?</strong></h5>
                <div class="formulario">
            <div class="radio">               
				            

				            <input type="radio" name="scrap" id="scrapSi" runat="server" >
				            <label for="scrapSi">SI</label>

		
				            <input type="radio" name="scrap" id="scrapNo" runat="server">
				            <label for="scrapNo">NO</label>
		
                            </div>
                         </div>
                    </div> 
                  </div> 

                        </div>




                        <div class="col s4">
                          
                                 <div class="card">       
        <div class="card-content">
         <h5><strong>¿Calidad ha iniciado procedimientos de contención?</strong></h5>
                <div class="formulario">
            <div class="radio">               
				            

				            <input type="radio" name="cal" id="calSi" runat="server" >
				            <label for="calSi">SI</label>

		
				            <input type="radio" name="cal" id="calNo" runat="server">
				            <label for="calNo">NO</label>
		
                            </div>
                         </div>
                    </div> 
                  </div>  


                        </div>



                                 <div class="col s4">
                          
                         <div class="row">
                             <div class="col s3" id="divIconB">
                                 <i class="medium material-icons">arrow_forward</i>
                             </div>

                             <div class="col s9">
                                 <asp:Button id="botonGuardar" Text="ASIGNAR" runat="server" OnClick="guardarConcern" class="input-group-addon btn btn-primary" /> 
                          <asp:Label id="lblMensaje" runat="server" />
                             </div>
                         </div>
      
                         

                            </div>                           


                    
                  </div>  


                        </div>


                            </div>







               <%------------------------------------------- BOTON ASIGNAR CONCERN-----------------------------------%>



                         


                    </div>






    </form>

  

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script type="text/javascript" src="../js/materialize.js"></script>
     <script type="text/javascript" src="../js/materialize.min.js"></script>
     <script type="text/javascript" src="../js/funciones.js"></script>
</body>
</html>
