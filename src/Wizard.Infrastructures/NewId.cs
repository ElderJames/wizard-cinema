using System;
using Wizard.Infrastructures.Snowflake;

namespace Wizard.Infrastructures
{
    public static partial class NewId
    {
        private static readonly IdWorker IdWorker;

        static NewId()
        {
            if (IdWorker == null)
                IdWorker = new IdWorker(0, 0);
        }

        public static long GenerateId()
        {
            return IdWorker.NextId();
        }

        public static Guid GenerateGuid()
        {
            return SequentialGuid.Create();
        }
    }
}
