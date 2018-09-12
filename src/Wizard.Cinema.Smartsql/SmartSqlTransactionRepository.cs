using System;
using System.Data;
using Infrastructures;
using SmartSql.Abstractions;

namespace Wizard.Cinema.Smartsql
{
    public class SmartSqlTransactionRepository : ITransactionRepository
    {
        private readonly ITransaction _transaction;

        public SmartSqlTransactionRepository(ITransaction transaction)
        {
            this._transaction = transaction;
        }

        public void UseTransaction(IsolationLevel level, Action action)
        {
            try
            {
                _transaction.BeginTransaction(level);
                action.Invoke();
                _transaction.CommitTransaction();
            }
            catch
            {
                _transaction.RollbackTransaction();
                throw;
            }
        }
    }
}
