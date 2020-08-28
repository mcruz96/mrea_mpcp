using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace MPCP_USERS
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
                if (session_abierta == "y")
                {

                    Response.Redirect("user/cerrarConcern.aspx");


                }




            }

          }



        protected void FormSoporte(object sender, EventArgs e)
        {

            DateTime today = DateTime.Today;
            string fecha = today.ToString("dd/MM/yyyy");
            string year = fecha.Substring(6, 4);
            string usuario = txtUsuarioSop.Text;
            string pass = txtPass.Text.Trim();
            string qry = "";

                qry = "SELECT * FROM MPCP_USERS WHERE USR= '" + usuario + "' AND PSWD= '" + pass + "'";


                try
                {

                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(qry, conn);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())

                    {
                        Session["aut"] = "y";

                        Session["sNombreS"] = sdr["NAME"].ToString();
                        Session["sPassword"] = sdr["PSWD"].ToString();
                        Session["sUsuario"] = sdr["USR"].ToString();
                        Session["sRole"] = sdr["ROLE"].ToString();

                    if (Session["sRole"].ToString()=="USER")
                    {
                        Response.Redirect("user/Default.aspx");
                    }

                    if (Session["sRole"].ToString() == "ADMIN")
                    {

                        Response.Redirect("admin/Default.aspx");
                    }
                        



                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Usuario y/o password incorrectos";


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
