using System;
using System.IO;

public class Document
{
    // --- Attributes ---
    private string _filename;
    private string _splitter = "<~@~>";
    private string _emptyLine = "<~!~>"; // A symbol showing where an empty line is meant to be displayed
    private List<List<string>> _contents = new List<List<string>>();
    private List<List<string>> _transcript = new List<List<string>>();

    // --- Constructors ---
    public Document(string filename)
    {
        _filename = filename;
    }
    public Document(string filename, string splitter, string emptyLine)
    {
        _filename = filename;
        _splitter = splitter;
        _emptyLine = emptyLine;
    }

    // Getters and Setters
    public List<List<string>> GetContents()
    {
        return _contents;
    }

    // --- Methods ---
    public void ReadFile()
    {
        string[] lines = System.IO.File.ReadAllLines(_filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(_splitter);
            List<string> itemContents = new List<string>();
            foreach(string l in parts)
            {
                if (l == _emptyLine)
                {
                    itemContents.Add("");
                }
                else if (l == "")
                {
                    //skip
                }
                else
                {
                    itemContents.Add(l);
                }
            }
            _contents.Add(itemContents);
        }        
    }
    public void SaveFile()
    {
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            foreach (List<string> item in _transcript)
            {
                string oneLine = "";
                foreach (string line in item)
                {
                    if (line == "")
                    {
                        oneLine += $"{_emptyLine}{_splitter}";
                    }
                    else
                    {
                        oneLine += $"{line}{_splitter}";
                    }
                } 
                outputFile.WriteLine(oneLine);
            }
        }
    }
}