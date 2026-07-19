namespace RazorLight.Tests;

public class ViewModel
{
    public required string Name { get; set; }
}

[TestClass]
public sealed class Simple
{
    [TestMethod]
    public async Task HellowWorld()
    {
        var engine = new RazorLightEngineBuilder()
            // required to have a default RazorLightProject type,
            // but not required to create a template from string.
            .UseEmbeddedResourcesProject(typeof(ViewModel))
            .SetOperatingAssembly(typeof(ViewModel).Assembly)
            .UseMemoryCachingProvider()
            .Build();

        string template = "Hello, @Model.Name. Welcome to RazorLight repository";
        ViewModel model = new ViewModel { Name = "John Doe" };

        string result = await engine.CompileRenderStringAsync("templateKey", template, model);

        Assert.AreEqual("Hello, John Doe. Welcome to RazorLight repository", result);
    }

    [TestMethod]
    public async Task IfCondition()
    {
        var engine = new RazorLightEngineBuilder()
            // required to have a default RazorLightProject type,
            // but not required to create a template from string.
            .UseEmbeddedResourcesProject(typeof(ViewModel))
            .SetOperatingAssembly(typeof(ViewModel).Assembly)
            .UseMemoryCachingProvider()
            .Build();

        string template = "@if(Model.Name == \"John Doe\") { <text>Hello, @Model.Name. Welcome to RazorLight repository</text> }";
        ViewModel model = new ViewModel { Name = "John Doe" };

        string result = await engine.CompileRenderStringAsync("templateKey", template, model);

        Assert.AreEqual("Hello, John Doe. Welcome to RazorLight repository", result);
    }

    [TestMethod]
    public async Task IfElseCondition()
    {
        var engine = new RazorLightEngineBuilder()
            // required to have a default RazorLightProject type,
            // but not required to create a template from string.
            .UseEmbeddedResourcesProject(typeof(ViewModel))
            .SetOperatingAssembly(typeof(ViewModel).Assembly)
            .UseMemoryCachingProvider()
            .Build();

        string template = "@if(Model.Name == \"John Doe\") { <text>Hello, @Model.Name. Welcome to RazorLight repository</text> } else { <text>Hello, stranger!</text> }";
        ViewModel model = new ViewModel { Name = "John Smith" };

        string result = await engine.CompileRenderStringAsync("templateKey", template, model);

        Assert.AreEqual("Hello, stranger!", result);
    }
}
