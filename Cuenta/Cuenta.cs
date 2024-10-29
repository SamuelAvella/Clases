using System;

public class Cuenta
{
    private string Titular { get; set; }
    private double Cantidad { get; set; }

    public Cuenta(string titular)
    {
        Titular = titular;
        Cantidad = 0;
    }

    public Cuenta(string titular, double cantidad)
    {
        Titular = titular;
        Cantidad = cantidad;
    }

    public override string ToString()
    {
        return $"Titular: {Titular}, Cantidad: {Cantidad:F2}";
    }

    public void Ingresar(double cantidad)
    {
        if (cantidad > 0)
            Cantidad += cantidad;
    }

    public void Retirar(double cantidad)
    {
        if (Cantidad - cantidad < 0)
        {
            Cantidad = 0;
        }
        else
        {
            Cantidad -= cantidad;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Cuenta cuenta1 = new Cuenta("Juan Pérez", 500.75);
        Console.WriteLine(cuenta1);

        cuenta1.Ingresar(150);
        Console.WriteLine("Después de ingresar 150:");
        Console.WriteLine(cuenta1);

        cuenta1.Retirar(200);
        Console.WriteLine("Después de retirar 200:");
        Console.WriteLine(cuenta1);

        cuenta1.Retirar(600);
        Console.WriteLine("Después de intentar retirar 600:");
        Console.WriteLine(cuenta1);
    }
}
