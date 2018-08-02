using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Infrastructures.Attributes
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