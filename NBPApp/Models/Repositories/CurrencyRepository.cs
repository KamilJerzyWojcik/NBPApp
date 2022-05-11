using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public void AddRange(IEnumerable<CurrencyDto> currencyDtos)
        {
            foreach(var c in currencyDtos)
            {
                Add(c);
            }
        }


        private void Update(CurrencyDto cD)
        {
            var current = _applicationDbContext.Currency.Where(c => c.Currency == cD.Currency && c.Code == cD.Code && c.Type == cD.Type).AsNoTracking().SingleOrDefault();

            if (current != null)
            {
                cD.Id = current.Id;
                _applicationDbContext.Currency.Update(cD);
                _applicationDbContext.SaveChanges();
            }
        }

        public void UpdateRange(IEnumerable<CurrencyDto> currencyDtos)
        {
            foreach (var c in currencyDtos)
            {
                Update(c);
            }
        }


    }
}
