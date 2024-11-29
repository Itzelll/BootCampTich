using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudADO
{
    internal class Program
    {
        static void Main(string[] args)
        {                        

            bool r = true;
            while (r)
            {
                Console.WriteLine("Elije una opcion");
                Console.WriteLine("1.- Consultar Todos" + "\n" +
                                  "2.- Consultar Solo uno " + "\n" +
                                  "3.- Agregar " + "\n" +
                                  "4.- Actualizar" + "\n" +
                                  "5.- Eliminar " + "\n" +
                                  "6.- Termina" + "\n");

                int opcion;
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ADOEstatus consultaTodo = new ADOEstatus();
                        foreach (var item in consultaTodo.Consultar())
                        {
                            Console.WriteLine($"Id: {item.id} Clave: {item.clave} Nombre: {item.nombre}\n");
                        }

                        break;
                    case 2:
                        ADOEstatus consultaUno = new ADOEstatus();
                        Console.WriteLine("Ingresa un id a consultar:");
                        int obj = int.Parse((Console.ReadLine()));                        
                        Estatus consulta = consultaUno.Consultar(obj);
                        Console.WriteLine($"\nId: {consulta.id} Clave: {consulta.clave} Nombre: {consulta.nombre}\n");                                                 

                        break;
                    case 3:
                        ADOEstatus agregar = new ADOEstatus();
                        Estatus add = new Estatus();

                        Console.WriteLine("Ingresa un id:");
                        add.id = int.Parse((Console.ReadLine()));
                        Console.WriteLine("Ingresa una clave:");
                        add.clave = Console.ReadLine();
                        Console.WriteLine("Ingresa un nombre:");
                        add.nombre = Console.ReadLine();

                        agregar.Agregar(add);
                        Console.WriteLine($"\nSe agregó el EstatusAlumno con el Id: {add.id}\n");

                        break;
                    case 4:
                        ADOEstatus actualizar = new ADOEstatus();
                        Estatus actu = new Estatus();

                        Console.WriteLine("Ingresa el id a actualizar:");
                        actu.id = int.Parse((Console.ReadLine()));
                        Console.WriteLine("Ingresa nueva clave:");
                        actu.clave = Console.ReadLine();
                        Console.WriteLine("Ingresa nuevo nombre:");
                        actu.nombre = Console.ReadLine();

                        actualizar.Actualizar(actu);
                        Console.WriteLine($"\nSe actualizó el {actu.id}: clave nueva: {actu.clave} nombre nuevo: {actu.nombre}");

                        break;
                    case 5:
                        ADOEstatus eliminar = new ADOEstatus();
                        Console.WriteLine("Ingresa un id a eliminar:");
                        int eli = int.Parse((Console.ReadLine()));
                        eliminar.Eliminar(eli);
                        Estatus objC = new Estatus();                        

                        break;
                    case 6:
                        r = false;
                        break;
                }
            }
        }
    }
}
