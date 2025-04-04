using FlagExplorer.Application.DTO;
using FlagExplorer.Application.Validators;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagExplorer.Testing.UnitTests
{
    public class ValidationTest
    {
        private CountryValidator _validator;

        public ValidationTest()
        {
            _validator = new CountryValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Null_Or_Empty()
        {
            // Arrange
            var country = new CountryDTO { Name = string.Empty };

            // Act
            var result = _validator.TestValidate(country);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Name).WithErrorMessage("Country name cannot be an empty string.");
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Less_Then_Five_Chars()
        {
            // Arrange
            var country = new CountryDTO { Name = "sou" };

            // Act
            var result = _validator.TestValidate(country);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Name).WithErrorMessage("Country name is invalid");
        }
    }
}
