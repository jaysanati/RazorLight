using RazorLight;

namespace Simple;

public class ViewModel
{
	public string Name { get; set; }
}

[TestClass]
public sealed class Simple
{
	[TestMethod]
	public async Task TestMethod1()
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
	}
}
