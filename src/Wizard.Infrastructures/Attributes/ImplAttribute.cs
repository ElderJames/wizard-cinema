using System;
using Microsoft.Extensions.DependencyInjection;

namespace Wizard.Infrastructures.Attributes
{
    public class ImplAttribute : Attribute
    {
        public Type InterfaceType { get; }

        public ServiceLifetime Lifetime { get; set; }

        public ImplAttribute(ServiceLifetime lifetime)
        {
            this.Lifetime = lifetime;
        }

        public ImplAttribute(ServiceLifetime lifetime, Type interfaceType)
        {
            this.InterfaceType = interfaceType;
        }
    }
}