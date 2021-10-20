using Dominio;
using Servicio;
using System;
using System.Windows.Forms;

namespace TP1_WinForms
{
    public partial class Confirmar : Form
    {
        private Articulo auxArt = new Articulo();
        public Confirmar(Articulo borrado)
        {
            InitializeComponent();
            auxArt = borrado;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloServicio borrar = new ArticuloServicio();
            borrar.BorrarDB(auxArt);
            Close();
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
