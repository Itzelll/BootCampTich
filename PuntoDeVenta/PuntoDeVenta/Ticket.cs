using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    internal class Ticket
    {
        public List<IArticulo> listArticulos = new List<IArticulo>();
        public void Imprimir()
        {
            foreach (var articulo in listArticulos)
            {
                Console.WriteLine(articulo.Imprimir());
            }
        }
    }
}
