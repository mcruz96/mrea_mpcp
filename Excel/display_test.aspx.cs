using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Configuration;


public partial class app_display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pantalla = Request["clave"].ToString();
        string mesa = Request["mesa"].ToString();
        string fecha_actual = DateTime.Now.ToString("yyyy-MM-dd");
        string nparte = "";
        int turno = 1;
        int qty_req = 0;
        int qty_prod = 0;

        ImprimeTitulo(mesa, turno, pantalla);

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection"].ToString());
        conn.Open();
        try
        {
            //mesa = "OV101";
            int estacion_temp = Convert.ToInt32(mesa.Substring(2, 1));
            int mesa_temp = Convert.ToInt32(mesa.Substring(3, 2));
            string qry_req1 = "SELECT * FROM plan_produccion WHERE activo = 1 AND fecha = '" + fecha_actual + "' AND estacion = '" + estacion_temp + "' AND mesa = '" + mesa_temp + "'";
            //lblMsg.Text = lblMsg.Text + "<br /> " + qry_req1;
            SqlCommand cmdreq1 = new SqlCommand(qry_req1, conn);
            SqlDataReader sdrreq1 = cmdreq1.ExecuteReader();
            while (sdrreq1.Read())
            {
                nparte = sdrreq1["parte"].ToString();
                if (turno == 1)
                    qty_req = Convert.ToInt32(sdrreq1["turno1"]);
                else
                    qty_req = Convert.ToInt32(sdrreq1["turno2"]);
                if (qty_req >= 1)
                {
                    //qty_prod = GetProdOV(nparte, turno);
                    //GraficaParte(nparte, qty_req, qty_prod);
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
        conn.Close();
    }

    private int GetProdOV(string nparte, int turno)
    {
        int suma = 0;
        OdbcConnection DbConnection = new OdbcConnection("dsn=CMSDAT;UID=FGUTIERREZ;PWD=FGUTIERREZ;");
        try
        {
            DbConnection.Open();
            OdbcCommand DbCommand = DbConnection.CreateCommand();
            string qry_cmsProd = "SELECT CAST(TIQTYP AS int) FROM RPRQX1 WHERE TIPART = '" + nparte + "' AND TIRDAT = CURRENT DATE AND TISHFT = '" + turno + "'";
            //lblMsg.Text = lblMsg.Text + "<br /> " + qry_cmsProd;
            DbCommand.CommandText = qry_cmsProd;
            OdbcDataReader DbReader = DbCommand.ExecuteReader();
            while (DbReader.Read())
            {
                string s_t_r = DbReader.GetString(0);
                //lblMsg.Text = lblMsg.Text + "<br /> Prod nparte: " + s_t_r;
                int intTemp = int.Parse(s_t_r);
                suma = suma + intTemp;
            }
            DbReader.Close();
            DbCommand.Dispose();
            DbConnection.Close();
        }
        catch (OdbcException ex)
        {
            lblMsg.Text = (ex.Message);
        }
        return suma;
    }

    private void GraficaParte(string nparte, decimal qty_req, decimal qty_prod)
    {
        decimal eficiencia_decimal = (qty_prod / qty_req) * 100;
        int eficiencia = Convert.ToInt32(eficiencia_decimal);
        string clase_bg = "#3be249";
        string clase_color = "#000000";
        if (eficiencia <= 80)
        {
            clase_bg = "#ff0000"; // rojo
            clase_color = "#ffffff";
        }
        if (eficiencia >= 81 && eficiencia <= 85)
        {
            clase_bg = "#e7ef09"; // amarillo
            clase_color = "#000000";
        }
        if (eficiencia >= 85)
        {
            clase_bg = "#3be249"; // verde
            clase_color = "#000000";
        }
        if (qty_prod == 0)
        {
            clase_bg = "#ff9900"; // naranja
            clase_color = "#000000";
        }
        string htmlToDisplay = "<div class=\"row\" style=\"margin-top: 15px; background: " + clase_bg + "; color: " + clase_color + ";\">" +
            "<div class=\"col-md-3 text-center\">" +
            "    <span style=\"width: 100%; text-align: center; font-size: 25px\"><b>" + nparte + "</b></span>" +
            "</div>" +
            "<div class=\"col-md-3 text-center\">" +
            "    <span style=\"width: 100%; text-align: center; font-size: 25px\"><b>" + qty_req + "</b></span>" +
            "</div>" +
            "<div class=\"col-md-3 text-center\">" +
            "    <span style=\"width: 100%; text-align: center; font-size: 25px\"><b>" + qty_prod + "</b></span>" +
            "</div>" +
            "<div class=\"col-md-3 text-center\">" +
            "    <span style=\"width: 100%; text-align: center; font-size: 25px\"><b>" + eficiencia + "%</b></span>" +
            "</div>" +
            "</div>";
        //DisplayDiv.InnerHtml += "Nparte: " + nparte + " Req: " + qty_req + " Prod: " + qty_prod + "<br />";
        DisplayDiv.InnerHtml += htmlToDisplay;
    }

    private void ImprimeTitulo(string mesa, int turno, string pantalla)
    {
        int estacion_temp = Convert.ToInt32(mesa.Substring(2, 1));
        int mesa_temp = Convert.ToInt32(mesa.Substring(3, 2));
        string titulo = "Pantalla: <b>" + pantalla + "</b> &nbsp; Estación: <b>" + estacion_temp.ToString() + "</b></b> &nbsp; &nbsp; Mesa: <b>M" + mesa_temp.ToString() + "</b></b> &nbsp; &nbsp; Turno: <b>" + turno.ToString() + "</b>";
        h2titulo.InnerHtml = titulo;
    }
}