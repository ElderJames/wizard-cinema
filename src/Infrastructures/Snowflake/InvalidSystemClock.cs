using System;

namespace Infrastructures.Snowflake
{
    public class InvalidSystemClock : Exception
    {
        public InvalidSystemClock(string message) : base(message)
        {
        }
    }
}
