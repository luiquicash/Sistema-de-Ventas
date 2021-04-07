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
    public partial class FrmListadoProductos : DevComponents.DotNetBar.Metro.MetroForm

    {
        private clsProducto P = new clsProducto();
        private clsCategoria C = new clsCategoria();
        clsCx Cx = new clsCx();
        public FrmListadoProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            ListarElementos();
            CargarListado();
            dataGridView1.ClearSelection();
            repetitivo();
            Mrepetitivo();
            button2.Enabled = false;
            clear();
        }
        public void buscarid()
        {
            Cx.conexion.Open();
            string sql = "select IdCategoria from Categoria where Descripcion =@id";
            SqlCommand cmd = new SqlCommand(sql, Cx.conexion);
            cmd.Parameters.AddWithValue("@id", cbxCategoria.Text);

            SqlDataReader reade = cmd.ExecuteReader();
            if (reade.Read())
            {
                id.Text = Convert.ToString(reade["IdCategoria"]);
                txtdesc.Text = cbxCategoria.Text;
                rbbuena.Checked = false;
                rdmedia.Checked = false;
                rbCero.Checked = false;
                rbtodos.Checked = false;
                radioButton1.Checked = false;
            }
            Cx.conexion.Close();
        }

        private void Stretch(object sender, EventArgs e)
        {
            foreach (DataGridViewImageColumn column in
                dataGridView1.Columns)
            {
                column.ImageLayout = DataGridViewImageCellLayout.Stretch;
                column.Description = "Stretched";
            }
        }

        private void ZoomToImage(object sender, EventArgs e)
        {
            foreach (DataGridViewImageColumn column in
                dataGridView1.Columns)
            {
                column.ImageLayout = DataGridViewImageCellLayout.Zoom;
                column.Description = "Zoomed";
            }
        }

        private void NormalImage(object sender, EventArgs e)
        {
            foreach (DataGridViewImageColumn column in
                dataGridView1.Columns)
            {
                column.ImageLayout = DataGridViewImageCellLayout.Normal;
                column.Description = "Normal";
            }
        }

        private void ListarElementos()
        {
            if (id.Text.Trim() != "")
            {
                cbxCategoria.DisplayMember = "Descripcion";
                cbxCategoria.ValueMember = "IdCategoria";
                cbxCategoria.DataSource = C.Listar();
                cbxCategoria.SelectedItem = id.Text;
            }
            else
            {
                cbxCategoria.DisplayMember = "Descripcion";
                cbxCategoria.ValueMember = "IdCategoria";
                cbxCategoria.DataSource = C.Listar();
            }
        }

        public void clear()
        {
            id.Clear();
            rbbuena.Checked = false;
            rdmedia.Checked = false;
            rbCero.Checked = false;
            rbtodos.Checked = false;
            radioButton1.Checked = false;
            rbfechaing.Checked = false;
            rbfechamod.Checked = false;
            txtdesc.Text = "";
            CargarListado();
        }
        public void CargarListado(string palabra = null)
        {
            try
            {
                decimal compras = 0, total = 0, ventas = 0, totalproducto = 0;
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

                if (palabra != null)
                {
                    //declaramos el comando para realizar la busqueda
                    comando.CommandText = "Select IdProducto,IdCategoria,Nombre,Marca,PrecioCompra,PrecioVenta,Stock,FechaVencimiento,FechaModificacion,itbis," +
                        "Pmax =COALESCE(dbo.Producto.Pmax,0),Pmin =COALESCE(dbo.Producto.Pmin,0) From Producto Where Nombre LIKE '%" + palabra + "%' OR Marca LIKE '%" + palabra + "%'";
                }
                else
                {
                    //declaramos el comando para realizar la busqueda
                    comando.CommandText = "Select IdProducto,IdCategoria,Nombre,Marca,PrecioCompra,PrecioVenta,Stock,FechaVencimiento,FechaModificacion,itbis," +
                        "Pmax =COALESCE(dbo.Producto.Pmax,0),Pmin =COALESCE(dbo.Producto.Pmin,0) From Producto";
                }

                //especificamos que es de tipo Text
                comando.CommandType = CommandType.Text;
                //se abre la conexion
                con.Open();
                //limpiamos los renglones de la datagridview
                dataGridView1.Rows.Clear();
                //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                dr = comando.ExecuteReader();
                //el ciclo while se ejecutará mientras lea registros en la tabla
                while (dr.Read())
                {
                    //variable de tipo entero para ir enumerando los la filas del datagridview
                    int renglon = dataGridView1.Rows.Add();
                    // especificamos en que fila se mostrará cada registro
                    // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

                    dataGridView1.Rows[renglon].Cells[0].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdProducto")));
                    dataGridView1.Rows[renglon].Cells[1].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdCategoria")));
                    dataGridView1.Rows[renglon].Cells[2].Value = dr.GetString(dr.GetOrdinal("Nombre"));
                    dataGridView1.Rows[renglon].Cells[3].Value = dr.GetString(dr.GetOrdinal("Marca"));
                    dataGridView1.Rows[renglon].Cells[4].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioCompra")));
                    dataGridView1.Rows[renglon].Cells[5].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioVenta")));
                    dataGridView1.Rows[renglon].Cells[6].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("Stock")));
                    dataGridView1.Rows[renglon].Cells[7].Value = dr.GetDateTime(dr.GetOrdinal("FechaVencimiento"));
                    dataGridView1.Rows[renglon].Cells[8].Value = dr.GetDateTime(dr.GetOrdinal("FechaModificacion"));
                    dataGridView1.Rows[renglon].Cells[9].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("itbis")));

                    compras += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[4].Value);
                    ventas += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[5].Value);
                    totalproducto += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[6].Value);
                    total = ventas - compras;
                    txttotalG.Text = Convert.ToString(total);
                    lbltotalproductos.Text = Convert.ToString(totalproducto);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Está Seguro que Desea Salir.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmRegistroProductos P = new FrmRegistroProductos();
            if (dataGridView1.SelectedRows.Count > 0)
                Program.Evento = 1;
            else
                Program.Evento = 0;
            dataGridView1.ClearSelection();
            P.label6.Text = "Fecha de Ingreso";
            P.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FrmRegistroProductos P = new FrmRegistroProductos();
                P.txtIdP.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                P.IdC.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                P.txtProducto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                P.txtMarca.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                P.txtPCompra.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                P.txtPVenta.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                P.txtStock.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                P.txtitbis.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                P.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[8].Value.ToString());
                P.button1.Visible = true;
                P.btnGuardar.Visible = false;
                P.label6.Text = "Fecha de Modificacion";
                P.label11.Text = "Actualizar Producto";
                P.Show();

                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
            }

            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                    dataGridView1.ClearSelection();
            }
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Program.abiertosecundarias = false;
            Program.IdProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Column1"].Value.ToString());
            Program.Descripcion = dataGridView1.CurrentRow.Cells["description"].Value.ToString();
            Program.Marca = dataGridView1.CurrentRow.Cells["marca"].Value.ToString();
            Program.PrecioVenta = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["pVenta"].Value.ToString());
            Program.Stock = Convert.ToInt32(dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString());
            Program.IdCategoria = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdC"].Value.ToString());
            Program.itbis = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["itbis"].Value.ToString());
            this.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void rbCero_CheckedChanged(object sender, EventArgs e)
        {
            decimal compras = 0, total = 0, ventas = 0, totalproducto = 0;
            if (rbCero.Checked == true)
            {
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
                comando.CommandText = "	Select IdProducto,IdCategoria,Nombre,Marca,PrecioCompra,PrecioVenta,Stock,FechaVencimiento,FechaModificacion,itbis,Pmax =COALESCE(dbo.Producto.Pmax,0),Pmin =COALESCE(dbo.Producto.Pmin,0) From Producto Where Stock=0";
                //especificamos que es de tipo Text
                comando.CommandType = CommandType.Text;
                //se abre la conexion
                con.Open();
                //limpiamos los renglones de la datagridview
                dataGridView1.Rows.Clear();
                //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                dr = comando.ExecuteReader();
                //el ciclo while se ejecutará mientras lea registros en la tabla
                while (dr.Read())
                {
                    //variable de tipo entero para ir enumerando los la filas del datagridview
                    int renglon = dataGridView1.Rows.Add();
                    // especificamos en que fila se mostrará cada registro
                    // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

                    dataGridView1.Rows[renglon].Cells[0].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdProducto")));
                    dataGridView1.Rows[renglon].Cells[1].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdCategoria")));
                    dataGridView1.Rows[renglon].Cells[2].Value = dr.GetString(dr.GetOrdinal("Nombre"));
                    dataGridView1.Rows[renglon].Cells[3].Value = dr.GetString(dr.GetOrdinal("Marca"));
                    dataGridView1.Rows[renglon].Cells[4].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioCompra")));
                    dataGridView1.Rows[renglon].Cells[5].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioVenta")));
                    dataGridView1.Rows[renglon].Cells[6].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("Stock")));
                    dataGridView1.Rows[renglon].Cells[8].Value = dr.GetDateTime(dr.GetOrdinal("FechaModificacion"));
                    dataGridView1.Rows[renglon].Cells[9].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("itbis")));

                    compras += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[4].Value);
                    ventas += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[5].Value);
                    totalproducto += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[6].Value);
                    lbltotalproductos.Text = Convert.ToString(totalproducto);
                    total = ventas - compras;
                    txttotalG.Text = Convert.ToString(total);
                }
                con.Close();
            }
            else
            {
                CargarListado();
            }
        }
        private void rdmedia_CheckedChanged(object sender, EventArgs e)
        {
            decimal compras = 0, total = 0, ventas = 0, totalproducto = 0;
            if (rdmedia.Checked == true)
            {
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
                comando.CommandText = "Select IdProducto,IdCategoria,Nombre,Marca,PrecioCompra,PrecioVenta,Stock,FechaVencimiento,FechaModificacion,itbis,Pmax =COALESCE(dbo.Producto.Pmax,0),Pmin =COALESCE(dbo.Producto.Pmin,0) From Producto Where Stock >4  And Stock <11 ";
                //especificamos que es de tipo Text
                comando.CommandType = CommandType.Text;
                //se abre la conexion
                con.Open();
                //limpiamos los renglones de la datagridview
                dataGridView1.Rows.Clear();
                //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                dr = comando.ExecuteReader();
                //el ciclo while se ejecutará mientras lea registros en la tabla
                while (dr.Read())
                {
                    //variable de tipo entero para ir enumerando los la filas del datagridview
                    int renglon = dataGridView1.Rows.Add();
                    // especificamos en que fila se mostrará cada registro
                    // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

                    dataGridView1.Rows[renglon].Cells[0].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdProducto")));
                    dataGridView1.Rows[renglon].Cells[1].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdCategoria")));
                    dataGridView1.Rows[renglon].Cells[2].Value = dr.GetString(dr.GetOrdinal("Nombre"));
                    dataGridView1.Rows[renglon].Cells[3].Value = dr.GetString(dr.GetOrdinal("Marca"));
                    dataGridView1.Rows[renglon].Cells[4].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioCompra")));
                    dataGridView1.Rows[renglon].Cells[5].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioVenta")));
                    dataGridView1.Rows[renglon].Cells[6].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("Stock")));
                    dataGridView1.Rows[renglon].Cells[7].Value = dr.GetDateTime(dr.GetOrdinal("FechaVencimiento"));
                    dataGridView1.Rows[renglon].Cells[8].Value = dr.GetDateTime(dr.GetOrdinal("FechaModificacion"));
                    dataGridView1.Rows[renglon].Cells[9].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("itbis")));

                    compras += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[4].Value);
                    ventas += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[5].Value);
                    totalproducto += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[6].Value);
                    lbltotalproductos.Text = Convert.ToString(totalproducto);
                    total = ventas - compras;
                    txttotalG.Text = Convert.ToString(total);
                }
                con.Close();
            }
            else
            {
                CargarListado();
            }
        }

        private void rbbuena_CheckedChanged(object sender, EventArgs e)
        {
            decimal compras = 0, total = 0, ventas = 0, totalproducto = 0;
            if (rbbuena.Checked == true)
            {
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
                comando.CommandText = "Select IdProducto,IdCategoria,Nombre,Marca,PrecioCompra,PrecioVenta,Stock,FechaVencimiento,FechaModificacion,itbis,Pmax =COALESCE(dbo.Producto.Pmax,0),Pmin =COALESCE(dbo.Producto.Pmin,0) From Producto Where Stock >10 ";
                //especificamos que es de tipo Text
                comando.CommandType = CommandType.Text;
                //se abre la conexion
                con.Open();
                //limpiamos los renglones de la datagridview
                dataGridView1.Rows.Clear();
                //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                dr = comando.ExecuteReader();
                //el ciclo while se ejecutará mientras lea registros en la tabla
                while (dr.Read())
                {
                    //variable de tipo entero para ir enumerando los la filas del datagridview
                    int renglon = dataGridView1.Rows.Add();
                    // especificamos en que fila se mostrará cada registro
                    // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

                    dataGridView1.Rows[renglon].Cells[0].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdProducto")));
                    dataGridView1.Rows[renglon].Cells[1].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdCategoria")));
                    dataGridView1.Rows[renglon].Cells[2].Value = dr.GetString(dr.GetOrdinal("Nombre"));
                    dataGridView1.Rows[renglon].Cells[3].Value = dr.GetString(dr.GetOrdinal("Marca"));
                    dataGridView1.Rows[renglon].Cells[4].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioCompra")));
                    dataGridView1.Rows[renglon].Cells[5].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioVenta")));
                    dataGridView1.Rows[renglon].Cells[6].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("Stock")));
                    dataGridView1.Rows[renglon].Cells[7].Value = dr.GetDateTime(dr.GetOrdinal("FechaVencimiento"));
                    dataGridView1.Rows[renglon].Cells[8].Value = dr.GetDateTime(dr.GetOrdinal("FechaModificacion"));
                    dataGridView1.Rows[renglon].Cells[9].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("itbis")));

                    compras += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[4].Value);
                    ventas += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[5].Value);
                    totalproducto += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[6].Value);
                    lbltotalproductos.Text = Convert.ToString(totalproducto);
                    total = ventas - compras;
                    txttotalG.Text = Convert.ToString(total);
                }
                con.Close();
            }
            else
            {
                CargarListado();
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            decimal compras = 0, total = 0, ventas = 0, totalproducto = 0;
            if (radioButton1.Checked == true)
            {
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
                comando.CommandText = "Select IdProducto,IdCategoria,Nombre,Marca,PrecioCompra,PrecioVenta,Stock,FechaVencimiento,FechaModificacion,itbis,Pmax =COALESCE(dbo.Producto.Pmax,0),Pmin =COALESCE(dbo.Producto.Pmin,0) From Producto Where Stock >0 and Stock <5 ";
                //especificamos que es de tipo Text
                comando.CommandType = CommandType.Text;
                //se abre la conexion
                con.Open();
                //limpiamos los renglones de la datagridview
                dataGridView1.Rows.Clear();
                //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                dr = comando.ExecuteReader();
                //el ciclo while se ejecutará mientras lea registros en la tabla
                while (dr.Read())
                {
                    //variable de tipo entero para ir enumerando los la filas del datagridview
                    int renglon = dataGridView1.Rows.Add();
                    // especificamos en que fila se mostrará cada registro
                    // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

                    dataGridView1.Rows[renglon].Cells[0].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdProducto")));
                    dataGridView1.Rows[renglon].Cells[1].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdCategoria")));
                    dataGridView1.Rows[renglon].Cells[2].Value = dr.GetString(dr.GetOrdinal("Nombre"));
                    dataGridView1.Rows[renglon].Cells[3].Value = dr.GetString(dr.GetOrdinal("Marca"));
                    dataGridView1.Rows[renglon].Cells[4].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioCompra")));
                    dataGridView1.Rows[renglon].Cells[5].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioVenta")));
                    dataGridView1.Rows[renglon].Cells[6].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("Stock")));
                    dataGridView1.Rows[renglon].Cells[7].Value = dr.GetDateTime(dr.GetOrdinal("FechaVencimiento"));
                    dataGridView1.Rows[renglon].Cells[8].Value = dr.GetDateTime(dr.GetOrdinal("FechaModificacion"));
                    dataGridView1.Rows[renglon].Cells[9].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("itbis")));

                    compras += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[4].Value);
                    ventas += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[5].Value);
                    totalproducto += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[6].Value);
                    lbltotalproductos.Text = Convert.ToString(totalproducto);
                    total = ventas - compras;
                    txttotalG.Text = Convert.ToString(total);
                }
                con.Close();
            }
            else
            {
                CargarListado();
            }
        }
        private void rbtodos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListado();
        }

        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarid();
            decimal compras = 0, total = 0, ventas = 0, totalproducto = 0;
            if (id.Text != "")
            {
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
                comando.CommandText = "Select IdProducto,IdCategoria,Nombre,Marca,PrecioCompra,PrecioVenta,Stock,FechaVencimiento,FechaModificacion,itbis,Pmax =COALESCE(dbo.Producto.Pmax,0),Pmin =COALESCE(dbo.Producto.Pmin,0) From Producto Where IdCategoria=" + id.Text;
                //especificamos que es de tipo Text
                comando.CommandType = CommandType.Text;
                //se abre la conexion
                con.Open();
                //limpiamos los renglones de la datagridview
                dataGridView1.Rows.Clear();
                //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                dr = comando.ExecuteReader();
                //el ciclo while se ejecutará mientras lea registros en la tabla
                while (dr.Read())
                {
                    //variable de tipo entero para ir enumerando los la filas del datagridview
                    int renglon = dataGridView1.Rows.Add();
                    // especificamos en que fila se mostrará cada registro
                    // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

                    dataGridView1.Rows[renglon].Cells[0].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdProducto")));
                    dataGridView1.Rows[renglon].Cells[1].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdCategoria")));
                    dataGridView1.Rows[renglon].Cells[2].Value = dr.GetString(dr.GetOrdinal("Nombre"));
                    dataGridView1.Rows[renglon].Cells[3].Value = dr.GetString(dr.GetOrdinal("Marca"));
                    dataGridView1.Rows[renglon].Cells[4].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioCompra")));
                    dataGridView1.Rows[renglon].Cells[5].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioVenta")));
                    dataGridView1.Rows[renglon].Cells[6].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("Stock")));
                    dataGridView1.Rows[renglon].Cells[7].Value = dr.GetDateTime(dr.GetOrdinal("FechaVencimiento"));
                    dataGridView1.Rows[renglon].Cells[8].Value = dr.GetDateTime(dr.GetOrdinal("FechaModificacion"));
                    dataGridView1.Rows[renglon].Cells[9].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("itbis")));

                    compras += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[4].Value);
                    ventas += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[5].Value);
                    totalproducto += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[6].Value);
                    lbltotalproductos.Text = Convert.ToString(totalproducto);
                    total = ventas - compras;
                    txttotalG.Text = Convert.ToString(total);
                }
                con.Close();
            }
            else
            {
                CargarListado();
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "cantidad")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                    e.CellStyle.BackColor = System.Drawing.Color.Red;
                }

                if (Convert.ToInt32(e.Value) > 0 && Convert.ToInt32(e.Value) < 5)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Black;
                    e.CellStyle.BackColor = System.Drawing.Color.Yellow;
                }

                if (Convert.ToInt32(e.Value) > 4 && Convert.ToInt32(e.Value) < 11)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Black;
                    e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                }

                if (Convert.ToInt32(e.Value) > 10)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Black;
                    e.CellStyle.BackColor = System.Drawing.Color.CornflowerBlue;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            id.Text = "";
            cbxCategoria.Text = "";
            clear();
            txtBuscarProducto.Text = "";
            CargarListado();
            Refresh();
        }

        string Reporte;
        private void To_pdf()
        {
            if (txtdesc.Text != "")
            {
                Reporte = "Inventario de Productos por Categoria " + cbxCategoria.Text;
            }

            if (rbtodos.Checked == true)
            {
                Reporte = "Inventario de Todos los Productos";
            }

            if (rbCero.Checked == true)
            {
                Reporte = "Inventario de Todos los Productos en Cero";
            }

            if (radioButton1.Checked == true)
            {
                Reporte = "Inventario de Todos los Productos con Cantidad Minima";
            }

            if (rdmedia.Checked == true)
            {
                Reporte = "Inventario de Todos los Productos con Cantidad Media";
            }

            if (rbbuena.Checked == true)
            {
                Reporte = "Inventario de Todos los Productos con Cantidad Suficiente";
            }

            if (txtdesc.Text != "")
            {
                Reporte = "Inventario de " + txtdesc.Text;
            }

            if (rbfechaing.Checked == true)
            {
                Reporte = "Inventario de Fecha de Ingreso \n" +
                    "Desde " + dtpfecha1.Text + "\n" +
                    "Hasta " + dtpfecha2.Text;
            }

            if (rbfechamod.Checked == true)
            {
                Reporte = "Inventario de Fecha de Modificacion \n" +
                    "Desde " + dtpfecha1.Text + "\n" +
                    "Hasta " + dtpfecha2.Text;
            }

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
            string filename = "Reporte" + DateTime.Now.ToString();
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
                    doc.Add(new Paragraph("Reporte de Inventario de Productos   "));
                    doc.Add(new Paragraph("                       "));
                    GenerarDocumento(doc);
                    doc.AddCreationDate();
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Total de Productos = " + lbltotalproductos.Text));
                    doc.Add(new Paragraph("Ganancias Total de Ventas= " + txttotalG.Text));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("____________________________________"));
                    doc.Add(new Paragraph("                         Firma              "));
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
                        datatable.AddCell(new Phrase(dataGridView1[j, i].Value.ToString(), FontFactory.GetFont("ARIAL", 6, iTextSharp.text.Font.NORMAL)));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
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
        private void btnimpimir_Click(object sender, EventArgs e)
        {
            To_pdf();
        }

        string repeto;
        public void repetitivo()
        {
            Cx.conexion.Open();
            string sql = "select top(1) Nombre, Sum( Cantidad ) AS total FROM  dbo.DetalleVenta INNER JOIN " +
                "dbo.Producto ON dbo.DetalleVenta.IdProducto = dbo.Producto.IdProducto where Producto.IdProducto = " +
                "DetalleVenta.IdProducto GROUP BY Nombre ORDER BY total DESC";
            SqlCommand cmd = new SqlCommand(sql, Cx.conexion);
            SqlDataReader reade = cmd.ExecuteReader();
            if (reade.Read())
            {
                repeto = reade["Nombre"].ToString();
                txtRep.Text = repeto;

            }
            Cx.conexion.Close();
        }

        string mrepeto;
        public void Mrepetitivo()
        {
            Cx.conexion.Open();
            string sql = "select top(1) Nombre, Sum( Cantidad ) AS total FROM  dbo.DetalleVenta INNER JOIN " +
                "dbo.Producto ON dbo.DetalleVenta.IdProducto = dbo.Producto.IdProducto where Producto.IdProducto = " +
                "DetalleVenta.IdProducto GROUP BY Nombre ORDER BY total ASC";
            SqlCommand cmd = new SqlCommand(sql, Cx.conexion);
            SqlDataReader reade = cmd.ExecuteReader();
            if (reade.Read())
            {
                mrepeto = reade["Nombre"].ToString();
                txtMrep.Text = mrepeto;
            }
            Cx.conexion.Close();
        }

        private void rbfechaing_CheckedChanged(object sender, EventArgs e)
        {
            decimal compras = 0, total = 0, ventas = 0, totalproducto = 0;
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
            comando.CommandText = "	Select * From Producto where FechaVencimiento BETWEEN convert(datetime, CONVERT(varchar(10), @fecha1, 103), 103) AND convert(datetime, CONVERT(varchar(10), @fecha2, 103), 103)";
            comando.Parameters.AddWithValue("@fecha1", dtpfecha1.Value);
            comando.Parameters.AddWithValue("@fecha2", dtpfecha2.Value);
            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            con.Open();
            //limpiamos los renglones de la datagridview
            dataGridView1.Rows.Clear();
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            //el ciclo while se ejecutará mientras lea registros en la tabla
            while (dr.Read())
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                int renglon = dataGridView1.Rows.Add();
                // especificamos en que fila se mostrará cada registro
                // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

                dataGridView1.Rows[renglon].Cells[0].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdProducto")));
                dataGridView1.Rows[renglon].Cells[1].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdCategoria")));
                dataGridView1.Rows[renglon].Cells[2].Value = dr.GetString(dr.GetOrdinal("Nombre"));
                dataGridView1.Rows[renglon].Cells[3].Value = dr.GetString(dr.GetOrdinal("Marca"));
                dataGridView1.Rows[renglon].Cells[4].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioCompra")));
                dataGridView1.Rows[renglon].Cells[5].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioVenta")));
                dataGridView1.Rows[renglon].Cells[6].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("Stock")));
                dataGridView1.Rows[renglon].Cells[7].Value = dr.GetDateTime(dr.GetOrdinal("FechaVencimiento"));
                dataGridView1.Rows[renglon].Cells[8].Value = dr.GetDateTime(dr.GetOrdinal("FechaModificacion"));
                dataGridView1.Rows[renglon].Cells[9].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("itbis")));

                totalproducto += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[6].Value);
                lbltotalproductos.Text = Convert.ToString(totalproducto);

                compras += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[4].Value);
                ventas += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[5].Value);

                total = ventas - compras;
                txttotalG.Text = Convert.ToString(total);
            }
            con.Close();
        }

        private void rbfechamod_CheckedChanged(object sender, EventArgs e)
        {
            decimal compras = 0, total = 0, ventas = 0, totalproducto = 0;

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
            comando.CommandText = "Select * From Producto where FechaModificacion BETWEEN convert(datetime, CONVERT(varchar(10), @fecha1, 103), 103) AND convert(datetime, CONVERT(varchar(10), @fecha2, 103), 103)";
            comando.Parameters.AddWithValue("@fecha1", dtpfecha1.Value);
            comando.Parameters.AddWithValue("@fecha2", dtpfecha2.Value);
            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            con.Open();
            //limpiamos los renglones de la datagridview
            dataGridView1.Rows.Clear();
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            //el ciclo while se ejecutará mientras lea registros en la tabla
            while (dr.Read())
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                int renglon = dataGridView1.Rows.Add();
                // especificamos en que fila se mostrará cada registro
                // nombredeldatagrid.filas[numerodefila].celdas[nombrdelacelda].valor=\

                dataGridView1.Rows[renglon].Cells[0].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdProducto")));
                dataGridView1.Rows[renglon].Cells[1].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("IdCategoria")));
                dataGridView1.Rows[renglon].Cells[2].Value = dr.GetString(dr.GetOrdinal("Nombre"));
                dataGridView1.Rows[renglon].Cells[3].Value = dr.GetString(dr.GetOrdinal("Marca"));
                dataGridView1.Rows[renglon].Cells[4].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioCompra")));
                dataGridView1.Rows[renglon].Cells[5].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("PrecioVenta")));
                dataGridView1.Rows[renglon].Cells[6].Value = Convert.ToString(dr.GetInt32(dr.GetOrdinal("Stock")));
                dataGridView1.Rows[renglon].Cells[7].Value = dr.GetDateTime(dr.GetOrdinal("FechaVencimiento"));
                dataGridView1.Rows[renglon].Cells[8].Value = dr.GetDateTime(dr.GetOrdinal("FechaModificacion"));
                dataGridView1.Rows[renglon].Cells[9].Value = Convert.ToString(dr.GetDecimal(dr.GetOrdinal("itbis")));

                totalproducto += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[6].Value);
                lbltotalproductos.Text = Convert.ToString(totalproducto);

                compras += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[4].Value);
                ventas += Convert.ToDecimal(dataGridView1.Rows[renglon].Cells[5].Value);

                total = ventas - compras;
                txttotalG.Text = Convert.ToString(total);
            }
            con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Program.IdProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (Program.IdProducto > 0)
            {
                if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Está Seguro que Desea Eliminar este Producto.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    using (SqlCommand cmd = new SqlCommand("eliminarProducto", Cx.conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = Program.IdProducto;

                        Cx.conexion.Open();
                        cmd.ExecuteNonQuery();
                        Cx.conexion.Close();
                        CargarListado();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por Favor Seleccione un producto antes de eliminarlo");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void FrmListadoProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.abiertosecundarias = false;
            Program.abierto = false;
            if (Program.CargoEmpleadoLogueado != "Administrador")
            {
                btnEditar.Enabled = false;
            }
        }

        private void FrmListadoProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.abiertosecundarias = false;
            Program.abierto = false;
            if (Program.CargoEmpleadoLogueado != "Administrador")
            {
                btnEditar.Enabled = false;
            }
        }

        private void txtBuscarProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscarProducto.Text.Length >= 3)
                CargarListado(txtBuscarProducto.Text);
        }
    }
}

