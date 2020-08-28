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

namespace MPCP_USERS.user
{
    public partial class CONCERNS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargaTabla();
        }


        public void cargaTabla()
        {

            DataTable dtbl = new DataTable();

            string query = "SELECT  b.NOMBRE_MAQ, b.AREA, b.UBICACION, (SELECT TOP 1 UPPER(DESCR) FROM FLD.ANDON_CODES WHERE a.STATUS_CODE=CODE_ID) as DEPARTAMENTO, (SELECT TOP 1 CONCAT(CONVERT(varchar,START,103),'  ',CONVERT(varchar,START,24)) FROM FLD.ANDON_HIST WHERE a.DTUCODE = DTUCODE ORDER BY RECORD_ID DESC) as INICIO, ( SELECT TOP 1 DATEDIFF(MINUTE,START,GETDATE()) FROM FLD.ANDON_HIST WHERE a.DTUCODE = DTUCODE ORDER BY RECORD_ID DESC) AS TIEMPO_MUERTO, UPPER((SELECT FullName FROM FWSECURITYAPPUSER x, FLD.ANDON_HIST y WHERE a.DTIME_ID = y.RECORD_ID and y.USER_SUPPORT = x.ID)) as SOPORTE FROM FLD.ANDON_STATUS a, CAT_MAQUINAS b WHERE a.STATUS = 2 AND (a.STATUS_CODE < 10 OR a.STATUS_CODE = 13) AND a.DTUCODE = b.NUMERO_MAQ ORDER BY TIEMPO_MUERTO";


            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection3"].ToString()))
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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            cargaTabla();
        }

        protected void gdvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[6].Text.Length != 6)
                {
                    e.Row.BackColor = Color.Yellow;
                }


            }



        }







    }

}