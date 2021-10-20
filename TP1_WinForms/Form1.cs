using Dominio;
using Servicio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TP1_WinForms
{
    public partial class VtnCatalogo : Form
    {
        private List<Articulo> listaArticulos;
        public VtnCatalogo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }

        private void cargar_datos()
        {
            ArticuloServicio service = new ArticuloServicio();
            listaArticulos = service.listar();
            dgvTabla.DataSource = listaArticulos;
            dgvTabla.Columns["ImagenURL"].Visible = false;
            dgvTabla.Columns["Id"].Visible = false;
            dgvTabla.Columns["Precio"].Visible = false;
            dgvTabla.Columns["Codigo"].Visible = false;
            dgvTabla.Columns["Descripcion"].Visible = false;
            dgvTabla.AutoResizeColumns();
        }

        private void btnDescripcion_Click_1(object sender, EventArgs e)
        {
            if (dgvTabla.RowCount>0)
            {
                Articulo ArtDesc = (Articulo)dgvTabla.CurrentRow.DataBoundItem;
                lblTitulo.Text = ArtDesc.Nombre;
                lblCodigo.Text = ArtDesc.Codigo;
                if (ArtDesc.Marca is null)
                {
                    lblMarca.Text = "Marca: Sin marca";
                }
                else
                {
                    lblMarca.Text = "Marca: " + ArtDesc.Marca.Nombre;
                }
                    
                if (ArtDesc.Categoria is null)
                {
                    lblCategoria.Text = "Categoria: Sin categoría";
                }
                else
                {
                    lblCategoria.Text = "Categoría: " + ArtDesc.Categoria.Nombre;
                }
                if (!(ArtDesc.Descripcion is null))
                {
                    lblDescripcion.Text = "Descripción: " + ArtDesc.Descripcion;
                }
                else
                {
                    lblDescripcion.Text = "Descripción: Sin descripción";
                }
                if (!(ArtDesc.Precio < 0))
                {
                    lblPrecio.Text = "Precio: " + ArtDesc.Precio;
                }
                else
                {
                    lblPrecio.Text = "Precio: Sin precio";
                }
                
            
                try
                {
                    pbxFoto.Load(ArtDesc.ImagenURL);
                }
                catch (Exception)
                {
                    pbxFoto.Load("https://st4.depositphotos.com/14953852/22772/v/600/depositphotos_227725020-stock-illustration-no-image-available-icon-flat.jpg");
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar();
            agregar.ShowDialog();
            cargar_datos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo auxAgregar = new Articulo();
            auxAgregar = (Articulo)dgvTabla.CurrentRow.DataBoundItem;
            Agregar agregar = new Agregar(auxAgregar);
            agregar.ShowDialog();
            cargar_datos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbxBuscar.Text == "")
                btnBuscar.BackColor = Color.Red;
            else {
                cbxBuscar.BackColor = SystemColors.Control;
                List<Articulo> aux = new List<Articulo>();
                for (int i = 0; i < listaArticulos.Count; i++)
                {
                    Articulo A = listaArticulos[i];
                    if (!(A.Codigo is null) && A.Codigo == txbBuscar.Text && cbxBuscar.Text == "Código")
                        aux.Add(A);
                    if (!(A.Nombre is null) && A.Nombre == txbBuscar.Text && cbxBuscar.Text == "Nombre")
                        aux.Add(A);
                    if (!(A.Marca is null) && A.Marca.Nombre == txbBuscar.Text && cbxBuscar.Text == "Marca")
                        aux.Add(A);
                    if (!(A.Categoria is null) && A.Categoria.Nombre == txbBuscar.Text && cbxBuscar.Text == "Categoria")
                        aux.Add(A);
                }
                if (txbBuscar.Text == "") dgvTabla.DataSource = listaArticulos;
                else dgvTabla.DataSource = aux;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Articulo borrado = (Articulo)dgvTabla.CurrentRow.DataBoundItem;
            Confirmar vtnConfirmar = new Confirmar(borrado);
            vtnConfirmar.ShowDialog();
            cargar_datos();
        }
    }
}
