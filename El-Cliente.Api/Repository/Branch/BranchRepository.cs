using El_Cliente.Api.Data;

namespace El_Cliente.Api.Repository.Branch
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DataContext _dataContext;

        public BranchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}