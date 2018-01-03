using System;
using Sprache;

namespace UgValidator
{
    public static class PhoneNumber
    {
        private static readonly Parser<string> PhoneNumberParser =
            (from zero in Sprache.Parse.Char('0').Once().Text()
            from restOfDigits in Sprache.Parse.Digit.Repeat(9).Text()
            select "256" + restOfDigits).Token().End();

        public static string Parse(string phoneNumber)
        {
            var parseResult = PhoneNumberParser.TryParse(phoneNumber);
            if (!parseResult.WasSuccessful)
            {
                throw new FormatException($"The value {phoneNumber} cannot be parsed as a phone number.");
            }

            return parseResult.Value;
        }

        public static void TryParse(string phoneNumber, out string result)
        {
            var parseResult = PhoneNumberParser.TryParse(phoneNumber);
            result = parseResult.WasSuccessful ? parseResult.Value : null;
        }
    }
}