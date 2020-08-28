using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MPCP.user
{
    public partial class cambiarPassword : System.Web.UI.Page
    {
        public static DateTime today = DateTime.Today;
        public static string fecha = today.ToString("dd/MM/yyyy");
        string year = fecha.Substring(6, 4);
        protected void Page_Load(object sender, EventArgs e)
        {

         


        }


        protected void cambiaPassword(object sender, EventArgs e)
        {

            string pass = txtPass.Text;
            string passRepeat = txtPassRepeat.Text;

            string dep = "";

            if (Mantenimiento.Checked==true){dep = "MANTENIMIENTO";}
            if (Tooling.Checked == true) { dep = "TOOLING"; }
            if (Materiales.Checked == true) { dep = "MATERIALES"; }
            if (Sistemas.Checked == true) { dep = "SISTEMAS"; }
            if (Calidad.Checked == true) { dep = "CALIDAD"; }
            if (Ingienería.Checked == true) { dep = "INGENIERIA"; }
            if (Producción.Checked == true) { dep = "PRODUCCION"; }











            if (pass == "" || passRepeat == "")
            {
                Response.Write("<script>window.alert('ERROR: LLENA CORRECTAMENTE LOS CAMPOS ')</script>");

            }

         

            else if (pass == passRepeat && pass != "mrea"+year)
            {


                try
                {

                    string usuario = Session["sUsuarioS"].ToString();

                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());
                    conn.Open();
                    string qry = "UPDATE FWSECURITYAPPUSER SET Password = '"+pass+"', Departament= '"+dep+"' WHERE PINcode= "+usuario+"";
                    SqlCommand cmd = new SqlCommand(qry, conn);
                    SqlDataReader sdr = cmd.ExecuteReader();                   
                    conn.Close();

                    Response.Write("<script>window.alert('Contraseña cambiada correctamente: Ingresa con tus nuevas credenciales')</script>");
                    Response.Redirect("../loginSoporte.aspx");

                }
                catch (Exception ex)
                {
                    lblMensaje.Text = ex.Message;
                }

            }

            else
            {
                lblMensaje.Text = "ERROR: Las contraseñas no coinciden";
            }




        }




    }
}