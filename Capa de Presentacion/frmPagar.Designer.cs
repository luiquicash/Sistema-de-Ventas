namespace Capa_de_Presentacion
{
	partial class frmPagar
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

#pragma warning disable CS0115 // 'frmPagar.Dispose(bool)': no se encontró ningún miembro adecuado para invalidar
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // 'frmPagar.Dispose(bool)': no se encontró ningún miembro adecuado para invalidar
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
            this.gbAbrir = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvCaja = new System.Windows.Forms.DataGridView();
            this.Id_caja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActual = new System.Windows.Forms.TextBox();
            this.txtCaja = new System.Windows.Forms.TextBox();
            this.gbPagar = new System.Windows.Forms.GroupBox();
            this.btnC = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmonto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDev = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpaga = new System.Windows.Forms.TextBox();
            this.txtCaja1 = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIdp = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.gbAbrir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).BeginInit();
            this.gbPagar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAbrir
            // 
            this.gbAbrir.BackColor = System.Drawing.Color.SeaGreen;
            this.gbAbrir.Controls.Add(this.button4);
            this.gbAbrir.Controls.Add(this.dgvCaja);
            this.gbAbrir.Controls.Add(this.button1);
            this.gbAbrir.Controls.Add(this.btnCerrar);
            this.gbAbrir.Controls.Add(this.label2);
            this.gbAbrir.Controls.Add(this.label1);
            this.gbAbrir.Controls.Add(this.txtActual);
            this.gbAbrir.Controls.Add(this.txtCaja);
            this.gbAbrir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAbrir.ForeColor = System.Drawing.Color.Black;
            this.gbAbrir.Location = new System.Drawing.Point(836, 13);
            this.gbAbrir.Margin = new System.Windows.Forms.Padding(4);
            this.gbAbrir.Name = "gbAbrir";
            this.gbAbrir.Padding = new System.Windows.Forms.Padding(4);
            this.gbAbrir.Size = new System.Drawing.Size(704, 300);
            this.gbAbrir.TabIndex = 0;
            this.gbAbrir.TabStop = false;
            this.gbAbrir.Text = "Apertura de Caja";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Tan;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Image = global::Capa_de_Presentacion.Properties.Resources.icons8_producto_30;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(400, 238);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(291, 40);
            this.button4.TabIndex = 6;
            this.button4.Text = "Entrar a Inventario";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // dgvCaja
            // 
            this.dgvCaja.AllowUserToAddRows = false;
            this.dgvCaja.AllowUserToDeleteRows = false;
            this.dgvCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaja.BackgroundColor = System.Drawing.Color.White;
            this.dgvCaja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaja.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCaja.ColumnHeadersHeight = 25;
            this.dgvCaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_caja,
            this.monto,
            this.fecha});
            this.dgvCaja.EnableHeadersVisualStyles = false;
            this.dgvCaja.GridColor = System.Drawing.Color.White;
            this.dgvCaja.Location = new System.Drawing.Point(24, 118);
            this.dgvCaja.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCaja.Name = "dgvCaja";
            this.dgvCaja.ReadOnly = true;
            this.dgvCaja.RowHeadersVisible = false;
            this.dgvCaja.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dgvCaja.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCaja.RowTemplate.Height = 24;
            this.dgvCaja.Size = new System.Drawing.Size(665, 112);
            this.dgvCaja.TabIndex = 5;
            // 
            // Id_caja
            // 
            this.Id_caja.FillWeight = 38.23428F;
            this.Id_caja.HeaderText = "ID Caja";
            this.Id_caja.MinimumWidth = 6;
            this.Id_caja.Name = "Id_caja";
            this.Id_caja.ReadOnly = true;
            // 
            // monto
            // 
            this.monto.FillWeight = 152.2843F;
            this.monto.HeaderText = "Monto Inicial";
            this.monto.MinimumWidth = 6;
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            // 
            // fecha
            // 
            // 
            // 
            // 
            this.fecha.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.fecha.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.fecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fecha.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.fecha.FillWeight = 109.4815F;
            this.fecha.HeaderText = "Fecha de Apertura";
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
            this.fecha.ReadOnly = true;
            this.fecha.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SpringGreen;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::Capa_de_Presentacion.Properties.Resources.icons8_abrir_carpeta_16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(528, 55);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "Abrir Caja";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.Red;
            this.btnCerrar.Location = new System.Drawing.Point(663, 12);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(29, 34);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(193, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad Actual";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monto En Caja";
            // 
            // txtActual
            // 
            this.txtActual.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActual.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtActual.Location = new System.Drawing.Point(196, 58);
            this.txtActual.Margin = new System.Windows.Forms.Padding(4);
            this.txtActual.Multiline = true;
            this.txtActual.Name = "txtActual";
            this.txtActual.Size = new System.Drawing.Size(143, 38);
            this.txtActual.TabIndex = 1;
            this.txtActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFinal_KeyPress);
            // 
            // txtCaja
            // 
            this.txtCaja.BackColor = System.Drawing.Color.SeaGreen;
            this.txtCaja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCaja.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaja.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtCaja.Location = new System.Drawing.Point(7, 58);
            this.txtCaja.Margin = new System.Windows.Forms.Padding(4);
            this.txtCaja.Multiline = true;
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.ReadOnly = true;
            this.txtCaja.Size = new System.Drawing.Size(144, 38);
            this.txtCaja.TabIndex = 0;
            this.txtCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbPagar
            // 
            this.gbPagar.BackColor = System.Drawing.Color.Gray;
            this.gbPagar.Controls.Add(this.btnC);
            this.gbPagar.Controls.Add(this.label6);
            this.gbPagar.Controls.Add(this.txtmonto);
            this.gbPagar.Controls.Add(this.label5);
            this.gbPagar.Controls.Add(this.txtDev);
            this.gbPagar.Controls.Add(this.button2);
            this.gbPagar.Controls.Add(this.label3);
            this.gbPagar.Controls.Add(this.label4);
            this.gbPagar.Controls.Add(this.txtpaga);
            this.gbPagar.Controls.Add(this.txtCaja1);
            this.gbPagar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPagar.ForeColor = System.Drawing.Color.Black;
            this.gbPagar.Location = new System.Drawing.Point(13, 13);
            this.gbPagar.Margin = new System.Windows.Forms.Padding(4);
            this.gbPagar.Name = "gbPagar";
            this.gbPagar.Padding = new System.Windows.Forms.Padding(4);
            this.gbPagar.Size = new System.Drawing.Size(704, 200);
            this.gbPagar.TabIndex = 1;
            this.gbPagar.TabStop = false;
            this.gbPagar.Text = "Realizar Pago";
            // 
            // btnC
            // 
            this.btnC.FlatAppearance.BorderSize = 0;
            this.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnC.ForeColor = System.Drawing.Color.Red;
            this.btnC.Location = new System.Drawing.Point(662, 19);
            this.btnC.Margin = new System.Windows.Forms.Padding(4);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(29, 35);
            this.btnC.TabIndex = 18;
            this.btnC.Text = "X";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(199, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Monto a Pagar :";
            // 
            // txtmonto
            // 
            this.txtmonto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmonto.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtmonto.Location = new System.Drawing.Point(201, 63);
            this.txtmonto.Margin = new System.Windows.Forms.Padding(4);
            this.txtmonto.Multiline = true;
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.ReadOnly = true;
            this.txtmonto.Size = new System.Drawing.Size(143, 47);
            this.txtmonto.TabIndex = 12;
            this.txtmonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(542, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Devuelta :";
            // 
            // txtDev
            // 
            this.txtDev.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDev.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtDev.Location = new System.Drawing.Point(545, 64);
            this.txtDev.Margin = new System.Windows.Forms.Padding(4);
            this.txtDev.Multiline = true;
            this.txtDev.Name = "txtDev";
            this.txtDev.Size = new System.Drawing.Size(143, 47);
            this.txtDev.TabIndex = 10;
            this.txtDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDev.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFinal_KeyPress);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SpringGreen;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = global::Capa_de_Presentacion.Properties.Resources.icons8_dinero_241;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(550, 138);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 54);
            this.button2.TabIndex = 9;
            this.button2.Text = "Pagar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(378, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Pagar con :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Monto En Caja";
            // 
            // txtpaga
            // 
            this.txtpaga.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpaga.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtpaga.Location = new System.Drawing.Point(381, 64);
            this.txtpaga.Margin = new System.Windows.Forms.Padding(4);
            this.txtpaga.Multiline = true;
            this.txtpaga.Name = "txtpaga";
            this.txtpaga.Size = new System.Drawing.Size(143, 47);
            this.txtpaga.TabIndex = 6;
            this.txtpaga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtpaga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFinal_KeyPress);
            this.txtpaga.Leave += new System.EventHandler(this.txtpaga_Leave);
            // 
            // txtCaja1
            // 
            this.txtCaja1.BackColor = System.Drawing.Color.Gray;
            this.txtCaja1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCaja1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaja1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtCaja1.Location = new System.Drawing.Point(23, 63);
            this.txtCaja1.Margin = new System.Windows.Forms.Padding(4);
            this.txtCaja1.Multiline = true;
            this.txtCaja1.Name = "txtCaja1";
            this.txtCaja1.ReadOnly = true;
            this.txtCaja1.Size = new System.Drawing.Size(144, 48);
            this.txtCaja1.TabIndex = 5;
            this.txtCaja1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtId.Location = new System.Drawing.Point(941, 476);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(78, 22);
            this.txtId.TabIndex = 16;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIdp
            // 
            this.txtIdp.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdp.Location = new System.Drawing.Point(941, 415);
            this.txtIdp.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdp.Name = "txtIdp";
            this.txtIdp.Size = new System.Drawing.Size(78, 22);
            this.txtIdp.TabIndex = 17;
            this.txtIdp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(941, 364);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 22);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // frmPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(732, 231);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtIdp);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.gbPagar);
            this.Controls.Add(this.gbAbrir);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuadres y Pagos";
            this.Load += new System.EventHandler(this.frmPagar_Load_1);
            this.gbAbrir.ResumeLayout(false);
            this.gbAbrir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).EndInit();
            this.gbPagar.ResumeLayout(false);
            this.gbPagar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtActual;
		private System.Windows.Forms.TextBox txtCaja;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCaja1;
		public System.Windows.Forms.GroupBox gbAbrir;
		public System.Windows.Forms.GroupBox gbPagar;
		public System.Windows.Forms.Button btnCerrar;
		public System.Windows.Forms.TextBox txtmonto;
		public System.Windows.Forms.TextBox txtDev;
		public System.Windows.Forms.TextBox txtpaga;
		public System.Windows.Forms.Button btnC;
		private System.Windows.Forms.DataGridView dgvCaja;
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'DevComponents' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'DevComponents' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
		public System.Windows.Forms.TextBox txtId;
		public System.Windows.Forms.TextBox txtIdp;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id_caja;
		private System.Windows.Forms.DataGridViewTextBoxColumn monto;
		private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn fecha;
		public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button4;
    }
}