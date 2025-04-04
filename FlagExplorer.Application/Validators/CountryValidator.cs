using FlagExplorer.Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagExplorer.Application.Validators
{
    public class CountryValidator : AbstractValidator<CountryDTO>
    {
        public CountryValidator()
        {
            RuleFor(country => country.Name)
             .NotEmpty().WithMessage("Country name cannot be an empty string.")
             .Length(5, 50).WithMessage("Country name is invalid");
        }
    }
}
