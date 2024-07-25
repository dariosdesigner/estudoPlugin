
namespace EstudoPlugin.NavigationPluginApi;

public interface INavigationPlugin
{
    Task<IReadOnlyList<NavigationItem>> GetNavigationItemsAsync();
}
