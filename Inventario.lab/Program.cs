namespace Inventario.lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Registro del Producto ===");

            Console.WriteLine("Nombre del producto: ");
            string nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Error");
                return;
            }
            Console.WriteLine("precio unitario (Q): ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Cantidad en existencia: ");
            int cantidad = int.Parse(Console.ReadLine());

            decimal valorTotal = precio * cantidad;

            Console.WriteLine();
            Console.WriteLine("--- ficha del producto ---");
            Console.WriteLine($"Producto : {nombre}");
            Console.WriteLine($"Precio   : Q {precio:N2}");
            Console.WriteLine($"cantidad : {cantidad}");
            Console.WriteLine($"Valor en inventario: Q {valorTotal:N2}");

            Console.Write("Código del producto: ");
            int codigo = int.Parse(Console.ReadLine());

            int faltante = 50 - cantidad;
            Console.WriteLine(
                $"Faltante para stock objetivo (50): {faltante}");
        }
    }
}