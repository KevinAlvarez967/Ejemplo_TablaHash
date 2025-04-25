using System;
using System.Collections.Generic; // Necesario para usar List y KeyValuePair

// Clase que representa la tabla hash
class TablaHash
{
    private const int TAMANO = 10; // Define el tamaño fijo de la tabla hash
    private List<KeyValuePair<string, string>>[] tabla; // Arreglo de listas para implementar encadenamiento

    // Constructor: inicializa cada posición de la tabla con una lista vacía
    public TablaHash()
    {
        tabla = new List<KeyValuePair<string, string>>[TAMANO];
        for (int i = 0; i < TAMANO; i++)
        {
            tabla[i] = new List<KeyValuePair<string, string>>();
        }
    }

    // Función hash sencilla: suma los valores ASCII de los caracteres de la clave y aplica módulo
    private int FuncionHash(string clave)
    {
        int suma = 0;
        foreach (char c in clave)
        {
            suma += c; // Suma el valor ASCII de cada carácter
        }
        return suma % TAMANO; // Retorna el índice dentro del rango del tamaño de la tabla
    }

    // Inserta un par clave-valor en la tabla
    public void Insertar(string clave, string valor)
    {
        int indice = FuncionHash(clave); // Calcula el índice usando la función hash

        // Recorre la lista en ese índice para ver si ya existe la clave
        for (int i = 0; i < tabla[indice].Count; i++)
        {
            if (tabla[indice][i].Key == clave) // Si la clave ya existe, actualiza su valor
            {
                tabla[indice][i] = new KeyValuePair<string, string>(clave, valor);
                return; // Sale de la función una vez actualizado
            }
        }

        // Si la clave no existe, la agrega al final de la lista
        tabla[indice].Add(new KeyValuePair<string, string>(clave, valor));
    }

    // Busca un valor asociado a una clave
    public string Buscar(string clave)
    {
        int indice = FuncionHash(clave); // Calcula el índice usando la función hash

        // Recorre la lista de ese índice buscando la clave
        foreach (var par in tabla[indice])
        {
            if (par.Key == clave)
                return par.Value; // Retorna el valor si la clave coincide
        }

        return null; // Si no se encuentra la clave, retorna null
    }

    // Muestra el contenido completo de la tabla hash
    public void Mostrar()
    {
        for (int i = 0; i < TAMANO; i++)
        {
            Console.Write($"Índice {i}: ");
            foreach (var par in tabla[i])
            {
                // Muestra cada par clave-valor almacenado en ese índice
                Console.Write($"[{par.Key}: {par.Value}] ");
            }
            Console.WriteLine(); // Salta a la siguiente línea después de cada índice
        }
    }

    // Función principal del programa
    static void Main()
    {
        TablaHash tabla = new TablaHash(); // Crea una instancia de la tabla hash

        // Inserta algunos datos de ejemplo
        tabla.Insertar("Juan", "Ingeniería");
        tabla.Insertar("Ana", "Contabilidad");
        tabla.Insertar("Luis", "Marketing");
        tabla.Insertar("Eva", "Recursos Humanos");

        // Muestra todo el contenido de la tabla
        Console.WriteLine("Contenido de la tabla hash:\n");
        tabla.Mostrar();

        // Prueba de búsqueda de claves
        Console.WriteLine("\nBuscar clave 'Ana': " + tabla.Buscar("Ana")); // Debería encontrarla
        Console.WriteLine("Buscar clave 'Carlos': " + tabla.Buscar("Carlos")); // No existe, debe retornar null
    }
}
