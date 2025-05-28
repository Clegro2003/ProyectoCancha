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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ctBarras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnUltimos7Dias = new System.Windows.Forms.Button();
            this.btnUltimos30Dias = new System.Windows.Forms.Button();
            this.btnEsteMes = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCanchasOcupadas = new System.Windows.Forms.Label();
            this.lblTituloCanchasOcupadas = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHoras = new System.Windows.Forms.Label();
            this.lblTituloTotalHorasReservadas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblReservas = new System.Windows.Forms.Label();
            this.lblTituloTotalReservas = new System.Windows.Forms.Label();
            this.ctPastel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ctBarras)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctPastel)).BeginInit();
            this.SuspendLayout();
            // 
            // ctBarras
            // 
            chartArea1.Name = "ChartArea1";
            this.ctBarras.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ctBarras.Legends.Add(legend1);
            this.ctBarras.Location = new System.Drawing.Point(28, 250);
            this.ctBarras.Name = "ctBarras";
            series1.ChartArea = "ChartArea1";
            series1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ctBarras.Series.Add(series1);
            this.ctBarras.Size = new System.Drawing.Size(740, 320);
            this.ctBarras.TabIndex = 0;
            this.ctBarras.Text = "chart1";
            // 
            // btnHoy
            // 
            this.btnHoy.Location = new System.Drawing.Point(666, 15);
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
            this.btnUltimos7Dias.Location = new System.Drawing.Point(840, 15);
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
            this.btnUltimos30Dias.Location = new System.Drawing.Point(1015, 15);
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
            this.btnEsteMes.Location = new System.Drawing.Point(1190, 15);
            this.btnEsteMes.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnEsteMes.Name = "btnEsteMes";
            this.btnEsteMes.Size = new System.Drawing.Size(173, 43);
            this.btnEsteMes.TabIndex = 54;
            this.btnEsteMes.Text = "Este Mes";
            this.btnEsteMes.UseVisualStyleBackColor = true;
            this.btnEsteMes.Click += new System.EventHandler(this.btnEsteMes_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.lblCanchasOcupadas);
            this.panel3.Controls.Add(this.lblTituloCanchasOcupadas);
            this.panel3.Location = new System.Drawing.Point(938, 71);
            this.panel3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(425, 90);
            this.panel3.TabIndex = 62;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(141)))), ((int)(((byte)(181)))));
            this.label11.Location = new System.Drawing.Point(489, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 25);
            this.label11.TabIndex = 3;
            this.label11.Text = "%";
            // 
            // lblCanchasOcupadas
            // 
            this.lblCanchasOcupadas.AutoSize = true;
            this.lblCanchasOcupadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanchasOcupadas.Location = new System.Drawing.Point(99, 42);
            this.lblCanchasOcupadas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCanchasOcupadas.Name = "lblCanchasOcupadas";
            this.lblCanchasOcupadas.Size = new System.Drawing.Size(97, 29);
            this.lblCanchasOcupadas.TabIndex = 1;
            this.lblCanchasOcupadas.Text = "100000";
            // 
            // lblTituloCanchasOcupadas
            // 
            this.lblTituloCanchasOcupadas.AutoSize = true;
            this.lblTituloCanchasOcupadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCanchasOcupadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(141)))), ((int)(((byte)(181)))));
            this.lblTituloCanchasOcupadas.Location = new System.Drawing.Point(100, 17);
            this.lblTituloCanchasOcupadas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloCanchasOcupadas.Name = "lblTituloCanchasOcupadas";
            this.lblTituloCanchasOcupadas.Size = new System.Drawing.Size(210, 25);
            this.lblTituloCanchasOcupadas.TabIndex = 0;
            this.lblTituloCanchasOcupadas.Text = "% Canchas Ocupadas";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblHoras);
            this.panel2.Controls.Add(this.lblTituloTotalHorasReservadas);
            this.panel2.Location = new System.Drawing.Point(386, 71);
            this.panel2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 90);
            this.panel2.TabIndex = 61;
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoras.Location = new System.Drawing.Point(99, 42);
            this.lblHoras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(97, 29);
            this.lblHoras.TabIndex = 1;
            this.lblHoras.Text = "100000";
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
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblReservas);
            this.panel1.Controls.Add(this.lblTituloTotalReservas);
            this.panel1.Location = new System.Drawing.Point(35, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 90);
            this.panel1.TabIndex = 60;
            // 
            // lblReservas
            // 
            this.lblReservas.AutoSize = true;
            this.lblReservas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservas.Location = new System.Drawing.Point(99, 42);
            this.lblReservas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReservas.Name = "lblReservas";
            this.lblReservas.Size = new System.Drawing.Size(97, 29);
            this.lblReservas.TabIndex = 1;
            this.lblReservas.Text = "100000";
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
            // 
            // ctPastel
            // 
            chartArea2.Name = "ChartArea1";
            this.ctPastel.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ctPastel.Legends.Add(legend2);
            this.ctPastel.Location = new System.Drawing.Point(787, 250);
            this.ctPastel.Name = "ctPastel";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ctPastel.Series.Add(series2);
            this.ctPastel.Size = new System.Drawing.Size(576, 303);
            this.ctPastel.TabIndex = 63;
            this.ctPastel.Text = "chart1";
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 617);
            this.Controls.Add(this.ctPastel);
            this.Controls.Add(this.panel3);
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
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctPastel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ctBarras;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnUltimos7Dias;
        private System.Windows.Forms.Button btnUltimos30Dias;
        private System.Windows.Forms.Button btnEsteMes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCanchasOcupadas;
        private System.Windows.Forms.Label lblTituloCanchasOcupadas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Label lblTituloTotalHorasReservadas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReservas;
        private System.Windows.Forms.Label lblTituloTotalReservas;
        private System.Windows.Forms.DataVisualization.Charting.Chart ctPastel;
    }
}