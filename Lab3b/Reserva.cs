using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3b
{
    internal class Reserva
    {
        public Reserva(int id, DateTime dateTime, Cliente cliente, List<Platillo> platillos)
        {
            Id = id;
            Fecha = dateTime;
            Cliente = cliente;
            Platillos = platillos;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public List<Platillo> Platillos { get; set; }
        public double Total { get; set; }

        public double CalcularTotal(List<Platillo> platillos)
        {
            double total = 0;
            foreach (Platillo platillo in platillos)
            {
                total += platillo.Precio;
            }
            return total;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine("-------PEDIDO-------");
            Console.WriteLine("\nNumero reserva: " + Id.ToString());
            Console.WriteLine("\nReservacion realizada en el " + Fecha.ToString());
            Console.WriteLine("\nCliente: " + Cliente.Nombre);
            Console.WriteLine("\nCorreo Cliente: " + Cliente.Correo);
            foreach (Platillo platillo in Platillos) Console.WriteLine("\nPlatillo: " + platillo.Nombre);
            Console.WriteLine("\nTotal: Q." + Total);
        }
    }
}
