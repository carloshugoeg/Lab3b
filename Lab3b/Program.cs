﻿using Lab3b;

List<Cliente> clientes = new List<Cliente>();
List<Reserva> reservas = new List<Reserva>();
int numeroPedido = 001;
do
{
    Console.Clear();
    Console.WriteLine("------Restaurante Amistades------");
    Console.WriteLine("\n     1. Registrar Cliente");
    Console.WriteLine("\n     2. Crear Reservacion");
    Console.WriteLine("\n     3. Mostrar Detalles de Clientes");
    Console.WriteLine("\n     4. Mostrar Detalles de Reservas");
    Console.WriteLine("\n     5. Buscar Cliente por Nombre");
    Console.WriteLine("\n     6. Buscar Reserva por Numero");

    string opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            Console.Clear();
            RegistrarCliente(clientes);
            break;
        case "2":
            Console.Clear();
            RegistrarReserva(reservas, numeroPedido, clientes);
            break;
        case "3":
            Console.Clear();
            DetallesClientes(clientes);
            break;
        case "4":
            Console.Clear();
            DetallesPedidos(reservas);
            break;
        case "5":
            Console.Clear();

            BuscarCliente(clientes);
            break;
        case "6":
            Console.Clear();
            BuscarPedido(reservas);
            break;
    }
} while (true);
void RegistrarCliente(List<Cliente> clientes)
{
    Console.WriteLine("-----AGREGAR CLIENTE------");
    Console.WriteLine("\n     1. Cliente Regular");
    Console.WriteLine("\n     2. Cliente VIP");
    Console.Write("\nEscoja una opcion: ");
    string opcion = Console.ReadLine();
    Console.Write("\nIngrese nombre completo: ");
    string nombre = Console.ReadLine();
    string correo;
    bool correoValido = false;
    do
    {
        do
        {
            Console.Write("Ingrese su correo electronico: ");
            correo = Console.ReadLine();
            if (correo.Contains("@"))
            {
                correoValido = true;
                break;
            }
            else Console.WriteLine("\nDireccion de correo no es valida");
        } while (true);

        foreach (Cliente cliente in clientes)
        {
            if (cliente.Correo.ToLower().Trim().Equals(correo.ToLower().Trim()))
            {
                Console.WriteLine("Este correo ya existe");
                correoValido = false;
            }
        }
    } while (!correoValido);
    Console.Write("Telefono: ");
    string telefono = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            clientes.Add(new Cliente(nombre, correo, telefono, -1));
            Console.WriteLine("Cliente Regular agregado correctamente");
            break;
        case "2":
            clientes.Add(new ClienteVIP(nombre, correo, telefono, 0.50));
            Console.WriteLine("CLiente VIP agregado correctamente");
            break;
    }
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
void RegistrarReserva(List<Reserva> reservas, int noPedido, List<Cliente> clientes)
{
    Console.WriteLine("------CREAR RESERVA------");
    Console.WriteLine("Reserva #" + numeroPedido);
    bool encontrado = false;
    Cliente comprador = null;
    do
    {
        Console.Write("\nIngrese correo del Cliente: ");
        string correobuscado = Console.ReadLine();

        foreach (Cliente cliente in clientes)
        {
            if (cliente.Correo.ToLower().Trim().Equals(correobuscado.ToLower().Trim()))
            {
                encontrado = true;
                comprador = cliente;
            }
        }
        if (!encontrado) Console.WriteLine("\nCliente no fue encontrado");
    } while (!encontrado);
    Console.WriteLine("\n------------Registrar Platillos---------------");
    Platillo platillo = new Platillo("", 0);
    Console.WriteLine("\n----------------------------------------------");
    List<Platillo> listaPlatillos = platillo.AgregarPlatillos();
    Reserva nuevaReserva = new Reserva(noPedido, DateTime.Now, comprador, listaPlatillos);
    nuevaReserva.Total = nuevaReserva.CalcularTotal(listaPlatillos);
    if (comprador is ClienteVIP)
    {
        Console.WriteLine($"\nUsted tiene un descuento del {comprador.Descuento * 100}%!!");
        nuevaReserva.Total = comprador.AplicarDescuento(nuevaReserva.Total);
    }
    Console.WriteLine("\n RESERVA REALIZADO CORRECTAMENTE");
    numeroPedido++;
    reservas.Add(nuevaReserva);
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();

}
void DetallesClientes(List<Cliente> clientes)
{
    Console.WriteLine("-------DETALLES CLIENTES--------");
    foreach (Cliente cliente in clientes)
    {
        Console.WriteLine("");
        cliente.MostrarInformacion();
        Console.WriteLine("");
        Console.WriteLine("----------------------");
    }
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
void DetallesPedidos(List<Reserva> reservas)
{
    Console.WriteLine("----------DETALLES RESERVAS--------\n\n");
    foreach (Reserva reserva in reservas)
    {

        Console.WriteLine("");
        reserva.MostrarInformacion();
        Console.WriteLine("");
        Console.WriteLine("----------------------");
    }
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
void BuscarCliente(List<Cliente> clientes)
{
    Console.WriteLine("-----BUSCAR CLIENTE-----");
    Console.Write("\nIngrese Nombre Completo del cliente: ");
    string nombrebuscado = Console.ReadLine();
    bool encontrado = false;
    foreach (Cliente cliente in clientes)
    {
        if (cliente.Nombre.ToLower().Trim().Equals(nombrebuscado.ToLower().Trim()))
        {
            Console.WriteLine("---------------\n");
            cliente.MostrarInformacion();
            Console.WriteLine("\n---------------");
            encontrado = true;
        }
    }
    if (!encontrado) Console.WriteLine("\nCliente no fue encontrado");
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
void BuscarPedido(List<Reserva> reservas)
{
    Console.Write("\nIngrese numero de reserva: ");
    int numeroPedido = int.Parse(Console.ReadLine());
    bool encontrado = false;
    foreach (Reserva reserva in reservas)
    {
        if (reserva.Id == numeroPedido)
        {
            Console.WriteLine("---------------\n");
            reserva.MostrarInformacion();
            Console.WriteLine("\n---------------");
            encontrado = true;
        }
    }
    if (!encontrado) Console.WriteLine("\nReserva no fue encontrado");
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}