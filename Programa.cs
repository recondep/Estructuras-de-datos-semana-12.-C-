// Clase que representa un libro  
public class Libro  
{  
    // Propiedades del libro  
    public string ISBN { get; set; } // Identificador único del libro (clave)  
    public string Titulo { get; set; } // Título del libro  
    public string Autor { get; set; } // Autor del libro  
    public string Genero { get; set; } // Género del libro  
    public bool Disponible { get; set; } // Indica si el libro está disponible para préstamo  

    // Constructor de la clase Libro  
    public Libro(string isbn, string titulo, string autor, string genero)  
    {  
        ISBN = isbn;  
        Titulo = titulo;  
        Autor = autor;  
        Genero = genero;  
        Disponible = true; // Por defecto, un libro recién registrado está disponible  
    }  

    // Sobreescribe el método ToString() para una representación legible del objeto Libro  
    public override string ToString()  
    {  
        return $"ISBN: {ISBN}, Título: {Titulo}, Autor: {Autor}, Género: {Genero}, Disponible: {Disponible}";  
    }  
}  

// Clase que representa la biblioteca  
public class Biblioteca  
{  
    // Diccionario para almacenar los libros (clave: ISBN, valor: objeto Libro)  
    private Dictionary<string, Libro> DiccionarioLibros { get; set; } = new Dictionary<string, Libro>();  

    // Conjunto para almacenar los libros que están actualmente prestados  
    private HashSet<Libro> LibrosPrestados { get; set; } = new HashSet<Libro>();  

    // Método para agregar un nuevo libro a la biblioteca  
    public void AgregarLibro(Libro libro)  
    {  
        // Verifica si ya existe un libro con el mismo ISBN  
        if (!DiccionarioLibros.ContainsKey(libro.ISBN))  
        {  
            // Agrega el libro al diccionario  
            DiccionarioLibros.Add(libro.ISBN, libro);  
            Console.WriteLine($"Libro '{libro.Titulo}' agregado correctamente.");  
        }  
        else  
        {  
            Console.WriteLine($"Error: Ya existe un libro con el ISBN '{libro.ISBN}'.");  
        }  
    }  

    // Método para prestar un libro  
    public void PrestarLibro(string isbn)  
    {  
        // Verifica si el libro existe en la biblioteca  
        if (DiccionarioLibros.ContainsKey(isbn))  
        {  
            Libro libro = DiccionarioLibros[isbn];  
            // Verifica si el libro está disponible  
            if (libro.Disponible)  
            {  
                // Marca el libro como no disponible  
                libro.Disponible = false;  
                // Agrega el libro al conjunto de libros prestados  
                LibrosPrestados.Add(libro);  
                Console.WriteLine($"Libro '{libro.Titulo}' prestado correctamente.");  
            }  
            else  
            {  
                Console.WriteLine($"Error: El libro '{libro.Titulo}' no está disponible para préstamo.");  
            }  
        }  
        else  
        {  
            Console.WriteLine($"Error: No se encontró ningún libro con el ISBN '{isbn}'.");  
        }  
    }  

    // Método para devolver un libro  
    public void DevolverLibro(string isbn)  
    {  
        // Verifica si el libro existe en la biblioteca  
        if (DiccionarioLibros.ContainsKey(isbn))  
        {  
            Libro libro = DiccionarioLibros[isbn];  
            // Verifica si el libro no está disponible (está prestado)  
            if (!libro.Disponible)  
            {  
                // Marca el libro como disponible  
                libro.Disponible = true;  
                // Remueve el libro del conjunto de libros prestados  
                LibrosPrestados.Remove(libro);  
                Console.WriteLine($"Libro '{libro.Titulo}' devuelto correctamente.");  
            }  
            else  
            {  
                Console.WriteLine($"Error: El libro '{libro.Titulo}' ya está disponible.");  
            }  
        }  
        else  
        {  
            Console.WriteLine($"Error: No se encontró ningún libro con el ISBN '{isbn}'.");  
        }  
    }  

    // Método para buscar un libro por ISBN  
    public Libro BuscarLibroPorISBN(string isbn)  
    {  
        // Verifica si el libro existe en la biblioteca  
        if (DiccionarioLibros.ContainsKey(isbn))  
        {  
            // Retorna el libro encontrado  
            return DiccionarioLibros[isbn];  
        }  
        else  
        {  
            Console.WriteLine($"No se encontró ningún libro con el ISBN '{isbn}'.");  
            return null;  
        }  
    }  

    // Método para mostrar la lista de libros prestados  
    public void MostrarLibrosPrestados()  
    {  
        // Verifica si hay libros prestados  
        if (LibrosPrestados.Count > 0)  
        {  
            Console.WriteLine("Libros actualmente prestados:");  
            // Itera sobre el conjunto de libros prestados  
            foreach (Libro libro in LibrosPrestados)  
            {  
                Console.WriteLine(libro); // Imprime la información del libro (gracias al método ToString())  
            }  
        }  
        else  
        {  
            Console.WriteLine("No hay libros prestados actualmente.");  
        }  
    }  
}  

// Clase principal del programa  
public class Program  
{  
    // Método Main (punto de entrada del programa)  
    public static void Main(string[] args)  
    {  
        // Crea una instancia de la clase Biblioteca  
        Biblioteca biblioteca = new Biblioteca();  

        // Agrega algunos libros a la biblioteca  
        biblioteca.AgregarLibro(new Libro("978-0321765723", "The Lord of the Rings", "J.R.R. Tolkien", "Fantasy"));  
        biblioteca.AgregarLibro(new Libro("978-0743273565", "The Hitchhiker's Guide to the Galaxy", "Douglas Adams", "Science Fiction"));  
        biblioteca.AgregarLibro(new Libro("978-0061122415", "To Kill a Mockingbird", "Harper Lee", "Classic"));  

        // Presta un libro  
        biblioteca.PrestarLibro("978-0321765723");  

        // Muestra los libros prestados  
        biblioteca.MostrarLibrosPrestados();  

        // Devuelve el libro prestado  
        biblioteca.DevolverLibro("978-0321765723");  

        // Muestra los libros prestados después de la devolución  
        biblioteca.MostrarLibrosPrestados();  

        // Busca un libro por ISBN  
        Libro libroEncontrado = biblioteca.BuscarLibroPorISBN("978-0743273565");  
        if (libroEncontrado != null)  
        {  
            Console.WriteLine($"Libro encontrado: {libroEncontrado}");  
        }  
    }  
}  
