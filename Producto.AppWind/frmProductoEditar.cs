using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Producto.Dominio;
using Producto.Logic;



namespace Producto.AppWind
{
    public partial class frmProductoEditar : Form
    {

        Productos producto;

        public frmProductoEditar(Productos productos)
        {
            InitializeComponent();
            this.producto = productos;

        }

        private void cargarDatos()
        {
            cboCategoria.DataSource = CategoriaBL.Listar();
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IDC";



        }


        private void frmProductoEditar_Load(object sender, EventArgs e)
        {

            btnAcept.Enabled = false;

            cargarDatos();

            if (producto.ID > 0)
            {

                asignarControles();

            }
        }

        private void grabarPr(object sender, EventArgs e)
        {
            int sto = int.Parse(txtStock.Text);
            double pre = double.Parse(txtPrecio.Text);
         

            if (pre > 2500)
            {
                MessageBox.Show("El precio no debe exceder a los S/2500.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return;
            }



            if (pre < 1)
            {
                MessageBox.Show("Por favor ingrese un prcio correcto", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }



            if (sto <= 5 )
            {
                MessageBox.Show("El stock debe ser mayor a 5.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);


                
                return;
            }

            else
            {

                asignarAObjeto();

                this.DialogResult = DialogResult.OK;

            }


        }


        private void asignarAObjeto()
        {
            this.producto.Nombres = txtProducto.Text;
            this.producto.Marca = txtMarca.Text;
            this.producto.Precio =double.Parse(txtPrecio.Text);
            this.producto.Stock = int.Parse(txtStock.Text);
            this.producto.IdCategoria = int.Parse(cboCategoria.SelectedValue.ToString());

        }


        private void asignarControles()
        {


            txtProducto.Text = producto.Nombres;
            txtMarca.Text = producto.Marca;
            txtPrecio.Text= producto.Precio.ToString();
            txtStock.Text = producto.Stock.ToString();
            cboCategoria.SelectedValue = producto.IdCategoria;
     
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
                e.Handled = true;

            else if (char.IsNumber(e.KeyChar))
                e.Handled = true;

            else if (char.IsSymbol(e.KeyChar))
                e.Handled = true;

            else if (char.IsPunctuation(e.KeyChar))
                e.Handled = true;

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsLetter(e.KeyChar))
                e.Handled = true;

            else if (char.IsSymbol(e.KeyChar))
                e.Handled = true;


        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (char.IsDigit(e.KeyChar))
                e.Handled = true;

            else if (char.IsNumber(e.KeyChar))
                e.Handled = true;

            else if (char.IsSymbol(e.KeyChar))
                e.Handled = true;

            else if (char.IsPunctuation(e.KeyChar))
                e.Handled = true;

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsLetter(e.KeyChar))
                e.Handled = true;

            else if (char.IsSymbol(e.KeyChar))
                e.Handled = true;

            else if (char.IsPunctuation(e.KeyChar))
                e.Handled = true;

        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {

            if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text != ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }


            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = true;

            }

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

            if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }


            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = true;

            }

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }


            else if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = true;

            }
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

            if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }


            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = true;

            }

        }


    }
}
