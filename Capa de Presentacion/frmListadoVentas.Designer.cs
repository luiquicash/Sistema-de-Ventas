namespace Capa_de_Presentacion
{
	partial class frmListadoVentas
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

#pragma warning disable CS0115 // 'frmListadoVentas.Dispose(bool)': no se encontró ningún miembro adecuado para invalidar
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // 'frmListadoVentas.Dispose(bool)': no se encontró ningún miembro adecuado para invalidar
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.can = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.igv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.NCF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscarid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMontvend = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.id_p = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCantvend = new System.Windows.Forms.TextBox();
            this.lblV = new System.Windows.Forms.Label();
            this.txtidprod = new System.Windows.Forms.TextBox();
            this.lblTV = new System.Windows.Forms.Label();
            this.lblPV = new System.Windows.Forms.Label();
            this.txtprod = new System.Windows.Forms.TextBox();
            this.lblT = new System.Windows.Forms.Label();
            this.txtTtal = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblDir = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.txtRepi = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpfecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpfecha1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.CategoryOfProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadOfProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioOfProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txttotalventaespecifica = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGanancias = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.combo_tipo_NCF = new System.Windows.Forms.ComboBox();
            this.cbtipodocumento = new System.Windows.Forms.CheckBox();
            this.vereliminadas = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(13, 129);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 343);
            this.panel1.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombrecliente,
            this.idcliente,
            this.Tipo,
            this.idEm,
            this.idp,
            this.can,
            this.descripcion,
            this.pre,
            this.igv,
            this.subtotal,
            this.restante,
            this.total,
            this.fecha,
            this.NCF,
            this.nroComprobante,
            this.PrecioCompra});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, -1);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(887, 345);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id Venta";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 95;
            // 
            // nombrecliente
            // 
            this.nombrecliente.HeaderText = "Nombre Cliente";
            this.nombrecliente.MinimumWidth = 6;
            this.nombrecliente.Name = "nombrecliente";
            this.nombrecliente.Visible = false;
            this.nombrecliente.Width = 145;
            // 
            // idcliente
            // 
            this.idcliente.HeaderText = "Id Cliente";
            this.idcliente.MinimumWidth = 6;
            this.idcliente.Name = "idcliente";
            this.idcliente.Visible = false;
            this.idcliente.Width = 104;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo Factura";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            this.Tipo.Width = 127;
            // 
            // idEm
            // 
            this.idEm.HeaderText = "Id Empleado";
            this.idEm.MinimumWidth = 6;
            this.idEm.Name = "idEm";
            this.idEm.Visible = false;
            this.idEm.Width = 124;
            // 
            // idp
            // 
            this.idp.HeaderText = "Id Producto";
            this.idp.MinimumWidth = 6;
            this.idp.Name = "idp";
            this.idp.ReadOnly = true;
            this.idp.Visible = false;
            this.idp.Width = 120;
            // 
            // can
            // 
            this.can.HeaderText = "Cantidad";
            this.can.MinimumWidth = 6;
            this.can.Name = "can";
            this.can.ReadOnly = true;
            this.can.Width = 101;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripcion Producto";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            this.descripcion.Width = 190;
            // 
            // pre
            // 
            this.pre.HeaderText = "Precio Por Unidad";
            this.pre.MinimumWidth = 6;
            this.pre.Name = "pre";
            this.pre.ReadOnly = true;
            this.pre.Width = 164;
            // 
            // igv
            // 
            this.igv.HeaderText = "ITBIS";
            this.igv.MinimumWidth = 6;
            this.igv.Name = "igv";
            this.igv.Width = 75;
            // 
            // subtotal
            // 
            this.subtotal.HeaderText = "Sub-total";
            this.subtotal.MinimumWidth = 6;
            this.subtotal.Name = "subtotal";
            this.subtotal.Width = 102;
            // 
            // restante
            // 
            this.restante.HeaderText = "Restante";
            this.restante.MinimumWidth = 6;
            this.restante.Name = "restante";
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.Width = 74;
            // 
            // fecha
            // 
            // 
            // 
            // 
            this.fecha.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.fecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fecha.HeaderText = "Fecha de Venta";
            this.fecha.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.fecha.MinimumWidth = 6;
            // 
            // 
            // 
            this.fecha.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fecha.MonthCalendar.BackgroundStyle.Class = "";
            this.fecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.fecha.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.fecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fecha.MonthCalendar.DisplayMonth = new System.DateTime(2019, 7, 1, 0, 0, 0, 0);
            this.fecha.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.fecha.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fecha.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.fecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fecha.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.fecha.Name = "fecha";
            this.fecha.Width = 145;
            // 
            // NCF
            // 
            this.NCF.HeaderText = "Tipo Comprobante";
            this.NCF.MinimumWidth = 6;
            this.NCF.Name = "NCF";
            this.NCF.Width = 168;
            // 
            // nroComprobante
            // 
            this.nroComprobante.HeaderText = "Numero de Comprobante";
            this.nroComprobante.MinimumWidth = 6;
            this.nroComprobante.Name = "nroComprobante";
            this.nroComprobante.Width = 212;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio de Compra";
            this.PrecioCompra.MinimumWidth = 6;
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.Visible = false;
            this.PrecioCompra.Width = 162;
            // 
            // txtBuscarid
            // 
            this.txtBuscarid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarid.Location = new System.Drawing.Point(395, 92);
            this.txtBuscarid.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarid.Name = "txtBuscarid";
            this.txtBuscarid.Size = new System.Drawing.Size(367, 25);
            this.txtBuscarid.TabIndex = 8;
            this.txtBuscarid.TextChanged += new System.EventHandler(this.txtBuscarCliente_TextChanged);
            this.txtBuscarid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarid_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Buscar por ID Venta  o Descripcion de Producto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1331, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtMontvend
            // 
            this.txtMontvend.Location = new System.Drawing.Point(287, 582);
            this.txtMontvend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMontvend.Name = "txtMontvend";
            this.txtMontvend.ReadOnly = true;
            this.txtMontvend.Size = new System.Drawing.Size(113, 22);
            this.txtMontvend.TabIndex = 97;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeight = 29;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_p,
            this.sub,
            this.cant});
            this.dataGridView2.Location = new System.Drawing.Point(1496, 88);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(381, 384);
            this.dataGridView2.TabIndex = 96;
            // 
            // id_p
            // 
            this.id_p.FillWeight = 44.24779F;
            this.id_p.HeaderText = "ID";
            this.id_p.MinimumWidth = 6;
            this.id_p.Name = "id_p";
            // 
            // sub
            // 
            this.sub.FillWeight = 85.64481F;
            this.sub.HeaderText = "Total x Prod";
            this.sub.MinimumWidth = 6;
            this.sub.Name = "sub";
            // 
            // cant
            // 
            this.cant.FillWeight = 170.1074F;
            this.cant.HeaderText = "Cant Vendida x Prod";
            this.cant.MinimumWidth = 6;
            this.cant.Name = "cant";
            // 
            // txtCantvend
            // 
            this.txtCantvend.Location = new System.Drawing.Point(287, 643);
            this.txtCantvend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCantvend.Name = "txtCantvend";
            this.txtCantvend.ReadOnly = true;
            this.txtCantvend.Size = new System.Drawing.Size(113, 22);
            this.txtCantvend.TabIndex = 99;
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblV.Location = new System.Drawing.Point(11, 582);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(167, 18);
            this.lblV.TabIndex = 100;
            this.lblV.Text = "Total Vendido en el Dia :";
            // 
            // txtidprod
            // 
            this.txtidprod.Location = new System.Drawing.Point(1496, 495);
            this.txtidprod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtidprod.Name = "txtidprod";
            this.txtidprod.Size = new System.Drawing.Size(100, 22);
            this.txtidprod.TabIndex = 101;
            // 
            // lblTV
            // 
            this.lblTV.AutoSize = true;
            this.lblTV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTV.Location = new System.Drawing.Point(11, 643);
            this.lblTV.Name = "lblTV";
            this.lblTV.Size = new System.Drawing.Size(239, 18);
            this.lblTV.TabIndex = 102;
            this.lblTV.Text = "Total de Veces Vendidas en el Dia :";
            // 
            // lblPV
            // 
            this.lblPV.AutoSize = true;
            this.lblPV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPV.Location = new System.Drawing.Point(11, 613);
            this.lblPV.Name = "lblPV";
            this.lblPV.Size = new System.Drawing.Size(228, 18);
            this.lblPV.TabIndex = 104;
            this.lblPV.Text = "Producto Mas Vendido en el Dia :";
            // 
            // txtprod
            // 
            this.txtprod.Location = new System.Drawing.Point(287, 613);
            this.txtprod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtprod.Name = "txtprod";
            this.txtprod.ReadOnly = true;
            this.txtprod.Size = new System.Drawing.Size(143, 22);
            this.txtprod.TabIndex = 103;
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT.Location = new System.Drawing.Point(11, 523);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(106, 18);
            this.lblT.TabIndex = 106;
            this.lblT.Text = "Total Vendido :";
            // 
            // txtTtal
            // 
            this.txtTtal.Location = new System.Drawing.Point(287, 523);
            this.txtTtal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTtal.Name = "txtTtal";
            this.txtTtal.ReadOnly = true;
            this.txtTtal.Size = new System.Drawing.Size(113, 22);
            this.txtTtal.TabIndex = 105;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Khaki;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Image = global::Capa_de_Presentacion.Properties.Resources.icons8_imprimir;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(772, 643);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(327, 39);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Imprimir Reporte de Ventas";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.SpringGreen;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnNuevo.Image = global::Capa_de_Presentacion.Properties.Resources.icons8_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(772, 549);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(128, 39);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDir.ForeColor = System.Drawing.Color.Black;
            this.lblDir.Location = new System.Drawing.Point(1512, 588);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(76, 17);
            this.lblDir.TabIndex = 108;
            this.lblDir.Text = "Direccion";
            this.lblDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.Location = new System.Drawing.Point(1510, 519);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(65, 29);
            this.lblLogo.TabIndex = 107;
            this.lblLogo.Text = "logo";
            // 
            // txtRepi
            // 
            this.txtRepi.Location = new System.Drawing.Point(1496, 561);
            this.txtRepi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRepi.Name = "txtRepi";
            this.txtRepi.Size = new System.Drawing.Size(100, 22);
            this.txtRepi.TabIndex = 109;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.dtpfecha2);
            this.groupBox3.Controls.Add(this.dtpfecha1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(456, 495);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(287, 167);
            this.groupBox3.TabIndex = 110;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar por Fecha";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::Capa_de_Presentacion.Properties.Resources.icons8_buscar;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 106);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 38);
            this.button1.TabIndex = 111;
            this.button1.Text = "Buscar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(183, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 18);
            this.label12.TabIndex = 110;
            this.label12.Text = "Hasta:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 18);
            this.label11.TabIndex = 109;
            this.label11.Text = "Desde :";
            // 
            // dtpfecha2
            // 
            this.dtpfecha2.CustomFormat = "";
            this.dtpfecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfecha2.Location = new System.Drawing.Point(151, 63);
            this.dtpfecha2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpfecha2.Name = "dtpfecha2";
            this.dtpfecha2.Size = new System.Drawing.Size(121, 24);
            this.dtpfecha2.TabIndex = 107;
            // 
            // dtpfecha1
            // 
            this.dtpfecha1.CustomFormat = "";
            this.dtpfecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfecha1.Location = new System.Drawing.Point(12, 63);
            this.dtpfecha1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpfecha1.Name = "dtpfecha1";
            this.dtpfecha1.Size = new System.Drawing.Size(121, 24);
            this.dtpfecha1.TabIndex = 107;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGray;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = global::Capa_de_Presentacion.Properties.Resources.icons8_limpiar;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(772, 502);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 39);
            this.button2.TabIndex = 111;
            this.button2.Text = "Limpiar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(498, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 29);
            this.label3.TabIndex = 112;
            this.label3.Text = "Listado de Ventas Realizadas";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView3);
            this.panel2.Location = new System.Drawing.Point(912, 126);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 471);
            this.panel2.TabIndex = 113;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.Gray;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView3.ColumnHeadersHeight = 29;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryOfProducts,
            this.CantidadOfProducts,
            this.PrecioOfProducts});
            this.dataGridView3.Location = new System.Drawing.Point(5, 4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(425, 464);
            this.dataGridView3.TabIndex = 0;
            // 
            // CategoryOfProducts
            // 
            this.CategoryOfProducts.HeaderText = "Tipo";
            this.CategoryOfProducts.MinimumWidth = 125;
            this.CategoryOfProducts.Name = "CategoryOfProducts";
            this.CategoryOfProducts.ReadOnly = true;
            this.CategoryOfProducts.Width = 125;
            // 
            // CantidadOfProducts
            // 
            this.CantidadOfProducts.HeaderText = "Cantidad";
            this.CantidadOfProducts.MinimumWidth = 90;
            this.CantidadOfProducts.Name = "CantidadOfProducts";
            this.CantidadOfProducts.ReadOnly = true;
            this.CantidadOfProducts.Width = 90;
            // 
            // PrecioOfProducts
            // 
            this.PrecioOfProducts.HeaderText = "Total";
            this.PrecioOfProducts.MinimumWidth = 100;
            this.PrecioOfProducts.Name = "PrecioOfProducts";
            this.PrecioOfProducts.ReadOnly = true;
            this.PrecioOfProducts.Width = 125;
            // 
            // txttotalventaespecifica
            // 
            this.txttotalventaespecifica.Location = new System.Drawing.Point(1254, 603);
            this.txttotalventaespecifica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txttotalventaespecifica.Name = "txttotalventaespecifica";
            this.txttotalventaespecifica.ReadOnly = true;
            this.txttotalventaespecifica.Size = new System.Drawing.Size(100, 22);
            this.txttotalventaespecifica.TabIndex = 114;
            this.txttotalventaespecifica.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 552);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 18);
            this.label4.TabIndex = 116;
            this.label4.Text = "Total de Ganancias :";
            // 
            // txtGanancias
            // 
            this.txtGanancias.Location = new System.Drawing.Point(287, 552);
            this.txtGanancias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGanancias.Name = "txtGanancias";
            this.txtGanancias.ReadOnly = true;
            this.txtGanancias.Size = new System.Drawing.Size(113, 22);
            this.txtGanancias.TabIndex = 115;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Firebrick;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Image = global::Capa_de_Presentacion.Properties.Resources.icons8_eliminar;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(772, 596);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 39);
            this.button3.TabIndex = 117;
            this.button3.Text = "Eliminar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // combo_tipo_NCF
            // 
            this.combo_tipo_NCF.BackColor = System.Drawing.Color.White;
            this.combo_tipo_NCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_tipo_NCF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.combo_tipo_NCF.FormattingEnabled = true;
            this.combo_tipo_NCF.Location = new System.Drawing.Point(817, 93);
            this.combo_tipo_NCF.Margin = new System.Windows.Forms.Padding(4);
            this.combo_tipo_NCF.Name = "combo_tipo_NCF";
            this.combo_tipo_NCF.Size = new System.Drawing.Size(328, 24);
            this.combo_tipo_NCF.TabIndex = 118;
            // 
            // cbtipodocumento
            // 
            this.cbtipodocumento.AutoSize = true;
            this.cbtipodocumento.Location = new System.Drawing.Point(779, 97);
            this.cbtipodocumento.Name = "cbtipodocumento";
            this.cbtipodocumento.Size = new System.Drawing.Size(18, 17);
            this.cbtipodocumento.TabIndex = 119;
            this.cbtipodocumento.UseVisualStyleBackColor = true;
            // 
            // vereliminadas
            // 
            this.vereliminadas.AutoSize = true;
            this.vereliminadas.Location = new System.Drawing.Point(1153, 97);
            this.vereliminadas.Name = "vereliminadas";
            this.vereliminadas.Size = new System.Drawing.Size(124, 21);
            this.vereliminadas.TabIndex = 120;
            this.vereliminadas.Text = "Ver Eliminadas";
            this.vereliminadas.UseVisualStyleBackColor = true;
            this.vereliminadas.CheckedChanged += new System.EventHandler(this.vereliminadas_CheckedChanged);
            // 
            // frmListadoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1371, 690);
            this.Controls.Add(this.vereliminadas);
            this.Controls.Add(this.cbtipodocumento);
            this.Controls.Add(this.combo_tipo_NCF);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGanancias);
            this.Controls.Add(this.txttotalventaespecifica);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtRepi);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.lblT);
            this.Controls.Add(this.txtTtal);
            this.Controls.Add(this.lblPV);
            this.Controls.Add(this.txtprod);
            this.Controls.Add(this.lblTV);
            this.Controls.Add(this.txtidprod);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.txtCantvend);
            this.Controls.Add(this.txtMontvend);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBuscarid);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmListadoVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Ventas";
            this.Load += new System.EventHandler(this.frmListadoVentas_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnNuevo;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtBuscarid;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridViewTextBoxColumn id_p;
		private System.Windows.Forms.DataGridViewTextBoxColumn sub;
		private System.Windows.Forms.DataGridViewTextBoxColumn cant;
		private System.Windows.Forms.TextBox txtidprod;
		public System.Windows.Forms.Button btnCancelar;
		public System.Windows.Forms.Label lblDir;
		public System.Windows.Forms.Label lblLogo;
		public System.Windows.Forms.TextBox txtRepi;
		public System.Windows.Forms.TextBox txtMontvend;
		public System.Windows.Forms.TextBox txtCantvend;
		public System.Windows.Forms.Label lblV;
		public System.Windows.Forms.Label lblTV;
		public System.Windows.Forms.Label lblPV;
		public System.Windows.Forms.TextBox txtprod;
		public System.Windows.Forms.Label lblT;
		public System.Windows.Forms.TextBox txtTtal;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.DateTimePicker dtpfecha2;
		private System.Windows.Forms.DateTimePicker dtpfecha1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEm;
        private System.Windows.Forms.DataGridViewTextBoxColumn idp;
        private System.Windows.Forms.DataGridViewTextBoxColumn can;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn pre;
        private System.Windows.Forms.DataGridViewTextBoxColumn igv;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn restante;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn NCF;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroComprobante;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryOfProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadOfProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioOfProducts;
        public System.Windows.Forms.TextBox txttotalventaespecifica;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtGanancias;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox combo_tipo_NCF;
        private System.Windows.Forms.CheckBox cbtipodocumento;
        private System.Windows.Forms.CheckBox vereliminadas;
    }
}