namespace GUI
{
    partial class Reporte
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ctBarras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnUltimos7Dias = new System.Windows.Forms.Button();
            this.btnUltimos30Dias = new System.Windows.Forms.Button();
            this.btnEsteMes = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalHoras = new System.Windows.Forms.Label();
            this.lblTituloTotalHorasReservadas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalReservas = new System.Windows.Forms.Label();
            this.lblTituloTotalReservas = new System.Windows.Forms.Label();
            this.ctPastel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpFechaHora = new System.Windows.Forms.DateTimePicker();
            this.btnVerPorHora = new System.Windows.Forms.Button();
            this.dgvDashboard = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ctBarras)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctPastel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctBarras
            // 
            this.ctBarras.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea3.Name = "ChartArea1";
            this.ctBarras.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.ctBarras.Legends.Add(legend3);
            this.ctBarras.Location = new System.Drawing.Point(125, 399);
            this.ctBarras.Name = "ctBarras";
            series3.ChartArea = "ChartArea1";
            series3.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.ctBarras.Series.Add(series3);
            this.ctBarras.Size = new System.Drawing.Size(740, 320);
            this.ctBarras.TabIndex = 0;
            this.ctBarras.Text = "chart1";
            // 
            // btnHoy
            // 
            this.btnHoy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHoy.Location = new System.Drawing.Point(1242, 171);
            this.btnHoy.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(173, 43);
            this.btnHoy.TabIndex = 57;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = true;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnUltimos7Dias
            // 
            this.btnUltimos7Dias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUltimos7Dias.Location = new System.Drawing.Point(1242, 124);
            this.btnUltimos7Dias.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnUltimos7Dias.Name = "btnUltimos7Dias";
            this.btnUltimos7Dias.Size = new System.Drawing.Size(173, 43);
            this.btnUltimos7Dias.TabIndex = 56;
            this.btnUltimos7Dias.Text = "Ultimos 7 Dias";
            this.btnUltimos7Dias.UseVisualStyleBackColor = true;
            this.btnUltimos7Dias.Click += new System.EventHandler(this.btnUltimos7Dias_Click);
            // 
            // btnUltimos30Dias
            // 
            this.btnUltimos30Dias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUltimos30Dias.Location = new System.Drawing.Point(1429, 171);
            this.btnUltimos30Dias.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnUltimos30Dias.Name = "btnUltimos30Dias";
            this.btnUltimos30Dias.Size = new System.Drawing.Size(173, 43);
            this.btnUltimos30Dias.TabIndex = 55;
            this.btnUltimos30Dias.Text = "Ultimos 30 Dias";
            this.btnUltimos30Dias.UseVisualStyleBackColor = true;
            this.btnUltimos30Dias.Click += new System.EventHandler(this.btnUltimos30Dias_Click);
            // 
            // btnEsteMes
            // 
            this.btnEsteMes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEsteMes.Location = new System.Drawing.Point(1429, 124);
            this.btnEsteMes.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnEsteMes.Name = "btnEsteMes";
            this.btnEsteMes.Size = new System.Drawing.Size(173, 43);
            this.btnEsteMes.TabIndex = 54;
            this.btnEsteMes.Text = "Este Mes";
            this.btnEsteMes.UseVisualStyleBackColor = true;
            this.btnEsteMes.Click += new System.EventHandler(this.btnEsteMes_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblTotalHoras);
            this.panel2.Controls.Add(this.lblTituloTotalHorasReservadas);
            this.panel2.Location = new System.Drawing.Point(611, 125);
            this.panel2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 90);
            this.panel2.TabIndex = 61;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblTotalHoras
            // 
            this.lblTotalHoras.AutoSize = true;
            this.lblTotalHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHoras.Location = new System.Drawing.Point(99, 42);
            this.lblTotalHoras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalHoras.Name = "lblTotalHoras";
            this.lblTotalHoras.Size = new System.Drawing.Size(97, 29);
            this.lblTotalHoras.TabIndex = 1;
            this.lblTotalHoras.Text = "100000";
            // 
            // lblTituloTotalHorasReservadas
            // 
            this.lblTituloTotalHorasReservadas.AutoSize = true;
            this.lblTituloTotalHorasReservadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTotalHorasReservadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(141)))), ((int)(((byte)(181)))));
            this.lblTituloTotalHorasReservadas.Location = new System.Drawing.Point(100, 17);
            this.lblTituloTotalHorasReservadas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloTotalHorasReservadas.Name = "lblTituloTotalHorasReservadas";
            this.lblTituloTotalHorasReservadas.Size = new System.Drawing.Size(222, 25);
            this.lblTituloTotalHorasReservadas.TabIndex = 0;
            this.lblTituloTotalHorasReservadas.Text = "Total Horas Reservadas";
            this.lblTituloTotalHorasReservadas.Click += new System.EventHandler(this.lblTituloTotalHorasReservadas_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTotalReservas);
            this.panel1.Controls.Add(this.lblTituloTotalReservas);
            this.panel1.Location = new System.Drawing.Point(278, 124);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 90);
            this.panel1.TabIndex = 60;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblTotalReservas
            // 
            this.lblTotalReservas.AutoSize = true;
            this.lblTotalReservas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalReservas.Location = new System.Drawing.Point(99, 42);
            this.lblTotalReservas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalReservas.Name = "lblTotalReservas";
            this.lblTotalReservas.Size = new System.Drawing.Size(97, 29);
            this.lblTotalReservas.TabIndex = 1;
            this.lblTotalReservas.Text = "100000";
            // 
            // lblTituloTotalReservas
            // 
            this.lblTituloTotalReservas.AutoSize = true;
            this.lblTituloTotalReservas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTotalReservas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(141)))), ((int)(((byte)(181)))));
            this.lblTituloTotalReservas.Location = new System.Drawing.Point(100, 17);
            this.lblTituloTotalReservas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloTotalReservas.Name = "lblTituloTotalReservas";
            this.lblTituloTotalReservas.Size = new System.Drawing.Size(163, 25);
            this.lblTituloTotalReservas.TabIndex = 0;
            this.lblTituloTotalReservas.Text = "Total de reservas";
            this.lblTituloTotalReservas.Click += new System.EventHandler(this.lblTituloTotalReservas_Click);
            // 
            // ctPastel
            // 
            this.ctPastel.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea4.Name = "ChartArea1";
            this.ctPastel.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.ctPastel.Legends.Add(legend4);
            this.ctPastel.Location = new System.Drawing.Point(1083, 382);
            this.ctPastel.Name = "ctPastel";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.ctPastel.Series.Add(series4);
            this.ctPastel.Size = new System.Drawing.Size(576, 303);
            this.ctPastel.TabIndex = 63;
            this.ctPastel.Text = "chart1";
            // 
            // dtpFechaHora
            // 
            this.dtpFechaHora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFechaHora.Location = new System.Drawing.Point(158, 352);
            this.dtpFechaHora.Name = "dtpFechaHora";
            this.dtpFechaHora.Size = new System.Drawing.Size(251, 22);
            this.dtpFechaHora.TabIndex = 64;
            this.dtpFechaHora.ValueChanged += new System.EventHandler(this.dtpFechaHora_ValueChanged);
            // 
            // btnVerPorHora
            // 
            this.btnVerPorHora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVerPorHora.Location = new System.Drawing.Point(429, 351);
            this.btnVerPorHora.Name = "btnVerPorHora";
            this.btnVerPorHora.Size = new System.Drawing.Size(185, 23);
            this.btnVerPorHora.TabIndex = 65;
            this.btnVerPorHora.Text = "RESERVAS POR HORA";
            this.btnVerPorHora.UseVisualStyleBackColor = true;
            this.btnVerPorHora.Click += new System.EventHandler(this.btnVerPorHora_Click_1);
            // 
            // dgvDashboard
            // 
            this.dgvDashboard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvDashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDashboard.Location = new System.Drawing.Point(664, 747);
            this.dgvDashboard.Name = "dgvDashboard";
            this.dgvDashboard.RowHeadersWidth = 51;
            this.dgvDashboard.RowTemplate.Height = 24;
            this.dgvDashboard.Size = new System.Drawing.Size(774, 184);
            this.dgvDashboard.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Heavy", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(611, 101);
            this.label1.TabIndex = 67;
            this.label1.Text = "BOOKING BOOT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.WhatsApp_Image_2025_03_10_at_22_24_48;
            this.pictureBox1.Location = new System.Drawing.Point(29, 224);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDashboard);
            this.Controls.Add(this.btnVerPorHora);
            this.Controls.Add(this.dtpFechaHora);
            this.Controls.Add(this.ctPastel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnHoy);
            this.Controls.Add(this.btnUltimos7Dias);
            this.Controls.Add(this.btnUltimos30Dias);
            this.Controls.Add(this.btnEsteMes);
            this.Controls.Add(this.ctBarras);
            this.Name = "Reporte";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctBarras)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctPastel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ctBarras;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnUltimos7Dias;
        private System.Windows.Forms.Button btnUltimos30Dias;
        private System.Windows.Forms.Button btnEsteMes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalHoras;
        private System.Windows.Forms.Label lblTituloTotalHorasReservadas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalReservas;
        private System.Windows.Forms.Label lblTituloTotalReservas;
        private System.Windows.Forms.DataVisualization.Charting.Chart ctPastel;
        private System.Windows.Forms.DateTimePicker dtpFechaHora;
        private System.Windows.Forms.Button btnVerPorHora;
        private System.Windows.Forms.DataGridView dgvDashboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}