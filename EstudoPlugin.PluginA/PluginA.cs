
using EstudoPlugin.Plugin;

namespace EstudoPlugin.PluginA;

public sealed class PluginA : IPluginApi
{
    public Task<string> GetDataAsync()
=>
       Task.FromResult("Data from Plugin A!");

}
