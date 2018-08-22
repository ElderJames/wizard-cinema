using System;
using System.Data;
using SmartSql.Abstractions;

namespace Wizard.Cinema.Smartsql
{
    public interface ISmartSqlTransaction
    {
        void UseTran(IsolationLevel level, Action action);
    }

    public class SmartSqlTransaction : ISmartSqlTransaction
    {
        private readonly ITransaction _transaction;

        public SmartSqlTransaction(ITransaction transaction)
        {
            this._transaction = transaction;
        }

        public void UseTran(IsolationLevel level, Action action)
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
