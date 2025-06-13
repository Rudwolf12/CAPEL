using RazorLight;
using System.IO;
using System.Threading.Tasks;

var outputDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
Directory.CreateDirectory(outputDir);

// Crear motor RazorLight apuntando a la carpeta de Views
var engine = new RazorLightEngineBuilder()
    .UseFileSystemProject(Path.Combine(Directory.GetCurrentDirectory(), "Views"))
    .UseMemoryCachingProvider()
    .Build();

async Task GeneratePage(string viewName, string outputFileName, object model, string pageTitle)
{
    // Renderizar contenido de la vista (sin layout)
    string body = await engine.CompileRenderAsync(viewName, model);

    // Cargar layout
    string layoutPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "_Layout.cshtml");
    string layoutTemplate = await File.ReadAllTextAsync(layoutPath);

    // Reemplazar marcador {{Body}} y {{Title}} en layout
    string fullHtml = layoutTemplate
        .Replace("@RenderBody()", body) // Como layout tiene RenderBody() usamos esto
        .Replace("@ViewData[\"Title\"]", pageTitle)
        .Replace("@RenderSectionAsync(\"Scripts\", required: false)", ""); // Si usas scripts, agregar lógica aquí

    // Guardar archivo resultante en wwwroot
    string outputPath = Path.Combine(outputDir, outputFileName);
    await File.WriteAllTextAsync(outputPath, fullHtml);

    Console.WriteLine($"Página generada: {outputFileName}");
}

// Generar todas las páginas
await GeneratePage("Index.cshtml", "index.html", null, "Home");
await GeneratePage("Contacto.cshtml", "contacto.html", null, "Contacto");
await GeneratePage("Horarios.cshtml", "horarios.html", null, "Horarios");
await GeneratePage("Error.cshtml", "error.html", new { RequestId = "N/A" }, "Error");

Console.WriteLine("Generación de páginas estáticas completada.");
