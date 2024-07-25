using Autofac;
using EstudoPlugin.HtmlFragmentPlugin.PluginApi;
using EstudoPlugin.Plugin.Shared;

namespace EstudoPlugin.HtmlFragmentPluginFeature
{
    public sealed class PluginModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<GenericPluginProvider<IHtmlFragmentPlugin>>()
                .SingleInstance();
            builder
                .RegisterType<LateLoadPluginProvider<IHtmlFragmentPlugin>>()
                .SingleInstance();
            builder
               .RegisterType<PluginListModel<IHtmlFragmentPlugin>>()
               .SingleInstance();
        }
    }
}
