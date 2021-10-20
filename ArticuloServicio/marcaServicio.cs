using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Windows.Forms;



namespace Servicio
{
    public class marcaServicio
    {
        public List<marca> listaMarcas()
        {
            List<marca> listaMarcas = new List<marca>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("select Id, Descripcion from MARCAS");
                datos.LecturaDB();
                while (datos.Lector.Read())
                {
                    marca aux = new marca();
                    aux.Id = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                    aux.Nombre = (string)datos.Lector["Descripcion"];
                    listaMarcas.Add(aux);
                }
                
                return listaMarcas;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                throw ex;
            }

        }
        public void AgregarMDB(marca nueva)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("insert into MARCAS (Descripcion) values (@Descripcion)");
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