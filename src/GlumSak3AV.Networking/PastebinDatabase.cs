namespace GlumSak3AV.Networking;

public class PastebinDatabase
{
    private List<Entry> _entries = new List<Entry>();

    public List<Entry> Entries
    {
        set => _entries = value;
        get => _entries;
    }

    private string _databaseName = string.Empty;

    public string DatabaseName
    {
        set => _databaseName = value;
        get => _databaseName;
    }

    public PastebinDatabase(List<Entry> entries, string url, string databaseName = "")
    {
        DatabaseName = databaseName == "" ? $"Database_{StringHelpers.RandomString(6)}" : databaseName;

        if (entries.Count > 0)
            Entries = entries;

        if (!string.IsNullOrEmpty(url))
        {
            foreach (Entry entry in GetEntriesFromPaste(!File.Exists(url)
                         ? WebReader.ReadFromUrl(url).Result
                         : File.ReadAllLines(url)))
            {
                Entries.Add(entry);
            }
        }
        else
        {
            throw new DatabaseException("Cannot define an invalid file URL/Path.");
        }
    }

    public string GetValueOfType(string identifier, string type)
    {
        return GetEntryByIdentifier(identifier).GetValueOfType(type);
    }

    public string GetTypeOfValue(string identifier, string value)
    {
        return GetEntryByIdentifier(identifier).GetTypeOfValue(value);
    }

    public Entry GetEntryByIdentifier(string identifier)
    {
        foreach (var entry in _entries)
        {
            if (entry.GetIdentifier() == identifier) return entry;
        }

        throw new DatabaseException("Could not find the specified Identifier!\nIs the specified Identifier valid?");
    }

    private List<Entry> GetEntriesFromPaste(IEnumerable<string> lines)
    {
        var result = new List<Entry>();

        foreach (var line in lines)
        {
            result.Add(EntryCreator.CreateEntry(line)); //rtrnEntries.Add(EntryCreator.CreateEntry(line));
        }

        return result;
    }

    public void PrintAllEntries()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry.GetEntryInOneLine());
        }
    }

    public void DeInitialize()
    {
        _entries = new List<Entry> { };
        DatabaseName = string.Empty;
    }
}