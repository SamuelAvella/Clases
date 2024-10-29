using System;
using System.Collections.Generic;

public class Contacto
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }

    public Contacto(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }

    public override bool Equals(object obj)
    {
        return obj is Contacto contacto && Nombre.Equals(contacto.Nombre, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return Nombre.GetHashCode();
    }
}

public class Agenda
{
    private List<Contacto> contactos;
    private int maxSize;

    public Agenda(int tamaño = 10)
    {
        contactos = new List<Contacto>(tamaño);
        maxSize = tamaño;
    }

    public void AñadirContacto(Contacto c)
    {
        if (!AgendaLlena() && !ExisteContacto(c))
        {
            contactos.Add(c);
            Console.WriteLine($"Contacto {c.Nombre} añadido.");
        }
        else
        {
            Console.WriteLine("No se puede añadir el contacto. Agenda llena o contacto ya existe.");
        }
    }

    public bool ExisteContacto(Contacto c)
    {
        return contactos.Contains(c);
    }

    public void ListarContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("No hay contactos en la agenda.");
            return;
        }

        Console.WriteLine("Contactos en la agenda:");
        foreach (var contacto in contactos)
        {
            Console.WriteLine($"Nombre: {contacto.Nombre}, Teléfono: {contacto.Telefono}");
        }
    }

    public void BuscaContacto(string nombre)
    {
        var contacto = contactos.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (contacto != null)
        {
            Console.WriteLine($"Teléfono de {nombre}: {contacto.Telefono}");
        }
        else
        {
            Console.WriteLine($"Contacto {nombre} no encontrado.");
        }
    }

    public void EliminarContacto(Contacto c)
    {
        if (contactos.Remove(c))
        {
            Console.WriteLine($"Contacto {c.Nombre} eliminado.");
        }
        else
        {
            Console.WriteLine($"Contacto {c.Nombre} no encontrado en la agenda.");
        }
    }

    public bool AgendaLlena()
    {
        return contactos.Count >= maxSize;
    }

    public int HuecosLibres()
    {
        return maxSize - contactos.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Agenda agenda = new Agenda();
        int opcion;

        do
        {
            Console.WriteLine("\n--- Menú de Agenda ---");
            Console.WriteLine("1. Añadir Contacto");
            Console.WriteLine("2. Listar Contactos");
            Console.WriteLine("3. Buscar Contacto");
            Console.WriteLine("4. Eliminar Contacto");
            Console.WriteLine("5. Verificar si la Agenda está Llena");
            Console.WriteLine("6. Ver Huecos Libres");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Nombre del contacto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Teléfono del contacto: ");
                    string telefono = Console.ReadLine();
                    agenda.AñadirContacto(new Contacto(nombre, telefono));
                    break;
                case 2:
                    agenda.ListarContactos();
                    break;
                case 3:
                    Console.Write("Nombre del contacto a buscar: ");
                    string nombreBusqueda = Console.ReadLine();
                    agenda.BuscaContacto(nombreBusqueda);
                    break;
                case 4:
                    Console.Write("Nombre del contacto a eliminar: ");
                    string nombreEliminar = Console.ReadLine();
                    agenda.EliminarContacto(new Contacto(nombreEliminar, ""));
                    break;
                case 5:
                    Console.WriteLine(agenda.AgendaLlena() ? "La agenda está llena." : "La agenda tiene espacio disponible.");
                    break;
                case 6:
                    Console.WriteLine($"Huecos libres: {agenda.HuecosLibres()}");
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        } while (opcion != 0);
    }
}
