using CapaEntidades.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsPedido
{
    public partial class FrmDevueltas : Form
    {
        public FrmDevueltas()
        {
            InitializeComponent();
            this.btnSave.Click += BtnSave_Click;

            this.Load += FrmDevueltas_Load;
            this.numericRecibido.KeyPress += NumericRecibido_KeyPress;
        }

        private void NumericRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (this.Total_devolver != 0)
                {
                    this.CalcularDevuelta();
                    this.OnBtnSaveClick?.Invoke(this, e);
                    this.Close();
                }
                else
                {
                    this.CalcularDevuelta();
                }
            }
        }
        private void CalcularDevuelta()
        {
            if (this.numericRecibido.Value != 0)
            {
                this.Total_recibido = this.numericRecibido.Value;

                this.Total_devolver = this.Total_pagar - this.Total_recibido;

                this.txtDevuelta.Text = this.Total_devolver.ToString("C").Replace(",00", "");
            }
        }
        private void FrmDevueltas_Load(object sender, EventArgs e)
        {
            this.Show();

            this.numericRecibido.Focus();
            this.numericRecibido.Select(0, this.numericRecibido.Value.ToString().Length);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.OnBtnSaveClick?.Invoke(this, e);
            this.Close();
        }
        public void AsignarDatos(decimal total_pagar)
        {
            this.txtPagar.Text = total_pagar.ToString("C").Replace(",00", "");
            this.Total_pagar = total_pagar;
        }

        public decimal Total_pagar { get; set; }
        public decimal Total_recibido { get; set; }
        public decimal Total_devolver { get; set; }
        public DataTable DtDetalle{ get; set; }
        public Ventas Venta { get; set; }

        public event EventHandler OnBtnSaveClick;
    }
}
