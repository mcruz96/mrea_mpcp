<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MPCP.user.Default" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MPCP-SALTILLO</title>

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

     <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link type="text/css" rel="stylesheet" href="../css/materialize.min.css"  media="screen,projection"/>   
    <link type="text/css" rel="stylesheet" href="../css/style_user.css"/>
    <script type="text/javascript" src="../js/funciones.js"></script>

</head>
<body>

    

  <nav id="navMenu">
        <div class="row">

            <div class="col s4"><span data-target="slide-out" class="sidenav-trigger"><i class="material-icons" id="iconMenu" style="cursor:default;">menu</i></span></div>           
             <div class="col s4" id="divMPCP"><span class="flow-text"><p style="margin:0; font-size:3rem; cursor:default;">MPCP</p></span></div>
            <div class="col s4"></div>
              
    </div>     
  </nav>
        

  <ul id="slide-out" class="sidenav">
   <img class="responsive-img" id="logoMrea" src="../images/logo.png">
    <li><a href="CONCERNS.aspx" runat="server"><i class="material-icons">timeline</i>Seguimiento</a></li>
    <li><a href="abrirConcern.aspx" runat="server"><i class="material-icons">add_circle_outline</i>Asignar Concern</a></li>
     <li><a href="cerrarConcern.aspx"><i class="material-icons">lock_outline</i>Cerrar Concern</a></li>      
      <li><a href="reportes.aspx" runat="server"><i class="material-icons">content_paste</i>Reportes</a></li>


      
     
             <li><a href="../?exit=1"  runat="server" id="sidenavExit"><i class="material-icons">power_settings_new</i>Cerrar Sesión</a></li>
      

  </ul>

          

   



      <div class="container">
    
          <div class="row" id="filaConcernsA">
             <div class="col s12">              
                    
                  <div class="col s3"></div>

                         <div class="col s4" id="cAbiertos">Concerns Abiertos:</div>
                 <div class="col s1" id="numAbiertos">
                  
                      <asp:Label id="abiertos" runat="server" />
                           
                 </div>
                 
                 <div class="col s4">
                      <a class="btn-floating btn-large waves-effect waves-light red" href="CONCERNS.aspx" runat="server"><i class="material-icons"  id="botonFlotante">add</i></a>
   
                 </div>

             
       

              </div>
  
        </div>

   
          <div class="row" id="divInicio">
              <div class="col s12"> 
           
                  <div class="card">
    <div class="card-image waves-effect waves-block waves-light">
      
    </div>
    <div class="card-content">

       <div class="card-title activator grey-text text-darken-4">
            <span class="card-title activator grey-text text-darken-4" id="tituloConcern">CONCERNS ABIERTOS POR ÁREAS<i class="material-icons right">more_vert</i></span>

       </div>

     
      
        <div id="piechart">

        </div>


    </div>
    <div class="card-reveal">

              <div class="card-title activator grey-text text-darken-4"> 
                   <span class="card-title grey-text text-darken-4" id="tituloConcern2">CONCERNS ASIGNADOS A DEPARTAMENTOS<i class="material-icons right">close</i></span>
      
              </div>

     
        
                        <div class="row">
                     

                                     <div class="col s12">
                      <div id="divTabla">                                                         
         

           <asp:GridView ID="gdvLista" runat="server" 
             AutoGenerateColumns="False" CellPadding="4" 
             ForeColor="#333333" GridLines="None" Width="100%" RowStyle-HorizontalAlign="Center" HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CssClass="responsive-table">
         <AlternatingRowStyle BackColor="White" />
         <Columns>             
             <asp:BoundField DataField="AREA_SOPORTE" HeaderText="AREA DE APOYO" />
             <asp:BoundField DataField="PREFAB" HeaderText="PREFAB" />
             <asp:BoundField DataField="EFFF" HeaderText="EFFF" />
             <asp:BoundField DataField="CYF" HeaderText="CYF" />
              <asp:BoundField DataField="HI" HeaderText="H&I" />
              <asp:BoundField DataField="CNC" HeaderText="CNC" />
             <asp:BoundField DataField="PWT" HeaderText="PWT" />
             <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" />
         </Columns>
               <PagerStyle HorizontalAlign="Center" />
    
         
     </asp:GridView>         
       
         </div>

			            
                    </div>
                            
                        </div>


                       
                          <asp:Label id="lblMensaje" runat="server" />


    </div>
  </div>

              </div>
               
          </div>


           <div class="col s8" name="areas">
                                
                <asp:Label class="lblDeps" id="lblPrefab" Text="" runat="server" />
                <asp:Label class="lblDeps" id="lblEfff" Text="" runat="server" />
               <asp:Label class="lblDeps" id="lblCyf" Text="" runat="server" />
                 <asp:Label class="lblDeps" id="lblHi" Text="" runat="server" />
                  <asp:Label class="lblDeps" id="lblCnc" Text="" runat="server" />
                <asp:Label class="lblDeps" id="lblPwt" Text="" runat="server" />

            </div>



      </div>





        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script type="text/javascript" src="../js/materialize.js"></script>
     <script type="text/javascript" src="../js/materialize.min.js"></script>
     <script type="text/javascript" src="../js/funciones.js"></script>
</body>
</html>
