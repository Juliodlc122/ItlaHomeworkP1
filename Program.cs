using System;
using System.Collections.Generic;
//Julio Ruiz Matricuala:2024-2009
class ContactAgenda
{
    static List<int> ids = new List<int>();
    static Dictionary<int, string> names = new Dictionary<int, string>();
    static Dictionary<int, string> lastnames = new Dictionary<int, string>();
    static Dictionary<int, string> addresses = new Dictionary<int, string>();
    static Dictionary<int, string> telephones = new Dictionary<int, string>();
    static Dictionary<int, string> emails = new Dictionary<int, string>();
    static Dictionary<int, int> ages = new Dictionary<int, int>();
    static Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

    static void Main()
    {
        Console.WriteLine("Bienvenido a tu Agenda Personal");

        bool running = true;
        while (running)
        {
            MostrarMenu();
            int opcion = LeerOpcion();
            Console.Clear();

            switch (opcion)
            {
                case 1: AgregarContacto(); break;
                case 2: MostrarContactos(); break;
                case 3: BuscarContacto(); break;
                case 4: ModificarContacto(); break;
                case 5: EliminarContacto(); break;
                case 6: running = false; break;
                default: Console.WriteLine("Opción inválida. Intente de nuevo."); break;
            }
        }

        Console.WriteLine("Agenda finalizada.");
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\nMenú de Opciones:");
        Console.WriteLine("1. Agregar Contacto");
        Console.WriteLine("2. Ver Contactos");
        Console.WriteLine("3. Buscar Contacto");
        Console.WriteLine("4. Modificar Contacto");
        Console.WriteLine("5. Eliminar Contacto");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static int LeerOpcion()
    {
        return int.TryParse(Console.ReadLine(), out int opcion) ? opcion : 0;
    }

    static void AgregarContacto()
    {
        int id = ids.Count + 1;
        Console.Write("Nombre: "); string name = Console.ReadLine();
        Console.Write("Apellido: "); string lastname = Console.ReadLine();
        Console.Write("Dirección: "); string address = Console.ReadLine();
        Console.Write("Teléfono: "); string phone = Console.ReadLine();
        Console.Write("Email: "); string email = Console.ReadLine();
        Console.Write("Edad: "); int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("¿Es mejor amigo? (1.Sí / 2.No): ");
        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

        ids.Add(id);
        names[id] = name;
        lastnames[id] = lastname;
        addresses[id] = address;
        telephones[id] = phone;
        emails[id] = email;
        ages[id] = age;
        bestFriends[id] = isBestFriend;

        Console.WriteLine("Contacto agregado exitosamente.");
    }

    static void MostrarContactos()
    {
        if (ids.Count == 0)
        {
            Console.WriteLine("No hay contactos registrados.");
            return;
        }

        Console.WriteLine("\nListado de Contactos:");

        foreach (var id in ids)
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Nombre: {names[id]}");
            Console.WriteLine($"Apellido: {lastnames[id]}");
            Console.WriteLine($"Dirección: {addresses[id]}");
            Console.WriteLine($"Teléfono: {telephones[id]}");
            Console.WriteLine($"Email: {emails[id]}");
            Console.WriteLine($"Edad: {ages[id]}");
            Console.WriteLine($"¿Mejor amigo?: {(bestFriends[id] ? "Sí" : "No")}");
            Console.WriteLine("------------------------------------------");
        }
    }

    static void BuscarContacto()
    {
        Console.Write("\nDigite nombre o apellido para buscar: ");
        string filtro = Console.ReadLine().ToLower();
        bool encontrado = false;

        foreach (var id in ids)
        {
            if (names[id].ToLower().Contains(filtro) || lastnames[id].ToLower().Contains(filtro))
            {
                Console.WriteLine($"ID: {id}");
                Console.WriteLine($"Nombre: {names[id]}");
                Console.WriteLine($"Apellido: {lastnames[id]}");
                Console.WriteLine($"Teléfono: {telephones[id]}");
                Console.WriteLine($"Email: {emails[id]}");
                Console.WriteLine($"Edad: {ages[id]}");
                Console.WriteLine($"¿Mejor amigo?: {(bestFriends[id] ? "Sí" : "No")}");
                Console.WriteLine("------------------------------------------");
                encontrado = true;
            }
        }

        if (!encontrado) Console.WriteLine("No se encontró ningún contacto.");
    }

    static void ModificarContacto()
    {
        Console.Write("\nDigite el ID del contacto a modificar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("Contacto no encontrado.");
            return;
        }

        Console.Write("Nuevo nombre: "); names[id] = Console.ReadLine();
        Console.Write("Nuevo apellido: "); lastnames[id] = Console.ReadLine();
        Console.Write("Nueva dirección: "); addresses[id] = Console.ReadLine();
        Console.Write("Nuevo teléfono: "); telephones[id] = Console.ReadLine();
        Console.Write("Nuevo email: "); emails[id] = Console.ReadLine();
        Console.Write("Nueva edad: "); ages[id] = Convert.ToInt32(Console.ReadLine());
        Console.Write("¿Es mejor amigo? (1.Sí / 2.No): "); bestFriends[id] = Convert.ToInt32(Console.ReadLine()) == 1;

        Console.WriteLine("Contacto actualizado correctamente.");
    }

    static void EliminarContacto()
    {
        Console.Write("\nDigite el ID del contacto a eliminar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);
        telephones.Remove(id);
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);

        Console.WriteLine("Contacto eliminado correctamente.");
    }
}