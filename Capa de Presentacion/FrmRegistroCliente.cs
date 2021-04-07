using CapaLogicaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Capa_de_Presentacion
{
    public partial class FrmRegistroCliente : DevComponents.DotNetBar.Metro.MetroForm
    {
        private clsCliente C = new clsCliente();
        clsCx Cx = new clsCx();
        public FrmRegistroCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ProximaFechaPago = DateTime.Today;
            if (txtmonto.Text.Trim() != "")
            {
                if (txtDni.Text.Trim() != "")
                {
                    if (txtApellidos.Text.Trim() != "")
                    {
                        if (txtNombres.Text.Trim() != "")
                        {
                            if (txtDireccion.Text.Trim() != "")
                            {
                                if (txtTelefono.Text.Trim() != "")
                                {
                                    if (Program.Evento == 0)
                                    {
                                        using (SqlConnection con = new SqlConnection(Cx.conet))
                                        {
                                            using (SqlCommand cmd = new SqlCommand("RegistrarCliente", con))
                                            {
                                                cmd.CommandType = CommandType.StoredProcedure;

                                                cmd.Parameters.Add("@Dni", SqlDbType.NVarChar).Value = txtDni.Text;
                                                cmd.Parameters.Add("@Apellidos", SqlDbType.NVarChar).Value = txtApellidos.Text;
                                                cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar).Value = txtNombres.Text;
                                                cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = txtDireccion.Text;
                                                cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = txtTelefono.Text;
                                                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = 1;
                                                cmd.Parameters.Add("@TipoPago", SqlDbType.NVarChar).Value = combo_tipo_pago.Text;
                                                cmd.Parameters.Add("@tiempo", SqlDbType.Int).Value = 0;
                                                cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = txtmonto.Text;

                                                var tipopago = combo_tipo_pago.Text.ToLower();
                                                if (tipopago == "diario")
                                                {
                                                    ProximaFechaPago.AddDays(1);
                                                }
                                                else if (tipopago == "semanal")
                                                {
                                                    ProximaFechaPago.AddDays(7);
                                                }
                                                else if (tipopago == "quincenal")
                                                {
                                                    ProximaFechaPago.AddDays(14);
                                                }
                                                else if (tipopago == "mensual")
                                                {
                                                    ProximaFechaPago.AddMonths(1);
                                                }
                                                else
                                                {
                                                    ProximaFechaPago.AddYears(1);
                                                }

                                                cmd.Parameters.Add("@ProximaFechaPago", SqlDbType.Date).Value = ProximaFechaPago.ToString();

                                                DevComponents.DotNetBar.MessageBoxEx.Show("Se Registro Correctamente", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                con.Open();
                                                cmd.ExecuteNonQuery();
                                                con.Close();
                                                Limpiar();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese N° de Teléfono o Celular.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtTelefono.Focus();
                                }
                            }
                            else
                            {
                                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Dirección del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtDireccion.Focus();
                            }
                        }
                        else
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Nombre(s) del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNombres.Focus();
                        }
                    }
                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Apellido(s) del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtApellidos.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese N° de cedula del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDni.Focus();
                }
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese el monto que pagara el Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDni.Focus();
            }
        }

        private void Limpiar()
        {
            txtDni.Text = "";
            txtApellidos.Clear();
            txtNombres.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtDni.Focus();
        }

        public void cargar_combo_pago(ComboBox combo_tipo_pago)
        {
            SqlCommand cm = new SqlCommand("CARGARcomboPago", Cx.conexion);
            cm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            combo_tipo_pago.DisplayMember = "descripcion";
            combo_tipo_pago.ValueMember = "id";
            combo_tipo_pago.DataSource = dt;
        }

        private void FrmRegistroCliente_Load(object sender, EventArgs e)
        {
            txtDni.Focus();
            cargar_combo_pago(combo_tipo_pago);
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.sololetras(e);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Program.abiertosecundarias = false;
            Program.abierto = false;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtmonto.Text.Trim() != "")
            {
                if (txtDni.Text.Trim() != "")
                {
                    if (txtApellidos.Text.Trim() != "")
                    {
                        if (txtNombres.Text.Trim() != "")
                        {
                            if (txtDireccion.Text.Trim() != "")
                            {
                                if (txtTelefono.Text.Trim() != "")
                                {
                                    if (Program.Evento == 1)
                                    {
                                        using (SqlConnection con = new SqlConnection(Cx.conet))
                                        {
                                            using (SqlCommand cmd = new SqlCommand("ActualizarCliente", con))
                                            {
                                                cmd.CommandType = CommandType.StoredProcedure;

                                                cmd.Parameters.Add("@Dni", SqlDbType.NVarChar).Value = txtDni.Text;
                                                cmd.Parameters.Add("@Apellidos", SqlDbType.NVarChar).Value = txtApellidos.Text;
                                                cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar).Value = txtNombres.Text;
                                                cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = txtDireccion.Text;
                                                cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = txtTelefono.Text;
                                                cmd.Parameters.Add("@Tipopago", SqlDbType.NVarChar).Value = combo_tipo_pago.Text;
                                                cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = txtmonto.Text;
                                                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = 1;
                                                DevComponents.DotNetBar.MessageBoxEx.Show("Se Actualizo Correctamente", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                con.Open();
                                                cmd.ExecuteNonQuery();
                                                con.Close();
                                                Limpiar();
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese N° de Teléfono o Celular.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtTelefono.Focus();
                                }
                            }
                            else
                            {
                                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Dirección del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtDireccion.Focus();
                            }
                        }
                        else
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Nombre(s) del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNombres.Focus();
                        }
                    }
                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Apellidos del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtApellidos.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese N° de D.N.I del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDni.Focus();
                }
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese el monto que pagara el Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDni.Focus();
            }
        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }
    }
}
