using CapaLogicaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Capa_de_Presentacion
{
    public partial class frmAlineamiento : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmAlineamiento()
        {
            InitializeComponent();
        }

        clsCx Cx = new clsCx();
        public void cargar_combo_Tipo(ComboBox tipo)
        {
            SqlCommand cm = new SqlCommand("CARGARcomboTipotrabajo", Cx.conexion);
            cm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            tipo.DisplayMember = "descripcion";
            tipo.ValueMember = "id";
            tipo.DataSource = dt;
        }


        public void clean()
        {
            Program.pagoRealizado = 0;
            Program.Id4 = 0;
            Program.fecha4 = "";
            Program.pago4 = 0;
            Program.nota = "";
            Program.nombre4 = "";
            Program.apellido4 = "";
            Program.tipopago4 = "";
            txttipopago.Text = "";
            txtTotal.Clear();
            txtnombre.Clear();
            txttipopago.Clear();
            txtapellido.Clear();
            Program.realizopago = false;
            Program.ReImpresion = "";
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            FrmBuscarAlineacionyBalanceo C = new FrmBuscarAlineacionyBalanceo();
            C.Show();
        }

        private void frmTaller_Activated(object sender, EventArgs e)
        {
            txtapellido.Text = Program.apellido4;
            txttipopago.Text = Program.tipopago4;
            txtnombre.Text = Program.nombre4;
            dtpFecha.Text = Program.fecha4;
            txtTotal.Text = Convert.ToString(Program.pago4);
            lblidAliBal.Text = Program.Id4 + "";
        }


        public void tickEstiloP()
        {
            CrearTiket ticket = new CrearTiket();

            //cabecera del ticket.
            //Image img =Image.FromFile("LogoCepeda.png");
            //ticket.HeaderImage = img;
            ticket.TextoCentro(lblLogo.Text);
            ticket.TextoIzquierda(lbldir.Text);
            ticket.TextoIzquierda("TELEFONOS:" + lbltel.Text + "/" + lblTel2.Text);
            ticket.TextoIzquierda("RNC: " + lblrnc.Text);
            ticket.TextoIzquierda("EMAIL:" + lblCorreo.Text);
            ticket.lineasGuio();

            //SUB CABECERA.
            ticket.TextoIzquierda("ATENDIDO: " + txtUsu.Text);
            ticket.TextoIzquierda("FECHA: " + dtpFecha.Text);

            //ARTICULOS A VENDER.
            ticket.lineasGuio();

            ticket.TextoIzquierda("TIPO DE PAGO CLIENTE: " + txttipopago.Text);
            ticket.TextoIzquierda("NOMBRE CLIENTE: " + txtnombre.Text);
            ticket.TextoIzquierda("APELLIDO: " + txtapellido.Text);
            ticket.TextoIzquierda("");
            //resumen de la venta
            ticket.AgregarTotales("       MONTO PAGADO: ", decimal.Parse(txtTotal.Text));

            //TEXTO FINAL DEL TICKET
            ticket.TextoIzquierda("EXTRA");
            ticket.TextoCentro("!GRACIAS POR VISITARNOS");

            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.CortaTicket();//CORTAR TICKET
            ticket.ImprimirTicket("POS-80");//NOMBRE DE LA IMPRESORA
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var ProximaFechaPago = dtpFecha.Value;
            using (SqlConnection con = new SqlConnection(Cx.conet))
            {
                using (SqlCommand cmd = new SqlCommand("Registrarpagocliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = Program.Id4;

                    var tipopago = txttipopago.Text.ToLower();
                    if (tipopago == "diario")
                    {
                        ProximaFechaPago = dtpFecha.Value.AddDays(1);
                    }
                    else if (tipopago == "semanal")
                    {
                        ProximaFechaPago = dtpFecha.Value.AddDays(7);
                    }
                    else if (tipopago == "quincenal")
                    {
                        ProximaFechaPago = dtpFecha.Value.AddDays(14);
                    }
                    else if (tipopago == "mensual")
                    {
                        ProximaFechaPago = dtpFecha.Value.AddMonths(1);
                    }
                    else
                    {
                        ProximaFechaPago = dtpFecha.Value.AddYears(1);
                    }

                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = ProximaFechaPago.ToString();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    using (SqlCommand cmd2 = new SqlCommand("pagos_re", con))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;

                        string idVenta = (Program.idcaja.ToString() + DateTime.Today.Second.ToString() + Program.IdEmpleadoLogueado.ToString());
                        //Tabla de pago
                        cmd2.Parameters.Add("@IdVenta", SqlDbType.Int).Value = Convert.ToInt32(idVenta);
                        cmd2.Parameters.Add("@id_pago", SqlDbType.Int).Value = Program.idPago;
                        cmd2.Parameters.Add("@id_caja", SqlDbType.Int).Value = Program.idcaja;
                        cmd2.Parameters.Add("@monto", SqlDbType.Decimal).Value = Program.Caja;
                        cmd2.Parameters.Add("@ingresos", SqlDbType.Decimal).Value = Program.pagoRealizado;
                        if (Program.Devuelta > 0)
                        {
                            cmd2.Parameters.Add("@egresos", SqlDbType.Decimal).Value = Program.Devuelta;
                        }
                        else
                        {
                            cmd2.Parameters.Add("@egresos", SqlDbType.Decimal).Value = 0;
                        }
                        cmd2.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(Program.Fechapago);
                        cmd2.Parameters.Add("@deuda", SqlDbType.Decimal).Value = 0;

                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                    }
                    Program.pagoRealizado = 0;
                    MessageBox.Show("Pago Confirmado");
                    if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Desea Factura?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        tickEstiloP();
                    }
                    clean();
                    Program.abiertosecundarias = false;
                    Program.abierto = false;
                    FrmBuscarAlineacionyBalanceo F = new FrmBuscarAlineacionyBalanceo();
                    F.limpiar();
                    F.cargardata();
                }
                this.Close();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Program.abiertosecundarias = false;
            Program.abierto = false;
            clean();
            this.Close();
        }

        private void txtmodelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }
        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.sololetras(e);
        }

        private void frmAlineamiento_Load(object sender, EventArgs e)
        {
            button1.Hide();
        }

        private void btnpagar_Click(object sender, EventArgs e)
        {
            frmPagar pa = new frmPagar();
            pa.txtmonto.Text = txtTotal.Text;
            pa.gbAbrir.Visible = false;
            pa.btnCerrar.Visible = false;
            button1.Show();

            Program.tipopago4 = txttipopago.Text;
            Program.nombre4 = txtnombre.Text;
            Program.apellido4 = txtapellido.Text;
            Program.fecha4 = dtpFecha.Text;
            Program.pago4 = Convert.ToDecimal(txtTotal.Text);

            pa.Show();
        }
    }
}
