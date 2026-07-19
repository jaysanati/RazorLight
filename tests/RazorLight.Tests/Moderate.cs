using RazorLight.Tests.ViewModels;

namespace RazorLight.Tests;

[TestClass]
public class Moderate
{
	[TestMethod]
	public async Task RenderLibrary()
	{
		var engine = new RazorLightEngineBuilder()
					// required to have a default RazorLightProject type,
					// but not required to create a template from string.
					.UseEmbeddedResourcesProject(typeof(LibraryViewModel))
					.SetOperatingAssembly(typeof(LibraryViewModel).Assembly)
					.UseMemoryCachingProvider()
					.Build();

		string template = File.ReadAllText("Templates\\Library.cshtml");
		var model = new LibraryViewModel { Name = "Great Library" };

		string result = await engine.CompileRenderStringAsync("templateKey", template, model);
	}
}
