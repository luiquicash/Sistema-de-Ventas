namespace Capa_de_Presentacion
{
	partial class frmLimitantesNCF
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
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
            this.data_comprobante = new System.Windows.Forms.DataGridView();
            this.id_comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secuenciai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secuenciaf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblcomp = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpfinal = new System.Windows.Forms.DateTimePicker();
            this.dtpinicio = new System.Windows.Forms.DateTimePicker();
            this.txtfinal = new System.Windows.Forms.TextBox();
            this.txtinicio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.data_ncf = new System.Windows.Forms.DataGridView();
            this.id_ncf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_comprobante)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_ncf)).BeginInit();
            this.SuspendLayout();
            // 
            // data_comprobante
            // 
            this.data_comprobante.AllowUserToAddRows = false;
            this.data_comprobante.BackgroundColor = System.Drawing.Color.White;
            this.data_comprobante.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_comprobante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.data_comprobante.ColumnHeadersHeight = 29;
            this.data_comprobante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_comprobante,
            this.secuenciai,
            this.secuenciaf,
            this.fecha_inicio,
            this.fecha_final});
            this.data_comprobante.EnableHeadersVisualStyles = false;
            this.data_comprobante.GridColor = System.Drawing.Color.Black;
            this.data_comprobante.Location = new System.Drawing.Point(24, 513);
            this.data_comprobante.Name = "data_comprobante";
            this.data_comprobante.RowHeadersWidth = 51;
            this.data_comprobante.RowTemplate.Height = 24;
            this.data_comprobante.Size = new System.Drawing.Size(977, 221);
            this.data_comprobante.TabIndex = 72;
            // 
            // id_comprobante
            // 
            this.id_comprobante.HeaderText = "ID";
            this.id_comprobante.MinimumWidth = 6;
            this.id_comprobante.Name = "id_comprobante";
            this.id_comprobante.Width = 125;
            // 
            // secuenciai
            // 
            this.secuenciai.HeaderText = "Secuencia Inicial";
            this.secuenciai.MinimumWidth = 6;
            this.secuenciai.Name = "secuenciai";
            this.secuenciai.Width = 200;
            // 
            // secuenciaf
            // 
            this.secuenciaf.HeaderText = "Secuancia Final";
            this.secuenciaf.MinimumWidth = 6;
            this.secuenciaf.Name = "secuenciaf";
            this.secuenciaf.Width = 200;
            // 
            // fecha_inicio
            // 
            this.fecha_inicio.HeaderText = "Fecha Inicial";
            this.fecha_inicio.MinimumWidth = 6;
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.Width = 200;
            // 
            // fecha_final
            // 
            this.fecha_final.HeaderText = "Fecha Final";
            this.fecha_final.MinimumWidth = 6;
            this.fecha_final.Name = "fecha_final";
            this.fecha_final.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblcomp);
            this.groupBox2.Controls.Add(this.txtid);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpfinal);
            this.groupBox2.Controls.Add(this.dtpinicio);
            this.groupBox2.Controls.Add(this.txtfinal);
            this.groupBox2.Controls.Add(this.txtinicio);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.groupBox2.Location = new System.Drawing.Point(566, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 386);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Limitantes";
            // 
            // lblcomp
            // 
            this.lblcomp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblcomp.AutoEllipsis = true;
            this.lblcomp.AutoSize = true;
            this.lblcomp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblcomp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblcomp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblcomp.Location = new System.Drawing.Point(85, 42);
            this.lblcomp.Margin = new System.Windows.Forms.Padding(0);
            this.lblcomp.Name = "lblcomp";
            this.lblcomp.Size = new System.Drawing.Size(171, 18);
            this.lblcomp.TabIndex = 76;
            this.lblcomp.Text = "Tipo de Comprobante";
            this.lblcomp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.Enabled = false;
            this.txtid.Location = new System.Drawing.Point(232, 107);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(82, 22);
            this.txtid.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 74;
            this.label6.Text = "ID NCF";
            // 
            // dtpfinal
            // 
            this.dtpfinal.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpfinal.CalendarTrailingForeColor = System.Drawing.SystemColors.Desktop;
            this.dtpfinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfinal.Location = new System.Drawing.Point(232, 215);
            this.dtpfinal.Name = "dtpfinal";
            this.dtpfinal.Size = new System.Drawing.Size(165, 22);
            this.dtpfinal.TabIndex = 72;
            // 
            // dtpinicio
            // 
            this.dtpinicio.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpinicio.CalendarTrailingForeColor = System.Drawing.SystemColors.Desktop;
            this.dtpinicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpinicio.Location = new System.Drawing.Point(232, 170);
            this.dtpinicio.Name = "dtpinicio";
            this.dtpinicio.Size = new System.Drawing.Size(165, 22);
            this.dtpinicio.TabIndex = 71;
            // 
            // txtfinal
            // 
            this.txtfinal.BackColor = System.Drawing.Color.White;
            this.txtfinal.Location = new System.Drawing.Point(232, 333);
            this.txtfinal.Name = "txtfinal";
            this.txtfinal.Size = new System.Drawing.Size(165, 22);
            this.txtfinal.TabIndex = 70;
            this.txtfinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtinicio_KeyPress);
            // 
            // txtinicio
            // 
            this.txtinicio.BackColor = System.Drawing.Color.White;
            this.txtinicio.Location = new System.Drawing.Point(232, 286);
            this.txtinicio.Name = "txtinicio";
            this.txtinicio.Size = new System.Drawing.Size(165, 22);
            this.txtinicio.TabIndex = 69;
            this.txtinicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtinicio_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 68;
            this.label4.Text = "Secuencia Inicial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 67;
            this.label3.Text = "Secuencia Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "Fecha Final:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 65;
            this.label1.Text = "Fecha Inicial:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.data_ncf);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.groupBox1.Location = new System.Drawing.Point(24, 111);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(524, 337);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elige el NCF que vas a Limitar";
            // 
            // data_ncf
            // 
            this.data_ncf.AllowUserToAddRows = false;
            this.data_ncf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_ncf.BackgroundColor = System.Drawing.Color.White;
            this.data_ncf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_ncf.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.data_ncf.ColumnHeadersHeight = 29;
            this.data_ncf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_ncf,
            this.tipo,
            this.Activo});
            this.data_ncf.EnableHeadersVisualStyles = false;
            this.data_ncf.GridColor = System.Drawing.Color.Black;
            this.data_ncf.Location = new System.Drawing.Point(8, 25);
            this.data_ncf.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.data_ncf.Name = "data_ncf";
            this.data_ncf.RowHeadersVisible = false;
            this.data_ncf.RowHeadersWidth = 51;
            this.data_ncf.RowTemplate.Height = 24;
            this.data_ncf.Size = new System.Drawing.Size(506, 304);
            this.data_ncf.TabIndex = 0;
            this.data_ncf.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.data_ncf_CellFormatting);
            this.data_ncf.DoubleClick += new System.EventHandler(this.data_ncf_DoubleClick);
            // 
            // id_ncf
            // 
            this.id_ncf.FillWeight = 50.17418F;
            this.id_ncf.HeaderText = "ID NCF";
            this.id_ncf.MinimumWidth = 45;
            this.id_ncf.Name = "id_ncf";
            // 
            // tipo
            // 
            this.tipo.FillWeight = 177.6333F;
            this.tipo.HeaderText = "Tipo De NCF";
            this.tipo.MinimumWidth = 6;
            this.tipo.Name = "tipo";
            // 
            // Activo
            // 
            this.Activo.FillWeight = 72.19251F;
            this.Activo.HeaderText = "Activo";
            this.Activo.MinimumWidth = 45;
            this.Activo.Name = "Activo";
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.SpringGreen;
            this.btnAplicar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAplicar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAplicar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnAplicar.ForeColor = System.Drawing.Color.Black;
            this.btnAplicar.Image = global::Capa_de_Presentacion.Properties.Resources.icons8_aplicar;
            this.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicar.Location = new System.Drawing.Point(24, 455);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(119, 42);
            this.btnAplicar.TabIndex = 71;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(992, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 24);
            this.label5.TabIndex = 73;
            this.label5.Text = "X";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(345, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(299, 29);
            this.label7.TabIndex = 113;
            this.label7.Text = "Limitaciones de los NCF";
            // 
            // frmLimitantesNCF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1027, 746);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.data_comprobante);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLimitantesNCF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Limitantes NCF";
            this.Load += new System.EventHandler(this.frmLimitantesNCF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_comprobante)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_ncf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView data_comprobante;
		private System.Windows.Forms.DataGridViewTextBoxColumn id_comprobante;
		private System.Windows.Forms.DataGridViewTextBoxColumn secuenciai;
		private System.Windows.Forms.DataGridViewTextBoxColumn secuenciaf;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicio;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha_final;
		private System.Windows.Forms.Button btnAplicar;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtid;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dtpfinal;
		private System.Windows.Forms.DateTimePicker dtpinicio;
		private System.Windows.Forms.TextBox txtfinal;
		private System.Windows.Forms.TextBox txtinicio;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView data_ncf;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label lblcomp;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_ncf;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activo;
    }
}