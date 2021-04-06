namespace Capa_de_Presentacion
{
	partial class frmMovimientoCaja
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

#pragma warning disable CS0115 // 'frmMovimientoCaja.Dispose(bool)': no se encontró ningún miembro adecuado para invalidar
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // 'frmMovimientoCaja.Dispose(bool)': no se encontró ningún miembro adecuado para invalidar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_caja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.egresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscarCaja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDir = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnimprimir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblgastos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.lbldeu = new System.Windows.Forms.Label();
            this.lblegr = new System.Windows.Forms.Label();
            this.lbling = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montogasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agregargasto = new System.Windows.Forms.Button();
            this.txtdescripciondegasto = new System.Windows.Forms.TextBox();
            this.txtmontogasto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmonto_inicial = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(27, 93);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 439);
            this.panel1.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_pago,
            this.id_caja,
            this.monto,
            this.ingresos,
            this.egresos});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(-1, -1);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(630, 434);
            this.dataGridView1.TabIndex = 0;
            // 
            // id_pago
            // 
            this.id_pago.HeaderText = "ID Pago";
            this.id_pago.MinimumWidth = 80;
            this.id_pago.Name = "id_pago";
            this.id_pago.Width = 80;
            // 
            // id_caja
            // 
            this.id_caja.HeaderText = "ID Caja";
            this.id_caja.MinimumWidth = 6;
            this.id_caja.Name = "id_caja";
            this.id_caja.Visible = false;
            this.id_caja.Width = 125;
            // 
            // monto
            // 
            this.monto.HeaderText = "Monto venta";
            this.monto.MinimumWidth = 120;
            this.monto.Name = "monto";
            this.monto.Width = 120;
            // 
            // ingresos
            // 
            this.ingresos.HeaderText = "Pagos";
            this.ingresos.MinimumWidth = 110;
            this.ingresos.Name = "ingresos";
            this.ingresos.Width = 110;
            // 
            // egresos
            // 
            this.egresos.HeaderText = "Devueltas";
            this.egresos.MinimumWidth = 110;
            this.egresos.Name = "egresos";
            this.egresos.Width = 110;
            // 
            // txtBuscarCaja
            // 
            this.txtBuscarCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCaja.Location = new System.Drawing.Point(175, 56);
            this.txtBuscarCaja.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarCaja.Name = "txtBuscarCaja";
            this.txtBuscarCaja.Size = new System.Drawing.Size(189, 25);
            this.txtBuscarCaja.TabIndex = 14;
            this.txtBuscarCaja.TextChanged += new System.EventHandler(this.txtBuscarCaja_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Buscar por ID Caja :";
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDir.Location = new System.Drawing.Point(1302, 240);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(24, 17);
            this.lblDir.TabIndex = 54;
            this.lblDir.Text = "dir";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.Location = new System.Drawing.Point(1300, 211);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(65, 29);
            this.lblLogo.TabIndex = 53;
            this.lblLogo.Text = "logo";
            // 
            // btnimprimir
            // 
            this.btnimprimir.BackColor = System.Drawing.Color.Khaki;
            this.btnimprimir.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnimprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnimprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimprimir.ForeColor = System.Drawing.Color.Black;
            this.btnimprimir.Image = global::Capa_de_Presentacion.Properties.Resources.icons8_imprimir;
            this.btnimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnimprimir.Location = new System.Drawing.Point(964, 602);
            this.btnimprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(192, 33);
            this.btnimprimir.TabIndex = 16;
            this.btnimprimir.Text = "Imprimir Reporte";
            this.btnimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnimprimir.UseVisualStyleBackColor = false;
            this.btnimprimir.Click += new System.EventHandler(this.btnimprimir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1148, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 24);
            this.label2.TabIndex = 55;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(469, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(256, 29);
            this.label11.TabIndex = 79;
            this.label11.Text = "Movimientos en Caja";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 558);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 18);
            this.label3.TabIndex = 80;
            this.label3.Text = "Total de Pagos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(319, 558);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 18);
            this.label4.TabIndex = 82;
            this.label4.Text = "Total de Devueltas:";
            // 
            // lblgastos
            // 
            this.lblgastos.AutoSize = true;
            this.lblgastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgastos.Location = new System.Drawing.Point(638, 558);
            this.lblgastos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblgastos.Name = "lblgastos";
            this.lblgastos.Size = new System.Drawing.Size(118, 18);
            this.lblgastos.TabIndex = 83;
            this.lblgastos.Text = "Total de Gastos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(932, 558);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 84;
            this.label6.Text = "Total Final:";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbltotal.Location = new System.Drawing.Point(1016, 558);
            this.lbltotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(20, 18);
            this.lbltotal.TabIndex = 88;
            this.lbltotal.Text = "...";
            // 
            // lbldeu
            // 
            this.lbldeu.AutoSize = true;
            this.lbldeu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldeu.ForeColor = System.Drawing.Color.Gold;
            this.lbldeu.Location = new System.Drawing.Point(765, 558);
            this.lbldeu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldeu.Name = "lbldeu";
            this.lbldeu.Size = new System.Drawing.Size(20, 18);
            this.lbldeu.TabIndex = 87;
            this.lbldeu.Text = "...";
            // 
            // lblegr
            // 
            this.lblegr.AutoSize = true;
            this.lblegr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblegr.ForeColor = System.Drawing.Color.Red;
            this.lblegr.Location = new System.Drawing.Point(467, 558);
            this.lblegr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblegr.Name = "lblegr";
            this.lblegr.Size = new System.Drawing.Size(20, 18);
            this.lblegr.TabIndex = 86;
            this.lblegr.Text = "...";
            // 
            // lbling
            // 
            this.lbling.AutoSize = true;
            this.lbling.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbling.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbling.Location = new System.Drawing.Point(133, 558);
            this.lbling.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbling.Name = "lbling";
            this.lbling.Size = new System.Drawing.Size(20, 18);
            this.lbling.TabIndex = 85;
            this.lbling.Text = "...";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Location = new System.Drawing.Point(719, 174);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 356);
            this.panel2.TabIndex = 89;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.ColumnHeadersHeight = 29;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.descripcion,
            this.montogasto});
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(-1, 1);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(437, 351);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id Gasto";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 125;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.MinimumWidth = 150;
            this.descripcion.Name = "descripcion";
            this.descripcion.Width = 150;
            // 
            // montogasto
            // 
            this.montogasto.HeaderText = "Monto";
            this.montogasto.MinimumWidth = 120;
            this.montogasto.Name = "montogasto";
            this.montogasto.ReadOnly = true;
            this.montogasto.Width = 120;
            // 
            // agregargasto
            // 
            this.agregargasto.BackColor = System.Drawing.Color.CornflowerBlue;
            this.agregargasto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.agregargasto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.agregargasto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.agregargasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregargasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregargasto.ForeColor = System.Drawing.Color.Black;
            this.agregargasto.Image = global::Capa_de_Presentacion.Properties.Resources.icons8_agregar;
            this.agregargasto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.agregargasto.Location = new System.Drawing.Point(1101, 133);
            this.agregargasto.Margin = new System.Windows.Forms.Padding(4);
            this.agregargasto.Name = "agregargasto";
            this.agregargasto.Size = new System.Drawing.Size(55, 33);
            this.agregargasto.TabIndex = 90;
            this.agregargasto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.agregargasto.UseVisualStyleBackColor = false;
            this.agregargasto.Click += new System.EventHandler(this.agregargasto_Click);
            // 
            // txtdescripciondegasto
            // 
            this.txtdescripciondegasto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdescripciondegasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescripciondegasto.Location = new System.Drawing.Point(865, 100);
            this.txtdescripciondegasto.Margin = new System.Windows.Forms.Padding(4);
            this.txtdescripciondegasto.Name = "txtdescripciondegasto";
            this.txtdescripciondegasto.Size = new System.Drawing.Size(291, 25);
            this.txtdescripciondegasto.TabIndex = 91;
            // 
            // txtmontogasto
            // 
            this.txtmontogasto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmontogasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmontogasto.Location = new System.Drawing.Point(865, 141);
            this.txtmontogasto.Margin = new System.Windows.Forms.Padding(4);
            this.txtmontogasto.Name = "txtmontogasto";
            this.txtmontogasto.Size = new System.Drawing.Size(175, 25);
            this.txtmontogasto.TabIndex = 92;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(720, 102);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 18);
            this.label7.TabIndex = 93;
            this.label7.Text = "Descripcion :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(720, 141);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 18);
            this.label8.TabIndex = 94;
            this.label8.Text = "Monto :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(861, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 20);
            this.label5.TabIndex = 95;
            this.label5.Text = "Registro de Gastos";
            // 
            // txtmonto_inicial
            // 
            this.txtmonto_inicial.Location = new System.Drawing.Point(1294, 301);
            this.txtmonto_inicial.Name = "txtmonto_inicial";
            this.txtmonto_inicial.Size = new System.Drawing.Size(100, 22);
            this.txtmonto_inicial.TabIndex = 96;
            // 
            // frmMovimientoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1183, 652);
            this.Controls.Add(this.txtmonto_inicial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtmontogasto);
            this.Controls.Add(this.txtdescripciondegasto);
            this.Controls.Add(this.agregargasto);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.lbldeu);
            this.Controls.Add(this.lblegr);
            this.Controls.Add(this.lbling);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblgastos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.btnimprimir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBuscarCaja);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMovimientoCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos en Caja";
            this.Activated += new System.EventHandler(this.frmMovimientoCaja_Activated);
            this.Load += new System.EventHandler(this.frmMovimientoCaja_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnimprimir;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtBuscarCaja;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label lblDir;
		public System.Windows.Forms.Label lblLogo;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblgastos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label lbldeu;
        private System.Windows.Forms.Label lblegr;
        private System.Windows.Forms.Label lbling;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button agregargasto;
        private System.Windows.Forms.TextBox txtdescripciondegasto;
        private System.Windows.Forms.TextBox txtmontogasto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn montogasto;
        private System.Windows.Forms.TextBox txtmonto_inicial;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_caja;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn egresos;
    }
}