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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulatedGridView();
                PopulatedGridView2();
            }




        }


        void PopulatedGridView()
        {




            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
            {
                sqlCon.Open();

                //WHERE tipo_mejora = 'Seguridad' and fecha_propuesta BETWEEN '"+fechaInicio+"' AND '"+fechaFin+"'
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM MPCP_AREAS", sqlCon);
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
                    string query = "UPDATE MPCP_AREAS SET NAME=@name WHERE ID=@id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@id", TablaDatos.DataKeys[e.RowIndex].Value.ToString());
                    sqlCmd.Parameters.AddWithValue("@name", (TablaDatos.Rows[e.RowIndex].FindControl("txtNombre") as TextBox).Text.Trim());
                    
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
                    string query = "INSERT INTO MPCP_AREAS (NAME) VALUES(@name)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@name", (TablaDatos.FooterRow.FindControl("txtNombre") as TextBox).Text.Trim());
                 
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
                    string query = "DELETE FROM MPCP_AREAS WHERE ID= @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@id", TablaDatos.DataKeys[e.RowIndex].Value.ToString());

                    sqlCmd.ExecuteNonQuery();
                    PopulatedGridView();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }


        }








        void PopulatedGridView2()
        {




            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
            {
                sqlCon.Open();

                //WHERE tipo_mejora = 'Seguridad' and fecha_propuesta BETWEEN '"+fechaInicio+"' AND '"+fechaFin+"'
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM MPCP_CUSTOMERS", sqlCon);
                sqlDa.Fill(dtbl);
            }

            if (dtbl.Rows.Count > 0)
            {
                TablaDatos2.DataSource = dtbl;
                TablaDatos2.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                TablaDatos2.DataSource = dtbl;
                TablaDatos2.DataBind();
                TablaDatos2.Rows[0].Cells.Clear();
                TablaDatos2.Rows[0].Cells.Add(new TableCell());
                TablaDatos2.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                TablaDatos2.Rows[0].Cells[0].Text = "NO SE ENCONTRARON DATOS...";
                TablaDatos2.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                TablaDatos2.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            }




        }


        protected void TablaDatos2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            TablaDatos2.EditIndex = e.NewEditIndex;
            PopulatedGridView2();

        }

        protected void TablaDatos2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            TablaDatos2.EditIndex = -1;
            PopulatedGridView2();
        }

        protected void TablaDatos2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
                {
                    sqlCon.Open();
                    string query = "UPDATE MPCP_CUSTOMERS SET NAME=@name WHERE ID=@id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@id", TablaDatos2.DataKeys[e.RowIndex].Value.ToString());
                    sqlCmd.Parameters.AddWithValue("@name", (TablaDatos2.Rows[e.RowIndex].FindControl("txtNombre") as TextBox).Text.Trim());

                    sqlCmd.ExecuteNonQuery();
                    TablaDatos2.EditIndex = -1;
                    PopulatedGridView2();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        protected void TablaDatos2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Addnew"))
            {

                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO MPCP_CUSTOMERS (NAME) VALUES(@name)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@name", (TablaDatos2.FooterRow.FindControl("txtNombre") as TextBox).Text.Trim());

                    sqlCmd.ExecuteNonQuery();
                    PopulatedGridView2();


                }


            }
        }

        protected void TablaDatos2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {

                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM MPCP_CUSTOMERS WHERE ID= @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@id", TablaDatos2.DataKeys[e.RowIndex].Value.ToString());

                    sqlCmd.ExecuteNonQuery();
                    PopulatedGridView2();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }


        }









    }

}