using System;

namespace Wizard.Infrastructures.Snowflake
{
    public class InvalidSystemClock : Exception
    {
        public InvalidSystemClock(string message) : base(message)
        {
        }
    }
}