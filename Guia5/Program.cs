using System;
using System.Data;
namespace Guia5
{
    public class Program
    {
        // Define un array con un tamaño fijo de 5 para almacenar objetos de tipo Telefono
        private static Telefono[] inventario = new Telefono[5];

        // Contador para llevar el total de telefonos registrados
        private static int cantidadTelefonos = 0;

        public static void Main()
        {
            // Variable para controlar el ciclo del menu
            bool continuar = true;

            // Ciclo que muestra el menu hasta que el usuario decida salir
            while (continuar)
            {
                // Muestra las opciones del menu
                MostrarMenu();

                // Leer la opción del usuario
                string opcion = Console.ReadLine();
                int opciones = Convert.ToInt32(opcion);

                // Ejecutar accion basada en la opción seleccionada
                switch (opciones)
                {
                    case 1:
                        RegistrarTelefono();//case 1: Llama al metodo RegistrarTelefono()
                        break;
                    case 2:
                        MostrarTelefonosRegistrados();//case 2: Llama al metodo MostrarTelefonosRegistrados()
                        break;
                    case 3:
                        Stock();//case 3: Llama al metodo Stock()
                        break;
                    case 4:
                        continuar = false;//case 4: Cambia continuar a false y muestra un mensaje de salida.
                        Console.WriteLine("Saliendo del programa.");
                        break;
                    default:// Muestra un mensaje de error si la opción no es válida.
                        Console.WriteLine("Error: la opción no es válida. Por favor, elija de nuevo.");
                        break;
                }
            }
        }

        private static void MostrarMenu()
        {
            // Muestra las opciones del menu y solicita al usuario que seleccione una opcion.
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Registrar Telefono");
            Console.WriteLine("2. Mostrar Telefonos Registrados");
            Console.WriteLine("3. Consultar Stock de un Telefono Especifico");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
        }

        private static void RegistrarTelefono()
        {
            // Verifica si el inventario esta lleno
            if (cantidadTelefonos >= inventario.Length)
            {
                Console.WriteLine("Inventario lleno. No es posible registrar mas telefonos.");
                return;
            }

            // Selección del tipo de teléfono a registrar
            Console.WriteLine("Seleccione el tipo de teléfono que desea registrar:");
            Console.WriteLine("1. Teléfono Inteligente");
            Console.WriteLine("2. Teléfono Básico");
            string tipos = Console.ReadLine();
            int tipo = Convert.ToInt32(tipos);

            Telefono nuevoTelefono = null;

            // Ingresar detalles comunes del teléfono
            Console.Write("Ingrese la marca: ");
            string marca = Console.ReadLine();
            Console.Write("Ingrese el modelo: ");
            string modelo = Console.ReadLine();
            Console.Write("Ingrese el precio: ");
            string precios = Console.ReadLine();
            decimal precio = Convert.ToDecimal(precios);
            Console.Write("Ingrese el stock: ");
            string Stock = Console.ReadLine();
            int stock = Convert.ToInt32(Stock);

            // // Verifica si el tipo de telefono seleccionado es 1 (Telefono Inteligente)
            if (tipo == 1)
            {
                nuevoTelefono = new TelefonoInteligente();// Crea una nueva instancia de TelefonoInteligente

                Console.Write("Ingrese el sistema operativo: ");// Solicita al usuario ingresar el sistema operativo
                string sistemaOperativo = Console.ReadLine();

                Console.Write("Ingrese la memoria RAM (GB): ");//Solicita al usuario ingresar la memoria Ram
                string memoria = Console.ReadLine();
                int memoriaram = Convert.ToInt32(memoria);

                // Asigna los valores ingresados a las propiedades del nuevo teléfono inteligente
                ((TelefonoInteligente)nuevoTelefono).sistemaoperativo = sistemaOperativo;
                ((TelefonoInteligente)nuevoTelefono).memoriaram = memoriaram;
            }
            else if (tipo == 2)// Verifica si el tipo de teléfono seleccionado es 2 (Telefono Basico)
            {
                nuevoTelefono = new TelefonoBasico();
                // Pregunta  al usuario  si el telefono tiene Radio FM
                Console.Write("¿Tiene Radio FM? (Si/No): ");
                string tieneRadio = Console.ReadLine();//Lee la entrada del usuario y la almacena en la variable tieneRadio
                bool tieneRadioFM = false;
                for (int i = 0; i < tieneRadio.Length; i++) //Inicia un bucle for que recorrerá cada caracter de la cadena tieneRadio
                {
                    tieneRadioFM = (tieneRadio[i] == 'M' || tieneRadio[i] == 'm'); //Dentro del bucle, verifica si algun caracter de la cadena es Mayuscula o minuscula.
                }

                Console.Write("¿Tiene Linterna? (Si/No): ");//Pregunta al usuario si el telefono tiene linterna
                string tieneLinterna = Console.ReadLine();
                bool tieneLinternaBool = false;
                for (int i = 0; i < tieneLinterna.Length; i++)
                {
                    tieneLinternaBool = (tieneLinterna[i] == 'M' || tieneLinterna[i] == 'm');
                }


                ((TelefonoBasico)nuevoTelefono).TieneRadioFM = tieneRadioFM;
                ((TelefonoBasico)nuevoTelefono).TieneLinterna = tieneLinternaBool;
            }
            else
            {
                Console.WriteLine("El tipo de telefono no es valido. Intentelo de nuevo");
                return;
            }

            // Asignar los valores comunes al nuevo teléfono
            nuevoTelefono.marca = marca;
            nuevoTelefono.modelo = modelo;
            nuevoTelefono.precio = precio;
            nuevoTelefono.stock = stock;

            // Agregar el nuevo teléfono al inventario
            inventario[cantidadTelefonos] = nuevoTelefono;
            cantidadTelefonos++; // Incrementar el contador de teléfonos registrados
            Console.WriteLine("El teléfono se ha registrado exitosamente.");
        }

        private static void MostrarTelefonosRegistrados()
        {
            // Verificar si hay teléfonos registrados
            if (cantidadTelefonos == 0)
            {
                Console.WriteLine("No hay teléfonos registrados.");
                return;
            }

            // Mostrar la lista de teléfonos registrados
            Console.WriteLine("Lista de teléfonos registrados:");
            for (int i = 0; i < cantidadTelefonos; i++)
            {
                inventario[i].mostrarinformacion();
                Console.WriteLine();
            }
        }

        private static void Stock()
        {
            // Pedir al usuario el modelo del teléfono a buscar
            Console.Write("Ingrese el modelo del teléfono: ");
            string modelo = Console.ReadLine();

            Telefono telefonoEncontrado = null;

            // Buscar el teléfono por modelo en el inventario
            for (int i = 0; i < cantidadTelefonos; i++)
            {
                //Dentro del bucle, se utiliza una declaracion if para comparar el modelo del telefono actual (inventario[i].modelo) con el modelo buscado (modelo)


                if (inventario[i].modelo.ToLower() == modelo.ToLower())//ToLower() convierte ambos modelos a minusculas para realizar una comparacion insensible a mayusculas y minusculas.

                {
                    telefonoEncontrado = inventario[i];
                    break;//Una vez que se encuentra el telefono buscado se utiliza break para salir del bucle
                }
            }

            // Mostrar la información del teléfono encontrado o un mensaje si no se encuentra
            if (telefonoEncontrado != null)
            {
                telefonoEncontrado.mostrarinformacion();
            }
            else
            {
                Console.WriteLine("El teléfono que está buscando no ha sido encontrado.");
            }
        }
    }
}

