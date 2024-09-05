namespace CapaPresentacion.Formularios.FormsProductos
{
    partial class FrmObservarProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObservarProductos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.panelProductos = new CapaPresentacion.Controles.CustomGridPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panelTiposProductos = new CapaPresentacion.Controles.CustomGridPanel();
            this.gbTiposProductos = new System.Windows.Forms.GroupBox();
            this.btnProductsBuys = new System.Windows.Forms.Button();
            this.btnProductsInventory = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbResultados.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbTiposProductos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.txtBusqueda);
            this.groupBox1.Controls.Add(this.btnAddProduct);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(418, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda de productos";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(47, 34);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(35, 35);
            this.btnRefresh.TabIndex = 33;
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(700, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 30);
            this.btnClose.TabIndex = 31;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtBusqueda.Location = new System.Drawing.Point(88, 37);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(545, 32);
            this.txtBusqueda.TabIndex = 2;
            this.txtBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddProduct.BackgroundImage")));
            this.btnAddProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProduct.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnAddProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Location = new System.Drawing.Point(6, 34);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(35, 35);
            this.btnAddProduct.TabIndex = 30;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            // 
            // gbResultados
            // 
            this.gbResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultados.Controls.Add(this.panelProductos);
            this.gbResultados.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResultados.Location = new System.Drawing.Point(231, 99);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(919, 525);
            this.gbResultados.TabIndex = 2;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Resultados";
            // 
            // panelProductos
            // 
            this.panelProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProductos.AutoScroll = true;
            this.panelProductos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelProductos.BackgroundImage")));
            this.panelProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelProductos.Location = new System.Drawing.Point(6, 34);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.PageSize = 10;
            this.panelProductos.Size = new System.Drawing.Size(909, 485);
            this.panelProductos.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.panelTiposProductos);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(219, 525);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Categorías";
            // 
            // panelTiposProductos
            // 
            this.panelTiposProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTiposProductos.AutoScroll = true;
            this.panelTiposProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelTiposProductos.Location = new System.Drawing.Point(6, 34);
            this.panelTiposProductos.Name = "panelTiposProductos";
            this.panelTiposProductos.PageSize = 10;
            this.panelTiposProductos.Size = new System.Drawing.Size(209, 485);
            this.panelTiposProductos.TabIndex = 0;
            // 
            // gbTiposProductos
            // 
            this.gbTiposProductos.Controls.Add(this.btnProductsBuys);
            this.gbTiposProductos.Controls.Add(this.btnProductsInventory);
            this.gbTiposProductos.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTiposProductos.Location = new System.Drawing.Point(7, -3);
            this.gbTiposProductos.Name = "gbTiposProductos";
            this.gbTiposProductos.Size = new System.Drawing.Size(405, 78);
            this.gbTiposProductos.TabIndex = 34;
            this.gbTiposProductos.TabStop = false;
            this.gbTiposProductos.Text = "Tipos de productos";
            // 
            // btnProductsBuys
            // 
            this.btnProductsBuys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductsBuys.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnProductsBuys.FlatAppearance.BorderSize = 0;
            this.btnProductsBuys.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProductsBuys.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnProductsBuys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductsBuys.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductsBuys.ForeColor = System.Drawing.Color.Gray;
            this.btnProductsBuys.Image = ((System.Drawing.Image)(resources.GetObject("btnProductsBuys.Image")));
            this.btnProductsBuys.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductsBuys.Location = new System.Drawing.Point(242, 28);
            this.btnProductsBuys.Margin = new System.Windows.Forms.Padding(5);
            this.btnProductsBuys.Name = "btnProductsBuys";
            this.btnProductsBuys.Size = new System.Drawing.Size(153, 34);
            this.btnProductsBuys.TabIndex = 37;
            this.btnProductsBuys.Text = "VENTA";
            this.btnProductsBuys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductsBuys.UseVisualStyleBackColor = true;
            // 
            // btnProductsInventory
            // 
            this.btnProductsInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductsInventory.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnProductsInventory.FlatAppearance.BorderSize = 0;
            this.btnProductsInventory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProductsInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnProductsInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductsInventory.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductsInventory.ForeColor = System.Drawing.Color.Gray;
            this.btnProductsInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnProductsInventory.Image")));
            this.btnProductsInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductsInventory.Location = new System.Drawing.Point(8, 30);
            this.btnProductsInventory.Margin = new System.Windows.Forms.Padding(5);
            this.btnProductsInventory.Name = "btnProductsInventory";
            this.btnProductsInventory.Size = new System.Drawing.Size(224, 32);
            this.btnProductsInventory.TabIndex = 36;
            this.btnProductsInventory.Text = "INVENTARIO";
            this.btnProductsInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductsInventory.UseVisualStyleBackColor = true;
            // 
            // FrmObservarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1155, 641);
            this.Controls.Add(this.gbTiposProductos);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbResultados);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmObservarProductos";
            this.Text = "Observar productos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbResultados.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.gbTiposProductos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.GroupBox gbResultados;
        private CapaPresentacion.Controles.CustomGridPanel panelProductos;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox4;
        private CapaPresentacion.Controles.CustomGridPanel panelTiposProductos;
        private System.Windows.Forms.GroupBox gbTiposProductos;
        private System.Windows.Forms.Button btnProductsBuys;
        private System.Windows.Forms.Button btnProductsInventory;
    }
}