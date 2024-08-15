using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3b
{
    internal class Cliente
    {
        public Cliente(string nombre, string correo, string direccion, double descuento)
        {
            Nombre = nombre;
            Correo = correo;
            Telefono = Telefono;
            Descuento = descuento;
        }

        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public double Descuento { get; set; }
        public Reserva Reserva { get; set; }
        public virtual void MostrarInformacion()
        {
            Console.WriteLine("--------CLIENTE--------");
            Console.WriteLine("\nNombre: " + Nombre);
            Console.WriteLine("\nCorreo: " + Correo);
            Console.WriteLine("\nTelefono: " + Telefono);
            if (Descuento != -1) Console.WriteLine($"\nDescuento: {Descuento * 100}%");
            if (Reserva is not null)
            {
                Console.WriteLine("Reserva: " + Reserva.Id);
            }
        }
        public virtual double AplicarDescuento(double precio)
        {
            if (Descuento == 0)
            {
                return precio;
            }
            Console.WriteLine("Tu membresia tiene un descuento!!");
            Console.WriteLine("\nPrecio Anterior: Q." + precio);
            precio = (precio) - (precio * Descuento);
            Console.WriteLine("Nuevo Precio: Q." + precio);
            Console.ReadLine();
            return precio;
        }
        public virtual void AsignarReserva(Reserva reserva) => Reserva = reserva;
    }
}
  
