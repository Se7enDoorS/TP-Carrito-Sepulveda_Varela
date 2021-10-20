using Dominio;
using Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_WinForms
{
    public partial class AgregarM_C : Form
    {
        private string tipo;
        public AgregarM_C(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void AgregarM_C_Load(object sender, EventArgs e)
        {
            lblDescripcion.Text = "Nombre de " + tipo;
            lblTitulo.Text = "Agregar nueva " + tipo;
            this.Text = "Agregar " + tipo; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            marca nuevaM = new marca();
            categoria nuevaC = new categoria();
            marcaServicio newServiceM = new marcaServicio();
            categoriaServicio newServiceC = new categoriaServicio();
            try
            {
                if (txbNueva.Text == "")
                    txbNueva.BackColor = Color.Red;
                else
                {
                    txbNueva.BackColor = System.Drawing.SystemColors.Control;
                    if (tipo == "Marca")
                    {
                        List<marca> listaMarca = newServiceM.listaMarcas();
                        bool existe = false;
                        foreach (marca A in listaMarca)
                        {
                            if (A.Nombre == txbNueva.Text)
                            {
                                MessageBox.Show("Esta marca ya existe!");
                                existe = true;
                            }
                        }
                        if (!existe)
                        {
                            nuevaM.Nombre = txbNueva.Text;
                            newServiceM.AgregarMDB(nuevaM);
                        }
                    }
                    else
                    {
                        List<categoria> listaCategoria = newServiceC.listaCategorias();
                        bool existe = false;
                        foreach (categoria A in listaCategoria)
                        {
                            if (A.Nombre == txbNueva.Text)
                            {
                                MessageBox.Show("Esta categoria ya existe!");
                                existe = true;
                               
                            }
                        }
                        if (!existe)
                        {
                            nuevaC.Nombre = txbNueva.Text;
                            newServiceC.AgregarMDB(nuevaC);
                        }
                    }
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }
    }
}
