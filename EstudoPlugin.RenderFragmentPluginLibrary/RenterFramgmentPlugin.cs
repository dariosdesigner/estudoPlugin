using EstudoPlugin.Plugin;
using Microsoft.AspNetCore.Components;

namespace EstudoPlugin.RenderFragmentPluginLibrary
{
    public class RenterFramgmentPlugin : IPluginApi3
    {
        public Task<RenderFragment> GetRenderFragmentAsync() =>
            Task.FromResult(new RenderFragment(builder =>
            {
                var content = """<div class='alert alert-primary' role='alert'>Woah! this is from PluginApi3""";
                builder.OpenElement(1, "p");
                builder.AddContent(2, new MarkupString(content));
                builder.CloseElement();
            }));

    }
}
