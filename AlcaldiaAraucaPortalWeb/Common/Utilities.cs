using System.Text.RegularExpressions;

namespace AlcaldiaAraucaPortalWeb.Common
{
    public class Utilities
    {
        public static string StartCharacterToUpper(string str)
        {
            string x = str.Substring(0, 1);

            x = x.ToUpper();

            str = x + str.Substring(1, str.Length - 1);

            return str;
        }

        public static string ConvertToTextInLik(string cadena)
        {
            //            pattern = @"(http:\/\/([\w.]+\/?)\S*)";
            //string pattern = @"(https?://[^\s]+)";
            //Regex re = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //cadena = re.Replace(cadena, "<a href=\"$1\" target=\"_blank\">ver mas</a>");
            //return cadena;

            var urlregex = new Regex(@"\b\({0,1}(?<url>(www|ftp)\.[^ ,""\s<)]*)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Finds URLs with a protocol
            var httpurlregex = new Regex(@"\b\({0,1}(?<url>[^>](http://www\.|http://|https://|ftp://)[^,""\s<)]*)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Finds email addresses
            var emailregex = new Regex(@"\b(?<mail>[a-zA-Z_0-9.-]+\@[a-zA-Z_0-9.-]+\.\w+)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);


            cadena = urlregex.Replace(cadena, " <a href=\"${url}\" target=\"_blank\">ver aqui</a>");
            cadena = httpurlregex.Replace(cadena, " <a href=\"${url}\" target=\"_blank\">ver aqui</a>");
            cadena = emailregex.Replace(cadena, "<a href=\"mailto:${mail}\">ver aqui</a>");

            return cadena;
        }

    }
}
