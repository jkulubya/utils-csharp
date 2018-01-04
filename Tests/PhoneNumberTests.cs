using System;
using System.IO;
using Sprache;
using Uganda;
using Xunit;

namespace Tests
{
    public class PhoneNumberTests
    {
        [Theory]
        [FlatFileData("PhoneNumberTestsData/validnumbers.txt")]
        public void ParseWithValidNumber(string value)
        {
            var number = PhoneNumber.Parse(value);
            
            Assert.Equal("256700192133", number);
        }
        
        [Theory]
        [FlatFileData("PhoneNumberTestsData/validnumbers.txt")]
        public void TryParseWithValidNumber(string value)
        {
            PhoneNumber.TryParse(value, out var number);
            
            Assert.Equal("256700192133", number);
        }

        [Theory]
        [FlatFileData("PhoneNumberTestsData/invalidnumbers.txt")]
        public void ParseShouldThrowWhenNumberIsInvalid(string value)
        {
            Assert.Throws<FormatException>(() => PhoneNumber.Parse(value));
        }
        
        [Theory]
        [FlatFileData("PhoneNumberTestsData/invalidnumbers.txt")]
        public void TryParseShouldReturnNullWhenNumberIsInvalid(string value)
        {
            PhoneNumber.TryParse(value, out var number);
            
            Assert.Null(number);
        }
    }
}