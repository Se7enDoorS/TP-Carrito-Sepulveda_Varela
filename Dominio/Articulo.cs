using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int Id
        { get; set; }
        public string Codigo
        { get; set; }
        public string Nombre
        { get; set; }
        public string Descripcion
        { get; set; }
        public marca Marca
        { get; set; }
        public categoria Categoria
        { get; set; }
        public string ImagenURL
        { get; set; }
        public decimal Precio
        { get; set; }
    }
}
