using System;
using System.Security.Cryptography.X509Certificates;
using Sprache;

namespace Uganda
{
    public static class PhoneNumber
    {
        // 0XXXXXXXXX
        private static readonly Parser<string> SimplePhoneNumberParser =
            (from zero in Sprache.Parse.Char('0').Once().Text()
            from restOfDigits in Sprache.Parse.Digit.Repeat(9).Text()
            select "256" + restOfDigits).Token().End();
        
        // XXXXXXXXX
        private static readonly Parser<string> SimplePhoneNumberWithNoLeadingZeroParser =
            (from digits in Sprache.Parse.Digit.Repeat(9).Text()
            select "256" + digits).Token().End();

        // 256XXXXXXXXX
        private static readonly Parser<string> NumberWithCountryCodeButNoPlusSignParser =
            (from cc in Sprache.Parse.String("256").Text()
            from restOfDigits in Sprache.Parse.Digit.Repeat(9).Text()
            select cc + restOfDigits).Token().End();

        // +256XXXXXXXXX
        private static readonly Parser<string> NumberWithCountryCodeWithPlusSignParser =
            (from plus in Sprache.Parse.Char('+').Once().Text()
            from cc in Sprache.Parse.String("256").Text()
            from restOfDigits in Sprache.Parse.Digit.Repeat(9).Text()
            select cc + restOfDigits).Token().End();
        
            

        public static string Parse(string phoneNumber)
        {
            if (String.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentNullException(nameof(phoneNumber), "The phone number cannot be null");
            }
            
            TryParse(phoneNumber, out var result);
            
            if (result == null)
            {
                throw new FormatException($"The value {phoneNumber} cannot be parsed as a phone number.");
            }
            return result;
        }

        public static void TryParse(string phoneNumber, out string result)
        {
            if (String.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentNullException(nameof(phoneNumber), "The phone number cannot be null");
            }

            result = null;
            
            var parseResult = SimplePhoneNumberWithNoLeadingZeroParser.TryParse(phoneNumber);
            if (parseResult.WasSuccessful)
            {
                result = parseResult.Value;
                return;
            }

            parseResult = SimplePhoneNumberParser.TryParse(phoneNumber);
            if (parseResult.WasSuccessful)
            {
                result = parseResult.Value;
                return;
            }

            parseResult = NumberWithCountryCodeButNoPlusSignParser.TryParse(phoneNumber);
            if (parseResult.WasSuccessful)
            {
                result = parseResult.Value;
                return;
            }

            parseResult = NumberWithCountryCodeWithPlusSignParser.TryParse(phoneNumber);
            if (parseResult.WasSuccessful)
            {
                result = parseResult.Value;
                return;
            }
        }
    }
}