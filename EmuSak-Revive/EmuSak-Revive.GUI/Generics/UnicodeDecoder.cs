using System.Globalization;
using System.Text.RegularExpressions;

namespace EmuSak_Revive.GUI.Generics
{
    public static class UnicodeDecoder
    {
        private static Regex _regex = new Regex(@"\\u(?<Value>[a-zA-Z0-9]{4})", RegexOptions.Compiled);

        public static string Decoder(string value)
        {
            return _regex.Replace(
                value,
                m => ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString()
            );
        }
    }
}