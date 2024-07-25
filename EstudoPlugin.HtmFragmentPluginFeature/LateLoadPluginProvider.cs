using Autofac;
using EstudoPlugin.Plugin.Shared;
using System.Reflection;

namespace EstudoPlugin.HtmlFragmentPluginFeature;

public sealed class LateLoadPluginProvider<TPluginApi>
{
    private readonly GenericPluginProvider<TPluginApi> _genericPluginProvider;
    private readonly List<TPluginApi> _plugins;
    public event EventHandler<EventArgs>? PluginsChanged;
    public LateLoadPluginProvider(GenericPluginProvider<TPluginApi> genericPluginProvider)
    {
        _genericPluginProvider = genericPluginProvider;
        _plugins = new List<TPluginApi>();
        FileSystemWatcher watcher = new(AppDomain.CurrentDomain.BaseDirectory, "*plugin*.dll");
        watcher.EnableRaisingEvents = true;
        watcher.Created += Watcher_Created;
    }
    public IReadOnlyList<TPluginApi> GetPlugins()
    {
        var combinedPlugins = _genericPluginProvider.GetPlugins().ToList();
        combinedPlugins.AddRange(_plugins);
        return combinedPlugins;
    }


    private void Watcher_Created(object sender, FileSystemEventArgs e)
    {
        ContainerBuilder builder = new ContainerBuilder();
        var assembly = Assembly.LoadFrom(e.FullPath);
        builder
            .RegisterAssemblyTypes(assembly)
            .Where(t => typeof(TPluginApi).IsAssignableFrom(t)
                    && !t.IsAbstract
                    && t.IsClass)
            .AsImplementedInterfaces()
            .SingleInstance();

        var container = builder.Build();
        var scope = container.BeginLifetimeScope();
        var plugins = scope.Resolve<IEnumerable<TPluginApi>>();
        _plugins.AddRange(plugins);
        PluginsChanged?.Invoke(this, EventArgs.Empty);
    }
}
