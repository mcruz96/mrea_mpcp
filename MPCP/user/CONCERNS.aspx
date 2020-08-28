<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CONCERNS.aspx.cs" Inherits="MPCP.user.CONCERNS" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MPCP-SALTILLO</title>

     <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link type="text/css" rel="stylesheet" href="../css/materialize.min.css"  media="screen,projection"/>   
    <link type="text/css" rel="stylesheet" href="../css/estilosTabla.css"/>


</head>
<body>


    
  <nav id="navMenu">
        <div class="row">

            <div class="col s4"><span data-target="slide-out" class="sidenav-trigger"><i class="material-icons" id="iconMenu" style="cursor:default;">menu</i></span></div>           
             <div class="col s4" id="divMPCP"><span class="flow-text"><p style="margin:0; font-size:2rem; cursor:default;">PAROS ACTIVOS</p></span></div>           
            <div class="col s4"></div>
                
    </div>     
  </nav>
        

  <ul id="slide-out" class="sidenav">
   <img class="responsive-img" id="logoMrea" src="../images/logo.png">
    <li><a href="Default.aspx" runat="server"><i class="material-icons">home</i>Inicio</a></li>
    <li><a href="abrirConcern.aspx" runat="server"><i class="material-icons">add_circle_outline</i>Asignar Concern</a></li>
     <li><a href="cerrarConcern.aspx"><i class="material-icons">lock_outline</i>Cerrar Concern</a></li>      
      <li><a href="reportes.aspx" runat="server"><i class="material-icons">content_paste</i>Reportes</a></li>

  </ul>



    <form runat="server">
        <div class="container">
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
      <div class="container">
    
          <div class="row">
               <div class="col s12">
                      <div id="divTabla">                                                         
         

           <asp:GridView ID="gdvLista" runat="server" 
             AutoGenerateColumns="False" CellPadding="4" 
             ForeColor="#333333" GridLines="None" Width="100%" RowStyle-HorizontalAlign="Center" HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="gdvLista_RowDataBound" CssClass="responsive-table">
         <AlternatingRowStyle BackColor="White" />
         <Columns>             
             <asp:BoundField DataField="NOMBRE_MAQ" HeaderText="MAQUINA" />
             <asp:BoundField DataField="AREA" HeaderText="AREA" />
             <asp:BoundField DataField="UBICACION" HeaderText="UBICACION" />
             <asp:BoundField DataField="DEPARTAMENTO" HeaderText="SOPORTE" />
              <asp:BoundField DataField="INICIO" HeaderText="INICIO DE PARO" />
              <asp:BoundField DataField="TIEMPO_MUERTO" HeaderText="TIEMPO MUERTO (MINUTOS)" />
             <asp:BoundField DataField="SOPORTE" HeaderText="ATENCION" />
         </Columns>
               <PagerStyle HorizontalAlign="Center" />
         <%--<EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
         
     </asp:GridView>         
       
         </div>

			            
                    </div>
          </div>
            
  



        </div>

 
        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick">
        </asp:Timer>

        </div>
</form>
      <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script type="text/javascript" src="../js/materialize.js"></script>
     <script type="text/javascript" src="../js/materialize.min.js"></script>
     <script type="text/javascript" src="../js/funciones.js"></script>

   </body>
</html>
