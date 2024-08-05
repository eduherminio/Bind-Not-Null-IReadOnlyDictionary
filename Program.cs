using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

MyOptions instance = new();
var section = config.GetSection("Options");
section.Bind(instance/*, opt => opt.ErrorOnUnknownConfiguration = true*/);

Console.WriteLine(instance.Enabled);
Console.WriteLine(instance.Fields.Count);

public class MyOptions
{
    public bool Enabled { get; set; } = false;

    public IReadOnlyDictionary<string, object> Fields { get; set; } = new Dictionary<string, object>();

    // Workaround:

    //#if NET8_0_OR_GREATER
    //    = new Dictionary<string, object>();
    //#else
    //    //= null!;
    //#endif
}