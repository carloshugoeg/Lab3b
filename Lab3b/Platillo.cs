using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3b
{
    internal class Platillo
    {
        public Platillo(string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public List<Platillo> AgregarPlatillos()
        {
            List<Platillo> listaPlatillos = new List<Platillo>();
            do
            {
                Console.WriteLine("---Nuevo Platillo---");
                Console.Write("\nNombre Platillo: ");
                string nombre = Console.ReadLine();
                double precio = PedirPrecio();
                listaPlatillos.Add(new Platillo(nombre, precio));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPLatillo Agregado Correctamente!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("\nDesea agregar otro platillo? y/n");
                string option = Console.ReadLine().ToLower().Trim();
                if (option == "n") { break; }
            } while (true);
            return listaPlatillos;

        }
        public double PedirPrecio()
        {
            do
            {
                try
                {

                    double precio;
                    do
                    {
                        Console.Write("Ingrese el precio de su producto: Q.");
                        precio = double.Parse(Console.ReadLine());
                        if (precio == 0 || precio == null)
                        {
                            Console.WriteLine("Valor no puede ser 0");
                            Console.ReadLine();
                        }
                    } while (precio == 0);
                    return precio;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("INPUT INVALIDO");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Venta-----");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("EL numero es demasiado grande");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Venta-----");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Venta-----");
                }
            } while (true);
        }
    }
}
