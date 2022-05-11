using System.Collections.Generic;
using System.Linq;

namespace NBPApp.Models.Repositories
{
    public interface ICurrencyRepository
    {
        public IQueryable<CurrencyDto> GetAll();
        public void Add(CurrencyDto currencyDto);
        public void AddRange(IEnumerable<CurrencyDto> currencyDtos);
        public void UpdateRange(IEnumerable<CurrencyDto> currencyDtos);
    }
}
