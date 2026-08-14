using System;

namespace Inventario.Lab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Program.cs — Laboratorio 05: normalizar y buscar texto de productos
            // Las instrucciones se ejecutan de arriba hacia abajo.

            Console.WriteLine("=== Registro de producto ===");

            // Paso 1 — Capturar y validar los datos con TryParse (Clase 3, sin cambios)
            Console.Write("Código del producto: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Error: el nombre del producto no puede estar vacío.");
                return;
            }

            // ============================================================
            // NUEVO — Clase 05, Paso 1: normalizar el nombre
            // ============================================================
            nombre = nombre.Trim();
            string nombreNormalizado = nombre.ToUpper();
            Console.WriteLine($"Nombre guardado como: {nombreNormalizado}");

            // NUEVO — Clase 05, Paso 2: generar un código a partir del texto
            // ("codigoGenerado" para no chocar con el "codigo" (int) de la Clase 2)
            int nPrefijo = Math.Min(3, nombreNormalizado.Length);
            string prefijo = nombreNormalizado.Substring(0, nPrefijo);
            string codigoGenerado = $"{prefijo}-{nombreNormalizado.Length:D2}";
            Console.WriteLine($"Código generado: {codigoGenerado}");

            Console.Write("Precio unitario (Q): ");
            bool precioOk = decimal.TryParse(Console.ReadLine(), out decimal precio);
            if (!precioOk || precio <= 0)
            {
                Console.WriteLine("Error: el precio debe ser un número mayor que cero.");
                return;
            }

            Console.Write("Cantidad en existencia: ");
            bool cantOk = int.TryParse(Console.ReadLine(), out int cantidad);
            if (!cantOk || cantidad < 0)
            {
                Console.WriteLine("Error: la cantidad debe ser un entero no negativo.");
                return;
            }

            Console.WriteLine("Producto válido. ¡Datos aceptados!");

            // Paso 2 — Clasificar el stock con if / else if / else (Clase 3, sin cambios)
            string estado;
            if (cantidad == 0)
                estado = "AGOTADO";
            else if (cantidad < 10)
                estado = "STOCK BAJO";
            else
                estado = "DISPONIBLE";

            decimal valorTotal = precio * cantidad;
            int faltante = 50 - cantidad;

            Console.WriteLine();
            Console.WriteLine("--- Ficha del producto ---");
            Console.WriteLine($"Código   : {codigo}");
            Console.WriteLine($"Producto : {nombre}");
            Console.WriteLine($"Precio   : Q {precio:N2}");
            Console.WriteLine($"Cantidad : {cantidad}");
            Console.WriteLine($"Estado   : {estado}");
            Console.WriteLine($"Valor en inventario: Q {valorTotal:N2}");
            Console.WriteLine($"Faltante para stock objetivo (50): {faltante}");

            // ============================================================
            // NUEVO — Clase 05, Paso 3: buscar por coincidencia
            // ============================================================
            Console.Write("Buscar texto en el nombre: ");
            string termino = Console.ReadLine().Trim().ToUpper();
            bool coincide = nombreNormalizado.Contains(termino);
            Console.WriteLine(coincide
                ? $"Coincidencia encontrada: '{nombreNormalizado}' contiene '{termino}'."
                : $"Sin coincidencia: '{nombreNormalizado}' no contiene '{termino}'.");

            // NUEVO — Clase 05, Paso 4 (reto, no es parte del entregable obligatorio):
            // IVA y unidades sueltas, con los datos reales ya capturados.
            decimal precioConIva = precio * 1.12m;
            int sueltas = cantidad % 6;
            Console.WriteLine($"Precio con IVA: Q {precioConIva:N2} | Unidades sueltas (cajas de 6): {sueltas}");

            // prueba
            int cant = 20;
            int res = cant / 6 * 6;
            Console.WriteLine($"Prueba: {cant} / 6 * 6 = {res}");

            // ============================================================
            // Clase 04 — menú repetitivo con do-while (sin cambios)
            // ============================================================
            string opcion;
            int totalProductos = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("=== MENÚ INVENTARIO ===");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Ver total de productos");
                Console.WriteLine("3. Salir");
                Console.Write("Elige una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        totalProductos++;
                        Console.WriteLine($"-> Producto agregado. Total: {totalProductos}");
                        break;
                    case "2":
                        Console.WriteLine($"-> Tienes {totalProductos} producto(s) registrados.");
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }
            }
            while (opcion != "3");

            // Clase 04 — Ciclo for: proyección de stock para 5 días (sin cambios)
            Console.WriteLine();
            Console.WriteLine("--- Proyección de stock (5 días, +3 unidades/día) ---");
            int stock = cantidad;
            for (int dia = 1; dia <= 5; dia++)
            {
                stock += 3;
                int faltanteProyectado = 50 - stock;
                Console.WriteLine($"Día {dia}: stock proyectado = {stock} (faltante: {faltanteProyectado})");
            }
        }
    }
}
