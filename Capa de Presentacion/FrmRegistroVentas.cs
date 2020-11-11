﻿using System;
using System.Collections.Generic;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaLogicaNegocio;
using System.Diagnostics;
using System.IO;

namespace Capa_de_Presentacion
{
    public partial class FrmRegistroVentas : DevComponents.DotNetBar.Metro.MetroForm
    {
        clsVentas Ventas = new clsVentas();
        clsDetalleVenta Detalle = new clsDetalleVenta();
        private List<clsVenta> lst = new List<clsVenta>();
		clsCx Cx = new clsCx();
		public FrmRegistroVentas()
        {
            InitializeComponent();
        }
		private void FrmVentas_Load(object sender, EventArgs e)
		{
			actualzarestadoscomprobantes();
			llenar_data_ncf();
			cargar_combo_NCF(combo_tipo_NCF);
			cargar_combo_Tipofactura(cbtipofactura);
			btnRegistrarVenta.Hide();
			btnImprimir.Visible = false;
			btnAgregar.Visible = false;
			button2.Visible = false;
			llenar();
			btnEliminarItem.Enabled = false;
			frmPagar pa = new frmPagar();
			txttotal.Text = Convert.ToString(pa.txtmonto.Text);
		}

		public void actualzarestadoscomprobantes()
		{
			var listaidint = new List<int>();

            for (int i = 0; i <= 9; i++)
            {
				listaidint.Add(i);
            }

			foreach(var item in listaidint)
            {
				Cx.conexion.Open();
				string sql = "SELECT * FROM ncf INNER JOIN Comprobantes ON ncf.id_ncf = Comprobantes.id_comprobante where ncf.id_ncf=@id order by id_ncf";
				SqlCommand cmd = new SqlCommand(sql, Cx.conexion);
				cmd.Parameters.AddWithValue("@id", item);

				SqlDataReader reade = cmd.ExecuteReader();
				if (reade.Read())
				{
					int secuf = Convert.ToInt32(reade["secuenciaF"]);
					int secui = Convert.ToInt32(reade["secuenciaIni"]);

					DateTime fechaini = DateTime.Today;
					DateTime fechafin = Convert.ToDateTime(reade["fecha_final"]);

					if (secui > secuf || fechaini >= fechafin)
					{
						Cx.conexion.Close();
						using (SqlConnection con = new SqlConnection(Cx.conet))
						{
							using (SqlCommand cmdup = new SqlCommand("UpdateState", con))
							{
								cmdup.CommandType = CommandType.StoredProcedure;
								cmdup.Parameters.Add("@id", SqlDbType.Int).Value = item;
								con.Open();
								cmdup.ExecuteNonQuery();
								con.Close();
							}
						}
					}
				}
				Cx.conexion.Close();
			}
		}

		public void cargar_combo_NCF(ComboBox combo_tipo_NCF)
		{
			SqlCommand cm = new SqlCommand("CARGARcomboNCF", Cx.conexion);
			cm.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter da = new SqlDataAdapter(cm);
			DataTable dt = new DataTable();
			da.Fill(dt);

			combo_tipo_NCF.DisplayMember = "descripcion_ncf";
			combo_tipo_NCF.ValueMember = "id_ncf";
			combo_tipo_NCF.DataSource = dt;
		}

		public void cargar_combo_Tipofactura(ComboBox tipofactura)
		{
			SqlCommand cm = new SqlCommand("CARGARcomboTipoFactura", Cx.conexion);
			cm.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter da = new SqlDataAdapter(cm);
			DataTable dt = new DataTable();
			da.Fill(dt);

			tipofactura.DisplayMember = "descripcion";
			tipofactura.ValueMember = "id";
			tipofactura.DataSource = dt;
		}

		public void llenar_data_ncf()
		{   //declaramos la cadena  de conexion
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
			comando.CommandText = "SELECT  id_secuencia, secuenciaNCF, fecha from NCFGenerados";
			//especificamos que es de tipo Text
			comando.CommandType = CommandType.Text;
			//se abre la conexion
			con.Open();
			//limpiamos los renglones de la datagridview
			data_ncf.Rows.Clear();
			//a la variable DataReader asignamos  el la variable de tipo SqlCommand
			dr = comando.ExecuteReader();
			//el ciclo while se ejecutará mientras lea registros en la tabla
			while (dr.Read())
			{
				//variable de tipo entero para ir enumerando los la filas del datagridview
				int renglon = data_ncf.Rows.Add();
				// especificamos en que fila se mostrará cada registro
				// nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

				data_ncf.Rows[renglon].Cells["id_secuencia"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("id_secuencia")));
				data_ncf.Rows[renglon].Cells["secuencia"].Value = dr.GetString(dr.GetOrdinal("secuenciaNCF"));
				data_ncf.Rows[renglon].Cells["fecha"].Value = dr.GetDateTime(dr.GetOrdinal("fecha"));
			}
			con.Close();
		}
		public void llenar()
		{
			string cadSql = "select top(1) IdVenta from Venta order by IdVenta desc";

			SqlCommand comando = new SqlCommand(cadSql, Cx.conexion);
			Cx.conexion.Open();

			SqlDataReader leer = comando.ExecuteReader();

			int varcodigo;

			if (leer.Read() == true)
			{
				varcodigo = Convert.ToInt32(leer["IdVenta"]) + 1;
				txtIdVenta.Text = varcodigo.ToString();
			}
			else
			{
				txtIdVenta.Text = "1";
			}
			Cx.conexion.Close();
		}
		
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            FrmListadoClientes C = new FrmListadoClientes();
			C.Show();
        }

		bool activar;
		private void FrmVentas_Activated(object sender, EventArgs e)
		{
			txtDocIdentidad.Text = Program.DocumentoIdentidad;
			txtDatos.Text = Program.ApellidosCliente + ", " + Program.NombreCliente;
			txtidCli.Text = Program.IdCliente + "";
			txtIdProducto.Text = Program.IdProducto + "";
			txtDescripcion.Text = Program.Descripcion;
			txtMarca.Text = Program.Marca;
			txtStock.Text = Program.Stock + "";
			txtPVenta.Text = Program.PrecioVenta + "";
			txtIgv.Text = Program.itbis + "";
			txtIdV.Text = Program.Id + "";
			txttotal.Text = Program.total + "";
			lblsubt.Text = Program.ST + "";
			lbligv.Text = Program.igv + "";
			
			if (Program.Esabono != "" && Program.Esabono != null && Program.pagoRealizado > 0)
			{
				button2.Visible = true;
				btnSalir.Visible = false;
			}
			else if (Program.pagoRealizado > 0)
			{
				btnRegistrarVenta.Visible = true;
				btnSalir.Visible = false;
			}
			else
			{
				btnRegistrarVenta.Visible = false;
				btnSalir.Visible = true;
			}

			if (Program.Esabono != "" && Program.Esabono !=null)
			{
				activar = true;
				btnImprimir.Visible = false;
				btnSalir.Visible = true;
			}
			else if (Program.Id == 0)
			{
				activar = false;
			}
			else
			{
				activar = true;
				btnImprimir.Visible = true;
			}


			if (activar == true)
			{
				cbtipofactura.Text = Program.tipo;
				combo_tipo_NCF.Text = Program.NCF;
				txtNCF.Text = Program.NroComprobante;
				txttotal.Text = Program.total + "";
				lblsubt.Text = Program.ST + "";
				lbligv.Text = Program.igv + "";
				txtidEmp.Text = Program.IdEmpleado + "";
				dateTimePicker1.Text = Program.fecha;


				if (txtidCli.Text == "0" || txtidCli.Text == null || Program.IdCliente + "" == null || Program.IdCliente + "" == "0")
				{
					Cx.conexion.Open();
					string sql = "select idCliente from Cliente where DNI=@DNI";
					SqlCommand Command = new SqlCommand(sql, Cx.conexion);
					Command.Parameters.AddWithValue("@DNI", Program.DocumentoIdentidad);
					SqlDataReader reade = Command.ExecuteReader();
					if (reade.Read())
					{
						txtidCli.Text = reade["idCliente"].ToString();
					}
					Cx.conexion.Close();
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
				comando.CommandText = "SELECT * from DetalleVenta WHERE IdVenta  like '%" + txtIdV.Text + "%'";
				//especificamos que es de tipo Text
				comando.CommandType = CommandType.Text;
				//se abre la conexion
				con.Open();
				//limpiamos los renglones de la datagridview
				dgvVenta.Rows.Clear();
				//a la variable DataReader asignamos  el la variable de tipo SqlCommand
				dr = comando.ExecuteReader();
				while (dr.Read())
				{
					//variable de tipo entero para ir enumerando los la filas del datagridview
					int renglon = dgvVenta.Rows.Add();
					// especificamos en que fila se mostrará cada registro
					// nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

					dgvVenta.Rows[renglon].Cells["IdD"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdVenta")));
					dgvVenta.Rows[renglon].Cells["cantidadP"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("Cantidad")));
					dgvVenta.Rows[renglon].Cells["DescripcionP"].Value = dr.GetString(dr.GetOrdinal("detalles_P"));
					dgvVenta.Rows[renglon].Cells["PrecioU"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioUnitario")));
					dgvVenta.Rows[renglon].Cells["SubtoTal"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("SubTotal")));
					dgvVenta.Rows[renglon].Cells["IDP"].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdProducto")));
					dgvVenta.Rows[renglon].Cells["IGV"].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("Igv")));
				}
				con.Close();
			}
		}
        private void btnBusquedaProducto_Click(object sender, EventArgs e)
        {
            FrmListadoProductos P = new FrmListadoProductos();
			btnAgregar.Visible = true;
			P.Show();
        }

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			clsVenta V = new clsVenta();

			if (txtDocIdentidad.Text.Trim() != "")
			{
				if (txtDescripcion.Text.Trim() != "")
				{
					if (txtCantidad.Text.Trim() != "")
					{
						if (Convert.ToInt32(txtCantidad.Text) >= 0)
						{
							if (Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStock.Text))
							{
								V.IdProducto = Convert.ToInt32(txtIdProducto.Text);
								V.IdVenta = Convert.ToInt32(txtIdVenta.Text);
								V.Descripcion = txtDescripcion.Text + " - " + txtMarca.Text;
								V.Cantidad = Convert.ToInt32(txtCantidad.Text);

								if (Convert.ToDecimal(txtIgv.Text) > 0)
								{
									V.Igv = Convert.ToDecimal(txtIgv.Text);
								}

								V.PrecioVenta = Convert.ToDecimal(txtPVenta.Text);

								V.SubTotal = Math.Round((Convert.ToDecimal(txtPVenta.Text) + Convert.ToDecimal(txtIgv.Text))* Convert.ToInt32(txtCantidad.Text), 2);
								btnAgregar.Visible = false;
								lst.Add(V);
								LlenarGri();
								Limpiar();
							}
							else
							{
								DevComponents.DotNetBar.MessageBoxEx.Show("Stock Insuficiente para Realizar la Venta.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
							}
						}
						else
						{
							DevComponents.DotNetBar.MessageBoxEx.Show("Cantidad Ingresada no Válida.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
							txtCantidad.Clear();
							txtCantidad.Focus();
						}
					}
					else
					{
						DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Cantidad a Vender.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						txtCantidad.Focus();
					}
				}
				else
				{
					DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor buscar un Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				}
			}
			else
			{
				DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Busque el Cliente a Vender.", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}
		private void LlenarGri() {
            Decimal SumaSubTotal = 0; Decimal SumaIgv=0; Decimal SumaTotal=0;
            dgvVenta.Rows.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                dgvVenta.Rows.Add();
                dgvVenta.Rows[i].Cells["idD"].Value = lst[i].IdVenta;
				dgvVenta.Rows[i].Cells["DescripcionP"].Value = lst[i].Descripcion;
				dgvVenta.Rows[i].Cells["cantidadP"].Value = lst[i].Cantidad;
				dgvVenta.Rows[i].Cells["IGV"].Value = lst[i].Igv;
				dgvVenta.Rows[i].Cells["PrecioU"].Value = lst[i].PrecioVenta;
                dgvVenta.Rows[i].Cells["SubtoTal"].Value = lst[i].SubTotal;
                dgvVenta.Rows[i].Cells["IDP"].Value = lst[i].IdProducto;
				
				SumaSubTotal += Convert.ToDecimal(dgvVenta.Rows[i].Cells["SubtoTal"].Value);
                SumaIgv += Convert.ToDecimal(dgvVenta.Rows[i].Cells["IGV"].Value);
				SumaTotal =Math.Round(SumaSubTotal,2);

				lblsubt.Text = Convert.ToString(SumaSubTotal);
				lbligv.Text = Convert.ToString(SumaIgv);
				txttotal.Text= Convert.ToString(SumaTotal);
			} 
        }
        private void Limpiar() {
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtStock.Clear();
            txtPVenta.Clear();
            txtCantidad.Clear();
            txtCantidad.Focus();
			txtIgv.Clear();
            Program.Descripcion = "";
            Program.Stock = 0;
            Program.Marca = "";
            Program.PrecioVenta = 0;
			Program.IdProducto = 0; 
		}
        private void btnSalir_Click(object sender, EventArgs e)
        {	
			if(chkComprobante.Checked== false && txtNCF.Text !="")
            {
				if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Desea Agregar Comprobantes a la Factura?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
				{
					chkComprobante.Checked = true;
				}
				else
                {
					chkComprobante.Checked = false;
					txtNCF.Text = "Sin NCF";
					combo_tipo_NCF.Text = "Ningún Tipo de Comprobante";
				}
			}

			if(chkComprobante.Checked == false && txtNCF.Text == "")
            {
				chkComprobante.Checked = false;
				txtNCF.Text = "Sin NCF";
				combo_tipo_NCF.Text = "Ningún Tipo de Comprobante";
			}
			
			frmPagar pa = new frmPagar();
			Program.total = Convert.ToDecimal(txttotal.Text);
			Program.igv = Convert.ToDecimal(lbligv.Text);
			Program.ST = Convert.ToDecimal(lblsubt.Text);
			pa.txtmonto.Text = txttotal.Text;
			pa.gbAbrir.Visible = false;
			pa.btnCerrar.Visible = false;
			pa.Show();

			Program.tipo = cbtipofactura.Text;
		}
        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
			List<clsVenta> lista = new List<clsVenta>();
			Program.IdProducto = Convert.ToInt32(dgvVenta.CurrentRow.Cells["IDP"].Value.ToString());
			if (Program.IdProducto > 0)
			{
				decimal Igv = 0;
				decimal subtotal = 0;
				decimal SumaSubTotal =0;
				decimal SumaIgv = 0;
				decimal SumaTotal = 0;

				foreach (var item in lst)
				{
					if (item.IdProducto != Program.IdProducto)
					{
						lista.Add(item);

						Igv = item.Igv;
						subtotal = item.SubTotal;

						SumaSubTotal += subtotal;
						SumaIgv += Igv;
						SumaTotal = SumaSubTotal + SumaIgv;
					}
					else
                    {
						lista.Remove(item);
					}

					lblsubt.Text = Convert.ToString(SumaSubTotal);
					lst = lista;
				}
				btnEliminarItem.Enabled = false;
				dgvVenta.Rows.RemoveAt(dgvVenta.SelectedRows[0].Index);
			}
			else
			{
				MessageBox.Show("Por Favor Seleccione un producto antes de eliminarlo");
			}
		}

		decimal restante = 0;
		public void VentaRealizada()
        {
			using (SqlConnection con = new SqlConnection(Cx.conet))
			{
				using (SqlCommand cmd = new SqlCommand("RegistrarVenta", con))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					//tabla Ventas
					cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = Convert.ToInt32(txtidCli.Text);
					cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = Convert.ToInt32(txtIdVenta.Text);
					cmd.Parameters.Add("@TipoFactura", SqlDbType.NVarChar).Value = cbtipofactura.Text;
					if (cbtipofactura.Text == "Credito")
					{
						restante = Convert.ToDecimal(txttotal.Text) - Program.pagoRealizado;
						cmd.Parameters.Add("@Restante", SqlDbType.Decimal).Value = restante;
					}
					else
					{
						cmd.Parameters.Add("@Restante", SqlDbType.Decimal).Value = 0;
					}
					cmd.Parameters.Add("@Serie", SqlDbType.Int).Value = Convert.ToInt32(txtid.Text);
					cmd.Parameters.Add("@NroDocumento", SqlDbType.NVarChar).Value = txtNCF.Text;
					cmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = txtidEmp.Text;
					cmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar).Value = combo_tipo_NCF.Text;
					cmd.Parameters.Add("@FechaVenta", SqlDbType.DateTime).Value = dateTimePicker1.Text;
					cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = Convert.ToDecimal(txttotal.Text);

					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();
				}

				using (SqlCommand cmd1 = new SqlCommand("RegistrarDetalleVenta", con))
					foreach (DataGridViewRow row in dgvVenta.Rows)
					{
						cmd1.CommandType = CommandType.StoredProcedure;

						//Tabla detalles ventas
						cmd1.Parameters.Add("@IdVenta", SqlDbType.Int).Value = Convert.ToInt32(row.Cells["IdD"].Value);
						cmd1.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Convert.ToInt32(row.Cells["cantidadP"].Value);
						cmd1.Parameters.Add("@detalles", SqlDbType.NVarChar).Value = Convert.ToString(row.Cells["DescripcionP"].Value);
						cmd1.Parameters.Add("@PrecioUnitario", SqlDbType.Float).Value = Convert.ToDouble(row.Cells["PrecioU"].Value);
						cmd1.Parameters.Add("@SubTotal", SqlDbType.Float).Value = Convert.ToDouble(row.Cells["SubtoTal"].Value);
						cmd1.Parameters.Add("@IdProducto", SqlDbType.Int).Value = Convert.ToInt32(row.Cells["IDP"].Value);
						cmd1.Parameters.Add("@Igv", SqlDbType.Float).Value = Convert.ToDouble(row.Cells["IGV"].Value);

						con.Open();
						cmd1.ExecuteNonQuery();
						cmd1.Parameters.Clear();
						con.Close();
					}


				foreach (DataGridViewRow row in dgvVenta.Rows)
				{
                    SqlCommand sqlCommand = new SqlCommand("UpdateStock", con);
                    using (SqlCommand cmd3 = sqlCommand)
					{
						cmd3.CommandType = CommandType.StoredProcedure;

						//UpdateStock
						cmd3.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Convert.ToInt32(row.Cells["cantidadP"].Value);
						cmd3.Parameters.Add("@IdProducto", SqlDbType.Int).Value = Convert.ToInt32(row.Cells["IDP"].Value);

						con.Open();
						cmd3.ExecuteNonQuery();
						con.Close();
					}
				}

				using (SqlCommand cmd2 = new SqlCommand("pagos_re", con))
				{
					cmd2.CommandType = CommandType.StoredProcedure;

					//Tabla de pago
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
					if (cbtipofactura.Text == "Credito")
					{
                        cmd2.Parameters.Add("@deuda", SqlDbType.Decimal).Value = restante;
					}
					else
					{
						cmd2.Parameters.Add("@deuda", SqlDbType.Decimal).Value = 0;
					}
					

					con.Open();
					cmd2.ExecuteNonQuery();
					con.Close();
				}
				Program.pagoRealizado = 0;
				MessageBox.Show("Venta Registrada y Pago Confirmado");
			}
		}

   		private void btnRegistrarVenta_Click(object sender, EventArgs e)
		{
			if (dgvVenta.Rows.Count > 0)
			{		
				if(chkComprobante.Checked==true)
                {
					using (SqlConnection con = new SqlConnection(Cx.conet))
					{
						Cx.conexion.Open();
						string sql = "Select * From Venta Where IdVenta =@IdVenta";
						SqlCommand Command = new SqlCommand(sql, Cx.conexion);
						Command.Parameters.AddWithValue("@IdVenta", Convert.ToInt32(txtIdVenta.Text));

						SqlDataReader reade = Command.ExecuteReader();
						if (!reade.Read())
						{
							using (SqlCommand cmd = new SqlCommand("generar", con))
							{
								cmd.CommandType = CommandType.StoredProcedure;
								cmd.Parameters.Add("@id_ncf", SqlDbType.Int).Value = Convert.ToInt32(txtid.Text);
								cmd.Parameters.Add("@id_secuencia", SqlDbType.Int).Value = Convert.ToInt32(combo_tipo_NCF.SelectedIndex);
								cmd.Parameters.Add("@secuencia", SqlDbType.NVarChar).Value = txtNCF.Text;

								con.Open();
								cmd.ExecuteNonQuery();
								con.Close();

								llenar_data_ncf();
								buscarid();
							}
						}

						Cx.conexion.Close();
					}
				}
				else
                {
					txtNCF.Text = "Sin NCF";
					combo_tipo_NCF.Text = "Ningún Tipo de Comprobante";
				}
				
				VentaRealizada();


				if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Que tipo de factura desea? \n Si=Pequeña \n No=Grande ", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
				{
					tickEstilo();
				}
				else
                {
					To_pdf();
				}
					
				llenar();
				Limpiar();
				Limpiar1();
		}
			else
			{
				MessageBox.Show("Debe Agregar al menos una Venta");
			}
		}

		private void Limpiar1() {
			Program.Esabono = "";
			txtIgv.Clear();
            txtDocIdentidad.Clear();
            txtDatos.Clear();
            dgvVenta.Rows.Clear();
            Program.IdEmpleadoLogueado = 0;
            Program.IdCliente = 0;
            txtIdProducto.Clear();
			Program.pagoRealizado = 0;
            Program.DocumentoIdentidad = "";
            Program.ApellidosCliente = "";
            Program.NombreCliente = "";
			Program.Id = 0;
			Program.total = 0;
			Program.ST = 0;
			Program.igv = 0;
			Program.fecha = "";
			Program.NroComprobante = "";
			Program.NCF = "";
			txtNCF.Clear();
			lst.Clear();
		}

		public void tickEstilo()
		{
			CrearTiket ticket = new CrearTiket();

			//cabecera del ticket.
			if (Program.ReImpresion != null)
			{
				ticket.textoDerecha(Program.ReImpresion);
			}
			ticket.textoCentro(lblLogo.Text);
			ticket.textoIzquierda("");
			ticket.textoIzquierda(lblDir.Text);
			ticket.textoIzquierda("Tel: " + lblTel1.Text + "/" + lblTel2.Text);
			ticket.textoIzquierda("Correo: " + lblCorreo.Text);
			ticket.textoIzquierda("Tipo de Comprobante: " + combo_tipo_NCF.Text);
			ticket.textoIzquierda("Tipo de Factura: " + cbtipofactura.Text.ToUpper());
			ticket.textoIzquierda("Numero de Comprobante: " + txtNCF.Text);
			ticket.textoIzquierda("RNC: " + lblrnc.Text);
			ticket.textoExtremos("CAJA #1", "ID VENTA: " + txtIdVenta.Text);
			ticket.lineasGuio();

			//SUB CABECERA.
			ticket.textoIzquierda("ATENDIDO POR: " + txtUsu.Text);
			ticket.textoIzquierda("CLIENTE: " + txtDatos.Text);
			ticket.textoIzquierda("");
			ticket.textoIzquierda("FECHA: " + dateTimePicker1.Text);
			ticket.textoIzquierda("HORA: " + DateTime.Now.ToShortTimeString());

			//ARTICULOS A VENDER.
			ticket.EncabezadoVentas();// NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
			ticket.lineasGuio();
			//SI TIENE UN DATAGRIDVIEW DONDE ESTAN SUS ARTICULOS A VENDER PUEDEN USAR ESTA MANERA PARA AGREARLOS
			foreach (DataGridViewRow fila in dgvVenta.Rows)
			{
				ticket.AgregarArticulo(fila.Cells["DescripcionP"].Value.ToString(), int.Parse(fila.Cells["cantidadP"].Value.ToString()),
				decimal.Parse(fila.Cells["SubtoTal"].Value.ToString()), decimal.Parse(fila.Cells["IGV"].Value.ToString()));
			}

			//resumen de la venta
			ticket.agregarTotales("TOTAL    : ", decimal.Parse(txttotal.Text));
			ticket.agregarTotales("RESTANTE : ", decimal.Parse(restante.ToString()));
			ticket.textoIzquierda(" ");
			ticket.textoCentro("__________________________________");

			//TEXTO FINAL DEL TICKET
			ticket.textoIzquierda("EXTRA");
			ticket.textoIzquierda("FAVOR REVISE SU MERCANCIA AL RECIBIRLA");
			ticket.textoCentro("!GRACIAS POR SU COMPRA!");
			ticket.ImprimirTicket("POS-80");//NOMBRE DE LA IMPRESORA
			ticket.textoIzquierda("");
			ticket.textoIzquierda("");
			ticket.textoIzquierda("");
			ticket.textoIzquierda("");
			ticket.textoIzquierda("");
			ticket.textoIzquierda("");
			ticket.textoIzquierda("");
			ticket.CortaTicket();
		}

		private void txtPVenta_KeyPress(object sender, KeyPressEventArgs e)
		{
			validar.solonumeros(e);
		}

		private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
		{	frmListadoVentas F = new frmListadoVentas();
			F.btnCancelar.Visible = false;
			F.Show();
		}

		public void buscarid()
		{
			Cx.conexion.Close();
			Cx.conexion.Open();
			string sql = "SELECT id_ncf FROM ncf WHERE id_ncf =@id";
			SqlCommand cmd = new SqlCommand(sql, Cx.conexion);
			cmd.Parameters.AddWithValue("@id", combo_tipo_NCF.SelectedIndex + 1);

			SqlDataReader reade = cmd.ExecuteReader();
			if (reade.Read())
			{
				txtid.Text = Convert.ToString(reade["id_ncf"]);
			}

			Cx.conexion.Close();
			actualzarestadoscomprobantes();
		}

		private void combo_tipo_NCF_SelectionChangeCommitted(object sender, EventArgs e)
		{
			int secuencia = 0;
			try
			{
				SqlDataReader LectorSecuencia;

				Cx.conexion.Open();
				SqlCommand Comando = new SqlCommand();
				Comando.Connection = Cx.conexion;
				Comando.CommandText = "Select * From ncf where id_ncf like '%" + combo_tipo_NCF.SelectedValue + "%'";
				LectorSecuencia = Comando.ExecuteReader();

				if (LectorSecuencia.Read() == true)
				{
					txtNCF.Text = LectorSecuencia.GetString(2);
					secuencia = LectorSecuencia.GetInt32(3);
					txtNCF.Text = txtNCF.Text + secuencia.ToString("00000000");
				}
				else
				{
					MessageBox.Show("No existe un registro con este codigo, verifique y trate de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					return;
				}

				LectorSecuencia.Close();
			}
			catch (Exception Error)
			{
				MessageBox.Show(Error.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			finally
			{
				Cx.conexion.Close();
			}
		}

		private void combo_tipo_NCF_SelectedIndexChanged(object sender, EventArgs e)
		{
			buscarid();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Limpiar();
			Limpiar1();
		}

		private void label18_Click(object sender, EventArgs e)
		{
			btnImprimir.Visible = false;
			btnAgregar.Visible = false;
			Program.pagoRealizado = 0;
			Limpiar();
			Limpiar1();
			this.Close();
		}

        private void dgvVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			if (dgvVenta.Rows.Count > 0)
			{ dgvVenta.Rows[dgvVenta.CurrentRow.Index].Selected = true; }
		}

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
			if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Que tipo de factura desea? \n Si=Pequeña \n No=Grande ", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
			{
				tickEstilo();
			}
			else
			{
				To_pdf();
			}
			btnImprimir.Visible = false;
			Limpiar1();
		}

		private void To_pdf()
		{
			Document doc = new Document(PageSize.LETTER, 10f, 10f, 10f, 0f);
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            Image image1 = Image.GetInstance("LogoCepeda.png");
            image1.ScaleAbsoluteWidth(100);
            image1.ScaleAbsoluteHeight(50);
            saveFileDialog1.InitialDirectory = @"C:";
			saveFileDialog1.Title = "Factura para " + txtDatos.Text;
			saveFileDialog1.DefaultExt = "pdf";
			saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
			saveFileDialog1.FilterIndex = 2;
			saveFileDialog1.RestoreDirectory = true;
			string filename = "Venta" + DateTime.Now.ToString();
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
				if (Program.ReImpresion != null)
				{
					doc.Add(new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                            " + Program.ReImpresion, FontFactory.GetFont("ARIAL", 5, iTextSharp.text.Font.ITALIC, color: BaseColor.RED)));
				}
				doc.Add(new Paragraph("                                                                                                                                                                                                                                                     " + envio, FontFactory.GetFont("ARIAL", 7, iTextSharp.text.Font.ITALIC)));
				doc.Add(image1);
				doc.Add(new Paragraph(chunk));
				doc.Add(new Paragraph(ubicado, FontFactory.GetFont("ARIAL", 9, iTextSharp.text.Font.NORMAL)));
				doc.Add(new Paragraph(" "));
				doc.Add(new Paragraph("ATENDIDO POR: " + txtUsu.Text + "                                                                                                              " + "Tipo de Factura: "  + cbtipofactura.Text.ToUpper(), FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
				doc.Add(new Paragraph("CLIENTE: " + txtDatos.Text + "                                                                                                                           " + combo_tipo_NCF.Text, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
				doc.Add(new Paragraph("Documento del Cliente: " + txtDocIdentidad.Text + "                                                                                                                            " + "Numero de Comprobante: " + txtNCF.Text, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
				doc.Add(new Paragraph(" "));
				GenerarDocumento(doc);
				doc.AddCreationDate();
				if(dgvVenta.Rows.Count>=1)
                {
					int filas = 25 - dgvVenta.Rows.Count;
					if(filas>1)
                    {
						for (int i = 1; i < filas; i++)
						{
							doc.Add(new Paragraph("                       "));
						}
					}
                }
				doc.Add(new Paragraph("Total de Ventas   : " + txttotal.Text, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
				doc.Add(new Paragraph("Total de Restante : " + restante.ToString(), FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
				doc.Add(new Paragraph("                       "));
				doc.Add(new Paragraph("_________________________" + "                                                                                                                                                 " + "_________________________", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
				doc.Add(new Paragraph("      Facturado Por      " + "                                                                                                                                                                         " + "     Recibido Por  ", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
				doc.Add(new Paragraph("                       "));
				doc.Add(new Paragraph("Nota: Los productos con garantia pierden su garantia si deja perder la factura.", FontFactory.GetFont("ARIAL", 6, iTextSharp.text.Font.ITALIC,color: BaseColor.RED)));
				doc.Close();
				Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
			}
		}
		public void GenerarDocumento(Document document)
		{
			int i, j;
			PdfPTable datatable = new PdfPTable(dgvVenta.ColumnCount);
			datatable.DefaultCell.Padding = 3;
			float[] headerwidths = GetTamañoColumnas(dgvVenta);
			datatable.SetWidths(headerwidths);
			datatable.WidthPercentage = 100;
			datatable.DefaultCell.BorderWidth = 1;
			datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
			for (i = 0; i < dgvVenta.ColumnCount; i++)
			{
				datatable.AddCell(dgvVenta.Columns[i].HeaderText);
			}
			datatable.HeaderRows = 1;
			datatable.DefaultCell.BorderWidth = 1;
			for (i = 0; i < dgvVenta.Rows.Count; i++)
			{
				for (j = 0; j < dgvVenta.Columns.Count; j++)
				{
					if (dgvVenta[j, i].Value != null)
					{
						datatable.AddCell(new Phrase(dgvVenta[j, i].Value.ToString(), FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
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

        private void dgvVenta_Click(object sender, EventArgs e)
        {
			btnEliminarItem.Enabled = true;
		}

        private void txtPVenta_KeyPress_1(object sender, KeyPressEventArgs e)
        {
			validar.solonumeros(e);
		}

        private void button2_Click(object sender, EventArgs e)
        {
			restante = Convert.ToDecimal(txttotal.Text) - Program.pagoRealizado;
			using (SqlConnection con = new SqlConnection(Cx.conet))
			{
				using (SqlCommand cmd = new SqlCommand("AbonaraVenta", con))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					//tabla Ventas
					cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = Program.Id;
					cmd.Parameters.Add("@Restante", SqlDbType.Decimal).Value = restante;

					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();
				}

				using (SqlCommand cmd2 = new SqlCommand("Actualizarpagos_re", con))
				{
					cmd2.CommandType = CommandType.StoredProcedure;

					//Tabla de pago
					cmd2.Parameters.Add("@id_pago", SqlDbType.Int).Value = Program.idPago;
					cmd2.Parameters.Add("@id_caja", SqlDbType.Int).Value = Program.idcaja;
					cmd2.Parameters.Add("@monto", SqlDbType.Decimal).Value = Program.Caja;
					cmd2.Parameters.Add("@ingresos", SqlDbType.Decimal).Value = Program.pagoRealizado;
					if(Program.Devuelta>0)
                    {
						cmd2.Parameters.Add("@egresos", SqlDbType.Decimal).Value = Program.Devuelta;
					}
                    else
                    {
						cmd2.Parameters.Add("@egresos", SqlDbType.Decimal).Value = 0;
					}
					cmd2.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(Program.Fechapago);
					cmd2.Parameters.Add("@deuda", SqlDbType.Decimal).Value = restante;

					con.Open();
					cmd2.ExecuteNonQuery();
					con.Close();
				}
				Program.pagoRealizado = 0;
				MessageBox.Show("Abono Registrado y Pago Confirmado");

				if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Que tipo de factura desea? \n Si=Pequeña \n No=Grande ", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
				{
					tickEstilo();
				}
				else
				{
					To_pdf();
				}

				llenar();
				Limpiar();
				Limpiar1();
			}
		}
    }
}
