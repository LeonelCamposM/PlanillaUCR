using Xunit;
using FluentAssertions;
using Domain.ValueObjects;

namespace Tests.Domain
{
    public class InputValidatorTest
    {
        InputValidator inputValidator = new InputValidator();

        [Fact]
        public void SqlInjection()
        {
            //act
            bool result = inputValidator.ValidateStringSafety("prueba' or 1=1 --");

            //assert
            result.Should().Be(false);
        }

        [Fact]
        public void HiddenQuery()
        {
            //act
            bool result = inputValidator.ValidateStringSafety("Prueba01!' Drop Table Payment--");

            //assert
            result.Should().Be(false);
        }

        [Fact]
        public void HiddenUpdateQuery()
        {
            //act
            bool result = inputValidator.ValidateStringSafety("Prueba01!' Update Table Payment--");

            //assert
            result.Should().Be(false);
        }

        [Fact]
        public void cleanString()
        {
            //act
            bool result = inputValidator.ValidateStringSafety("Prueba01!");

            //assert
            result.Should().Be(true);
        }

        [Fact]
        public void bigString()
        {
            // arrange
            string stringBig = string.Empty;
            for(int i = 0; i < 300; i++)
            {
                stringBig += "prueba";
            }

            //act
            bool result = inputValidator.ValidateStringSafety(stringBig);

            //assert
            result.Should().Be(false);
        }
    }
}
