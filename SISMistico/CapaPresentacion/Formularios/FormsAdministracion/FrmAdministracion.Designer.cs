namespace CapaPresentacion.Formularios.FormsAdministracion
{
    partial class FrmAdministracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdministracion));
            this.gbTurno = new System.Windows.Forms.GroupBox();
            this.panelTurno = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddIngreso = new System.Windows.Forms.Button();
            this.btnAddGasto = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.graphicsVentas2 = new CapaPresentacion.Formularios.FormsEstadisticas.FormEstadisticasIniciales.GraphicsVentas();
            this.graphicsVentas1 = new CapaPresentacion.Formularios.FormsEstadisticas.FormEstadisticasIniciales.GraphicsVentas();
            this.btnAddNovedad = new System.Windows.Forms.Button();
            this.gbTurno.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTurno
            // 
            this.gbTurno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbTurno.Controls.Add(this.panelTurno);
            this.gbTurno.Location = new System.Drawing.Point(9, -4);
            this.gbTurno.Margin = new System.Windows.Forms.Padding(2);
            this.gbTurno.Name = "gbTurno";
            this.gbTurno.Padding = new System.Windows.Forms.Padding(2);
            this.gbTurno.Size = new System.Drawing.Size(571, 596);
            this.gbTurno.TabIndex = 0;
            this.gbTurno.TabStop = false;
            this.gbTurno.Text = "Caja del día";
            // 
            // panelTurno
            // 
            this.panelTurno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTurno.Location = new System.Drawing.Point(4, 26);
            this.panelTurno.Margin = new System.Windows.Forms.Padding(2);
            this.panelTurno.Name = "panelTurno";
            this.panelTurno.Size = new System.Drawing.Size(562, 566);
            this.panelTurno.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnAddNovedad);
            this.groupBox2.Controls.Add(this.btnAddIngreso);
            this.groupBox2.Controls.Add(this.btnAddGasto);
            this.groupBox2.Location = new System.Drawing.Point(981, -4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(218, 596);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accesos directos";
            // 
            // btnAddIngreso
            // 
            this.btnAddIngreso.BackColor = System.Drawing.Color.White;
            this.btnAddIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddIngreso.FlatAppearance.BorderSize = 0;
            this.btnAddIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIngreso.Font = new System.Drawing.Font("Segoe UI Emoji", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIngreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddIngreso.Image = ((System.Drawing.Image)(resources.GetObject("btnAddIngreso.Image")));
            this.btnAddIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddIngreso.Location = new System.Drawing.Point(3, 28);
            this.btnAddIngreso.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddIngreso.Name = "btnAddIngreso";
            this.btnAddIngreso.Size = new System.Drawing.Size(205, 56);
            this.btnAddIngreso.TabIndex = 14;
            this.btnAddIngreso.Text = "Registrar ingreso";
            this.btnAddIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddIngreso.UseVisualStyleBackColor = false;
            // 
            // btnAddGasto
            // 
            this.btnAddGasto.BackColor = System.Drawing.Color.White;
            this.btnAddGasto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGasto.FlatAppearance.BorderSize = 0;
            this.btnAddGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGasto.Font = new System.Drawing.Font("Segoe UI Emoji", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGasto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddGasto.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGasto.Image")));
            this.btnAddGasto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddGasto.Location = new System.Drawing.Point(3, 88);
            this.btnAddGasto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddGasto.Name = "btnAddGasto";
            this.btnAddGasto.Size = new System.Drawing.Size(205, 56);
            this.btnAddGasto.TabIndex = 13;
            this.btnAddGasto.Text = "Registrar gasto";
            this.btnAddGasto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddGasto.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.graphicsVentas2);
            this.groupBox3.Controls.Add(this.graphicsVentas1);
            this.groupBox3.Location = new System.Drawing.Point(584, -4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(384, 596);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estadísticas";
            // 
            // graphicsVentas2
            // 
            this.graphicsVentas2.BackColor = System.Drawing.Color.White;
            this.graphicsVentas2.Font = new System.Drawing.Font("Segoe UI Emoji", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphicsVentas2.Location = new System.Drawing.Point(7, 285);
            this.graphicsVentas2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphicsVentas2.Name = "graphicsVentas2";
            this.graphicsVentas2.Size = new System.Drawing.Size(358, 255);
            this.graphicsVentas2.TabIndex = 1;
            // 
            // graphicsVentas1
            // 
            this.graphicsVentas1.BackColor = System.Drawing.Color.White;
            this.graphicsVentas1.Font = new System.Drawing.Font("Segoe UI Emoji", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphicsVentas1.Location = new System.Drawing.Point(5, 24);
            this.graphicsVentas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphicsVentas1.Name = "graphicsVentas1";
            this.graphicsVentas1.Size = new System.Drawing.Size(359, 255);
            this.graphicsVentas1.TabIndex = 0;
            // 
            // btnAddNovedad
            // 
            this.btnAddNovedad.BackColor = System.Drawing.Color.White;
            this.btnAddNovedad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNovedad.FlatAppearance.BorderSize = 0;
            this.btnAddNovedad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNovedad.Font = new System.Drawing.Font("Segoe UI Emoji", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNovedad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddNovedad.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNovedad.Image")));
            this.btnAddNovedad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNovedad.Location = new System.Drawing.Point(3, 152);
            this.btnAddNovedad.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNovedad.Name = "btnAddNovedad";
            this.btnAddNovedad.Size = new System.Drawing.Size(205, 56);
            this.btnAddNovedad.TabIndex = 16;
            this.btnAddNovedad.Text = "Registrar novedad";
            this.btnAddNovedad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNovedad.UseVisualStyleBackColor = false;
            // 
            // FrmAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 602);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbTurno);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAdministracion";
            this.Text = "Administracion Chandozos";
            this.gbTurno.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTurno;
        private System.Windows.Forms.Panel panelTurno;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddGasto;
        private System.Windows.Forms.Button btnAddIngreso;
        private FormsEstadisticas.FormEstadisticasIniciales.GraphicsVentas graphicsVentas2;
        private FormsEstadisticas.FormEstadisticasIniciales.GraphicsVentas graphicsVentas1;
        private System.Windows.Forms.Button btnAddNovedad;
    }
}