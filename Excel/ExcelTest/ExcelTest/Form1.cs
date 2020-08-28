using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml;

namespace ExcelTest
{
    public partial class MREA : Form
    {
        static string confServer = "";
        static string confDb = "";
        static string confUsr = "";
        static string confPsw = "";
        static string argTipoRep = "";
        static string argTipoTop = "";
        static string argFecha1 = "";
        static string argFecha2 = "";
        static string argAreaProd = "";
        static string argAreaSop = "";
        static string argMaquina = "";
        static string argTurno = "";
        static string argNombre = "";
        public MREA()
        {
            InitializeComponent();
        }

        private void prueba_conexion()
        {
            try
            {
                string server = txtServer.Text;
                string db = txtDb.Text;
                string usr = txtUsr.Text;
                string psw = txtPsw.Text;
                SqlConnection cnn;
                string connectionString = null;
                string sql = null;
                string data = null;
                connectionString = @"data source=" + server + ";initial catalog=" + db + ";user id=" + usr + ";password=" + psw + ";";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                MessageBox.Show("Conexion correcra");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message);
            }
        }

        private void genera_diseno()
        {
            string path = System.IO.Directory.GetCurrentDirectory();

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Imagenes
            xlWorkSheet.Shapes.AddPicture("C:\\inetpub\\wwwroot\\AndonReport\\images\\logo.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 10, 5, 70, 70);
            xlWorkSheet.Shapes.AddPicture("C:\\inetpub\\wwwroot\\AndonReport\\images\\accelerate.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 520, 5, 110, 70);
            xlWorkSheet.Range["H7"].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
            // Colores
            Excel.Range TitleRange;
            TitleRange = xlWorkSheet.get_Range("B7", "J7");
            TitleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            TitleRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            // Header 
            Excel.Range HdrRange;
            xlWorkSheet.get_Range("C2", "H3").Merge(false);
            HdrRange = xlWorkSheet.get_Range("C2", "H3");
            HdrRange.FormulaR1C1 = "REPORTE DE TIEMPO MUERTO CON DEPARTAMENTOS";
            HdrRange.Font.Size = 14;
            HdrRange.HorizontalAlignment = 3;
            HdrRange.VerticalAlignment = 3;
          // Fecha y Hora
          string localDate = DateTime.Now.ToString();
            Excel.Range HdrDate;
            xlWorkSheet.get_Range("C4", "H4").Merge(false);
            HdrDate = xlWorkSheet.get_Range("C4", "H4");
            HdrDate.FormulaR1C1 = localDate;
            HdrDate.Font.Size = 11;
            HdrDate.HorizontalAlignment = 3;
            HdrDate.VerticalAlignment = 3;
           



            // Textos
            //xlWorkSheet.Cells[Row, Col]
            xlWorkSheet.Cells[7, 2] = "AREA PRODUCTIVA";
            xlWorkSheet.Cells[7, 3] = "MAQUINA";
            xlWorkSheet.Cells[7, 4] = "TIEMPO PARO";
            xlWorkSheet.Cells[7, 5] = "TIEMPO RESPUESTA";
            xlWorkSheet.Cells[7, 6] = "INICIO";
            xlWorkSheet.Cells[7, 7] = "SOPORTE";
            xlWorkSheet.Cells[7, 8] = "FIN";
            xlWorkSheet.Cells[7, 9] = "MOTIVO";
            xlWorkSheet.Cells[7, 10] = "FALLA PREVIA";

            // Ancho de las columnas
            xlWorkSheet.Columns[1].ColumnWidth = 8;
            xlWorkSheet.Columns[2].ColumnWidth = 8;
            xlWorkSheet.Columns[3].ColumnWidth = 12;
            xlWorkSheet.Columns[4].ColumnWidth = 12;
            xlWorkSheet.Columns[5].ColumnWidth = 12;
            xlWorkSheet.Columns[6].ColumnWidth = 18;
            xlWorkSheet.Columns[7].ColumnWidth = 18;
            xlWorkSheet.Columns[8].ColumnWidth = 18;
            xlWorkSheet.Columns[9].ColumnWidth = 18;
            xlWorkSheet.Columns[10].ColumnWidth = 18;
            string fechaActual = localDate.Replace("/", "-");
            fechaActual = fechaActual.Replace(":", "-");
            fechaActual = fechaActual.Replace(" ", "-");
            fechaActual = fechaActual.Replace("a.-m.", "AM");
            fechaActual = fechaActual.Replace("p.-m.", "PM");
            xlWorkBook.SaveAs("C:\\inetpub\\wwwroot\\AndonReport\\xlsx\\" + argNombre, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            //MessageBox.Show(@"Excel file created!");
            this.Close();

        }

        private void genera_xlsx()
        {
            string path = System.IO.Directory.GetCurrentDirectory();

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Imagenes
            xlWorkSheet.Shapes.AddPicture("C:\\inetpub\\wwwroot\\AndonReport\\images\\logo.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 10, 5, 70, 70);
            xlWorkSheet.Shapes.AddPicture("C:\\inetpub\\wwwroot\\AndonReport\\images\\accelerate.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 450, 5, 110, 70);

            // Colores
            Excel.Range TitleRange;
            if (argTipoRep == "tipo_detallado")
                TitleRange = xlWorkSheet.get_Range("B7", "J7");
            else
                TitleRange = xlWorkSheet.get_Range("B7", "D7");
            TitleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            TitleRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            // Header 
            Excel.Range HdrRange;
            xlWorkSheet.get_Range("C2", "H3").Merge(false);
            HdrRange = xlWorkSheet.get_Range("C2", "H3");
            if (argTipoRep == "tipo_detallado")
                HdrRange.FormulaR1C1 = "REPORTE DE TIEMPO MUERTO CON DEPARTAMENTOS";
            else if (argTipoRep == "tipo_concentrado")
                HdrRange.FormulaR1C1 = "REPORTE DE TIEMPO MUERTO CONCENTRADO";
            else if (argTipoRep == "tipo_top5")
                HdrRange.FormulaR1C1 = "REPORTE DE TIEMPO MUERTO TOP 5";
            else if (argTipoRep == "tipo_top10")
                HdrRange.FormulaR1C1 = "REPORTE DE TIEMPO MUERTO TOP 10";
            HdrRange.Font.Size = 14;
            HdrRange.HorizontalAlignment = 3;
            HdrRange.VerticalAlignment = 3;

            // Fecha y Hora
            string localDate = DateTime.Now.ToString();
            Excel.Range HdrDate;
            xlWorkSheet.get_Range("C4", "H4").Merge(false);
            HdrDate = xlWorkSheet.get_Range("C4", "H4");
            HdrDate.FormulaR1C1 = localDate;
            HdrDate.Font.Size = 11;
            HdrDate.HorizontalAlignment = 3;
            HdrDate.VerticalAlignment = 3;


            // Textos
            //xlWorkSheet.Cells[Row, Col]
            if (argTipoRep == "tipo_detallado")
            {
                xlWorkSheet.Cells[7, 2] = "AREA PRODUCTIVA";
                xlWorkSheet.Cells[7, 3] = "MAQUINA";
                xlWorkSheet.Cells[7, 4] = "TIEMPO PARO";
                xlWorkSheet.Cells[7, 5] = "TIEMPO RESPUESTA";
                xlWorkSheet.Cells[7, 6] = "TIEMPO SOLUCION";
                xlWorkSheet.Cells[7, 7] = "INICIO";
                xlWorkSheet.Cells[7, 8] = "SOPORTE";
                xlWorkSheet.Cells[7, 9] = "FIN";
                xlWorkSheet.Cells[7, 10] = "MOTIVO";
              
                //xlWorkSheet.Cells[7, 10] = "FALLA PREVIA";
             

                // Ancho de las columnas
                xlWorkSheet.Columns[1].ColumnWidth = 15;
                xlWorkSheet.Columns[2].ColumnWidth = 12;
                xlWorkSheet.Columns[3].ColumnWidth = 12;
                xlWorkSheet.Columns[4].ColumnWidth = 12;
                xlWorkSheet.Columns[5].ColumnWidth = 12;
                xlWorkSheet.Columns[6].ColumnWidth = 12;
                xlWorkSheet.Columns[7].ColumnWidth = 22;
                xlWorkSheet.Columns[8].ColumnWidth = 22;
                xlWorkSheet.Columns[9].ColumnWidth = 22;
                xlWorkSheet.Columns[10].ColumnWidth = 20;
               
                //xlWorkSheet.Columns[10].ColumnWidth = 18;
            }
            else
            {
                xlWorkSheet.Cells[7, 2] = "AREA PRODUCTIVA";
                xlWorkSheet.Cells[7, 3] = "MAQUINA";
                xlWorkSheet.Cells[7, 4] = "TIEMPO PARO";

                xlWorkSheet.Columns[1].ColumnWidth = 10;
                xlWorkSheet.Columns[2].ColumnWidth = 18;
                xlWorkSheet.Columns[3].ColumnWidth = 15;
                xlWorkSheet.Columns[4].ColumnWidth = 18;
            }

            // Datos
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            string data = null;
            // Producción
            string server = txtServer.Text;
            string db = txtDb.Text;
            string usr = txtUsr.Text;
            string psw = txtPsw.Text;
            // Pruebas, laptop Luis
            /*
             *
            confServer = "DESKTOP-C6ELTSG";
            confDb = "MARS";
            confUsr = "sa";
            confPsw = "ikolor";
            */
            /* Variables disponibles
            confServer
            confDb
            confUsr
            confPsw
            argFecha1
            argFecha2
            argAreaProd
            argAreaSop
            argMaquina
            */
            int i = 0;
            int j = 0;
            int conteo = -2;
            connectionString = @"data source=" + confServer + ";initial catalog=" + confDb + ";user id=" + confUsr + ";password=" + confPsw + ";";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            // Producción //
            // Reporte Detallado
            if (argTipoRep == "tipo_detallado")
            {
                sql = "SELECT C.Area, A.DTUCODE, DATEDIFF(minute, A.START, A.CLOSED) AS TOTAL_TIME, DATEDIFF(minute, A.START, A.SUPP_DATE) AS WAIT_TIME, CAST(DATEDIFF(minute, A.START, A.CLOSED) AS int) - CAST(DATEDIFF(minute, A.START, A.SUPP_DATE) AS int) AS SOPORTE, A.START, A.SUPP_DATE, A.CLOSED, B.DESCR AS DESC_CODE, A.LAST_FAIL FROM FLD.ANDON_HIST A INNER JOIN FLD.ANDON_CODES B ON A.DT_CODE = B.CODE_ID INNER JOIN ANDON_MACH C ON A.DTUCODE = C.Maquina AND DATEDIFF(minute, A.START, A.CLOSED) > 0";
                if (argFecha1 != "" && argFecha2 != "")
                {
                    sql += " AND A.START BETWEEN '" + argFecha1 + "' AND '" + argFecha2 + "'";
                }
                if (argAreaSop != "0")
                {
                    sql += " AND B.CODE_ID = '" + argAreaSop + "'";
                }
                if (argMaquina != "0")
                {
                    sql += " AND A.DTUCODE = '" + argMaquina + "'";
                }
                if (argAreaProd != "0")
                {
                    sql += " AND C.Area = '" + argAreaProd + "'";
                }
                sql += " ORDER BY START";
            }

            int where_impreso = 0;
            // Reporte TOP y Concentrado
            if (argTipoRep == "tipo_top5" || argTipoRep == "tipo_top10" || argTipoRep == "tipo_concentrado")
            {
                if (argTipoRep == "tipo_top10")
                    sql = "SELECT TOP(10) Area, DTUCODE, SUM(TOTAL_TIME) AS SUM_TIME, Area FROM ANDON_REPORT_VIEW ";
                if (argTipoRep == "tipo_top5")
                    sql = "SELECT TOP(5) Area, DTUCODE, SUM(TOTAL_TIME) AS SUM_TIME, Area FROM ANDON_REPORT_VIEW ";
                if (argTipoRep == "tipo_concentrado")
                    sql = "SELECT Area, DTUCODE, SUM(TOTAL_TIME) AS SUM_TIME, Area FROM ANDON_REPORT_VIEW ";
                if (argFecha1 != "" && argFecha2 != "")
                {
                    if (where_impreso == 0)
                    {
                        sql += " WHERE ";
                        where_impreso = 1;
                    }
                    else
                    {
                        sql += " AND ";
                        where_impreso = 1;
                    }
                    sql += " START BETWEEN '" + argFecha1 + "' AND '" + argFecha2 + "'";
                }
                if (argAreaSop != "0")
                {
                    if (where_impreso == 0)
                    {
                        sql += " WHERE ";
                        where_impreso = 1;
                    }
                    else
                    {
                        sql += " AND ";
                        where_impreso = 1;
                    }
                    sql += " CODE_ID = '" + argAreaSop + "'";
                }
                if (argMaquina != "0")
                {
                    if (where_impreso == 0)
                    {
                        sql += " WHERE ";
                        where_impreso = 1;
                    }
                    else
                    {
                        sql += " AND ";
                        where_impreso = 1;
                    }
                    sql += " DTUCODE = '" + argMaquina + "'";
                }
                if (argAreaProd != "0")
                {
                    if (where_impreso == 0)
                    {
                        sql += " WHERE ";
                        where_impreso = 1;
                    }
                    else
                    {
                        sql += " AND ";
                        where_impreso = 1;
                    }
                    sql += " Area = '" + argAreaProd + "'";
                }
                sql += " GROUP BY Area, DTUCODE ORDER BY SUM_TIME DESC";

                //xlWorkSheet.Cells[7, 10] = sql;
                conteo = -1;
            }
            
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 2; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 8, j + 2] = data;
                }
            }

            // Nombre del xlsx
            //string localDate = DateTime.Now.ToString();
            string fechaActual = localDate.Replace("/", "-");
            fechaActual = fechaActual.Replace(":", "-");
            fechaActual = fechaActual.Replace(" ", "-");
            fechaActual = fechaActual.Replace("a.-m.", "AM");
            fechaActual = fechaActual.Replace("p.-m.", "PM");
            xlWorkBook.SaveAs("C:\\inetpub\\wwwroot\\AndonReport\\xlsx\\" + argNombre, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            //MessageBox.Show(@"Excel file created!");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            genera_xlsx();
        }

        
        private void MREA_Load(object sender, EventArgs e)
        {
            leerXmlConfig();
            leerXmlArgumentos();
            genera_xlsx();
        }

        private void leerXmlConfig()
        {
            string path = Application.StartupPath;
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\inetpub\\wwwroot\\AndonReport\\xml\\config.xml");
            XmlNode nodeServer = doc.DocumentElement.SelectSingleNode("/config/server");
            string xmlServer = nodeServer.InnerText;
            XmlNode nodeBd = doc.DocumentElement.SelectSingleNode("/config/bd");
            string xmlBd = nodeBd.InnerText;
            XmlNode nodeUser = doc.DocumentElement.SelectSingleNode("/config/user");
            string xmlUser = nodeUser.InnerText;
            XmlNode nodePass = doc.DocumentElement.SelectSingleNode("/config/pass");
            string xmlPass = nodePass.InnerText;
            confServer = xmlServer;
            confDb = xmlBd;
            confUsr = xmlUser;
            confPsw = xmlPass;
            txtServer.Text = xmlServer;
            txtDb.Text = xmlBd;
            txtUsr.Text = xmlUser;
            txtPsw.Text = xmlPass;
        }

        private void leerXmlArgumentos()
        {
            string path = Application.StartupPath;
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\inetpub\\wwwroot\\AndonReport\\xml\\xml_argumentos.xml");
            XmlNode nodeNombre = doc.DocumentElement.SelectSingleNode("/cuerpo/Nombre");
            string xmlNombre = nodeNombre.InnerText;
            XmlNode nodetr = doc.DocumentElement.SelectSingleNode("/cuerpo/TipoReporte");
            string xmltr = nodetr.InnerText;
            XmlNode nodett = doc.DocumentElement.SelectSingleNode("/cuerpo/TipoTop");
            string xmltt = nodett.InnerText;
            XmlNode nodef1 = doc.DocumentElement.SelectSingleNode("/cuerpo/Fecha1");
            string xmlf1 = nodef1.InnerText;
            XmlNode nodef2 = doc.DocumentElement.SelectSingleNode("/cuerpo/Fecha2");
            string xmlf2 = nodef2.InnerText;
            XmlNode nodeap = doc.DocumentElement.SelectSingleNode("/cuerpo/AreaProd");
            string xmlap = nodeap.InnerText;
            XmlNode nodeas = doc.DocumentElement.SelectSingleNode("/cuerpo/AreaSop");
            string xmlas = nodeas.InnerText;
            XmlNode nodemaquina = doc.DocumentElement.SelectSingleNode("/cuerpo/Maquina");
            string xmlmaquina = nodemaquina.InnerText;
            XmlNode nodeturno = doc.DocumentElement.SelectSingleNode("/cuerpo/Turno");
            string xmlturno = nodeturno.InnerText;
            argNombre = xmlNombre;
            argTipoRep = xmltr;
            argTipoTop = xmltt;
            argFecha1 = xmlf1;
            argFecha2 = xmlf2;
            argAreaProd = xmlap;
            argAreaSop = xmlas;
            argMaquina = xmlmaquina;
            argTurno = xmlturno;
            txtTipoRep.Text = argTipoRep;
            txtTipoTop.Text = argTipoTop;
            txtFecha1.Text = argFecha1;
            txtFecha2.Text = argFecha2;
            txtAreaProd.Text = argAreaProd;
            txtAreaSop.Text = argAreaSop;
            txtMaquina.Text = argMaquina;
            txtNombre.Text = argNombre;
            txtTurno.Text = argTurno;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //prueba_conexion();
            genera_diseno();
        }
    }
}
