using System.Xml.Linq;

Console.WriteLine("Ingrese la ruta del archivo XML:");
string filePath = Console.ReadLine();

// Verifica si el archivo existe
if (!File.Exists(filePath))
{
    Console.WriteLine("El archivo no existe.");
    return;
}

// Carga el archivo XML
XDocument doc = XDocument.Load(filePath);

// Obtiene el nombre de los elementos
var headers = doc.Root.Elements().First().Elements().Select(e => e.Name.LocalName).ToArray();

// Procesa cada elemento del archivo XML
foreach (var element in doc.Root.Elements().Skip(1)) // Salta el primer elemento (encabezado)
{
    // Procesa los datos de cada elemento
    foreach (var header in headers)
    {
        var data = element.Element(header).Value;
        Console.WriteLine($"Encabezado: {header}, Dato: {data}");
    }
}