using El_Cliente.Api.Data;

namespace El_Cliente.Api.Repository.Registration
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly DataContext _dataContext;

        public RegistrationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}