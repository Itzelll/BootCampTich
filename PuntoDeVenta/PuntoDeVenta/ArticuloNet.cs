using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    internal class ArticuloNet : IArticulo
    {
        public string Imprimir()
        {
            return "Articulo de .NET";
        }
    }
}
