using System.Linq;

namespace NBPApp.Models.Repositories
{
    public interface ICurrencyRepository
    {
        public IQueryable<CurrencyDto> GetAll();
        public void Add(CurrencyDto currencyDto);
    }
}
