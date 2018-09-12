using System;
using System.Data;

namespace Infrastructures
{
    public interface ITransactionRepository
    {
        void UseTransaction(IsolationLevel level, Action action);
    }
}
