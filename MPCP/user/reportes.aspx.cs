using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

using System.Drawing;

namespace MPCP.user
{
    public partial class reportes : System.Web.UI.Page
    {
        Boolean fec = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            dropdownAreas();
            //dropdownMaquinas();

         


            }


        public void dropdownAreas()
        {
            //string area = System.Configuration.ConfigurationSettings.AppSettings["area"].ToString();


            if (!IsPostBack)
            {


                try
                {

                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());

                    using (SqlCommand cmd = new SqlCommand("SELECT NAME FROM MPCP_AREAS"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cn.Open();
                        selectArea.DataSource = cmd.ExecuteReader();
                        selectArea.DataTextField = "NAME";
                        selectArea.DataBind();
                        cn.Close();
                    }



                }


                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }





            }



        }




        public void dropdownMaquinas()
        {
            //string area = System.Configuration.ConfigurationSettings.AppSettings["area"].ToString();


                try
                {

                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());

                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT NUMERO_MAQ FROM CAT_MAQUINAS WHERE AREA = '"+selectArea.SelectedValue+"' ORDER BY NUMERO_MAQ"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cn.Open();
                        selectMaquina.DataSource = cmd.ExecuteReader();
                        selectMaquina.DataTextField = "NUMERO_MAQ";
                        selectMaquina.DataBind();
                        cn.Close();
                    }



                }


                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }





            



        }



    


        protected void selectArea_SelectedIndexChanged(object sender, EventArgs e)
        {

           
                dropdownMaquinas();
            

            //if (CheckboxMaq.Checked == true)
            //{

            //    mensaje.Text = selectArea.SelectedValue;

            //}
        }




        protected void bajaReporte(object sender, EventArgs e)
        {



            if (abiertos.Checked == true)
            {
                if (txtFechaInicialR.Text.Length > 0 && txtFechaFinalR.Text.Length > 0)
                {
                    fec = true;

                }
                else
                {
                    fec = false;

                }

                concernsAbiertos();
            }

            else if (cerrados.Checked == true)
            {
                if (txtFechaInicialR.Text.Length > 0 && txtFechaFinalR.Text.Length > 0)
                {
                    fec = true;

                }
                else
                {
                    fec = false;

                }

                concernsCerrados();
            }


            else if (todo.Checked == true)
            {
                if (txtFechaInicialR.Text.Length > 0 && txtFechaFinalR.Text.Length > 0)
                {
                    fec = true;

                }
                else
                {
                    fec = false;

                }

                concernTodos();
            }

            txtFechaFinalR.Text = "";
            txtFechaInicialR.Text = "";


        }




        public void generaExcel()
        {

          


        }





        public void concernsAbiertos()
        {

            string fechaActual = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string fecha1 = "";
            string fecha2 = "";
            string query = "";
            string fec1 = "";
                string fec2 = "";

            if (txtFechaInicialR.Text.Length > 0 && txtFechaFinalR.Text.Length>0)
            {
                
                 
                fec1 = txtFechaInicialR.Text;
                fec2 = txtFechaFinalR.Text;

            }

          

            if (fec==false)
            {
                query = "SELECT CONVERT(varchar,FECHA_FALLA,103) as FECHA_FALLA , NUM_CONCERN, ID, NOMBRE_OPERADOR, AREA_SOPORTE, RIGHT( CONVERT(DATETIME, HORA_FALLA, 108),8) as HORA_FALLA, DEPARTAMENTO, NUM_PARTE, LINEA, NUMERO_MAQ, COORDINADOR, PROBLEMA FROM REPORT_CONCERN WHERE STATUS = 'A'";


            }

            if (fec == true)
            {
                query = "SELECT CONVERT(varchar,FECHA_FALLA,103) as FECHA_FALLA , NUM_CONCERN, ID, NOMBRE_OPERADOR, AREA_SOPORTE, RIGHT( CONVERT(DATETIME, HORA_FALLA, 108),8) as HORA_FALLA, DEPARTAMENTO, NUM_PARTE, LINEA, NUMERO_MAQ, COORDINADOR, PROBLEMA FROM REPORT_CONCERN WHERE STATUS = 'A' AND (FECHA_FALLA BETWEEN '"+fec1+"' AND '"+fec2+"') ";
            }
                
                    




            DataTable dtbl = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
            {
                sqlCon.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.Fill(dtbl);
                sqlCon.Close();
            }

            if (dtbl.Rows.Count > 0)
            {
                gdvLista.DataSource = dtbl;
                gdvLista.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gdvLista.DataSource = dtbl;
                gdvLista.DataBind();
                gdvLista.Rows[0].Cells.Clear();
                gdvLista.Rows[0].Cells.Add(new TableCell());
                gdvLista.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gdvLista.Rows[0].Cells[0].Text = "NO SE ENCONTRARON DATOS...";
                gdvLista.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gdvLista.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            }

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ReporteConcerns-" + fechaActual + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                //gdvLista.AllowPaging = false;
                //this.CargarData();




                gdvLista.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gdvLista.HeaderRow.Cells)
                {
                    cell.BackColor = gdvLista.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gdvLista.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gdvLista.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gdvLista.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gdvLista.RenderControl(hw);


                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }

        }







        public void concernsCerrados()
        {


            string fechaActual = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string fecha1 = "";
            string fecha2 = "";
            string query = "";
            string fec1 = "";
            string fec2 = "";

            if (txtFechaInicialR.Text.Length > 0 && txtFechaFinalR.Text.Length > 0)
            {

                fec1 = txtFechaInicialR.Text;
               fec2 = txtFechaFinalR.Text;

            }



            if (fec == false)
            {
                query = "SELECT HORA_ATENCION, RESPONSABLE, FECHA_CIERRE, HORA_CIERRE, TIEMPO_ATENCION, CAUSA_RAIZ, ACCIONES, TIEMPO_MUERTO, COMENT, CIERRE_MPCP FROM REPORT_CONCERN WHERE STATUS = 'C'";


            }

            if (fec == true)
            {
                query = "SELECT HORA_ATENCION, RESPONSABLE, FECHA_CIERRE, HORA_CIERRE, TIEMPO_ATENCION, CAUSA_RAIZ, ACCIONES, TIEMPO_MUERTO, COMENT, CIERRE_MPCP FROM REPORT_CONCERN  WHERE STATUS = 'C' AND (FECHA_FALLA BETWEEN '" + fec1 + "' AND '" + fec2 + "') ";
            }






            DataTable dtbl = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
            {
                sqlCon.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.Fill(dtbl);
                sqlCon.Close();
            }

            if (dtbl.Rows.Count > 0)
            {
                gdvLista2.DataSource = dtbl;
                gdvLista2.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gdvLista2.DataSource = dtbl;
                gdvLista2.DataBind();
                gdvLista2.Rows[0].Cells.Clear();
                gdvLista2.Rows[0].Cells.Add(new TableCell());
                gdvLista2.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gdvLista2.Rows[0].Cells[0].Text = "NO SE ENCONTRARON DATOS...";
                gdvLista2.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gdvLista2.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            }

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ReporteConcerns-" + fechaActual + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                //gdvLista.AllowPaging = false;
                //this.CargarData();




                gdvLista2.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gdvLista2.HeaderRow.Cells)
                {
                    cell.BackColor = gdvLista2.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gdvLista2.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gdvLista2.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gdvLista2.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gdvLista2.RenderControl(hw);


                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }


        }




        public void concernTodos()
        {


            string fechaActual = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string fecha1 = "";
            string fecha2 = "";
            string query = "";
            string fec1 = "";
            string fec2 = "";

            if (txtFechaInicialR.Text.Length > 0 && txtFechaFinalR.Text.Length > 0)
            {
             
                fec1 = txtFechaInicialR.Text;
                fec2 = txtFechaFinalR.Text;

            }



            if (fec == false)
            {
                query = "SELECT CONVERT(varchar,FECHA_FALLA,103) as FECHA_FALLA , NUM_CONCERN, ID, NOMBRE_OPERADOR, AREA_SOPORTE, RIGHT( CONVERT(DATETIME, HORA_FALLA, 108),8) as HORA_FALLA, DEPARTAMENTO, NUM_PARTE, LINEA, NUMERO_MAQ, COORDINADOR, PROBLEMA, HORA_ATENCION, RESPONSABLE, FECHA_CIERRE, HORA_CIERRE, TIEMPO_ATENCION, CAUSA_RAIZ, ACCIONES, TIEMPO_MUERTO, COMENT, CIERRE_MPCP FROM REPORT_CONCERN";


            }

            if (fec == true)
            {
                query = "SELECT CONVERT(varchar,FECHA_FALLA,103) as FECHA_FALLA , NUM_CONCERN, ID, NOMBRE_OPERADOR, AREA_SOPORTE, RIGHT( CONVERT(DATETIME, HORA_FALLA, 108),8) as HORA_FALLA, DEPARTAMENTO, NUM_PARTE, LINEA, NUMERO_MAQ, COORDINADOR, PROBLEMA, HORA_ATENCION, RESPONSABLE, FECHA_CIERRE, HORA_CIERRE, TIEMPO_ATENCION, CAUSA_RAIZ, ACCIONES, TIEMPO_MUERTO, COMENT, CIERRE_MPCP FROM REPORT_CONCERN WHERE FECHA_FALLA BETWEEN '" + fec1 + "' AND '" + fec2 + "' ";
            }






            DataTable dtbl = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString()))
            {
                sqlCon.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.Fill(dtbl);
                sqlCon.Close();
            }

            if (dtbl.Rows.Count > 0)
            {
                gdvLista3.DataSource = dtbl;
                gdvLista3.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gdvLista3.DataSource = dtbl;
                gdvLista3.DataBind();
                gdvLista3.Rows[0].Cells.Clear();
                gdvLista3.Rows[0].Cells.Add(new TableCell());
                gdvLista3.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gdvLista3.Rows[0].Cells[0].Text = "NO SE ENCONTRARON DATOS...";
                gdvLista3.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gdvLista3.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            }

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ReporteConcerns-" + fechaActual + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                //gdvLista.AllowPaging = false;
                //this.CargarData();




                gdvLista3.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gdvLista3.HeaderRow.Cells)
                {
                    cell.BackColor = gdvLista3.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gdvLista3.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gdvLista3.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gdvLista3.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gdvLista3.RenderControl(hw);


                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }



        }







        public override void VerifyRenderingInServerForm(Control control)
        {
            //verifica que el control está renderizado



        }


    }
}