using System.Globalization;
using System.Text.RegularExpressions;

namespace ExampleProject.Framework.Utils
{
    internal class StringUtils
    {
        private const string CurrencyRegex = "[^\\d.]";

        public static double GetDoubleFromString(string value)
        {
            
            string sanitizedValue = Regex.Replace(value, CurrencyRegex, "");

            
            return double.TryParse(sanitizedValue, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double result)
                ? result
                : 0.0;
        }
    }
}
