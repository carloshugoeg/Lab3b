using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3b
{
    internal class ClienteVIP : Cliente
    {
        public ClienteVIP(string nombre, string correo, string telefono, double descuento) : base(nombre, correo, telefono, descuento) { }
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("\nMembresia: VIP activa");
        }
    }
}
