using AutoMapper;
using FlagExplorer.Application.DTO;
using FlagExplorer.Application.Interfaces;
using FlagExplorer.Application.Validators;
using FlagExplorer.Domain.Entities;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace FlagExplorer.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<List<CountryDetailsDto>> GetAllCountries(CancellationToken cancellationToken = default)
        {
            var list = await _countryRepository.GetAllCountries(cancellationToken);
            return _mapper.Map<List<CountryDetailsDto>>(list);
        }

        public async Task<CountryDetailsDto> SearchByName(CountryDTO country, CancellationToken cancellationToken = default)
        {   
            var countryDetails = await _countryRepository.GetCountryByName(country.Name, cancellationToken);
            return _mapper.Map<CountryDetailsDto>(countryDetails);
        }
    }
}
