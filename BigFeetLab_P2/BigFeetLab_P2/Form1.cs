using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigFeetLab_P2
{
    public partial class Form1 : Form
    {
        List<ClsZapatos> zapatoData = new List<ClsZapatos>();

      

        public void CrearProducto()
        {
            ClsZapatos zapato = new ClsZapatos();

            try
            {
                if (txtMarca.Text != "" && txtDesc.Text != "" && cbCategoria.Text != "" && txtTalla.Text != "")
                {
                    
                    zapato.Marca = txtMarca.Text;
                    zapato.Descripcion = txtDesc.Text;
                    zapato.Categoria = cbCategoria.Text;
                    zapato.Talla = txtTalla.Text;
                    zapato.Cantidad = int.Parse(txtCantidad.Text);
                    zapato.PrecioCompra = float.Parse(txtPrecioCompra.Text);
                    zapato.PrecioVenta = zapato.PrecioCompra + (zapato.PrecioCompra  * 13 / 100);
                    zapatoData.Add(zapato);
                }
                else
                {
                    MessageBox.Show($"Uno de los campos esta vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception err)
            {
                MessageBox.Show($"Ha ocurrido un error {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MostrarProductos()
        {
            try
            {
                string Lista = "";
                foreach (ClsZapatos p in zapatoData)
                {
                    Lista = $"{Lista}Marca: {p.Marca} ---- Descripcion: {p.Descripcion} ---- Categoria: {p.Categoria} ---- Talla: {p.Talla} ---- Cantidad: {p.Cantidad} ---- Precio de Compra: {Convert.ToDecimal(p.PrecioCompra)} ---- Precio de Venta: {Convert.ToDecimal(p.PrecioVenta)}\n";
                }
                rtbMostrar.Text = Lista;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la lista");
            }
        }

        public void BuscarProducto()
        {
            try
            {
                if (txtDesc.Text != "")
                {
                    foreach (ClsZapatos p in zapatoData)
                    {
                        if (txtDesc.Text == p.Descripcion)
                        {
                            txtMarca.Text = p.Marca;
                            txtDesc.Text = p.Descripcion;
                            cbCategoria.Text = p.Categoria;
                            txtTalla.Text = p.Talla;
                            txtCantidad.Text = Convert.ToString(p.Cantidad);
                            txtPrecioCompra.Text = Convert.ToString(p.PrecioCompra);
                            VaciarCampos();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El campo para Actualizar debe de estar lleno");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar los cambios!!");
            }
        }

        public void ActualizarProducto()
        {
            try
            {
                if (txtDesc.Text != "")
                {
                    foreach (ClsZapatos p in zapatoData)
                    {
                        if (p.Descripcion == txtDesc.Text)
                        {
                            p.Marca = txtMarca.Text;
                            p.Descripcion = txtDesc.Text;
                            p.Categoria = cbCategoria.Text;
                            p.Talla = txtTalla.Text;
                            p.Cantidad = int.Parse(txtCantidad.Text);
                            p.PrecioVenta = p.PrecioCompra + (p.PrecioCompra * 13 / 100);
                            VaciarCampos();
                            MostrarProductos();
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El campo para Actualizar debe de estar lleno");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar los cambios!!");
            }
        }

        public void VaciarCampos()
        {
            txtMarca.Clear();
            txtDesc.Clear();
            cbCategoria.Text = "";
            txtTalla.Clear();
            txtCantidad.Clear();
            txtPrecioCompra.Clear();
        }

        public void EliminarProductos()
        {
            try
            {
                if (txtDesc.Text != "")
                {
                    foreach (ClsZapatos p in zapatoData)
                    {
                        if (p.Descripcion == txtDesc.Text)
                        {
                            DialogResult respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (respuesta == DialogResult.Yes)
                            {
                                zapatoData.Remove(p);
                                MostrarProductos();
                            }
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Campo nombre esta vacio!!");

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al elminar registro");
            }
        }

        public void FiltrarProducto()
        {
            string mostrar = "";
            string categoria;

            categoria = cbCategoriaFiltro.Text;

            var consulta = from a in zapatoData
                           where a.Categoria.Equals(categoria)
                           select a;

            foreach (ClsZapatos c in consulta)
            {
                mostrar = $"{mostrar}Marca: {c.Marca} ---- Descripcion: {c.Descripcion} ---- Categoria: {c.Categoria} ---- Talla: {c.Talla} ---- Cantidad: {c.Cantidad} ---- Precio de Compra: {Convert.ToDecimal(c.PrecioCompra)} ---- Precio de Venta: {Convert.ToDecimal(c.PrecioVenta)}\n";
            }

            rtbFiltro.Text = mostrar;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            CrearProducto();
            MostrarProductos();
            VaciarCampos();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FiltrarProducto();
            VaciarCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarProductos();
            VaciarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ingrese la descripcion del que desea actualizar, luego ingrese los campos que desea actualizar y da en guardar");
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtbFiltro.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            btnModificar.Enabled = true;
            ActualizarProducto();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
 