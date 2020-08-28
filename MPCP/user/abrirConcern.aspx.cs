using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls.WebParts;

namespace MPCP.user
{
    public partial class abrirConcern : System.Web.UI.Page
    {
        string seleccion = "";
        string txtId = "";
        string txtFechaC = "";
        string txtApoyoRequerido = "";
        string txtNomOperador = "";
        string txtNumMaquina = "";
        string txtHora = "";
        string txtDepartamento = "";
        string txtLinea = "";
        string txtNumParte = "";
        string txtCoordinador = "";
        string txaProblema = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            dropdownnumero();
            //cargaId();
            buscaConcern();
            locacion();
        }





        public void dropdownnumero()
        {
            string area = System.Configuration.ConfigurationSettings.AppSettings["area"].ToString();


            if (!IsPostBack)
            {


                try
                {

                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());

                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT c.RECORD_ID AS NUM_CONCERN FROM FLD.ANDON_HIST c, CAT_MAQUINAS b WHERE CONVERT(varchar,c.START,103)  = CONVERT(varchar,GETDATE(),103) AND (c.DTUCODE = b.NUMERO_MAQ AND b.AREA = '"+area+ "') AND (c.DT_CODE < 10 OR c.DT_CODE = 13) AND NOT EXISTS (SELECT NUM_CONCERN FROM REPORT_CONCERN WHERE NUM_CONCERN = c.RECORD_ID)"))
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



       



        public void buscaConcern()
        {

           

           

            txtNomOperador = Session["sNombre"].ToString();


            try
            {
                string qry = "SELECT top 1 CONVERT(varchar,START,103) as FECHA," +
                    "UPPER((SELECT TOP 1 DESCR FROM FLD.ANDON_CODES WHERE c.DT_CODE = CODE_ID)) as SOPORTE," +
                    "c.DTUCODE AS NUM_MAQUINA,CONVERT(varchar(15),CAST(START AS TIME),100) as HORA," +
                    "(SELECT TOP 1 AREA from CAT_MAQUINAS WHERE NUMERO_MAQ = c.DTUCODE) AS DEPARTAMENTO," +
                    "(SELECT TOP 1 UBICACION from CAT_MAQUINAS WHERE NUMERO_MAQ = c.DTUCODE) AS LINEA" +
                    " from FLD.ANDON_STATUS a, CAT_MAQUINAS b, FLD.ANDON_HIST c where c.RECORD_ID = '" + selectConcern.SelectedValue + "'";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand(qry, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())

                {

                    txtFechaC = sdr["FECHA"].ToString();                    
                   txtApoyoRequerido = sdr["SOPORTE"].ToString();                   
                    txtNumMaquina = sdr["NUM_MAQUINA"].ToString();
                    txtHora = sdr["HORA"].ToString();
                    txtDepartamento = sdr["DEPARTAMENTO"].ToString();
                    txtLinea = sdr["LINEA"].ToString();
                    NumMaquina.Text = sdr["NUM_MAQUINA"].ToString();
                    //lblMensaje.Text = txtDepartamento;




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



  
        public void locacion()
        {


            try
            {
                string qry = "SELECT TOP 1 NOMBRE_MAQ AS MAQUINA FROM CAT_MAQUINAS WHERE NUMERO_MAQ = '"+txtNumMaquina+"'";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());
                conn.Open();
            
                SqlCommand cmd = new SqlCommand(qry, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())

                {

                   lblUbicacion.Text = sdr["MAQUINA"].ToString();




                }
                else
                {
                    lblMensaje.Text = "CONCERN NO ENCONTRADO";


                }
                conn.Close();

                lblHora.Text = txtHora;
                lblApoyo.Text = txtApoyoRequerido;
               
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }


        }


 


        protected void guardarConcern(object sender, EventArgs e)
        {



            //if (txtFechaC == "" || txtNumMaquina == "" || txtApoyoRequerido == "" || txtId == "" || txtNomOperador == ""  || txtHora == "" || txtDepartamento == "" || txtNumParte == "" || txtLinea == "")
            //{

            //    Response.Write("<script>window.alert('ERROR: LLENA TODOS LOS CAMPOS ')</script>");
            //}
            //else
            //{
            //    Concern();
            //}

            Concern();


        }



        public void Concern()
        {



            string fecha = txtFechaC;
            string numConcern = selectConcern.SelectedValue;
                   
            string nomOperador = txtNomOperador.ToUpper();
            string areaSoporte = txtApoyoRequerido;            
            string departamento = txtDepartamento;
            string horaFalla = txtHora;
            string numParte = NumParte.Text.ToUpper() + " "+ selectCliente.SelectedValue;
            string linea = txtLinea;
            string numMaquin = NumMaquina.Text;
            string coordinador = "GILBERTO CRUZ";
            string problema = selectProblema.Value;


            string probRecurrente = "";
            string partesMal = "";
            string supervisor = "";
            string scrap = "";
            string contencion = "";

            if (recSi.Checked==true) {probRecurrente = "SI";} else if (recNo.Checked == true){probRecurrente = "NO";} else{ probRecurrente = "";}
            if (partesSi.Checked == true) { partesMal = "SI"; } else if (partesNo.Checked == true) { partesMal = "NO"; } else { partesMal = ""; }
            if (supSi.Checked == true) { supervisor = "SI"; } else if (supNo.Checked == true) { supervisor = "NO"; } else { supervisor = ""; }
            if (scrapSi.Checked == true) { scrap = "SI"; } else if (scrapNo.Checked == true) { scrap = "NO"; } else { scrap = ""; }
            if (calSi.Checked == true) { contencion = "SI"; } else if (calNo.Checked == true) { contencion = "NO"; } else { contencion = ""; }




            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLconection2"].ToString());
                conn.Open();
                string qry = "INSERT INTO REPORT_CONCERN (FECHA_FALLA, NUM_CONCERN, NOMBRE_OPERADOR, AREA_SOPORTE, HORA_FALLA, DEPARTAMENTO, NUM_PARTE, LINEA, NUMERO_MAQ, COORDINADOR, PROBLEMA, STATUS, RECURRENTE, PARTES_MAL, SUPERVISOR, SCRAP, CONTENCION) " +
                    " VALUES ( '" + fecha + "', '" + numConcern + "', '" + nomOperador + "', '" + areaSoporte + "', '" + horaFalla + "', '" + departamento + "', '" + numParte + "', '" + linea + "', '" + numMaquin + "', '" + coordinador + "', '" + problema + "', " +
                    " 'A' , '" + probRecurrente + "' , '" + partesMal + "', '" + supervisor + "', '" + scrap + "' , '" + contencion + "')";
            
                SqlCommand cmd = new SqlCommand(qry, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                limpiarCampos();
                conn.Close();

                //dropdownnumero();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

           
           

        }




        public void limpiarCampos()
        {




            Response.Write("<script>window.alert('CONCERN ABIERTO CORRECTAMENTE')</script>");

            Response.Redirect("../Default.aspx");

            //txtFechaC = "";
            //txtNumMaquina = "";
            //txtApoyoRequerido = "";
            //txtId= "";
            //txtNomOperador = "";
            //selectConcern.SelectedIndex = 0;
            //txtHora = "";
            //txtDepartamento = "";
            //txtNumParte = "";
            //txtLinea = "";
            //txtCoordinador = "";
            //txaProblema = "";


            //dropdownnumero();

        }




        protected void selectConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscaConcern();
            locacion();
        }


       

    }
}