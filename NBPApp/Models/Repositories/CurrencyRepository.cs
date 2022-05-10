using System.Linq;

namespace NBPApp.Models.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CurrencyRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Add(CurrencyDto currencyDto)
        {
            _applicationDbContext.Currency.Add(currencyDto);
            _applicationDbContext.SaveChanges();
        }

        public IQueryable<CurrencyDto> GetAll() =>_applicationDbContext.Currency;
       
    }
}
