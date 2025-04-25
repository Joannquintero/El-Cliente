using El_Cliente.Api.Data;

namespace El_Cliente.Api.Repository.Visit
{
    public class VisitRepository : IVisitRepository
    {
        private readonly DataContext _context;

        public VisitRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
    }
}