using Lab3b;

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

        case "4":
            Console.Clear();
            DetallesClientes(clientes);
            break;
        case "5":
            Console.Clear();
            DetallesVehiculos(vehiculos);
            break;
        case "6":
            Console.Clear();
            DetallesPedidos(pedidos);
            break;
        case "7":
            Console.Clear();
            Console.WriteLine("-----BUSCAR CLIENTE-----");
            BuscarCliente(clientes);
            break;
        case "8":
            Console.Clear();
            BuscarVehiculo(vehiculos);
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