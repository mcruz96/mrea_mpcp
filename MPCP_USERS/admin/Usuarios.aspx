<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="MPCP_USERS.admin.Usuarios" %>


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
      <li><a href="reportes.aspx" runat="server"><i class="material-icons">content_paste</i>Reportes</a></li>      
     
             <li><a href="../?exit=1"  runat="server" id="sidenavExit"><i class="material-icons">power_settings_new</i>Cerrar Sesión</a></li>
      

  </ul>

          

   



      <div class="container">
  
		 <div id="divTablaUsers">

		<div id="divSeguridad" runat="server">
             <asp:GridView ID="TablaDatos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="USR" 
            ShowHeaderWhenEmpty="true" OnRowCommand="TablaDatos_RowCommand" OnRowEditing="TablaDatos_RowEditing"
            OnRowCancelingEdit="TablaDatos_RowCancelingEdit" OnRowUpdating="TablaDatos_RowUpdating" OnRowDeleting="TablaDatos_RowDeleting" class="striped">
          

            <%--    TEMA   --%>

        


           <Columns>

                    <asp:TemplateField HeaderText = "USUARIO">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("USR") %>' runat="server" autocomplete="off" />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txtUsuario" Text='<%# Eval("USR") %>' runat="server" autocomplete="off" />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:TextBox ID="txtUsuario" runat="server" autocomplete="off" />
                    </FooterTemplate>
                </asp:TemplateField>

                  <asp:TemplateField HeaderText = "CONTRASEÑA">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("PSWD") %>' runat="server" autocomplete="off" />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txtPassword" Text='<%# Eval("PSWD") %>' runat="server" autocomplete="off" />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:TextBox ID="txtPassword" runat="server" autocomplete="off"/>
                    </FooterTemplate>
                </asp:TemplateField>

               
                  <asp:TemplateField HeaderText = "NOMBRE">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("NAME") %>' runat="server" autocomplete="off" />
                    </ItemTemplate>

                       <EditItemTemplate>
                        <asp:TextBox ID="txtNombre" Text='<%# Eval("NAME") %>' runat="server" autocomplete="off" />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:TextBox ID="txtNombre" runat="server" autocomplete="off" />
                    </FooterTemplate>
                </asp:TemplateField>

                  <asp:TemplateField HeaderText = "PERMISOS">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("ROLE") %>' runat="server" autocomplete="off"/>
                    </ItemTemplate>

                   <EditItemTemplate>
                        <asp:DropDownList ID="txtPermisos" runat="server">
                            <asp:ListItem>USER</asp:ListItem>
                            <asp:ListItem>ADMIN</asp:ListItem>                          
                           
                        </asp:DropDownList>
                    </EditItemTemplate>

                    <FooterTemplate>
                         <asp:DropDownList ID="txtPermisos" runat="server" >
                            <asp:ListItem>USER</asp:ListItem>
                            <asp:ListItem>ADMIN</asp:ListItem>                         
                           
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>



                      <asp:TemplateField HeaderText = "DEPARTAMENTO">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("DEP") %>' runat="server" autocomplete="off"/>
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
