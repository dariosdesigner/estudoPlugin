using Autofac;
using EstudoPlugin.NavigationPluginApi;
using EstudoPlugin.Plugin.Shared;
using System.Reflection;

namespace EstudoPluginApp;

public sealed class NavigationModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GenericPluginProvider<INavigationPlugin>>().SingleInstance();

        foreach (var file in Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*plugin*.dll", SearchOption.TopDirectoryOnly))

        {
            var assembly = Assembly.LoadFrom(file);
            builder.RegisterAssemblyTypes(assembly)
                .Where(t =>
                typeof(INavigationPlugin).IsAssignableFrom(t)
                && !t.IsAbstract
                && t.IsClass)
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
