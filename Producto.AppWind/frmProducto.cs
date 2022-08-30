using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Producto.Logic;
using Producto.Dominio;

namespace Producto.AppWind
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            var listado = ProductoBL.Listar();
            dgvDatos.Rows.Clear();
            foreach (var prod in listado)
            {

                dgvDatos.Rows.Add(prod.ID, prod.Nombres, prod.Marca, prod.Precio, prod.Categoriaa, prod.Stock);

            }
        }

        private void btnNuev_Click(object sender, EventArgs e)
        {


            var nuevoProd = new Productos();
            var frm = new frmProductoEditar(nuevoProd);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Text = "Nuevo";
                var exito = ProductoBL.Insertar(nuevoProd);
                if (exito)
                {

                    MessageBox.Show("El producto se ha registrado correctamente", "Productos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar el producto", "Productos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }


        }



        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (dgvDatos.Rows.Count > 0)
            {

                int filaActual = dgvDatos.CurrentRow.Index;
                var idProd = int.Parse(dgvDatos.Rows[filaActual].Cells[0].Value.ToString());
                var prodEditar = ProductoBL.BuscarPorId(idProd);
                var frm = new frmProductoEditar(prodEditar);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Text = "ACtualizar";

                    var exito = ProductoBL.Actualizar(prodEditar);

                    if (exito)
                    {

                        MessageBox.Show("El producto fue actualizado correctamente", "Productos",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido actualizar el producto", "Productos",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }



        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            if (dgvDatos.Rows.Count > 0)
            {

                int filaActual = dgvDatos.CurrentRow.Index;
                var idProd = int.Parse(dgvDatos.Rows[filaActual].Cells[0].Value.ToString());
                var nombreProd = dgvDatos.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("¿Realmente desea eliminar el producto " + nombreProd + " ?",
                    "FInanciera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {

                    var exito = ProductoBL.Eliminar(idProd);
                    if (exito)
                    {
                        MessageBox.Show("El producto ha sido eliminado", "Productos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();

                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el producto", "Productos",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

            }

        }
    }
}
