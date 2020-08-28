using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MPCP_USERS.user
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarConcern();
            cargaTabla();

        }




        public void cargarConcern()
        {
            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());
                conn.Open();
                string qry = "SELECT (SELECT COUNT(*) FROM REPORT_CONCERN WHERE STATUS='A' ) as ABIERTOS, (SELECT COUNT(*) FROM REPORT_CONCERN WHERE DEPARTAMENTO='PREFABRICADO' AND STATUS='A' ) AS PREFAB, (SELECT COUNT(*) FROM REPORT_CONCERN WHERE DEPARTAMENTO = 'EFFF' AND STATUS='A') AS EFFF, (SELECT COUNT(*) FROM REPORT_CONCERN WHERE DEPARTAMENTO = 'CNC' AND STATUS='A' ) AS CNC, (SELECT COUNT(*) FROM REPORT_CONCERN WHERE DEPARTAMENTO = 'CORTE Y FORMADO' AND STATUS='A' ) AS CYF, (SELECT COUNT(*) FROM REPORT_CONCERN WHERE DEPARTAMENTO = 'PWT' AND STATUS='A' ) AS PWT, (SELECT COUNT(*) FROM REPORT_CONCERN WHERE DEPARTAMENTO = 'HORNO/INSERCION' AND STATUS='A' ) AS HI FROM REPORT_CONCERN WHERE STATUS = 'A' ";
                SqlCommand cmd = new SqlCommand(qry, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())

                {

                    //abiertos.Text = sdr["ABIERTOS"].ToString();
                    lblPrefab.Text = sdr["PREFAB"].ToString();
                    lblEfff.Text = sdr["EFFF"].ToString();
                    lblCnc.Text = sdr["CNC"].ToString();
                    lblCyf.Text = sdr["CYF"].ToString();
                    lblPwt.Text = sdr["PWT"].ToString();
                    lblHi.Text = sdr["HI"].ToString();
                }
                else
                {
                    lblMensaje.Text = "";


                }
                conn.Close();
            }
            catch (Exception ex)

            {

                lblMensaje.Text = ex.Message;
            }



        }







        public void cargaTabla()
        {

            DataTable dtbl = new DataTable();

            string query = "SELECT DISTINCT  b.AREA_SOPORTE as AREA_SOPORTE, ";
            query = query + "(SELECT COUNT(*) FROM REPORT_CONCERN WHERE b.AREA_SOPORTE=AREA_SOPORTE AND DEPARTAMENTO='PREFABRICADO')AS PREFAB, ";
            query = query + "(SELECT COUNT(*) FROM REPORT_CONCERN WHERE b.AREA_SOPORTE=AREA_SOPORTE AND DEPARTAMENTO='EFFF')AS EFFF, ";
            query = query + "(SELECT COUNT(*) FROM REPORT_CONCERN WHERE b.AREA_SOPORTE=AREA_SOPORTE AND DEPARTAMENTO='CORTE Y FORMADO')AS CYF, ";
            query = query + "(SELECT COUNT(*) FROM REPORT_CONCERN WHERE b.AREA_SOPORTE=AREA_SOPORTE AND DEPARTAMENTO='HORNO/INSERCION')AS HI, ";
            query = query + "(SELECT COUNT(*) FROM REPORT_CONCERN WHERE b.AREA_SOPORTE=AREA_SOPORTE AND DEPARTAMENTO='CNC')AS CNC, ";
            query = query + "(SELECT COUNT(*) FROM REPORT_CONCERN WHERE b.AREA_SOPORTE=AREA_SOPORTE AND DEPARTAMENTO='PWT')AS PWT, ";
            query = query + "(SELECT COUNT(*) FROM REPORT_CONCERN WHERE b.AREA_SOPORTE=AREA_SOPORTE)AS TOTAL ";
            query = query + "FROM REPORT_CONCERN b WHERE b.AREA_SOPORTE IS NOT NULL ";


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
                gdvLista.Rows[0].Cells[0].Text = "NO SE ENCONTRARON CONCERNS ABIERTOS...";
                gdvLista.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gdvLista.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            }






        }



        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //verifica que el control está renderizado



        }







    }
}