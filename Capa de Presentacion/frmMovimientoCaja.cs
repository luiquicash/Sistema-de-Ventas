using CapaLogicaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Capa_de_Presentacion
{
    public partial class frmMovimientoCaja : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmMovimientoCaja()
        {
            InitializeComponent();
        }

        clsCx Cx = new clsCx();
        private void frmMovimientoCaja_Load(object sender, EventArgs e)
        {
            llenarid();
            llenar_data();
            llenar_datagastos();
            llenar();
        }

        public void llenarid()
        {
            string cadSql = "select top(1) id_caja,monto_inicial from Caja order by id_caja desc";

            SqlCommand comando = new SqlCommand(cadSql, Cx.conexion);
            Cx.conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                txtmonto_inicial.Text = leer["monto_inicial"].ToString();
                txtBuscarCaja.Text = leer["id_caja"].ToString();
            }
            Cx.conexion.Close();
        }

        public void llenar_datagastos()
        {
            decimal gastos = 0;
            //declaramos la cadena  de conexion
            string cadenaconexion = Cx.conet;
            //variable de tipo Sqlconnection
            SqlConnection con = new SqlConnection();
            //variable de tipo Sqlcommand
            SqlCommand comando = new SqlCommand();
            //variable SqlDataReader para leer los datos
            SqlDataReader dr;
            con.ConnectionString = cadenaconexion;
            comando.Connection = con;
            //declaramos el comando para realizar la busqueda
            comando.CommandText = "select id,monto,descripcion,fecha from Gastos WHERE fecha = convert(datetime,CONVERT(varchar(10), getdate(), 103),103)";
            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            con.Open();
            //limpiamos los renglones de la datagridview
            dataGridView2.Rows.Clear();
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                int renglon = dataGridView2.Rows.Add();
                // especificamos en que fila se mostrará cada registro
                // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\
                dataGridView2.Rows[renglon].Cells["id"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("id")));
                dataGridView2.Rows[renglon].Cells["descripcion"].Value = dr.GetString(dr.GetOrdinal("descripcion"));
                dataGridView2.Rows[renglon].Cells["montogasto"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("monto")));

                gastos += Math.Round(Convert.ToDecimal(dataGridView2.Rows[renglon].Cells["montogasto"].Value), 2);
            }

            lbldeu.Text = gastos.ToString();
            con.Close();
        }
        public void llenar_data()
        {
            decimal devuelta = 0, pagos = 0;
            int idcajaActual = 0;
            if (txtBuscarCaja.Text != "")
            {
                idcajaActual = Convert.ToInt32(txtBuscarCaja.Text);
            }
            //declaramos la cadena  de conexion
            string cadenaconexion = Cx.conet;
            //variable de tipo Sqlconnection
            SqlConnection con = new SqlConnection();
            //variable de tipo Sqlcommand
            SqlCommand comando = new SqlCommand();
            //variable SqlDataReader para leer los datos
            SqlDataReader dr;
            con.ConnectionString = cadenaconexion;
            comando.Connection = con;
            //declaramos el comando para realizar la busqueda
            comando.CommandText = "select id_caja,id_pago,monto,ingresos,egresos from Pagos WHERE dbo.Pagos.id_caja =" + idcajaActual;
            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            con.Open();
            //limpiamos los renglones de la datagridview
            dataGridView1.Rows.Clear();
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                int renglon = dataGridView1.Rows.Add();
                // especificamos en que fila se mostrará cada registro
                // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\
                //pagos
                dataGridView1.Rows[renglon].Cells["id_caja"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("id_caja")));
                dataGridView1.Rows[renglon].Cells["id_pago"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("id_pago")));
                dataGridView1.Rows[renglon].Cells["monto"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("monto")));
                dataGridView1.Rows[renglon].Cells["ingresos"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("ingresos")));
                dataGridView1.Rows[renglon].Cells["egresos"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("egresos")));

                devuelta += Math.Round(Convert.ToDecimal(dataGridView1.Rows[renglon].Cells["egresos"].Value), 2);
                pagos += Math.Round(Convert.ToDecimal(dataGridView1.Rows[renglon].Cells["ingresos"].Value), 2);
            }

            lblegr.Text = devuelta.ToString();
            lbling.Text = pagos.ToString();

            con.Close();
        }

        public void llenar()
        {
            string cadSql = "select * from NomEmp";

            SqlCommand comando = new SqlCommand(cadSql, Cx.conexion);
            Cx.conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                lblDir.Text = leer["DirEmp"].ToString();
                lblLogo.Text = leer["NombreEmp"].ToString();
            }
            Cx.conexion.Close();
        }
        private void To_pdf()
        {
            Document doc = new Document(PageSize.LETTER, 10f, 10f, 10f, 0f);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance("LogoCepeda.png");
            image1.ScaleAbsoluteWidth(140);
            image1.ScaleAbsoluteHeight(70);
            saveFileDialog1.InitialDirectory = @"C:";
            saveFileDialog1.Title = "Guardar Reporte";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string filename = "Reporte de Movimiento de Caja" + DateTime.Now.ToString();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                if (filename.Trim() != "")
                {
                    FileStream file = new FileStream(filename,
                    FileMode.OpenOrCreate,
                    FileAccess.ReadWrite,
                    FileShare.ReadWrite);
                    PdfWriter.GetInstance(doc, file);
                    doc.Open();
                    string remito = lblLogo.Text;
                    string ubicado = lblDir.Text;
                    string envio = "Fecha : " + DateTime.Now.ToString();

                    Chunk chunk = new Chunk(remito, FontFactory.GetFont("ARIAL", 16, iTextSharp.text.Font.BOLD, color: BaseColor.BLUE));
                    doc.Add(new Paragraph("                                                                                                                                                                                                                                                     " + envio, FontFactory.GetFont("ARIAL", 7, iTextSharp.text.Font.ITALIC)));
                    doc.Add(image1);
                    doc.Add(new Paragraph(chunk));
                    doc.Add(new Paragraph(ubicado, FontFactory.GetFont("ARIAL", 9, iTextSharp.text.Font.NORMAL)));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Reporte de Movimientos de Caja                      "));
                    doc.Add(new Paragraph("                       "));
                    GenerarDocumento(doc);
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Reporte de Gastos del Dia                           "));
                    doc.Add(new Paragraph("                       "));
                    GenerarDocumentogastos(doc);
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Totales de Pagos :" + lbling.Text));
                    doc.Add(new Paragraph("Totales de Gastos :" + lbldeu.Text));
                    doc.Add(new Paragraph("Totales Final :" + lbltotal.Text));
                    doc.AddCreationDate();
                    doc.Close();
                    Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
                }
            }
            else
            {
                MessageBox.Show("No guardo el Archivo");
            }
        }
        public void GenerarDocumento(Document document)
        {
            int i, j;
            PdfPTable datatable = new PdfPTable(dataGridView1.ColumnCount);
            float[] headerwidths = GetTamañoColumnas(dataGridView1);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            for (i = 0; i < dataGridView1.ColumnCount; i++)
            {
                datatable.AddCell(new Phrase(dataGridView1.Columns[i].HeaderText, FontFactory.GetFont("ARIAL", 7, iTextSharp.text.Font.BOLD)));
            }
            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 1;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1[j, i].Value != null)
                    {
                        datatable.AddCell(new Phrase(dataGridView1[j, i].Value.ToString(), FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
                    }
                }
                datatable.CompleteRow();
            }
            document.Add(datatable);
        }
        public void GenerarDocumentogastos(Document document)
        {
            int i, j;
            PdfPTable datatable = new PdfPTable(dataGridView2.ColumnCount);
            float[] headerwidths = GetTamañoColumnas(dataGridView2);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            for (i = 0; i < dataGridView2.ColumnCount; i++)
            {
                datatable.AddCell(new Phrase(dataGridView2.Columns[i].HeaderText, FontFactory.GetFont("ARIAL", 7, iTextSharp.text.Font.BOLD)));
            }
            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 1;
            for (i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    if (dataGridView2[j, i].Value != null)
                    {
                        datatable.AddCell(new Phrase(dataGridView2[j, i].Value.ToString(), FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
                    }
                }
                datatable.CompleteRow();
            }
            document.Add(datatable);
        }

        public float[] GetTamañoColumnasgastos(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;
        }

        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            To_pdf();
        }

        private void frmMovimientoCaja_Activated(object sender, EventArgs e)
        {
            decimal gastos = 0;
            decimal pagos = 0;
            decimal devuelta = 0;
            decimal total = 0;

            if (lbling.Text != "...")
            {
                pagos = Convert.ToDecimal(lbling.Text);
            }

            if (lblegr.Text != "...")
            {
                devuelta = Convert.ToDecimal(lblegr.Text);
            }

            if (lbldeu.Text != "...")
            {
                gastos = Convert.ToDecimal(lbldeu.Text);
            }

            total = pagos - gastos;

            lbltotal.Text = total.ToString();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            Program.idgastos = Convert.ToInt32(dataGridView2.CurrentRow.Cells["id"].Value.ToString());
            txtdescripciondegasto.Text = dataGridView2.CurrentRow.Cells["descripcion"].Value.ToString();
            txtmontogasto.Text = dataGridView2.CurrentRow.Cells["montogasto"].Value.ToString();
        }

        private void txtBuscarCaja_TextChanged(object sender, EventArgs e)
        {
            llenar_data();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Program.abiertosecundarias = false;
            Program.abierto = false;
            limpiar();
            this.Close();
        }

        public void limpiar()
        {
            Program.idgastos = 0;
            txtdescripciondegasto.Text = "";
            txtmontogasto.Text = "";
            dataGridView2.Rows.Clear();
        }
        private void agregargasto_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Cx.conet))
            {
                using (SqlCommand cmd = new SqlCommand("RegistrarGasto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //tabla gastos
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Program.idgastos;
                    cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = txtdescripciondegasto.Text;
                    cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = Convert.ToDecimal(txtmontogasto.Text);
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Today;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    limpiar();
                    llenar_datagastos();
                    MessageBox.Show("Gasto Registrado");
                }
            }
        }
    }
}
