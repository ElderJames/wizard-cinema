using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Infrastructures.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}
