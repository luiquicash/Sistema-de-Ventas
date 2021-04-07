using CapaLogicaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Capa_de_Presentacion
{
    public partial class FrmRegistroProductos : DevComponents.DotNetBar.Metro.MetroForm
    {
        private clsCategoria C = new clsCategoria();
        private clsProducto P = new clsProducto();
        clsCx Cx = new clsCx();
        public FrmRegistroProductos()
        {
            InitializeComponent();
        }

        private void FrmRegistroProductos_Load(object sender, EventArgs e)
        {
            ListarElementos();
        }

        public void ListarElementos()
        {
            if (IdC.Text.Trim() != "")
            {
                cbxCategoria.DisplayMember = "Descripcion";
                cbxCategoria.ValueMember = "IdCategoria";
                cbxCategoria.DataSource = C.Listar();
                cbxCategoria.SelectedValue = IdC.Text;
            }
            else
            {
                cbxCategoria.DisplayMember = "Descripcion";
                cbxCategoria.ValueMember = "IdCategoria";
                cbxCategoria.DataSource = C.Listar();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Cx.conexion != null && Cx.conexion.State == ConnectionState.Open)
            {
                Cx.conexion.Close();
            }

            clsProducto P = new clsProducto();
            if (txtProducto.Text.Trim() != "")
            {
                if (txtMarca.Text.Trim() != "")
                {
                    if (txtPCompra.Text.Trim() != "")
                    {
                        if (txtPVenta.Text.Trim() != "")
                        {
                            if (txtStock.Text.Trim() != "")
                            {
                                using (SqlConnection con = new SqlConnection(Cx.conet))
                                {
                                    using (SqlCommand cmd = new SqlCommand("RegistrarProducto", con))
                                    {

                                        Cx.conexion.Open();
                                        string sql = "Select * From Producto Where Nombre =@Nombre and Marca=@Marca";
                                        SqlCommand Command = new SqlCommand(sql, Cx.conexion);
                                        Command.Parameters.AddWithValue("@Nombre", txtProducto.Text.ToUpper());
                                        Command.Parameters.AddWithValue("@Marca", txtMarca.Text.ToUpper());

                                        SqlDataReader reade = Command.ExecuteReader();
                                        if (reade.Read())
                                        {
                                            DevComponents.DotNetBar.MessageBoxEx.Show("El producto ya existe", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            Cx.conexion.Close();
                                        }
                                        else
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = cbxCategoria.SelectedValue;
                                            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = txtProducto.Text.ToUpper();
                                            cmd.Parameters.Add("@Marca", SqlDbType.NVarChar).Value = txtMarca.Text.ToUpper();
                                            cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = txtStock.Text;
                                            cmd.Parameters.Add("@PrecioCompra", SqlDbType.Decimal).Value = txtPCompra.Text;
                                            cmd.Parameters.Add("@PrecioVenta", SqlDbType.Decimal).Value = txtPVenta.Text;
                                            cmd.Parameters.Add("@itbis", SqlDbType.Decimal).Value = txtitbis.Text;
                                            cmd.Parameters.Add("@FechaVencimiento", SqlDbType.Date).Value = dateTimePicker1.Text;
                                            cmd.Parameters.Add("@FechaModificacion", SqlDbType.Date).Value = dateTimePicker1.Text;
                                            cmd.Parameters.Add("@Pmax", SqlDbType.Decimal).Value = 0;
                                            cmd.Parameters.Add("@Pmin", SqlDbType.Decimal).Value = 0;

                                            DevComponents.DotNetBar.MessageBoxEx.Show("Se Registro Correctamente", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            con.Open();
                                            cmd.ExecuteNonQuery();
                                            con.Close();

                                            P.Listar();
                                            ListarElementos();
                                            Limpiar();
                                        }

                                    }
                                }
                            }
                            else
                            {
                                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Stock del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtStock.Focus();
                            }
                        }
                        else
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Precio de Venta del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPVenta.Focus();
                        }
                    }
                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Precio de Compra del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPCompra.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Marca del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMarca.Focus();
                }
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Nombre del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProducto.Focus();
            }
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            if (Program.abiertosecundarias == false)
            {
                FrmRegistrarCategoria C = new FrmRegistrarCategoria();
                Program.abiertosecundarias = true;
                C.Show();
            }
        }

        private void Limpiar()
        {
            Program.IdProducto = 0;
            Program.Descripcion = "";
            Program.Marca = "";
            Program.PrecioVenta = 0;
            Program.Stock = 0;
            Program.IdCategoria = 0;
            Program.itbis = 0;
            Program.tipo = "";

            txtProducto.Text = "";
            txtMarca.Clear();
            txtPCompra.Clear();
            txtPVenta.Clear();
            IdC.Clear();
            txtIdP.Clear();
            txtStock.Clear();
            dateTimePicker1.Value = DateTime.Now;
            txtProducto.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Está Seguro que Desea Salir.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmListadoProductos LP = new FrmListadoProductos();
            if (txtProducto.Text.Trim() != "")
            {
                if (txtMarca.Text.Trim() != "")
                {
                    if (txtPCompra.Text.Trim() != "")
                    {
                        if (txtPVenta.Text.Trim() != "")
                        {
                            if (txtStock.Text.Trim() != "")
                            {
                                using (SqlConnection con = new SqlConnection(Cx.conet))
                                {
                                    using (SqlCommand cmd = new SqlCommand("ActualizarProducto", con))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;

                                        cmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = cbxCategoria.SelectedValue;
                                        cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = txtIdP.Text;
                                        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = txtProducto.Text;
                                        cmd.Parameters.Add("@Marca", SqlDbType.NVarChar).Value = txtMarca.Text;
                                        cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = txtStock.Text;
                                        cmd.Parameters.Add("@PrecioCompra", SqlDbType.Decimal).Value = txtPCompra.Text;
                                        cmd.Parameters.Add("@PrecioVenta", SqlDbType.Decimal).Value = txtPVenta.Text;
                                        cmd.Parameters.Add("@itbis", SqlDbType.Decimal).Value = txtitbis.Text;
                                        cmd.Parameters.Add("@FechaModificacion", SqlDbType.Date).Value = dateTimePicker1.Text;
                                        cmd.Parameters.Add("@Pmax", SqlDbType.Decimal).Value = 0;
                                        cmd.Parameters.Add("@Pmin", SqlDbType.Decimal).Value = 0;

                                        DevComponents.DotNetBar.MessageBoxEx.Show("Se Actualizo Correctamente", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                        ListarElementos();
                                        LP.CargarListado();
                                        Limpiar();
                                    }
                                }
                            }
                            else
                            {
                                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Stock del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtStock.Focus();
                            }
                        }
                        else
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Precio de Venta del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPVenta.Focus();
                        }
                    }
                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Precio de Compra del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPCompra.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Marca del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMarca.Focus();
                }
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Nombre del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProducto.Focus();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Program.abiertosecundarias = false;
            Program.abierto = false;
            this.Close();
        }

        private void txtPCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //	OpenFileDialog flg = new OpenFileDialog();
        //	flg.InitialDirectory = "C:\\";
        //	flg.Filter = "Archivos jpg (*.jpg)|*.jpg|Archivos png (*.png)|*.png";
        //	if (flg.ShowDialog() == DialogResult.OK) pictureBox1.Load(flg.FileName);
        //}

        //bool activo;
        //private void FrmRegistroProductos_Activated(object sender, EventArgs e)
        //{
        //    if (txtIdP.Text == "")
        //    {
        //        activo = true;
        //    }
        //    else
        //    {
        //        activo = false;
        //    }

        //    if (activo == false)
        //    {
        //        SqlCommand command = new SqlCommand("select imagen from Producto where imagen IS NOT NULL AND IdProducto= @Clave", Cx.conexion);
        //        command.Parameters.AddWithValue("@Clave", txtIdP.Text);

        //        Cx.conexion.Open();
        //        SqlDataReader leer = command.ExecuteReader();

        //        if (leer.Read() == false)
        //        {
        //            pictureBox1.Image = null;
        //        }
        //        else
        //        {//Representa un set de comandos que es utilizado para llenar un DataSet
        //            SqlDataAdapter dp = new SqlDataAdapter(command);
        //            Cx.conexion.Close();

        //            //Representa un caché (un espacio) en memoria de los datos.
        //            DataSet ds = new DataSet("Producto");

        //                //Arreglo de byte en donde se almacenara la foto en bytes
        //                byte[] MyData = new byte[0];

        //                //Llenamosel DataSet con la tabla. 
        //                dp.Fill(ds, "Producto");

        //                //Inicializamos una fila de datos en la cual se almacenaran todos los datos de la fila seleccionada
        //                DataRow myRow = ds.Tables["Producto"].Rows[0];

        //            if (myRow["imagen"] != DBNull.Value)
        //            {
        //                //Se almacena el campo foto de la tabla en el arreglo de bytes
        //                MyData = (byte[])myRow["imagen"];

        //                //Se inicializa un flujo en memoria del arreglo de bytes
        //                MemoryStream stream = new MemoryStream(MyData);

        //                //En el picture box se muestra la imagen que esta almacenada en el flujo en memoria 
        //                //el cual contiene el arreglo de bytes
        //                pictureBox1.Image = System.Drawing.Image.FromStream(stream);
        //            }
        //            else
        //            {
        //                pictureBox1.Image = null;
        //            }

        //        }
        //    }
        //}
    }
}
