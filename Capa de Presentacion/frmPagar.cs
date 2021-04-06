using CapaLogicaNegocio;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Capa_de_Presentacion
{
    public partial class frmPagar : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmPagar()
        {
            InitializeComponent();
        }

        clsCx Cx = new clsCx();
        Correo c = new Correo();
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal MP = new FrmMenuPrincipal();
            MP.Show();
            this.Hide();
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //	if (txtActual.Text=="")
        //	{
        //		MessageBox.Show("Debe Ingresar un Monto");
        //	}
        //	else
        //	{
        //		using (SqlCommand cmd = new SqlCommand("abrir_caja", Cx.conexion))
        //		{
        //			string id_var = "";
        //			if (txtId.Text == "")
        //				id_var = "0";
        //			else
        //				id_var = txtId.Text;

        //                  cmd.CommandType = CommandType.StoredProcedure;

        //			cmd.Parameters.Add("@id_caja", SqlDbType.Int).Value = id_var;
        //			cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = Convert.ToDecimal(txtActual.Text);
        //			cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = dateTimePicker1.Text;

        //			Cx.conexion.Open();
        //			cmd.ExecuteNonQuery();
        //			Cx.conexion.Close();
        //		}
        //		llenar_data();
        //		MessageBox.Show("Datos Guardados");
        //		btnCerrar.Visible = true;
        //	}
        //}
        public void llenar()
        {
            string cadSql = "select top(1) montoactual from Caja order by id_caja desc";

            SqlCommand comando = new SqlCommand(cadSql, Cx.conexion);
            Cx.conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                //txtCaja.Text = leer["montoactual"].ToString();
                txtCaja1.Text = leer["montoactual"].ToString();
            }
            Cx.conexion.Close();
        }

        //public void llenarid()
        //{
        //	string cadSql = "select top(1) id_caja  from Caja order by id_caja desc";

        //	SqlCommand comando = new SqlCommand(cadSql, Cx.conexion);
        //	Cx.conexion.Open();

        //	SqlDataReader leer = comando.ExecuteReader();

        //	if (leer.Read() == true)
        //	{
        //		txtId.Text = leer["id_caja"].ToString();
        //	}
        //	Cx.conexion.Close();
        //}
        public void llenaridP()
        {
            string cadSql = "select top(1) id_caja from Caja order by id_caja desc";

            SqlCommand comando = new SqlCommand(cadSql, Cx.conexion);
            Cx.conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                txtId.Text = leer["id_caja"].ToString();
            }
            Cx.conexion.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Program.turno = 0;
            if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Desea realizar una copia de seguridad de la base de datos?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                ////////////////////Borrar copia de seguridad de base de datos anterior
                string direccion = @"C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\Backup\SalesSystem.bak";
                File.Delete(direccion);

                ////////////////////Creando copia de seguridad de base de datos nueva
                string comand_query = "BACKUP DATABASE [SalesSystem] TO  DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL13.MSSQLSERVER\\MSSQL\\Backup\\SalesSystem.bak'WITH NOFORMAT, NOINIT,  NAME = N'SalesSystem-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                SqlCommand comando = new SqlCommand(comand_query, Cx.conexion);
                try
                {
                    Cx.conexion.Open();
                    comando.ExecuteNonQuery();

                    ////////////////////Enviando al correo copia de seguridad de base de datos nueva
                    //c.enviarCorreo("sendingsystembackup@gmail.com", "evitarperdidadedatos/0", "Realizando la creacion diaria de respaldo de base de datos para evitar perdidas de datos en caso de algun problema con el equipo.",
                    //	"Backup de base de datos", "cepedaimport2715@hotmail.com", direccion);
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
        }
        private void txtpaga_Leave(object sender, EventArgs e)
        {
            if (txtpaga.Text != "")
            {
                decimal paga = decimal.Parse(txtpaga.Text);
                decimal total = decimal.Parse(txtmonto.Text);
                decimal devuelta = Math.Round(paga - total, 2);
                txtDev.Text = devuelta.ToString();
            }
        }
        private void frmPagar_Load_1(object sender, EventArgs e)
        {
            llenar();
            //llenarid();
            llenaridP();
            //llenar_data();

            //         if (tienefila == true)
            //         {
            //	button1.Visible = false;
            //             btnCerrar.Visible = true;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.tipo != "Credito" && Convert.ToDecimal(txtmonto.Text) > Convert.ToDecimal(txtpaga.Text))
            {
                Program.pagoRealizado = 0;
                MessageBox.Show("Por Favor Cambiar tipo de Factura, Las Facturas a Debito no Aceptan Deudas.");
            }
            else
            {
                if (txtpaga.Text == "")
                {
                    MessageBox.Show("Debe Ingresar un Monto");
                }
                else
                {
                    if (txtIdp.Text == "")
                        Program.idPago = 0;
                    else
                        Program.idPago = Convert.ToInt32(txtIdp.Text);
                    Program.Devuelta = Convert.ToDecimal(txtDev.Text);
                    Program.idcaja = Convert.ToInt32(txtId.Text);
                    Program.Fechapago = dateTimePicker1.Text;

                    decimal dev = decimal.Parse(txtDev.Text);
                    decimal paga = decimal.Parse(txtpaga.Text);

                    if (dev <= 0)
                    {
                        Program.pagoRealizado = paga;
                    }
                    else
                    {
                        Program.pagoRealizado = paga - dev;
                    }

                    Program.realizopago = true;
                    MessageBox.Show("Pago Realizado");
                }
            }
        }

        //private void btnImprimir_Click(object sender, EventArgs e)
        //{
        //	frmMovimientoCaja mo = new frmMovimientoCaja();
        //	mo.Show();
        //}

        private void btnC_Click(object sender, EventArgs e)
        {
            FrmRegistroVentas venta = new FrmRegistroVentas();
            venta.txttotal.Text = Program.pago4 + "";
            venta.lbligv.Text = Program.igv + "";
            venta.lblsubt.Text = Program.ST + "";
            this.Hide();
        }
        //bool tienefila = false;
        //public void llenar_data()
        //{
        //	//declaramos la cadena  de conexion
        //	string cadenaconexion = Cx.conet;
        //	//variable de tipo Sqlconnection
        //	SqlConnection con = new SqlConnection();
        //	//variable de tipo Sqlcommand
        //	SqlCommand comando = new SqlCommand();
        //	//variable SqlDataReader para leer los datos
        //	SqlDataReader dr;
        //	con.ConnectionString = cadenaconexion;
        //	comando.Connection = con;
        //	//declaramos el comando para realizar la busqueda
        //	comando.CommandText = "SELECT id_caja, monto_inicial,fecha  FROM Caja where monto_final =0 AND fecha = convert(datetime,CONVERT(varchar(10), getdate(), 103),103)";
        //	//especificamos que es de tipo Text
        //	comando.CommandType = CommandType.Text;
        //	//se abre la conexion
        //	con.Open();
        //	//limpiamos los renglones de la datagridview
        //	dgvCaja.Rows.Clear();
        //	//a la variable DataReader asignamos  el la variable de tipo SqlCommand
        //	dr = comando.ExecuteReader();
        //	while (dr.Read())
        //	{
        //		//variable de tipo entero para ir enumerando los la filas del datagridview
        //		int renglon = dgvCaja.Rows.Add();
        //		// especificamos en que fila se mostrará cada registro
        //		// nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

        //		dgvCaja.Rows[renglon].Cells["id_caja"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("id_caja")));
        //		dgvCaja.Rows[renglon].Cells["monto"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("monto_inicial")).ToString("C2"));
        //		dgvCaja.Rows[renglon].Cells["fecha"].Value = dr.GetDateTime(dr.GetOrdinal("fecha"));

        //		tienefila = true;
        //	}
        //      }

        //private void dgvCaja_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //	if(dgvCaja.Rows.Count > 0)
        //	{
        //		btnCerrar.Visible = true;
        //	}
        //	else
        //	{
        //		MessageBox.Show("Debe Insertar Un Monto Inicial De Caja");
        //	}
        //}

        //      private void button4_Click_1(object sender, EventArgs e)
        //      {
        //	FrmMenuPrincipal MP = new FrmMenuPrincipal();
        //	Program.inventario = "Inventario";
        //	MP.Show();
        //	this.Hide();
        //}

        private void txtFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        //private void txtFinal_Leave(object sender, EventArgs e)
        //{
        //	if (txtFinal.Text == "")
        //	{
        //		MessageBox.Show("Debe Ingresar un Monto");
        //	}
        //	else
        //	{
        //		if (txtGa.Text == "")
        //		{
        //			decimal i = 0;
        //			txtGa.Text = i.ToString();
        //		}
        //		if (txtPe.Text == "")
        //		{
        //			decimal i = 0;
        //			txtPe.Text = i.ToString();
        //		}

        //		decimal actual = decimal.Parse(txtCaja2.Text);
        //		decimal totales = decimal.Parse(txtFinal.Text);
        //		decimal montocaja = totales - actual;

        //		if (montocaja > 0)
        //		{
        //			txtGa.Text = montocaja.ToString();
        //			lbNota.Text = "SUS GANANCIAS SON DE: " + montocaja + " Pesos";
        //			lbNota.ForeColor = Color.GreenYellow;
        //			txtPe.Clear();
        //		}
        //		else if (montocaja == 0)
        //		{
        //			montocaja = 0;
        //			lbNota.Text = "NO HUBO PERDIDAS";
        //			lbNota.ForeColor = Color.DeepSkyBlue;
        //			txtPe.Clear();
        //			txtGa.Clear();
        //		}
        //		else
        //		{
        //			txtPe.Text = montocaja.ToString();
        //			lbNota.Text = "SUS PERDIDAS SON DE: " + montocaja + " Pesos";
        //			lbNota.ForeColor = Color.MediumVioletRed;
        //			txtGa.Clear();
        //		}
        //	}
        //}
    }
}
