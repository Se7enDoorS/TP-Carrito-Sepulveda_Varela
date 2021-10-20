using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Windows.Forms;

namespace Servicio
{
    public class categoriaServicio
    {
        public List<categoria> listaCategorias()
        {
            List<categoria> listaCategorias = new List<categoria>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("select Id, Descripcion as Categoria from CATEGORIAS");
                datos.LecturaDB();
                while (datos.Lector.Read())
                {
                    categoria aux = new categoria();
                    aux.Id = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Categoria"];
                    listaCategorias.Add(aux);
                }

                return listaCategorias;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }

        public void AgregarMDB(categoria nueva)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("insert into CATEGORIAS (Descripcion) values (@Descripcion)");
                datos.setearParametros("@Descripcion", nueva.Nombre);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }

    }
}
