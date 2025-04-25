using El_Cliente.Api.Data;

namespace El_Cliente.Api.Repository.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
    }
}