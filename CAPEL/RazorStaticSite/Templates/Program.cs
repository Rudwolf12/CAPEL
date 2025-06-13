using RazorLight;

var engine = new RazorLightEngineBuilder()
    .UseFileSystemProject(Path.Combine(Directory.GetCurrentDirectory(), "Templates"))
    .UseMemoryCaching()
    .Build();

// 1. Cargar el layout base como texto
var layoutTemplate = File.ReadAllText("Templates/layout.cshtml");

// 2. Lista de vistas a procesar
var pages = new[]
{
    new { View = "Index.cshtml", Title = "Inicio", Output = "index.html" },
    new { View = "Contacto.cshtml", Title = "Contacto", Output = "contacto.html" },
    new { View = "Horarios.cshtml", Title = "Horarios", Output = "horarios.html" }
};

var outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
Directory.CreateDirectory(outputDir);

foreach (var page in pages)
{
    // Renderizar solo el contenido de la vista
    var bodyHtml = await engine.CompileRenderAsync<object>(page.View, null);

    // Reemplazar en el layout
    var fullHtml = layoutTemplate
        .Replace("{{Body}}", bodyHtml)
        .Replace("{{Title}}", page.Title);

    File.WriteAllText(Path.Combine(outputDir, page.Output), fullHtml);
    Console.WriteLine($"✅ Página generada: {page.Output}");
}
