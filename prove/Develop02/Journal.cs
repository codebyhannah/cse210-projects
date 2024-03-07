using System;

public class Journal
{
    // --- Attributes ---
    public List<Entry> _entries;
    public string _filename;

    // --- Behaviors ---
    public void CreateEntry()
    {
        Entry entry = new Entry();

        entry.DisplayRandomPrompt();
        entry.Update();

        _entries.Add(entry);
    }
    public void DisplayJournal()
    {

    }
    public string[] ReadFile()
    {
        string[] yo = {"yo","yo"};
        return yo;
    }
    public void SaveFile()
    {

    }
}