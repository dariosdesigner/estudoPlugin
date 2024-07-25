using EstudoPlugin.HtmlFragmentPlugin.PluginApi;

namespace EstudoPlugin.HtmlFragmentPlugin;

public sealed class HtmlFragmentPlugin : IHtmlFragmentPlugin
{
    public Task<string> GetFragmentContentAsync()
    =>


       Task.FromResult(
           """<div class='alert alert-primary' role='alert'>This is a primary alert from a plugin - check it out!""");

}
