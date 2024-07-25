
using System.ComponentModel;

namespace EstudoPlugin.HtmlFragmentPluginFeature;

public class PluginListModel<TPluginApi> : INotifyPropertyChanged
{
    private readonly LateLoadPluginProvider<TPluginApi> _pluginProvider;

    public event PropertyChangedEventHandler? PropertyChanged;
    public PluginListModel(LateLoadPluginProvider<TPluginApi> lateLoadPluginProvider)
    {
        _pluginProvider = lateLoadPluginProvider;
        _pluginProvider.PluginsChanged += PluginProvider_PluginsChanged;
    }
    public IReadOnlyList<TPluginApi> Plugins=>_pluginProvider.GetPlugins();

    private void PluginProvider_PluginsChanged(object? sender, EventArgs e)
    {
        PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Plugins)));
    }
}
