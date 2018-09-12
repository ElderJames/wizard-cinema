using System;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.Attributes
{
    public class ImplAttribute : Attribute
    {
        public Type InterfaceType { get; }

        public ServiceLifetime Lifetime { get; set; }

        public ImplAttribute()
        {
            this.Lifetime = ServiceLifetime.Singleton;
        }

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
