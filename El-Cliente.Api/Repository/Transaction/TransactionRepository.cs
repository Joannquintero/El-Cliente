using El_Cliente.Api.Data;

namespace El_Cliente.Api.Repository.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _dataContext;

        public TransactionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}