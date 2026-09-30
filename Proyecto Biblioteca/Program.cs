namespace Proyecto_Biblioteca;

internal class Program
{
    static readonly BookCatalog catalog = new();
    static int nextId = 11;
    static void Main(string[] args)
    {
        SeedBooks();
        string option;

        do
        {
            Console.Clear();
            Console.WriteLine("====== SISTEMA DE BIBLIOTECA ======\n");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Buscar libro por ID");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("0. Salir");
            Console.Write("\nSeleccione una opción: ");
            option = Console.ReadLine() ?? string.Empty;

            switch (option)
            {
                case "1": AddBook(); break;
                case "2": ListBooks(); break;
                case "3": FindBook(); break;
                case "4": UpdateBook(); break;
                case "5": RemoveBook(); break;
                case "0": Console.WriteLine("\nSaliendo del sistema..."); break;
                default:
                    Console.WriteLine("\nOpción no válida.");
                    Console.ReadKey();
                    break;
            }
        } while (option != "0");
    }

    static void SeedBooks()
    {
        catalog.AddBook(new Book(1, "Cien años de soledad", 1967, "Realismo mágico"));
        catalog.AddBook(new Book(2, "Don Quijote de la Mancha", 1605, "Clásico"));
        catalog.AddBook(new Book(3, "1984", 1949, "Distopía"));
        catalog.AddBook(new Book(4, "El principito", 1943, "Fábula"));
        catalog.AddBook(new Book(5, "La fiesta del Chivo", 2000, "Novela histórica"));
        catalog.AddBook(new Book(6, "Rayuela", 1963, "Novela"));
        catalog.AddBook(new Book(7, "Orgullo y prejuicio", 1813, "Romance"));
        catalog.AddBook(new Book(8, "El señor de los anillos", 1954, "Fantasía"));
        catalog.AddBook(new Book(9, "Dune", 1965, "Ciencia ficción"));
        catalog.AddBook(new Book(10, "Clean Code", 2008, "Programación"));
    }

    static void AddBook()
    {
        Console.Clear();
        Console.WriteLine("Agregar un nuevo libro");
        string title = ReadString("\nTitulo: ");
        int year = ReadInt("\nAño: ");
        string gender = ReadString("\nGénero: ");

        if (catalog.AddBook(new Book(nextId, title, year, gender)))
        {
            Console.WriteLine($"\nLibro agregado exitosamente con ID {nextId}.");
            nextId++;
        }
        else
        {
            Console.WriteLine("\nNo se pudo agregar: el catálogo alcanzó su capacidad máxima de 20 libros.");
        }

        Console.Write("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
    static void ListBooks()
    {
        Console.Clear();
        Book[] books = catalog.GetBooks();

        if (books.Length == 0)
        {
            Console.WriteLine("No hay libros en el catálogo.");
        }
        else
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.GetBookInfo());
            }
        }

        Console.Write("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
    static void FindBook()
    {
        Console.Clear();
        int id = ReadInt("Ingrese el ID del libro a buscar: ");

        if (catalog.FindById(id) is Book book)
        {
            Console.WriteLine(book.GetBookInfo());
        }
        else
        {
            Console.WriteLine($"No se encontró un libro con ID {id}.");
        }
        Console.Write("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();

    }
    static void UpdateBook()
    {
        Console.Clear();
        int id = ReadInt("Ingrese el ID del libro a actualizar: ");

        if (catalog.FindById(id) is not Book book)
        {
            Console.WriteLine($"No se encontró un libro con ID {id}.");
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"\nDatos actuales: {book.GetBookInfo()}\n");

        string title = ReadString("Nuevo título: ");
        int year = ReadInt("Nuevo año: ");
        string genre = ReadString("Nuevo género: ");

        catalog.UpdateBook(id, title, year, genre);
        Console.WriteLine("\nLibro actualizado correctamente.");

        Console.Write("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void RemoveBook()
    {
        Console.Clear();
        int id = ReadInt("Ingrese el ID del libro a eliminar: ");

        if (catalog.RemoveBook(id))
        {
            Console.WriteLine($"\nEl libro con ID {id} fue eliminado.");
        }
        else
        {
            Console.WriteLine($"\nNo se encontró un libro con ID {id}.");
        }

        Console.Write("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                return number;
            }

            Console.WriteLine("Debe ingresar un número válido.");
        }
    }

    static string ReadString(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }

            Console.WriteLine("Este campo no puede estar vacío.");
        }
    }

}
