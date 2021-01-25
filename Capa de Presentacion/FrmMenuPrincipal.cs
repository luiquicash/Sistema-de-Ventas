﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaLogicaNegocio;
using System.IO;

namespace Capa_de_Presentacion
{
	public partial class FrmMenuPrincipal : DevComponents.DotNetBar.Metro.MetroForm
	{
		int EnviarFecha = 0;
		public FrmMenuPrincipal()
		{
			InitializeComponent();
		}

		Correo c = new Correo();
		clsCx Cx = new clsCx();
		clsUsuarios U = new clsUsuarios();
		private void FrmMenuPrincipal_Activated(object sender, EventArgs e)
		{
			lblUsuario.Text = Program.NombreEmpleadoLogueado;
			txtcargo.Text = Program.CargoEmpleadoLogueado;
			textBox1.Text = Program.CargoEmpleadoLogueado1;

			if (Program.inventario == "Inventario")
			{
				btnProductos.Visible = true;
				btnClientes.Visible = false;
				btnVentas.Visible = false;

				button5.Visible = false;
				button2.Visible = false;
				btnUsuarios.Visible = false;
				btnEmpleados.Visible = false;

				button1.Visible = false;
				button3.Visible = false;
				btnVer.Visible = false;
			}
			else
			{
				if (txtcargo.Text.Trim() != "Administrador")
				{
					btnProductos.Visible = true;
					btnClientes.Visible = true;
					btnVentas.Visible = true;

					button5.Visible = false;
					button2.Visible = false;
					btnUsuarios.Visible = false;
					btnEmpleados.Visible = false;

					button1.Visible = true;
					button3.Visible = true;
					btnVer.Visible = true;
				}
				else
				{
					btnProductos.Visible = true;
					btnClientes.Visible = true;
					btnVentas.Visible = true;

					button5.Visible = true;
					button2.Visible = true;
					btnUsuarios.Visible = true;
					btnEmpleados.Visible = true;

					button1.Visible = true;
					button3.Visible = true;
					btnVer.Visible = false;
				}
			}
		}
		private void FrmMenuPrincipal_Load(object sender, EventArgs e)
		{
			timer1.Interval = 500;
			timer1.Start();
			llenar();
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
				lblTel1.Text = leer["Tel1"].ToString();
				lblTel2.Text = leer["Tel2"].ToString();
				lblCorreo.Text = leer["Correo"].ToString();
				lblrnc.Text = leer["RNC"].ToString();
			}
			Cx.conexion.Close();
		}
		private void btnProductos_Click(object sender, EventArgs e)
		{
			if (txtcargo.Text.Trim() != "Administrador")
			{
				FrmListadoProductos P = new FrmListadoProductos();
				P.lblLogo.Text = lblLogo.Text;
				P.lblDir.Text = lblDir.Text;
				P.btnNuevo.Enabled = false;
				P.btnEditar.Enabled = false;
				P.button2.Enabled = false;
				P.Show();
			}
			else
			{
				FrmListadoProductos P = new FrmListadoProductos();
				P.lblLogo.Text = lblLogo.Text;
				P.lblDir.Text = lblDir.Text;
				P.Show();
			}
		}
		private void btnClientes_Click(object sender, EventArgs e)
		{
			FrmListadoClientes C = new FrmListadoClientes();
			if (Program.CargoEmpleadoLogueado != "Administrador")
			{
				C.btnActualizar.Enabled = false;
			}

			C.Show();
		}
		private void btnVentas_Click(object sender, EventArgs e)
		{
			FrmRegistroVentas V = new FrmRegistroVentas();
			V.txtUsu.Text = lblUsuario.Text;
			V.txtidEmp.Text = Convert.ToString(Program.IdEmpleadoLogueado);
			V.lblLogo.Text = lblLogo.Text;
			V.lblDir.Text = lblDir.Text;
			V.lblTel1.Text = lblTel1.Text;
			V.lblTel2.Text = lblTel2.Text;
			V.lblCorreo.Text = lblCorreo.Text;
			V.lblrnc.Text = lblrnc.Text;

			if (Program.CargoEmpleadoLogueado != "Administrador")
			{
				V.txtIgv.Enabled = false;
			}

			V.Show();
		}
		private void btnUsuarios_Click(object sender, EventArgs e)
		{
			FrmListadoUsuario U = new FrmListadoUsuario();
			U.Show();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			switch (EnviarFecha)
			{
				case 0: CapturarFechaSistema(); break;
			}
		}
		private void CapturarFechaSistema()
		{
			lblFecha.Text = DateTime.Now.ToShortDateString();
			lblHora.Text = DateTime.Now.ToShortTimeString();
		}

		private void btnEmpleados_Click(object sender, EventArgs e)
		{
			FrmListadoEmpleados E = new FrmListadoEmpleados();
			if (Program.CargoEmpleadoLogueado != "Administrador")
			{
				E.btnActualizar.Enabled = false;
			}

			E.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (Program.inventario == "Inventario")
			{
				Program.inventario = "";

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
						c.enviarCorreo("sendingsystembackup@gmail.com", "evitarperdidadedatos/0", "Realizando la creación diaria de respaldo de base de datos para evitar perdidas de datos en caso de algún problema con el equipo.",
							"Backup de base de datos" + DateTime.Now, "ferreteriaalmontekm13@gmail.com", direccion);
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
			else
			{
				cuadredecaja cuadre = new cuadredecaja();
				cuadre.lblLogo.Text = lblLogo.Text;
				cuadre.lblDir.Text = lblDir.Text;
				cuadre.lbltel1.Text = lblTel1.Text;
				cuadre.lbltel.Text = lblTel2.Text;
				cuadre.lblCorreo.Text = lblCorreo.Text;
				cuadre.lblrnc.Text = lblrnc.Text;
				cuadre.Show();
				this.Hide();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			frmTurno Tu = new frmTurno();
			Tu.lblLogo.Text = lblLogo.Text;
			Tu.textBox2.Text = Program.turno + "";
			Tu.Show();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			frmLimitantesNCF limi = new frmLimitantesNCF();
			limi.Show();
		}
		private void button3_Click(object sender, EventArgs e)
		{
			frmCambiarUsu Ca = new frmCambiarUsu();
			Ca.Show();
		}
		private void ckbLimite_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbLimite.Checked == true)
			{
				button2.Visible = true;
			}
			else
			{
				button2.Visible = false;
			}
		}
		private void ckbUsu_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbUsu.Checked == true)
			{
				btnUsuarios.Visible = true;
			}
			else
			{
				btnUsuarios.Visible = false;
			}
		}
		private void ckbEmp_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbEmp.Checked == true)
			{
				btnEmpleados.Visible = true;
			}
			else
			{
				btnEmpleados.Visible = false;
			}
		}
		private void btnVer_Click(object sender, EventArgs e)
		{
			usuario.Show();
			btnVer.Hide();
		}
		private void label1_Click(object sender, EventArgs e)
		{
			usuario.Hide();
			btnVer.Show();
		}
		public void button4_Click(object sender, EventArgs e)
		{
			U.User = txtUser.Text;
			U.Password = txtClave.Text;
			RecuperarDatosSesion1();
			MessageBox.Show("Buscando Usuario");
			Refresh();
			if (textBox1.Text.Trim() == "Administrador")
			{
				usuario.Hide();
				panel2.Show();
			}
			else
			{
				MessageBox.Show("No eres Administrador");
			}
			txtUser.Clear();
			txtClave.Clear();
		}
		private void RecuperarDatosSesion1()
		{
			DataRow row;
			DataTable dt = new DataTable();
			dt = U.DevolverDatosSesion(txtUser.Text, txtClave.Text);
			if (dt.Rows.Count == 1)
			{
				row = dt.Rows[0];
				Program.IdEmpleadoLogueado1 = Convert.ToInt32(row[0].ToString());
				Program.NombreEmpleadoLogueado1 = row[1].ToString();
				Program.CargoEmpleadoLogueado1 = row[2].ToString();
			}
		}
		private void label7_Click_1(object sender, EventArgs e)
		{
			Program.CargoEmpleadoLogueado1 = "";
			textBox1.Text = "";
			panel2.Hide();
			usuario.Hide();
			btnVer.Show();
		}
		private void button5_Click(object sender, EventArgs e)
		{
			frmListadoVentas vt = new frmListadoVentas();
			vt.lblLogo.Text = lblLogo.Text;
			vt.lblDir.Text = lblDir.Text;
			vt.Show();
		}

		private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				button4.PerformClick();
			}
		}

		bool val = false;
		private void lblLogo_MouseDown(object sender, MouseEventArgs e)
		{
			val = true;
		}

		private void lblLogo_MouseMove(object sender, MouseEventArgs e)
		{
			if (val == true)
			{
				this.Location = Cursor.Position;
			}
		}

		private void lblLogo_MouseUp(object sender, MouseEventArgs e)
		{
			val = false;
		}

		private void ckbback_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbback.Checked == true)
			{
				button5.Visible = true;
			}
			else
			{
				button5.Visible = false;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			frmMovimientoCaja move = new frmMovimientoCaja();
			move.Show();
		}

        private void button7_Click(object sender, EventArgs e)
        {
			frmAlineamiento V = new frmAlineamiento();
			V.txtUsu.Text = lblUsuario.Text;
			V.txtidEmp.Text = Convert.ToString(Program.IdEmpleadoLogueado);
			V.lblLogo.Text = lblLogo.Text;
			V.lbldir.Text = lblDir.Text;
			V.lbltel1.Text = lblTel1.Text;
			V.lbltel.Text = lblTel2.Text;
			V.lblCorreo.Text = lblCorreo.Text;
			V.lblrnc.Text = lblrnc.Text;
			V.Show();
		}
    }
}

