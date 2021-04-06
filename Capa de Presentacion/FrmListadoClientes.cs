using CapaLogicaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Capa_de_Presentacion
{
    public partial class FrmListadoClientes : DevComponents.DotNetBar.Metro.MetroForm
    {
        private clsCliente C = new clsCliente();
        clsCx Cx = new clsCx();
        int Listado = 0;

        public FrmListadoClientes()
        {
            InitializeComponent();
        }

        private void FrmListadoClientes_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 5000;
            ListarClientes();
            ListarClientes1();
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            button1.Enabled = false;
            if (Program.CargoEmpleadoLogueado != "Administrador")
            {

                btnActualizar.Enabled = false;
            }
        }

        private void ListarClientes()
        {
            DataTable dt = new DataTable();
            dt = C.Listado();
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0]);
                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                }
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            }
        }

        private void ListarClientes1()
        {
            DataTable dt = new DataTable();
            dt = C.Listado();
            try
            {
                dataGridView2.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(dt.Rows[i][0]);
                    dataGridView2.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView2.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView2.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dataGridView2.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    dataGridView2.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    dataGridView2.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                }
                dataGridView2.ClearSelection();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmRegistroCliente C = new FrmRegistroCliente();
            if (dataGridView1.SelectedRows.Count > 0)
                Program.Evento = 1;
            else
                Program.Evento = 0;
            dataGridView1.ClearSelection();
            C.Show();

            ListarClientes();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FrmRegistroCliente FrmC = new FrmRegistroCliente();
                FrmC.txtDni.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                FrmC.txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                FrmC.txtNombres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                FrmC.txtDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                FrmC.txtTelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                FrmC.txtDni.Focus();
                FrmC.button3.Visible = true;
                FrmC.label11.Text = "Actualizar Cliente";
                FrmC.Show();

                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
                ListarClientes();
                ListarClientes1();
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Seleccione la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1.ClearSelection();
            if (e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                C.Dni = txtBuscarCliente.Text;
                dt = C.BuscarCliente(C.Dni);
                try
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(dt.Rows[i][0]);
                        dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                        dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                        dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][5].ToString();
                    }
                    dataGridView1.ClearSelection();
                    timer1.Stop();
                }
                catch (Exception ex)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
                }
            }
            else
            {
                ListarClientes();
                timer1.Start();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Está Seguro que Desea Sair.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (Listado)
            {
                case 0: ListarClientes(); break;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Program.IdCliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Program.DocumentoIdentidad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Program.ApellidosCliente = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Program.NombreCliente = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.Close();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (e.KeyChar == 13)
                {
                    DialogResult Resultado = new DialogResult();
                    Resultado = DevComponents.DotNetBar.MessageBoxEx.Show("Está Seguro que Desea Editar Los Datos del Cliente.", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (Resultado == DialogResult.Yes)
                    {
                        FrmRegistroCliente FrmC = new FrmRegistroCliente();
                        FrmC.txtDni.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        FrmC.txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        FrmC.txtNombres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        FrmC.txtDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        FrmC.txtTelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        FrmC.txtmonto.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                        FrmC.txtDni.Focus();
                        FrmC.Show();
                        if (dataGridView1.SelectedRows.Count > 0)
                            Program.Evento = 1;
                        else
                            Program.Evento = 0;
                        dataGridView1.ClearSelection();
                    }
                    else
                    {
                        dataGridView1.ClearSelection();
                    }
                }
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombre, apellido;
            Program.IdCliente2 = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            Program.cedula = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            apellido = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            nombre = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            Program.nombres = apellido + "," + nombre;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.IdCliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (Program.IdCliente > 0)
            {
                Cx.conexion.Open();
                string sql = "select IdCliente from Venta where IdCliente =@id";
                SqlCommand cmd = new SqlCommand(sql, Cx.conexion);
                cmd.Parameters.AddWithValue("@id", Program.IdCliente);

                SqlDataReader reade = cmd.ExecuteReader();
                if (reade.Read())
                {
                    MessageBox.Show("No se Puede eliminar porque el Cliente tiene Ventas Registradas");
                }
                else
                {
                    if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Está Seguro que Desea Eliminar este Cliente.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        using (SqlCommand cmd1 = new SqlCommand("eliminarCliente", Cx.conexion))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.Add("@id", SqlDbType.Int).Value = Program.IdCliente;

                            cmd1.ExecuteNonQuery();
                            ListarClientes();
                            ListarClientes1();
                        }
                    }
                }
                Cx.conexion.Close();
            }
            else
            {
                MessageBox.Show("Por Favor Seleccione un cliente antes de eliminarlo");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Program.abiertosecundarias = false;
            Program.abierto = false;
            if (Program.CargoEmpleadoLogueado != "Administrador")
            {
                btnActualizar.Enabled = false;
            }

            this.Close();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Rows[dataGridView2.CurrentRow.Index].Selected = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
