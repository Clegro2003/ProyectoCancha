namespace GUI
{
    partial class Dashboard_Reporte
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea39 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend39 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series39 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea40 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend40 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series40 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ctPastel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ctBarras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvDashboard = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalReservas = new System.Windows.Forms.Label();
            this.lblTituloTotalReservas = new System.Windows.Forms.Label();
            this.dtpFechaHora = new System.Windows.Forms.DateTimePicker();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTotalHoras = new System.Windows.Forms.Label();
            this.lblTituloTotalHorasReservadas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnEsteMes = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnUltimos7Dias = new System.Windows.Forms.Button();
            this.btnUltimos30Dias = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctPastel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctBarras)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDashboard)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1744, 1027);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.ctBarras);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 618);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(866, 406);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.ctPastel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(875, 618);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(866, 406);
            this.panel5.TabIndex = 2;
            // 
            // ctPastel
            // 
            this.ctPastel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctPastel.BackColor = System.Drawing.Color.SkyBlue;
            chartArea39.Name = "ChartArea1";
            this.ctPastel.ChartAreas.Add(chartArea39);
            legend39.Name = "Legend1";
            this.ctPastel.Legends.Add(legend39);
            this.ctPastel.Location = new System.Drawing.Point(14, 17);
            this.ctPastel.Name = "ctPastel";
            this.ctPastel.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series39.ChartArea = "ChartArea1";
            series39.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series39.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series39.Legend = "Legend1";
            series39.Name = "Series1";
            this.ctPastel.Series.Add(series39);
            this.ctPastel.Size = new System.Drawing.Size(849, 362);
            this.ctPastel.TabIndex = 90;
            this.ctPastel.Text = "chart1";
            // 
            // ctBarras
            // 
            this.ctBarras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctBarras.BackColor = System.Drawing.Color.LightGreen;
            chartArea40.Name = "ChartArea1";
            this.ctBarras.ChartAreas.Add(chartArea40);
            legend40.Name = "Legend1";
            this.ctBarras.Legends.Add(legend40);
            this.ctBarras.Location = new System.Drawing.Point(3, 17);
            this.ctBarras.Name = "ctBarras";
            this.ctBarras.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series40.ChartArea = "ChartArea1";
            series40.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series40.Legend = "Legend1";
            series40.Name = "Series1";
            this.ctBarras.Series.Add(series40);
            this.ctBarras.Size = new System.Drawing.Size(854, 364);
            this.ctBarras.TabIndex = 84;
            this.ctBarras.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dtpFechaHora);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 208);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(866, 404);
            this.panel2.TabIndex = 95;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel8.Controls.Add(this.dgvDashboard);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(875, 208);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(866, 404);
            this.panel8.TabIndex = 96;
            // 
            // dgvDashboard
            // 
            this.dgvDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDashboard.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvDashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDashboard.Location = new System.Drawing.Point(30, 19);
            this.dgvDashboard.Name = "dgvDashboard";
            this.dgvDashboard.RowHeadersWidth = 51;
            this.dgvDashboard.RowTemplate.Height = 24;
            this.dgvDashboard.Size = new System.Drawing.Size(827, 355);
            this.dgvDashboard.TabIndex = 93;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.lblTotalReservas);
            this.panel3.Controls.Add(this.lblTituloTotalReservas);
            this.panel3.Location = new System.Drawing.Point(8, 179);
            this.panel3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(352, 103);
            this.panel3.TabIndex = 102;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lblTotalReservas
            // 
            this.lblTotalReservas.AutoSize = true;
            this.lblTotalReservas.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalReservas.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalReservas.Location = new System.Drawing.Point(5, 42);
            this.lblTotalReservas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalReservas.Name = "lblTotalReservas";
            this.lblTotalReservas.Size = new System.Drawing.Size(164, 46);
            this.lblTotalReservas.TabIndex = 1;
            this.lblTotalReservas.Text = "100000";
            // 
            // lblTituloTotalReservas
            // 
            this.lblTituloTotalReservas.AutoSize = true;
            this.lblTituloTotalReservas.BackColor = System.Drawing.Color.LightGray;
            this.lblTituloTotalReservas.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTotalReservas.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTituloTotalReservas.Location = new System.Drawing.Point(7, 10);
            this.lblTituloTotalReservas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloTotalReservas.Name = "lblTituloTotalReservas";
            this.lblTituloTotalReservas.Size = new System.Drawing.Size(257, 32);
            this.lblTituloTotalReservas.TabIndex = 0;
            this.lblTituloTotalReservas.Text = "Total de reservas";
            this.lblTituloTotalReservas.Click += new System.EventHandler(this.lblTituloTotalReservas_Click);
            // 
            // dtpFechaHora
            // 
            this.dtpFechaHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFechaHora.CalendarFont = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHora.CalendarForeColor = System.Drawing.Color.Navy;
            this.dtpFechaHora.CalendarMonthBackground = System.Drawing.SystemColors.Highlight;
            this.dtpFechaHora.CalendarTitleForeColor = System.Drawing.Color.Navy;
            this.dtpFechaHora.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHora.Location = new System.Drawing.Point(9, 340);
            this.dtpFechaHora.Name = "dtpFechaHora";
            this.dtpFechaHora.Size = new System.Drawing.Size(351, 34);
            this.dtpFechaHora.TabIndex = 104;
            this.dtpFechaHora.ValueChanged += new System.EventHandler(this.dtpFechaHora_ValueChanged);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.LightGray;
            this.panel6.Controls.Add(this.lblTotalHoras);
            this.panel6.Controls.Add(this.lblTituloTotalHorasReservadas);
            this.panel6.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(7, 54);
            this.panel6.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(353, 92);
            this.panel6.TabIndex = 103;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint_1);
            // 
            // lblTotalHoras
            // 
            this.lblTotalHoras.AutoSize = true;
            this.lblTotalHoras.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHoras.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalHoras.Location = new System.Drawing.Point(4, 30);
            this.lblTotalHoras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalHoras.Name = "lblTotalHoras";
            this.lblTotalHoras.Size = new System.Drawing.Size(164, 46);
            this.lblTotalHoras.TabIndex = 1;
            this.lblTotalHoras.Text = "100000";
            // 
            // lblTituloTotalHorasReservadas
            // 
            this.lblTituloTotalHorasReservadas.AutoSize = true;
            this.lblTituloTotalHorasReservadas.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTotalHorasReservadas.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTituloTotalHorasReservadas.Location = new System.Drawing.Point(4, 0);
            this.lblTituloTotalHorasReservadas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloTotalHorasReservadas.Name = "lblTituloTotalHorasReservadas";
            this.lblTituloTotalHorasReservadas.Size = new System.Drawing.Size(348, 32);
            this.lblTituloTotalHorasReservadas.TabIndex = 0;
            this.lblTituloTotalHorasReservadas.Text = "Total Horas Reservadas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 199);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Controls.Add(this.btnEsteMes);
            this.panel7.Controls.Add(this.btnHoy);
            this.panel7.Controls.Add(this.btnUltimos7Dias);
            this.panel7.Controls.Add(this.btnUltimos30Dias);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(875, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(866, 199);
            this.panel7.TabIndex = 97;
            // 
            // btnEsteMes
            // 
            this.btnEsteMes.BackColor = System.Drawing.Color.LightGreen;
            this.btnEsteMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEsteMes.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEsteMes.ForeColor = System.Drawing.Color.Navy;
            this.btnEsteMes.Location = new System.Drawing.Point(274, 91);
            this.btnEsteMes.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnEsteMes.Name = "btnEsteMes";
            this.btnEsteMes.Size = new System.Drawing.Size(239, 64);
            this.btnEsteMes.TabIndex = 87;
            this.btnEsteMes.Text = "Este Mes";
            this.btnEsteMes.UseVisualStyleBackColor = false;
            this.btnEsteMes.Click += new System.EventHandler(this.btnEsteMes_Click);
            // 
            // btnHoy
            // 
            this.btnHoy.BackColor = System.Drawing.Color.LightGreen;
            this.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHoy.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoy.ForeColor = System.Drawing.Color.Navy;
            this.btnHoy.Location = new System.Drawing.Point(32, 21);
            this.btnHoy.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(238, 60);
            this.btnHoy.TabIndex = 90;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = false;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnUltimos7Dias
            // 
            this.btnUltimos7Dias.BackColor = System.Drawing.Color.LightGreen;
            this.btnUltimos7Dias.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUltimos7Dias.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltimos7Dias.ForeColor = System.Drawing.Color.Navy;
            this.btnUltimos7Dias.Location = new System.Drawing.Point(274, 21);
            this.btnUltimos7Dias.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnUltimos7Dias.Name = "btnUltimos7Dias";
            this.btnUltimos7Dias.Size = new System.Drawing.Size(238, 58);
            this.btnUltimos7Dias.TabIndex = 89;
            this.btnUltimos7Dias.Text = "Ultimos 7 Dias";
            this.btnUltimos7Dias.UseVisualStyleBackColor = false;
            this.btnUltimos7Dias.Click += new System.EventHandler(this.btnUltimos7Dias_Click);
            // 
            // btnUltimos30Dias
            // 
            this.btnUltimos30Dias.BackColor = System.Drawing.Color.LightGreen;
            this.btnUltimos30Dias.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUltimos30Dias.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltimos30Dias.ForeColor = System.Drawing.Color.Navy;
            this.btnUltimos30Dias.Location = new System.Drawing.Point(32, 93);
            this.btnUltimos30Dias.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnUltimos30Dias.Name = "btnUltimos30Dias";
            this.btnUltimos30Dias.Size = new System.Drawing.Size(238, 62);
            this.btnUltimos30Dias.TabIndex = 88;
            this.btnUltimos30Dias.Text = "Ultimos 30 Dias";
            this.btnUltimos30Dias.UseVisualStyleBackColor = false;
            this.btnUltimos30Dias.Click += new System.EventHandler(this.btnUltimos30Dias_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::GUI.Properties.Resources.WhatsApp_Image_2025_05_29_at_4_371;
            this.pictureBox1.Location = new System.Drawing.Point(522, -16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 106;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(-11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(967, 137);
            this.label1.TabIndex = 94;
            this.label1.Text = "BOOKING BOT";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SkyBlue;
            this.label2.Location = new System.Drawing.Point(429, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 108);
            this.label2.TabIndex = 106;
            this.label2.Text = "RESERVAS \r\nREGISTRADAS:\r\n";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // Dashboard_Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 1027);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Dashboard_Reporte";
            this.Text = "Dashboard_Reporte";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Reporte_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctPastel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctBarras)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDashboard)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataVisualization.Charting.Chart ctPastel;
        private System.Windows.Forms.DataVisualization.Charting.Chart ctBarras;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgvDashboard;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalReservas;
        private System.Windows.Forms.Label lblTituloTotalReservas;
        private System.Windows.Forms.DateTimePicker dtpFechaHora;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblTotalHoras;
        private System.Windows.Forms.Label lblTituloTotalHorasReservadas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnEsteMes;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnUltimos7Dias;
        private System.Windows.Forms.Button btnUltimos30Dias;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}