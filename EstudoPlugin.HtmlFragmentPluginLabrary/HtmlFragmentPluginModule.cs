using Autofac;

namespace EstudoPlugin.HtmlFragmentPluginLabrary
{
    public sealed class HtmlFragmentPluginModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<HtmlFragmentPlugin>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
