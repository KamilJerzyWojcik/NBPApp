using System.Linq;

namespace NBPApp.Models.Repositories
{
    public interface ICurrentRepository
    {
        public IQueryable<CurrencyDto> GetAll();
    }
}
