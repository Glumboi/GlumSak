namespace GlumSak3AV.Networking
{
    public class EntryCreator
    {
        public static Entry CreateEntry(string line)
        {
            ReadOnlySpan<char> span = line.AsSpan();
            int bracketStart = span.IndexOf('[');
            int bracketEnd = span.IndexOf(']');
            string identifier = bracketStart == -1 ? "NOT DEFINED" : span.Slice(bracketStart + 1, bracketEnd - bracketStart - 1).ToString();

            List<string> types = new List<string>();
            List<string> values = new List<string>();

            span = span.Slice(bracketEnd + 1);
            while (span.Length > 0)
            {
                int colonPos = span.IndexOf(':');
                if (colonPos == -1)
                    break;

                string type = span.Slice(0, colonPos).Trim().ToString();
                types.Add(type);

                span = span.Slice(colonPos + 1);
                int commaPos = span.IndexOf(',');
                string value;
                if (commaPos == -1)
                {
                    value = span.Trim().ToString();
                    span = ReadOnlySpan<char>.Empty;
                }
                else
                {
                    value = span.Slice(0, commaPos).Trim().ToString();
                    span = span.Slice(commaPos + 1);
                }
                values.Add(value);
            }

            return new Entry(identifier, types.ToArray(), values.ToArray());
        }
    }
}