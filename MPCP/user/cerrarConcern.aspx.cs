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
    public partial class cerrarConcern : System.Web.UI.Page
    {

        string txtHoraAtencion = "";
        string txtResponsable = "";
        string txtHoraCierre = "";
        string txtFechaCierre = "";
        string txtTiempoAtencion = "";
        int id = 0;
        string txtTiempoMuerto = "";

        protected void Page_Load(object sender, EventArgs e)
        {




            dropdownnumero();
            buscaConcern();
            locacion();



        }




        protected void buscaConcern()
        {


            string concern = selectConcern.SelectedValue;
            lblMensaje.Text = "";
            string id = "1";
         



            try
            {
                string qry = "";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());
                conn.Open();
                qry = "SELECT  top 1 CONVERT(varchar(15),CAST(SUPP_DATE AS TIME),100) as HORA_ATENCION,";
                qry = qry + " UPPER((SELECT FullName FROM FWSECURITYAPPUSER WHERE c.USER_SUPPORT = ID)) as RESPONSABLE,";
                qry = qry + " CONVERT(varchar,CLOSED,103) as FECHA_CIERRE, CONVERT(varchar(15),CAST(CLOSED AS TIME),100) as HORA_CIERRE,";
                qry = qry + " DATEDIFF(MINUTE,c.START,c.CLOSED) as TIEMPO_MUERTO_M,";
                qry = qry + " DATEDIFF(MINUTE,c.SUPP_DATE,c.CLOSED) as TIEMPO_ATENCION";
                qry = qry + " from FLD.ANDON_STATUS a, CAT_MAQUINAS b, FLD.ANDON_HIST c where c.RECORD_ID = '" + concern+"'";
           
                SqlCommand cmd = new SqlCommand(qry, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())

                {

                    txtHoraAtencion = sdr["HORA_ATENCION"].ToString();
                    txtResponsable = sdr["RESPONSABLE"].ToString();
                    txtHoraCierre = sdr["HORA_CIERRE"].ToString();
                    txtFechaCierre = sdr["FECHA_CIERRE"].ToString();
                    txtTiempoAtencion = sdr["TIEMPO_ATENCION"].ToString();
                    txtTiempoMuerto = sdr["TIEMPO_MUERTO_M"].ToString();

                }
                else
                {
                    lblMensaje.Text = "CONCERN NO ENCONTRADO";


                }
                conn.Close();

                //cargaId();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }



        }





        protected void cierraConcern(object sender, EventArgs e)
        {



            if (txtHoraAtencion == "" || txtResponsable == "" || txtFechaCierre == "" || txtHoraCierre == "" || txtCausaRaiz.Text == "" || txtAcciones.Text == ""
               || txtComentarios.Text == "" || txtTiempoAtencion == "")
            {

                Response.Write("<script>window.alert('ERROR: LLENA TODOS LOS CAMPOS ')</script>");
            }
            else
            {
                Concern();
            }







        }






        public void dropdownnumero()
        {
            string usuario = Session["sUsuarioS"].ToString();
            string dep = Session["sDepS"].ToString();



            if (!IsPostBack)
            {

                try
                {

                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());

                    using (SqlCommand cmd = new SqlCommand("SELECT NUM_CONCERN FROM REPORT_CONCERN WHERE AREA_SOPORTE = '"+dep+"' AND STATUS ='A'"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cn.Open();
                        selectConcern.DataSource = cmd.ExecuteReader();
                        selectConcern.DataTextField = "NUM_CONCERN";
                        selectConcern.DataBind(); 
                        cn.Close();
                    }

                }

                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }


            }







        }


        public void Concern()
        {




            string fecha = txtFechaCierre;
            string horaAtencion = txtHoraAtencion;
            string responsable = txtResponsable;
            string horaCierre = txtHoraCierre;
            string tiempoMuerto = txtTiempoMuerto;


            string causaRaiz = txtCausaRaiz.Text.ToUpper();
            string acciones = txtAcciones.Text.ToUpper();
            string comentarios = txtComentarios.Text.ToUpper();





            string espcliente = "";
            string prodnotif = "";
            string desviacion = "";
            string calaprob = "";
            string retrabajo = "";
            string retrabajoaprob = "";




            if (especifSi.Checked == true) { espcliente = "SI"; } else if (especifNo.Checked == true) { espcliente = "NO"; } else { espcliente = ""; }
            if (especifNSi.Checked == true) { prodnotif = "SI"; } else if (especifNNo.Checked == true) { prodnotif = "NO"; } else { prodnotif = ""; }
            if (desvSi.Checked == true) { desviacion = "SI"; } else if (desvNo.Checked == true) { desviacion = "NO"; } else { desviacion = ""; }
            if (desvApSi.Checked == true) { calaprob = "SI"; } else if (desvApNo.Checked == true) { calaprob = "NO"; } else { calaprob = ""; }
            if (retrabajoSi.Checked == true) { retrabajo = "SI"; } else if (retrabajoNo.Checked == true) { retrabajo = "NO"; } else { retrabajo = ""; }
            if (retrabajoApSi.Checked == true) { retrabajoaprob = "SI"; } else if (retrabajoApNo.Checked == true) { retrabajoaprob = "NO"; } else { retrabajoaprob = ""; }



    


            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());
                conn.Open();
                string qry = "UPDATE REPORT_CONCERN set HORA_ATENCION = '" + horaAtencion + "', RESPONSABLE = '" + responsable + "', " +
                    "FECHA_CIERRE = '" + fecha + "', HORA_CIERRE = '"+horaCierre+"', CAUSA_RAIZ = '"+causaRaiz+"'," +
                    " ACCIONES='"+acciones+"', TIEMPO_MUERTO = '"+tiempoMuerto+"', TIEMPO_ATENCION = '"+txtTiempoAtencion+"', COMENT =" +
                    " '"+comentarios+ "', ESP_CLIENTE = '" + espcliente + "',  PROD_NOTIF = '" + prodnotif + "',  DESVIACION = '" + desviacion + "'," +
                    " CAL_APROB = '" + calaprob + "',  RETRABAJO = '" + retrabajo + "',  RETRABAJO_APROB = '" + retrabajoaprob + "', CIERRE_MPCP = CONVERT(varchar,GETDATE(),103),  STATUS='C' WHERE NUM_CONCERN = '" + selectConcern.SelectedValue + "'";

                //NUM_CONCERN = '" + selectConcern.SelectedValue+"'";

                SqlCommand cmd = new SqlCommand(qry, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
               
                conn.Close();

                limpiarCampos();

             



            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message+"ERROR EN UPDATE";
            }



        }





        public void limpiarCampos()
        {

            Response.Write("<script>window.alert('CONCERN CERRADO CORRECTAMENTE')</script>");


           
           
            txtHoraAtencion = "";
            txtResponsable = "";
            txtFechaCierre = "";
            txtHoraCierre = "";
            txtCausaRaiz.Text = "";
            txtAcciones.Text = "";
            txtTiempoAtencion = "";
            txtComentarios.Text = "";


            Response.Redirect("cerrarConcern.aspx");

        }


        public void locacion()
        {
            lblResponsable.Text = txtResponsable;
            lblHoraAtencion.Text = txtHoraAtencion;
            lblHoraCierre.Text = txtTiempoAtencion + " Minutos";         

        }




        protected void selectConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscaConcern();
            locacion();
        }

    }
}