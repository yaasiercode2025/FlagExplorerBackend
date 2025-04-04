using FlagExplorer.Application.DTO;

namespace FlagExplorer.Application.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryDetailsDto>> GetAllCountries(CancellationToken cancellationToken = default);
        Task<CountryDetailsDto> SearchByName(CountryDTO country, CancellationToken cancellationToken = default);
    }
}
