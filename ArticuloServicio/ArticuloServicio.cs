using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Servicio
{
    public class ArticuloServicio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("select A.id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, A.ImagenUrl as Imagen, A.Precio, M.Id as IdMarca, C.Id as IdCategoria from ARTICULOS A left join MARCAS M on M.Id = A.IdMarca left join CATEGORIAS C on C.Id = A.IdCategoria");
                datos.LecturaDB();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                    {
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    }
                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.Marca = new marca();
                        aux.Marca.Nombre = (string)datos.Lector["Marca"];
                        aux.Marca.Id = (int)datos.Lector["idMarca"];
                    }
                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        aux.Categoria = new categoria();
                        aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    if (!(datos.Lector["Precio"] is DBNull))
                    {
                        aux.Precio = Math.Round((decimal)datos.Lector["Precio"], 2);
                    }
                    aux.ImagenURL = (string)datos.Lector["Imagen"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void AgregarDB(Articulo nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("insert into Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.setearParametros("@Codigo", nuevo.Codigo);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Descripcion", nuevo.Descripcion);
                datos.setearParametros("@idMarca", nuevo.Marca.Id);
                datos.setearParametros("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@ImagenUrl", nuevo.ImagenURL);
                datos.setearParametros("@Precio", nuevo.Precio);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }

        }

        public void ModificarDB(Articulo modify)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("update Articulos set Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, IdMarca=@idMarca, IdCategoria=@idCategoria, ImagenUrl=@ImagenUrl, Precio=@precio where Id=@Id");
                datos.setearParametros("@Codigo", modify.Codigo);
                datos.setearParametros("@Nombre", modify.Nombre);
                datos.setearParametros("@Descripcion", modify.Descripcion);
                datos.setearParametros("@idMarca", modify.Marca.Id);
                datos.setearParametros("@idCategoria", modify.Categoria.Id);
                datos.setearParametros("@ImagenUrl", modify.ImagenURL);
                datos.setearParametros("@Precio", modify.Precio);
                datos.setearParametros("@Id", modify.Id);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }

        public void BorrarDB(Articulo borrarArt)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("delete from ARTICULOS where ID = " + borrarArt.Id);
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
