using System.Text.RegularExpressions;

namespace Ninico.Helpers
{
    public static class FormatHelper
    {
        // Format the phone number from 0922002360 to 092.2002.360
        public static string FormatPhoneNumber(string phoneNumber)
        {
            if(phoneNumber is null)
            {
                return string.Empty;
            }

            string cleanedPhoneNumber = Regex.Replace(phoneNumber, @"[^\d]", "");

            if (cleanedPhoneNumber.Length != 10)
            {
                return phoneNumber;
            }

            string formattedPhoneNumber = $"{cleanedPhoneNumber.Substring(0, 3)}.{cleanedPhoneNumber.Substring(3, 4)}.{cleanedPhoneNumber.Substring(7, 3)}";

            return formattedPhoneNumber;
        }
    }
}
