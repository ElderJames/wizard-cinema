using System;
using System.Data;

namespace Wizard.Cinema.Infrastructures
{
    public interface ITransactionRepository
    {
        void UseTransaction(IsolationLevel level, Action action);
    }
}
