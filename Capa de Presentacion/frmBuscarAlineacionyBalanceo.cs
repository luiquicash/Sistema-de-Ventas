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
    public partial class FrmBuscarAlineacionyBalanceo : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FrmBuscarAlineacionyBalanceo()
        {
            InitializeComponent();
        }

        clsCx Cx = new clsCx();
        public void limpiar()
        {
            txttotalG.Clear();
            dataGridView1.Rows.Clear();
        }

        public void cargardata()
        {
            double total = 0;
            //declaramos la cadena  de conexion
            string cadenaconexion = Cx.conet;
            //variable de tipo Sqlconnection
            SqlConnection conexion = new SqlConnection();
            //variable de tipo Sqlcommand
            SqlCommand comando = new SqlCommand();
            //variable SqlDataReader para leer los datos
            SqlDataReader dr;
            conexion.ConnectionString = cadenaconexion;
            comando.Connection = conexion;
            if (textBox1.Text != "")
            {
                //declaramos el comando para realizar la busqueda
                comando.CommandText = "select * from Cliente where Nombres like '%" + textBox1.Text.ToUpper() + "%' or Apellidos like '%" + textBox1.Text.ToUpper() + "%'  and ProximaFechaPago <= convert(datetime,CONVERT(varchar(10), @fecha, 103),103)";
                comando.Parameters.AddWithValue("@fecha", dtpfecha1.Value);
            }
            else
            {
                //declaramos el comando para realizar la busqueda
                comando.CommandText = "select * from Cliente where ProximaFechaPago <= convert(datetime,CONVERT(varchar(10), @fecha, 103),103)";
                comando.Parameters.AddWithValue("@fecha", dtpfecha1.Value);
            }
            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            conexion.Open();
            //limpiamos los renglones de la datagridview
            dataGridView1.Rows.Clear();
            txttotalG.Text = Convert.ToString(0);
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                int renglon = dataGridView1.Rows.Add();

                // especificamos en que fila se mostrará cada registro
                // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\
                dataGridView1.Rows[renglon].Cells["id"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdCliente")));
                dataGridView1.Rows[renglon].Cells["tipopago"].Value = dr.GetString(dr.GetOrdinal("TipoPago"));
                dataGridView1.Rows[renglon].Cells["nombre"].Value = dr.GetString(dr.GetOrdinal("Nombres"));
                dataGridView1.Rows[renglon].Cells["apellido"].Value = dr.GetString(dr.GetOrdinal("Apellidos"));
                dataGridView1.Rows[renglon].Cells["Tiempo"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("tiempo")));
                dataGridView1.Rows[renglon].Cells["pago"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("monto")));
                dataGridView1.Rows[renglon].Cells["fecha"].Value = dr.GetDateTime(dr.GetOrdinal("ProximaFechaPago"));

                total += Convert.ToDouble(dataGridView1.Rows[renglon].Cells["pago"].Value);
                txttotalG.Text = Convert.ToString(total);
            }
            conexion.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Program.nombre4 = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
            Program.apellido4 = dataGridView1.CurrentRow.Cells["apellido"].Value.ToString();
            Program.tipopago4 = dataGridView1.CurrentRow.Cells["tipopago"].Value.ToString();
            Program.fecha4 = dataGridView1.CurrentRow.Cells["fecha"].Value.ToString();
            Program.total4 = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["pago"].Value.ToString());
            Program.Id4 = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());

            frmAlineamiento pago = new frmAlineamiento();
            pago.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Program.abiertosecundarias = false;
            Program.abierto = false;
            this.Close();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cargardata();
        }
        public void cargar_combo_Tipo(ComboBox tipo)
        {
            SqlCommand cm = new SqlCommand("CARGARcomboPago", Cx.conexion);
            cm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbtipo.DisplayMember = "descripcion";
            cbtipo.ValueMember = "id";
            cbtipo.DataSource = dt;
        }

        public void buscarporfecha()
        {
            double total = 0;
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
            comando.CommandText = "select * from Cliente where ProximaFechaPago  <=  convert(datetime,CONVERT(varchar(10), @fecha, 103),103)";
            comando.Parameters.AddWithValue("@fecha", dtpfecha1.Value);
            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            con.Open();
            //limpiamos los renglones de la datagridview
            dataGridView1.Rows.Clear();
            txttotalG.Text = Convert.ToString(0);
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                int renglon = dataGridView1.Rows.Add();

                // especificamos en que fila se mostrará cada registro
                // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\
                dataGridView1.Rows[renglon].Cells["id"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdCliente")));
                dataGridView1.Rows[renglon].Cells["tipopago"].Value = dr.GetString(dr.GetOrdinal("TipoPago"));
                dataGridView1.Rows[renglon].Cells["nombre"].Value = dr.GetString(dr.GetOrdinal("Nombres"));
                dataGridView1.Rows[renglon].Cells["apellido"].Value = dr.GetString(dr.GetOrdinal("Apellidos"));
                dataGridView1.Rows[renglon].Cells["Tiempo"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("tiempo")));
                dataGridView1.Rows[renglon].Cells["pago"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("monto")));
                dataGridView1.Rows[renglon].Cells["fecha"].Value = dr.GetDateTime(dr.GetOrdinal("ProximaFechaPago"));

                total += Convert.ToDouble(dataGridView1.Rows[renglon].Cells["pago"].Value);
                txttotalG.Text = Convert.ToString(total);
            }
            con.Close();
        }
        private void frmBuscarAlineacionyBalanceo_Load(object sender, EventArgs e)
        {
            txttotalG.Text = Convert.ToString(0);
            cargardata();
            cargar_combo_Tipo(cbtipo);
            cbtipo.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            To_pdf();
        }
        private void To_pdf()
        {
            Document doc = new Document(PageSize.LETTER, 10f, 10f, 10f, 0f);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance("LogoCepeda.png");
            image1.ScaleAbsoluteWidth(100);
            image1.ScaleAbsoluteHeight(50);
            saveFileDialog1.InitialDirectory = @"C:";
            saveFileDialog1.Title = "Guardar Reporte";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string filename = "Reporte" + DateTime.Now.ToString();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
            }

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
                doc.Add(new Paragraph("Reporte de Listado de Pagos Pendientes                       "));
                doc.Add(new Paragraph("                       "));
                GenerarDocumento(doc);
                doc.AddCreationDate();
                doc.Add(new Paragraph("                       "));
                doc.Add(new Paragraph("Total de Ventas      : " + txttotalG.Text));
                doc.Add(new Paragraph("                       "));
                doc.Add(new Paragraph("____________________________________"));
                doc.Add(new Paragraph("                         Firma              "));
                doc.Close();
                Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
            }
        }
        public void GenerarDocumento(Document document)
        {
            int i, j;
            PdfPTable datatable = new PdfPTable(dataGridView1.ColumnCount);
            datatable.DefaultCell.Padding = 3;
            float[] headerwidths = GetTamañoColumnas(dataGridView1);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            for (i = 0; i < dataGridView1.ColumnCount; i++)
            {
                datatable.AddCell(dataGridView1.Columns[i].HeaderText);
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
        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;
        }

        private void agregargasto_Click(object sender, EventArgs e)
        {
            buscarporfecha();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double total = 0;
            //declaramos la cadena  de conexion
            string cadenaconexion = Cx.conet;
            //variable de tipo Sqlconnection
            SqlConnection conexion = new SqlConnection();
            //variable de tipo Sqlcommand
            SqlCommand comando = new SqlCommand();
            //variable SqlDataReader para leer los datos
            SqlDataReader dr;
            conexion.ConnectionString = cadenaconexion;
            comando.Connection = conexion;
            //declaramos el comando para realizar la busqueda
            comando.CommandText = "select * from Cliente where TipoPago like '%" + cbtipo.Text + "%' AND ProximaFechaPago  <=  convert(datetime,CONVERT(varchar(10), @fecha, 103),103)";
            comando.Parameters.AddWithValue("@fecha", dtpfecha1.Value);
            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            conexion.Open();
            //limpiamos los renglones de la datagridview
            dataGridView1.Rows.Clear();
            txttotalG.Text = Convert.ToString(0);
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                int renglon = dataGridView1.Rows.Add();

                // especificamos en que fila se mostrará cada registro
                // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\
                dataGridView1.Rows[renglon].Cells["id"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdCliente")));
                dataGridView1.Rows[renglon].Cells["tipopago"].Value = dr.GetString(dr.GetOrdinal("TipoPago"));
                dataGridView1.Rows[renglon].Cells["nombre"].Value = dr.GetString(dr.GetOrdinal("Nombres"));
                dataGridView1.Rows[renglon].Cells["apellido"].Value = dr.GetString(dr.GetOrdinal("Apellidos"));
                dataGridView1.Rows[renglon].Cells["Tiempo"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("tiempo")));
                dataGridView1.Rows[renglon].Cells["pago"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("monto")));
                dataGridView1.Rows[renglon].Cells["fecha"].Value = dr.GetDateTime(dr.GetOrdinal("ProximaFechaPago"));

                total += Convert.ToDouble(dataGridView1.Rows[renglon].Cells["pago"].Value);
                txttotalG.Text = Convert.ToString(total);
            }
            conexion.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cargardata();
        }
    }
}
