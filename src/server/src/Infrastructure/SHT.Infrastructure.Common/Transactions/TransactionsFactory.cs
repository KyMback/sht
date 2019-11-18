using System.Transactions;

namespace SHT.Infrastructure.Common.Transactions
{
    public static class TransactionsFactory
    {
        public static TransactionScope Create()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            return new TransactionScope(
                TransactionScopeOption.Required,
                options,
                TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}