using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;



namespace MPCP_USERS.admin
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PopulatedGridView();

            }


        }



        void PopulatedGridView()
        {




            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
            {
                sqlCon.Open();

                //WHERE tipo_mejora = 'Seguridad' and fecha_propuesta BETWEEN '"+fechaInicio+"' AND '"+fechaFin+"'
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM MPCP_USERS", sqlCon);
                sqlDa.Fill(dtbl);
            }

            if (dtbl.Rows.Count > 0)
            {
                TablaDatos.DataSource = dtbl;
                TablaDatos.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                TablaDatos.DataSource = dtbl;
                TablaDatos.DataBind();
                TablaDatos.Rows[0].Cells.Clear();
                TablaDatos.Rows[0].Cells.Add(new TableCell());
                TablaDatos.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                TablaDatos.Rows[0].Cells[0].Text = "NO SE ENCONTRARON DATOS...";
                TablaDatos.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                TablaDatos.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            }




        }


        protected void TablaDatos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            TablaDatos.EditIndex = e.NewEditIndex;
            PopulatedGridView();

        }

        protected void TablaDatos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            TablaDatos.EditIndex = -1;
            PopulatedGridView();
        }

        protected void TablaDatos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
                {
                    sqlCon.Open();
                    string query = "UPDATE MPCP_USERS SET USR=@usuario,PSWD=@password,NAME=@nombre,ROLE=@permisos, DEP=@departamento WHERE USR=@usuario";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@usuario", (TablaDatos.Rows[e.RowIndex].FindControl("txtUsuario") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@password", (TablaDatos.Rows[e.RowIndex].FindControl("txtPassword") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@nombre", (TablaDatos.Rows[e.RowIndex].FindControl("txtNombre") as TextBox).Text);
                    sqlCmd.Parameters.AddWithValue("@permisos", (TablaDatos.Rows[e.RowIndex].FindControl("txtPermisos") as DropDownList).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@departamento", (TablaDatos.Rows[e.RowIndex].FindControl("txtDep") as DropDownList).Text.Trim());

                    sqlCmd.ExecuteNonQuery();
                    TablaDatos.EditIndex = -1;
                    PopulatedGridView();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        protected void TablaDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Addnew"))
            {

                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO MPCP_USERS (USR,PSWD,NAME,ROLE,DEP) VALUES(@usuario,@password,@nombre,@permisos,@departamento)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@usuario", (TablaDatos.FooterRow.FindControl("txtUsuario") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@password", (TablaDatos.FooterRow.FindControl("txtPassword") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@nombre", (TablaDatos.FooterRow.FindControl("txtNombre") as TextBox).Text);
                    sqlCmd.Parameters.AddWithValue("@permisos", (TablaDatos.FooterRow.FindControl("txtPermisos") as DropDownList).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@departamento", (TablaDatos.FooterRow.FindControl("txtDep") as DropDownList).Text.Trim());

                    sqlCmd.ExecuteNonQuery();
                    PopulatedGridView();


                }


            }
        }

        protected void TablaDatos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {

                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM MPCP_USERS WHERE USR= @usuario";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@usuario", TablaDatos.DataKeys[e.RowIndex].Value.ToString());

                    sqlCmd.ExecuteNonQuery();
                    PopulatedGridView();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }


        }





    }
}