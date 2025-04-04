using FlagExplorer.Domain.Entities;

namespace FlagExplorer.Application.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries(CancellationToken cancellationToken = default);
        Task<Country> GetCountryByName(string name, CancellationToken cancellationToken = default);
    }
}