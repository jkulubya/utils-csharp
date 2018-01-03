using System;
using Sprache;
using UgValidator;
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
        public void ParseSimplePhoneNumber(string value)
        {
            var number = PhoneNumber.Parse(value);
            
            Assert.Equal("256700192133", number);
        }
        
        [Theory]
        [InlineData("  0700192133")]
        [InlineData("0700192133  ")]
        [InlineData("  0700192133  ")]
        [InlineData("0700192133")]
        public void TryParseSimplePhoneNumber(string value)
        {
            PhoneNumber.TryParse(value, out var number);
            
            Assert.Equal("256700192133", number);
        }

        [Theory]
        [InlineData("  070022233345675767")]
        [InlineData("070022233345675767  ")]
        [InlineData("  070022233345675767  ")]
        [InlineData("070022233345675767")]
        public void ThrowWhenNumberIsTooLong(string value)
        {
            Assert.Throws<FormatException>(() => PhoneNumber.Parse(value));
        }
        
        [Theory]
        [InlineData("  070022233345675767")]
        [InlineData("070022233345675767  ")]
        [InlineData("  070022233345675767  ")]
        [InlineData("070022233345675767")]
        public void ReturnNullWhenNumberIsTooLong(string value)
        {
            PhoneNumber.TryParse(value, out var number);
            
            Assert.Null(number);
        }
    }
}