using System;
using System.Data;

namespace Wizard.Infrastructures
{
    public interface ITransactionRepository
    {
        void UseTransaction(IsolationLevel level, Action action);
    }
}