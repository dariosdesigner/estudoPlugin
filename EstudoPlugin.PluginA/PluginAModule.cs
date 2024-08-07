﻿using Autofac;

namespace EstudoPlugin.PluginA
{
    public sealed class PluginAModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PluginA>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
