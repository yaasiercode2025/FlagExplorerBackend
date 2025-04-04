using FlagExplorer.Application.Interfaces;
using FlagExplorer.Domain.Entities;
using FlagExplorer.Infrastructre.Data;
using Microsoft.EntityFrameworkCore;

namespace FlagExplorer.Infrastructre.Repositories
{
    public class CountryRepository : ICountryRepository
    {

        private readonly FlagExplorerContext _context;

        public CountryRepository(FlagExplorerContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllCountries(CancellationToken cancellationToken = default)
        {
            return await _context.Countries.ToListAsync(cancellationToken);
        }

        public async Task<Country> GetCountryByName(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Countries.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
        }
    }
}
