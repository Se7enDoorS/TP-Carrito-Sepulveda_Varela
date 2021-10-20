using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Servicio;


namespace TP1_WinForms
{
    public partial class Agregar : Form
    {

        private Articulo auxArt = new Articulo();
        public Agregar()
        {
            InitializeComponent();
            auxArt = null;
        }

        public Agregar(Articulo aux)
        {
            InitializeComponent();
            auxArt = aux;
        }

        private void DescripcionArt_Load(object sender, EventArgs e)
        {
            marcaServicio serviceMarca = new marcaServicio();
            categoriaServicio serviceCategoria = new categoriaServicio();
            try
            {
                cmbMarca.DataSource = serviceMarca.listaMarcas();
                cmbMarca.ValueMember = "Id";
                cmbMarca.DisplayMember = "Nombre";

                cmbCategoria.DataSource = serviceCategoria.listaCategorias();
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DisplayMember = "Nombre";

                if (auxArt!=null)
                {
                    txbCodigo.Text = auxArt.Codigo;
                    txbDescripcion.Text = auxArt.Descripcion;
                    txbNombre.Text = auxArt.Nombre;
                    txtURLImagen.Text = auxArt.ImagenURL;
                    txtPrecio.Text = auxArt.Precio.ToString();
                    if (!(auxArt.Marca is null)) 
                        cmbMarca.SelectedValue = auxArt.Marca.Id;

                    if (!(auxArt.Categoria is null))
                        cmbCategoria.SelectedValue = auxArt.Categoria.Id;
                }
                else
                {
                    auxArt = new Articulo();
                }
                cargar_imagen(txtURLImagen.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cargar_imagen(string texto)
        {
            try
            {
                pbxImagen.Load(texto);
            }
            catch (Exception)
            {
                pbxImagen.Load("https://st4.depositphotos.com/14953852/22772/v/600/depositphotos_227725020-stock-illustration-no-image-available-icon-flat.jpg");
            }
            
        }

        private void txtURLImagen_TextChanged(object sender, EventArgs e)
        {
            cargar_imagen(txtURLImagen.Text);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txbNombre.Text == "")
                txbNombre.BackColor = Color.Red;
            else
                txbNombre.BackColor = System.Drawing.SystemColors.Control;
            if (txbCodigo.Text == "")
                txbCodigo.BackColor = Color.Red;
            else
                txbCodigo.BackColor = System.Drawing.SystemColors.Control;
            if (txbCodigo.Text != "" && txbNombre.Text != "")
            {
                ArticuloServicio newServicio = new ArticuloServicio();
                try
                {
                    auxArt.Nombre = txbNombre.Text;
                    auxArt.Descripcion = txbDescripcion.Text;
                    auxArt.Codigo = txbCodigo.Text;
                    auxArt.Categoria = (categoria)cmbCategoria.SelectedItem;
                    auxArt.Marca = (marca)cmbMarca.SelectedItem;
                    auxArt.ImagenURL = txtURLImagen.Text;
                    if (txtPrecio.Text != "")
                    {
                        auxArt.Precio = decimal.Parse(txtPrecio.Text);
                    }

                    if (auxArt.Id != 0)
                    {
                        newServicio.ModificarDB(auxArt);
                        MessageBox.Show("Artículo Modificado");
                    }
                    else
                    {
                        newServicio.AgregarDB(auxArt);
                        MessageBox.Show("Articulo agregado!");
                    }
                        Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw ex;
                }
            }
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            AgregarM_C vtnAgregarMC = new AgregarM_C("Marca");
            vtnAgregarMC.ShowDialog();
            marcaServicio serviceMarca = new marcaServicio();
            cmbMarca.DataSource = serviceMarca.listaMarcas();
            cmbMarca.ValueMember = "Id";
            cmbMarca.DisplayMember = "Nombre";
        }

        private void btnAgregarCat_Click(object sender, EventArgs e)
        {
            AgregarM_C vtnAgregarMC = new AgregarM_C("Categoria");
            vtnAgregarMC.ShowDialog();
            categoriaServicio serviceCategoria = new categoriaServicio();
            cmbCategoria.DataSource = serviceCategoria.listaCategorias();
            cmbCategoria.ValueMember = "Id";
            cmbCategoria.DisplayMember = "Nombre";
        }
    }
}
