using System.Linq;

namespace NBPApp.Models.Repositories
{
    public class CurrencyRepository : ICurrentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CurrencyRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<CurrencyDto> GetAll() =>_applicationDbContext.Currency;
       
    }
}
