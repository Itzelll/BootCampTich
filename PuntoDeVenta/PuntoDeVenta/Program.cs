using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ticket objTicket = new Ticket();

            objTicket.listArticulos.Add(new ArticuloTich());
            objTicket.listArticulos.Add(new ArticuloNet());
            objTicket.Imprimir();
            Console.ReadKey();
        }
    }
}
