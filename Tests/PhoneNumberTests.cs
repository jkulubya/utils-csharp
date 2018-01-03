using System;
using Sprache;
using Uganda;
using Xunit;

namespace Tests
{
    public class PhoneNumberTests
    {
        [Theory]
        [InlineData("  0700192133")]
        [InlineData("0700192133  ")]
        [InlineData("  0700192133  ")]
        [InlineData("0700192133")]
        [InlineData("  700192133")]
        [InlineData("700192133  ")]
        [InlineData("  700192133  ")]
        [InlineData("700192133")]
        [InlineData("  256700192133")]
        [InlineData("256700192133  ")]
        [InlineData("  256700192133  ")]
        [InlineData("256700192133")]
        [InlineData("  +256700192133")]
        [InlineData("+256700192133  ")]
        [InlineData("  +256700192133  ")]
        [InlineData("+256700192133")]
        public void ParseWithValidNumber(string value)
        {
            var number = PhoneNumber.Parse(value);
            
            Assert.Equal("256700192133", number);
        }
        
        [Theory]
        [InlineData("  0700192133")]
        [InlineData("0700192133  ")]
        [InlineData("  0700192133  ")]
        [InlineData("0700192133")]
        [InlineData("  700192133")]
        [InlineData("700192133  ")]
        [InlineData("  700192133  ")]
        [InlineData("700192133")]
        [InlineData("  256700192133")]
        [InlineData("256700192133  ")]
        [InlineData("  256700192133  ")]
        [InlineData("256700192133")]
        [InlineData("  +256700192133")]
        [InlineData("+256700192133  ")]
        [InlineData("  +256700192133  ")]
        [InlineData("+256700192133")]
        public void TryParseWithValidNumber(string value)
        {
            PhoneNumber.TryParse(value, out var number);
            
            Assert.Equal("256700192133", number);
        }

        [Theory]
        [InlineData("  070022233345675767")]
        [InlineData("070022233345675767  ")]
        [InlineData("  070022233345675767  ")]
        [InlineData("070022233345675767")]
        [InlineData("  70022233345675767")]
        [InlineData("70022233345675767  ")]
        [InlineData("  70022233345675767  ")]
        [InlineData("70022233345675767")]
        [InlineData("  25670022233345675767")]
        [InlineData("25670022233345675767  ")]
        [InlineData("  25670022233345675767  ")]
        [InlineData("25670022233345675767")]
        [InlineData("  +25670022233345675767")]
        [InlineData("+25670022233345675767  ")]
        [InlineData("  +25670022233345675767  ")]
        [InlineData("+25670022233345675767")]
        public void ParseShouldThrowWhenNumberIsTooLong(string value)
        {
            Assert.Throws<FormatException>(() => PhoneNumber.Parse(value));
        }
        
        [Theory]
        [InlineData("  070022233345675767")]
        [InlineData("070022233345675767  ")]
        [InlineData("  070022233345675767  ")]
        [InlineData("070022233345675767")]
        [InlineData("  70022233345675767")]
        [InlineData("70022233345675767  ")]
        [InlineData("  70022233345675767  ")]
        [InlineData("70022233345675767")]
        [InlineData("  25670022233345675767")]
        [InlineData("25670022233345675767  ")]
        [InlineData("  25670022233345675767  ")]
        [InlineData("25670022233345675767")]
        [InlineData("  +25670022233345675767")]
        [InlineData("+25670022233345675767  ")]
        [InlineData("  +25670022233345675767  ")]
        [InlineData("+25670022233345675767")]
        public void TryParseShouldReturnNullWhenNumberIsTooLong(string value)
        {
            PhoneNumber.TryParse(value, out var number);
            
            Assert.Null(number);
        }
    }
}