using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class categoria
    {
        public string Nombre
        { get; set; }
        public int Id
        { get; set; }
        public categoria()
        {
            Nombre = "Sin Categoria";
            Id = 0;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }

}
