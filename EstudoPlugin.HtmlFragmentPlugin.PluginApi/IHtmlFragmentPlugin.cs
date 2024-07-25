namespace EstudoPlugin.HtmlFragmentPlugin.PluginApi
{
    public interface IHtmlFragmentPlugin
    {
        Task<string> GetFragmentContentAsync();
    }
}
