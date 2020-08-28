using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;



namespace MPCP
{
    public partial class Default : System.Web.UI.Page
    {

        public static DateTime today = DateTime.Today;
        public static string fecha = today.ToString("dd/MM/yyyy");
        string year = fecha.Substring(6, 4);

        protected void Page_Load(object sender, EventArgs e)
        {

            lblMessage.Visible = false;


            lblMrea.Text = " © " + year + " Martinrea International Inc";
            //txtUsuarioOp.Focus();

            int exit = Convert.ToInt32(Request["exit"]);
            if (exit == 1)
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("Default.aspx");
            }
            else
            {
                string session_abierta = (string)(Session["aut"]);
                if (session_abierta == "soporte")
                {

                    Response.Redirect("user/cerrarConcern.aspx");


                }






            }

        }


        protected void Form(object sender, EventArgs e)
        {
            try
            {

                string usuario = txtUsuarioOp.Text.Trim();

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());
                conn.Open();
                string qry = "SELECT FullName FROM FWSECURITYAPPUSER WHERE PINcode=" + usuario + "";
                SqlCommand cmd = new SqlCommand(qry, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())

                {
                    Session["aut"] = "operador";
                    //Session["id_usuario"] = sdr["id_usuario"];
                    Session["sNombre"] = sdr["FullName"].ToString();

                    Response.Redirect("user/abrirConcern.aspx");
                    // lblMessage.Text = "<span class=\"alert alert-success\">" + sdr["nombre"] + "</span>";


                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Usuario incorrecto";


                }
                conn.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }






    }

}