<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maquinas.aspx.cs" Inherits="MPCP_USERS.admin.Maquinas" %>

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

    <form runat="server">
    

  <nav id="navMenu">
        <div class="row">

            <div class="col s4"><span data-target="slide-out" class="sidenav-trigger"><i class="material-icons" id="iconMenu" style="cursor:default;">menu</i></span></div>           
             <div class="col s4" id="divMPCP"><span class="flow-text"><p style="margin:0; font-size:3rem; cursor:default;">Usuarios</p></span></div>
            <div class="col s4"></div>
              
    </div>     
  </nav>
        

  <ul id="slide-out" class="sidenav">
   <img class="responsive-img" id="logoMrea" src="../images/logo.png">
    <li><a href="Default.aspx" runat="server"><i class="material-icons">timeline</i>Areas/Clientes</a></li>       
      <li><a href="Usuarios.aspx" runat="server"><i class="material-icons">content_paste</i>Usuarios</a></li>      
     
             <li><a href="../?exit=1"  runat="server" id="sidenavExit"><i class="material-icons">power_settings_new</i>Cerrar Sesión</a></li>
      

  </ul>

          

   



      <div class="container">
  


		 <div id="divTablaUsers">

                       
    <div class="row">      
      <div class="col s3"></div>

         <div class="col s4">
              <asp:DropDownList ID="selectArea" runat="server">                                                  
             </asp:DropDownList>
         </div>

        <div class="col s2">
             <asp:Button id="botonBuscaMaquina" Text="Consultar" runat="server" OnClick="buscaMaquina" class="btn btn-success" />
        </div>


      <div class="col s3"></div>
    </div>



		<div id="divSeguridad" runat="server">
             <asp:GridView ID="TablaDatos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="NUMERO_MAQ" 
            ShowHeaderWhenEmpty="true" OnRowCommand="TablaDatos_RowCommand" OnRowEditing="TablaDatos_RowEditing"
            OnRowCancelingEdit="TablaDatos_RowCancelingEdit" OnRowUpdating="TablaDatos_RowUpdating" OnRowDeleting="TablaDatos_RowDeleting" class="striped">
          

            <%--    TEMA   --%>

        


           <Columns>

                    <asp:TemplateField HeaderText = "NÚMERO">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("NUMERO_MAQ") %>' runat="server" autocomplete="off" />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txtNumMaquina" Text='<%# Eval("NUMERO_MAQ") %>' runat="server" autocomplete="off" />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:TextBox ID="txtNumMaquina" runat="server" autocomplete="off" />
                    </FooterTemplate>
                </asp:TemplateField>

                  <asp:TemplateField HeaderText = "NOMBRE">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("NOMBRE_MAQ") %>' runat="server" autocomplete="off" />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txtNomMaquina" Text='<%# Eval("NOMBRE_MAQ") %>' runat="server" autocomplete="off" />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:TextBox ID="txtNomMaquina" runat="server" autocomplete="off"/>
                    </FooterTemplate>
                </asp:TemplateField>



                   <asp:TemplateField HeaderText = "Area">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("AREA") %>' runat="server" autocomplete="off"/>
                    </ItemTemplate>

                   <EditItemTemplate>
                        <asp:DropDownList ID="selectAreaE" runat="server">                                                  
                          </asp:DropDownList>
                    </EditItemTemplate>

                    <FooterTemplate>
                           <asp:DropDownList ID="selectAreaF" runat="server">                                                  
                           </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>

               
                  <asp:TemplateField HeaderText = "UBICACION">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("AREA") %>' runat="server" autocomplete="off" />
                    </ItemTemplate>

                       <EditItemTemplate>
                        <asp:TextBox ID="txtArea" Text='<%# Eval("AREA") %>' runat="server" autocomplete="off" />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:TextBox ID="txtArea" runat="server" autocomplete="off" />
                    </FooterTemplate>
                </asp:TemplateField>

              



                      <asp:TemplateField HeaderText = "TIPO">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("TIPO_MAQ") %>' runat="server" autocomplete="off"/>
                    </ItemTemplate>

                   <EditItemTemplate>
                        <asp:DropDownList ID="txtDep" runat="server">
                            <asp:ListItem>PWT</asp:ListItem>
                            <asp:ListItem>EFFF</asp:ListItem>                          
                           
                        </asp:DropDownList>
                    </EditItemTemplate>

                    <FooterTemplate>
                         <asp:DropDownList ID="txtDep" runat="server" >
                            <asp:ListItem>PWT</asp:ListItem>
                            <asp:ListItem>EFFF</asp:ListItem>                         
                           
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>


              

                    <asp:TemplateField>
                         <ItemTemplate>
                       <asp:ImageButton ImageUrl="../images/editar.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="30px" Height="30px"/>
                      <asp:ImageButton ImageUrl="../images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="30px" Height="30px"/>
                     
                        </ItemTemplate> 

                        <EditItemTemplate>
                             <asp:ImageButton ImageUrl="../images/guardar.png" runat="server" CommandName="Update" ToolTip="Update" Width="30px" Height="30px"/>
                              <asp:ImageButton ImageUrl="../images/cancelar.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="30px" Height="30px"/>
                         </EditItemTemplate>
                                 
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="../images/add.png" runat="server" CommandName="Addnew" ToolTip="Add New" Width="30px" Height="30px"/>
                    
                        </FooterTemplate>
                    


                    </asp:TemplateField>
                  

            </Columns>                
        </asp:GridView>
        <br />

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
