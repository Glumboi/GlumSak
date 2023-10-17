namespace GlumSak3AV.Networking;

public struct Entry
{
    private string[] _values = new string[] { };

    public string[] Values
    {
        get => _values;
        private set => _values = value;
    }

    private string[] _types = new string[] { };

    public string[] Types
    {
        get => _types;
        private set => _types = value;
    }


    private string _identifier = String.Empty;

    public Entry(string identifier, string[] types, string[] values)
    {
        Values = values;
        Types = types;
        _identifier = $"[{identifier}]";
    }

    public string GetIdentifier()
    {
        return _identifier.Replace("[", "").Replace("]", "");
    }

    public string GetValueOfType(string type)
    {
        for (var index = 0; index < _types.Length; index++)
        {
            if (_types[index] == type)
            {
                return _values[index];
            }
        }

        throw new DatabaseException(
            "Could not find a Value matching the given Type. Are you reading from a valid paste?");
    }

    public string GetTypeOfValue(string value)
    {
        for (var index = 0; index < _types.Length; index++)
        {
            if (_values[index] == value)
            {
                return _types[index];
            }
        }

        throw new DatabaseException(
            "Could not find a Type matching the given Value. Are you reading from a valid paste?");
    }

    public string GetEntryInOneLine()
    {
        string result;
        string createdString = "Identifier: " + GetIdentifier() + " | ";

        if (_values == null) return string.Empty;

        for (var index = 0; index < _values.Length; index++)
        {
            createdString += _types[index] + ": " + _values[index] + ", ";
        }

        result = createdString;
        return result;
    }
}

public static class EntryExtras
{
    public static bool HasType(this Entry entry, string type)
    {
        foreach (var entryType in entry.Types)
        {
            if (entryType == type) return true;
        }

        return false;
    }

    public static bool HasValue(this Entry entry, string value)
    {
        foreach (var entryValue in entry.Values)
        {
            if (entryValue == value) return true;
        }

        return false;
    }
}