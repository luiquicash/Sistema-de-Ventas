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
    public partial class cuadredecaja : Form
    {
        public cuadredecaja()
        {
            InitializeComponent();
        }
        clsCx Cx = new clsCx();
        Correo c = new Correo();
        public void limpiar()
        {
            txtde5.Text = "";
            txtde10.Text = "";
            txtde25.Text = "";
            txtde50.Text = "";
            txtde100.Text = "";
            txtde200.Text = "";
            txtde500.Text = "";
            txtde1000.Text = "";
            txtde2000.Text = "";

            txtde5.ReadOnly = false;
            txtde10.ReadOnly = false;
            txtde25.ReadOnly = false;
            txtde50.ReadOnly = false;
            txtde100.ReadOnly = false;
            txtde200.ReadOnly = false;
            txtde500.ReadOnly = false;
            txtde1000.ReadOnly = false;
            txtde2000.ReadOnly = false;

            lbldeudas.Text = "";
            lblmontocuadre.Text = "";
            lblmontocaja.Text = "";
            lblmontoingreso.Text = "";
            lblmontogasto.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }
        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblmontocuadre.Text))
            {
                decimal montofinal = Convert.ToDecimal(lblmontocuadre.Text);
                using (SqlConnection con = new SqlConnection(Cx.conet))
                {
                    using (SqlCommand cmd = new SqlCommand("Registrarcuadre", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //tabla cuadre
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(lblidcaja.Text);
                        cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = txtde5.Text + "," + txtde10.Text + "," + txtde25.Text + ","
                            + txtde50.Text + "," + txtde100.Text + "," + txtde200.Text + "," + txtde500.Text + "," + txtde1000.Text + "," + txtde2000.Text;
                        cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = montofinal;
                        cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Today;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        To_pdf();
                        limpiar();
                        label18.Enabled = true;
                        MessageBox.Show("Cuadre Registrado");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe darle al boton de Sumar antes de registrar un nuevo Cuadre");
            }
        }
        public void llenardeudas(int id)
        {
            string cadSql = "select deuda from Caja where id_caja =" + id;

            SqlCommand comando = new SqlCommand(cadSql, Cx.conexion);
            Cx.conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                var deuda = Math.Round(Convert.ToDecimal(leer["deuda"].ToString()));
                lbldeudas.Text = deuda.ToString();
            }
            Cx.conexion.Close();
        }
        private void agregargasto_Click(object sender, EventArgs e)
        {
            limpiar();
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
            comando.CommandText = "Select * From Cuadre where fecha = convert(datetime,CONVERT(varchar(10), @fecha, 103),103)";
            comando.Parameters.AddWithValue("@fecha", dpkfechacuadre.Value);
            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            con.Open();
            //limpiamos los renglones de la datagridview
            dataGridView1.Rows.Clear();
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                limpiar();
                MessageBox.Show("No tiene ningún cuadre registrado en esta Fecha");
            }
            //el ciclo while se ejecutará mientras lea registros en la tabla
            while (dr.Read())
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                int renglon = dataGridView1.Rows.Add();
                // especificamos en que fila se mostrará cada registro
                // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

                dataGridView1.Rows[renglon].Cells[0].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("id")));
                dataGridView1.Rows[renglon].Cells[1].Value = dr.GetString(dr.GetOrdinal("descripcion"));
                dataGridView1.Rows[renglon].Cells[2].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("monto")));
                dataGridView1.Rows[renglon].Cells[3].Value = dr.GetDateTime(dr.GetOrdinal("fecha"));

                llenargridpagos(Convert.ToInt32(dataGridView1.Rows[renglon].Cells[0].Value));
                llenar(Convert.ToInt32(dataGridView1.Rows[renglon].Cells[0].Value));
                llenardeudas(Convert.ToInt32(dataGridView1.Rows[renglon].Cells[0].Value));
                llenargastos();

                string desglose = dr.GetString(dr.GetOrdinal("descripcion"));
                if (desglose != "")
                {
                    var marca = desglose;
                    string cadena = marca;
                    char delimitador = ',';
                    string[] valores = cadena.Split(delimitador);

                    txtde5.Text = valores[0];
                    txtde10.Text = valores[1];
                    txtde25.Text = valores[2];
                    txtde50.Text = valores[3];
                    txtde100.Text = valores[4];
                    txtde200.Text = valores[5];
                    txtde500.Text = valores[6];
                    txtde1000.Text = valores[7];
                    txtde2000.Text = valores[8];
                }

                txtde5.ReadOnly = true;
                txtde10.ReadOnly = true;
                txtde25.ReadOnly = true;
                txtde50.ReadOnly = true;
                txtde100.ReadOnly = true;
                txtde200.ReadOnly = true;
                txtde500.ReadOnly = true;
                txtde1000.ReadOnly = true;
                txtde2000.ReadOnly = true;

                lblmontocuadre.Text = dr.GetDecimal(dr.GetOrdinal("monto")).ToString();

                btnregistrar.Visible = false;
                btnimprimir.Visible = true;
                btnsuma.Visible = false;
            }

            con.Close();
        }
        public void llenargridpagos(int id)
        {
            decimal pagos = 0, devuelta = 0;
            //declar=0amos la cadena  de conexion
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
            comando.CommandText = "select id_caja,id_pago,monto,ingresos,egresos From Pagos WHERE id_caja =" + id;
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
                //pagos
                dataGridView2.Rows[renglon].Cells["id_caja"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("id_caja")));
                dataGridView2.Rows[renglon].Cells["id_pago"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("id_pago")));
                dataGridView2.Rows[renglon].Cells["montoventa"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("monto")));
                dataGridView2.Rows[renglon].Cells["ingresos"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("ingresos")));
                dataGridView2.Rows[renglon].Cells["egresos"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("egresos")));
                if (Convert.ToInt32(dataGridView2.Rows[renglon].Cells["id_caja"].Value) == id)
                {
                    pagos += Math.Round(Convert.ToDecimal(dataGridView2.Rows[renglon].Cells["ingresos"].Value), 2);
                    devuelta += Math.Round(Convert.ToDecimal(dataGridView2.Rows[renglon].Cells["egresos"].Value), 2);
                }
            }

            lblmontoingreso.Text = Math.Round(Convert.ToDecimal(pagos)).ToString();
            con.Close();
        }

        public void llenar(int id)
        {
            string cadSql = "select montoactual, monto_inicial from Caja where id_caja=" + id;

            SqlCommand comando = new SqlCommand(cadSql, Cx.conexion);
            Cx.conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                decimal montogasto = 0;
                var montoactual = Math.Round(Convert.ToDecimal(leer["montoactual"].ToString())).ToString();
                lblmontoinicial.Text = Math.Round(Convert.ToDecimal(leer["monto_inicial"].ToString())).ToString();

                if (lblmontogasto.Text != "")
                {
                    montogasto = Math.Round(Convert.ToDecimal(lblmontogasto.Text));
                }

                lblmontocaja.Text = Math.Round(Convert.ToDecimal(montoactual) - montogasto).ToString();
            }

            Cx.conexion.Close();
        }

        public void llenargastos()
        {
            decimal totalgasto = 0;
            string cadSql = "select * from Gastos where fecha = convert(datetime,CONVERT(varchar(10), @fecha, 103),103)";
            SqlCommand comando = new SqlCommand(cadSql, Cx.conexion);
            comando.Parameters.AddWithValue("@fecha", dpkfechacuadre.Value);
            Cx.conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                var monto = leer["monto"].ToString();
                totalgasto += Convert.ToDecimal(monto);
            }

            lblmontogasto.Text = Math.Round(totalgasto).ToString();

            Cx.conexion.Close();
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            To_pdf();
            limpiar();
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
            string filename = "Reporte de Cuadre de Caja";
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
                    string envio = "Fecha : " + +DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;

                    Chunk chunk = new Chunk(remito, FontFactory.GetFont("ARIAL", 16, iTextSharp.text.Font.BOLD, color: BaseColor.BLUE));
                    var fecha = new Paragraph(envio, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.ITALIC));
                    fecha.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(fecha);
                    image1.Alignment = Image.TEXTWRAP | Image.ALIGN_CENTER;
                    doc.Add(image1);
                    var chuckalign = new Paragraph(chunk);
                    chuckalign.Alignment = Element.ALIGN_CENTER;
                    doc.Add(chuckalign);
                    var ubicacionalign = new Paragraph(ubicado, FontFactory.GetFont("ARIAL", 9, iTextSharp.text.Font.NORMAL));
                    ubicacionalign.Alignment = Element.ALIGN_CENTER;
                    doc.Add(ubicacionalign);

                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Reporte de Cuadre de Caja"));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Total de Modenas de 5       : " + txtde5.Text));
                    doc.Add(new Paragraph("Total de Modenas de 10     : " + txtde10.Text));
                    doc.Add(new Paragraph("Total de Modenas de 25     : " + txtde25.Text));
                    doc.Add(new Paragraph("Total de Billetes de 50        : " + txtde50.Text));
                    doc.Add(new Paragraph("Total de Billetes de 100      : " + txtde100.Text));
                    doc.Add(new Paragraph("Total de Billetes de 200      : " + txtde200.Text));
                    doc.Add(new Paragraph("Total de Billetes de 500      : " + txtde500.Text));
                    doc.Add(new Paragraph("Total de Billetes de 1000    : " + txtde1000.Text));
                    doc.Add(new Paragraph("Total de Billetes de 2000    : " + txtde2000.Text));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Totales de Ingresos  : " + lblmontoingreso.Text));
                    doc.Add(new Paragraph("Totales de Gastos    : " + lblmontogasto.Text));
                    doc.Add(new Paragraph("Totales Final             : " + lblmontocuadre.Text));
                    doc.Add(new Paragraph("Totales De Deudas del dia : " + lbldeudas.Text));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph(lblmensaje.Text, FontFactory.GetFont("ARIAL", 10, iTextSharp.text.Font.NORMAL)));
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
        public void llenarid()
        {
            string cadSql = "select top(1) id_caja,deuda from Caja order by id_caja desc";

            SqlCommand comando = new SqlCommand(cadSql, Cx.conexion);
            Cx.conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                lbldeudas.Text = Math.Round(Convert.ToDecimal(leer["deuda"])).ToString();
                lblidcaja.Text = leer["id_caja"].ToString();
            }
            Cx.conexion.Close();
        }
        private void cuadredecaja_Load(object sender, EventArgs e)
        {
            int idcajaa = 0;
            label18.Enabled = false;
            btnregistrar.Enabled = false;
            btnsuma.Visible = true;

            llenarid();
            if (lblidcaja.Text != "")
            {
                idcajaa = Convert.ToInt32(lblidcaja.Text);
            }

            llenargastos();
            if (idcajaa > 0)
            {
                llenargridpagos(idcajaa);
                llenar(idcajaa);
            }

            btnimprimir.Visible = false;
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Program.abiertosecundarias = false;
            Program.abierto = false;
            if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Desea realizar una copia de seguridad de la base de datos?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                ////////////////////Borrar copia de seguridad de base de datos anterior
                string direccion = @"C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Backup\SalesSystem.bak";
                File.Delete(direccion);

                ////////////////////Creando copia de seguridad de base de datos nueva
                string comand_query = "BACKUP DATABASE [SalesSystem] TO  DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL12.MSSQLSERVER\\MSSQL\\Backup\\SalesSystem.bak'WITH NOFORMAT, NOINIT,  NAME = N'SalesSystem-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                SqlCommand comando = new SqlCommand(comand_query, Cx.conexion);
                try
                {
                    Cx.conexion.Open();
                    comando.ExecuteNonQuery();

                    ////////////////////Enviando al correo copia de seguridad de base de datos nueva
                    //c.enviarCorreo("sendingsystembackup@gmail.com", "evitarperdidadedatos/0", "Realizando la creación diaria de respaldo de base de datos para evitar perdidas de datos en caso de algún problema con el equipo.",
                    //    "Backup de base de datos" + DateTime.Now, "ferreteriaalmontekm13@gmail.com", direccion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
                finally
                {
                    Cx.conexion.Close();
                    Cx.conexion.Dispose();
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.Show();
            this.Close();
        }

        private void txtde5_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void btnsuma_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            decimal ingresos = 0;
            decimal gastos = 0;

            if (lblmontogasto.Text != "...")
            {
                gastos = Math.Round(Convert.ToDecimal(lblmontogasto.Text));
            }

            if (lblmontoingreso.Text != "...")
            {
                ingresos = Math.Round(Convert.ToDecimal(lblmontoingreso.Text));
            }

            decimal cuadre = ingresos - gastos;

            if (lbldeudas.Text == "")
            {
                txtde2000.Text = "0";
            }
            if (txtde5.Text == "")
            {
                txtde5.Text = "0";
            }
            if (txtde10.Text == "")
            {
                txtde10.Text = "0";
            }
            if (txtde25.Text == "")
            {
                txtde25.Text = "0";
            }
            if (txtde50.Text == "")
            {
                txtde50.Text = "0";
            }
            if (txtde100.Text == "")
            {
                txtde100.Text = "0";
            }
            if (txtde200.Text == "")
            {
                txtde200.Text = "0";
            }
            if (txtde500.Text == "")
            {
                txtde500.Text = "0";
            }
            if (txtde1000.Text == "")
            {
                txtde1000.Text = "0";
            }
            if (txtde2000.Text == "")
            {
                txtde2000.Text = "0";
            }

            total = Math.Round((5 * decimal.Parse(txtde5.Text)) + (10 * decimal.Parse(txtde10.Text)) + (25 * decimal.Parse(txtde25.Text)) +
                (50 * decimal.Parse(txtde50.Text)) + (100 * decimal.Parse(txtde100.Text)) + (200 * decimal.Parse(txtde200.Text)) + (500 * decimal.Parse(txtde500.Text)) +
                (1000 * decimal.Parse(txtde1000.Text)) + (2000 * decimal.Parse(txtde2000.Text)) + Convert.ToDecimal(lblmontoinicial.Text));

            if (cuadre < total)
            {
                var sobrantes = total - cuadre;
                lblmensaje.Text = "Cuadre excitoso Sobran : \n" + sobrantes + " Pesos";
                lblmensaje.ForeColor = System.Drawing.Color.White;
                btnregistrar.Enabled = true;
            }

            else if (cuadre == total)
            {
                lblmensaje.Text = "Cuadre exacto";
                lblmensaje.ForeColor = System.Drawing.Color.MidnightBlue;
                btnregistrar.Enabled = true;
            }
            else
            {
                var faltantes = cuadre - total;
                lblmensaje.Text = "Cuadre defectuoso, Faltan : \n" + faltantes + " Pesos";
                lblmensaje.ForeColor = System.Drawing.Color.Yellow;
                btnregistrar.Enabled = false;
            }

            lblmontocuadre.Text = total.ToString();
        }
    }
}