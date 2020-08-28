<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="MPCP_USERS.user.reportes" %>

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
             <div class="col s4" id="divMPCP"><span class="flow-text"><p style="margin:0; font-size:2rem; cursor:default;">REPORTES</p></span></div>
            <div class="col s4"></div>          
    </div>     
  </nav>
        

  <ul id="slide-out" class="sidenav">
   <img class="responsive-img" id="logoMrea" src="../images/logo.png">
    <li><a href="Default.aspx" runat="server"><i class="material-icons">home</i>Inicio</a></li>
    <li><a href="CONCERNS.aspx" runat="server"><i class="material-icons">timeline</i>Seguimiento</a></li>
 <li><a href="../?exit=1"  runat="server" id="sidenavExit"><i class="material-icons">power_settings_new</i>Cerrar Sesión</a></li>

  </ul>

   
    <form runat="server">

      <div class="container">
    
          <div class="row">
               <div class="col s12">
                     <div class="formulario">
			            <div class="radio">
                
				            <h2><strong id="status">Estatus de concern</strong></h2>

				            <input type="radio" name="chbx" id="abiertos" runat="server" >
				            <label for="abiertos">Abiertos</label>

		
				            <input type="radio" name="chbx" id="cerrados" runat="server">
				            <label for="cerrados">Cerrados</label>


                            <input type="radio" name="chbx" id="todo" runat="server">
				            <label for="todo">Todo</label>
		
                         </div>

                     </div>
                    </div>
          </div>
            
  
          <div class="row">
                  <div class="col s12" id="filaFechaR"> 
                      <div class="col s2"></div>
                      <div class="col s8">
                              <div class="row"> 
                                  <p id="lblFecha"><strong>Fecha (Opcional)</strong></p>
                            <div class="input-field col s5">
                              <i class="material-icons prefix">event</i>
                               <asp:TextBox runat="server" type="text" id="txtFechaInicialR" class="datepicker" autocomplete="off"/>
                              <label for="txtFechaInicialR">Fecha Inicial</label>
                            </div>                           
                            
                                  <div class="col s2" id="flecha">                                      
                                       <i class="material-icons prefix" id="flechaF">arrow_forward</i>
                                  </div>

                            <div class="input-field col s5">
                              <i class="material-icons prefix">event</i>
                               <asp:TextBox runat="server" type="text" id="txtFechaFinalR" class="datepicker" autocomplete="off"/>
                              <label for="txtFechaFinalR">Fecha final</label>
                            </div> 

                         </div>
                      </div>
                      <div class="col s2"></div>

                  </div>            
          </div>




            <div class="row">
                  <div class="col s12" id="filaBotonR"> 
                      <div class="col s2"></div>
                      <div class="col s8" id="divDescargar">
                           <asp:Button id="btnDescargar" Text="DESCARGAR" runat="server" class="btn btn-success btn-block" OnClick="bajaReporte" />
                      </div>
                      <div class="col s2"></div>

                  </div>
            
          </div>




          <div id="divTabla2">                                                         
         

           <asp:GridView ID="gdvLista" runat="server" 
             AutoGenerateColumns="False" CellPadding="4" 
             ForeColor="#333333" GridLines="None" Width="882px" RowStyle-HorizontalAlign="Center" HorizontalAlign="Center">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="FECHA_FALLA" HeaderText="FECHA" />
             <asp:BoundField DataField="NUM_CONCERN" HeaderText="N CONCERN" />
             <asp:BoundField DataField="ID" HeaderText="PROBLEMA ID" />
              <asp:BoundField DataField="NOMBRE_OPERADOR" HeaderText="NOMBRE DEL OPERADOR" />
              <asp:BoundField DataField="AREA_SOPORTE" HeaderText="APOYO REQUERIDO" />
              <asp:BoundField DataField="HORA_FALLA" HeaderText="HORA FALLA" />
              <asp:BoundField DataField="DEPARTAMENTO" HeaderText="DEPTO/AREA" />
              <asp:BoundField DataField="NUM_PARTE" HeaderText="N DE PARTE/CLIENTE" />
               <asp:BoundField DataField="LINEA" HeaderText="LINEA" />
              <asp:BoundField DataField="NUMERO_MAQ" HeaderText="N DE MAQUINA" />
              <asp:BoundField DataField="COORDINADOR" HeaderText="COORDINADOR/SUPERVISOR" />
              <asp:BoundField DataField="PROBLEMA" HeaderText="PROBLEMA" />

           
         </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
         
     </asp:GridView>         

       
         </div>






              <div id="divTabla3">                                                         
         

           <asp:GridView ID="gdvLista2" runat="server" 
             AutoGenerateColumns="False" CellPadding="4" 
             ForeColor="#333333" GridLines="None" Width="882px" RowStyle-HorizontalAlign="Center" HorizontalAlign="Center">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="HORA_ATENCION" HeaderText="HORA DE ATENCION" />
             <asp:BoundField DataField="RESPONSABLE" HeaderText="RESPONSABLE" />
             <asp:BoundField DataField="FECHA_CIERRE" HeaderText="FECHA DE CIERRE" />
              <asp:BoundField DataField="HORA_CIERRE" HeaderText="HORA DE CIERRE" />
                <asp:BoundField DataField="TIEMPO_ATENCION" HeaderText="TIEMPO DE ATENCION" />  
              <asp:BoundField DataField="CAUSA_RAIZ" HeaderText="CAUSA RAIZ" />
              <asp:BoundField DataField="ACCIONES" HeaderText="ACCIONES" />
              <asp:BoundField DataField="TIEMPO_MUERTO" HeaderText="TIEMPO MUERTO (MINUTOS)" />
              <asp:BoundField DataField="COMENT" HeaderText="COMENTARIOS" />               
              <asp:BoundField DataField="CIERRE_MPCP" HeaderText="CIERRE_MPCP" />
         
           
         </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
         
     </asp:GridView>          

       
         </div>





               <div id="divTabla4">                                                         
         

           <asp:GridView ID="gdvLista3" runat="server" 
             AutoGenerateColumns="False" CellPadding="4" 
             ForeColor="#333333" GridLines="None" Width="882px" RowStyle-HorizontalAlign="Center" HorizontalAlign="Center">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
            <asp:BoundField DataField="FECHA_FALLA" HeaderText="FECHA" />
             <asp:BoundField DataField="NUM_CONCERN" HeaderText="N CONCERN" />
             <asp:BoundField DataField="ID" HeaderText="PROBLEMA ID" />
              <asp:BoundField DataField="NOMBRE_OPERADOR" HeaderText="NOMBRE DEL OPERADOR" />
              <asp:BoundField DataField="AREA_SOPORTE" HeaderText="APOYO REQUERIDO" />
              <asp:BoundField DataField="HORA_FALLA" HeaderText="HORA FALLA" />
              <asp:BoundField DataField="DEPARTAMENTO" HeaderText="DEPTO/AREA" />
              <asp:BoundField DataField="NUM_PARTE" HeaderText="N DE PARTE/CLIENTE" />
               <asp:BoundField DataField="LINEA" HeaderText="LINEA" />
              <asp:BoundField DataField="NUMERO_MAQ" HeaderText="N DE MAQUINA" />
              <asp:BoundField DataField="COORDINADOR" HeaderText="COORDINADOR/SUPERVISOR" />
              <asp:BoundField DataField="PROBLEMA" HeaderText="PROBLEMA" />
            <asp:BoundField DataField="HORA_ATENCION" HeaderText="HORA DE ATENCION" />
             <asp:BoundField DataField="RESPONSABLE" HeaderText="RESPONSABLE" />
             <asp:BoundField DataField="FECHA_CIERRE" HeaderText="FECHA DE CIERRE" />
              <asp:BoundField DataField="HORA_CIERRE" HeaderText="HORA DE CIERRE" />
                <asp:BoundField DataField="TIEMPO_ATENCION" HeaderText="TIEMPO DE ATENCION" />  
              <asp:BoundField DataField="CAUSA_RAIZ" HeaderText="CAUSA RAIZ" />
              <asp:BoundField DataField="ACCIONES" HeaderText="ACCIONES" />
              <asp:BoundField DataField="TIEMPO_MUERTO" HeaderText="TIEMPO MUERTO (MINUTOS)" />
              <asp:BoundField DataField="COMENT" HeaderText="COMENTARIOS" />               
              <asp:BoundField DataField="CIERRE_MPCP" HeaderText="CIERRE_MPCP" />      

         </Columns>

         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
         
     </asp:GridView>          

       
         </div>


        </div>


</form>
   <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script type="text/javascript" src="../js/materialize.js"></script>
     <script type="text/javascript" src="../js/materialize.min.js"></script>
     <script type="text/javascript" src="../js/funciones.js"></script>
</body>
</html>
