
using Microsoft.AspNetCore.Components;

namespace EstudoPlugin.Plugin;

public interface IPluginApi
{
    Task<string> GetDataAsync();
}
public interface IPluginApi3
{
    Task<RenderFragment> GetRenderFragmentAsync();
}


