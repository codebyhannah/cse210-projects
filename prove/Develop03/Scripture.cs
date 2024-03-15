using System;
using System.Security.Cryptography;

class Scripture
{
    // --- Attributes ---
    private Reference _reference;
    private List<List<Word>> _scriptureText = new List<List<Word>>();
    private string _fileName;

    // --- Constructors ---
    public Scripture() // default
    {
        //_reference = new Reference("Doctrine and Covenants", 6, 36);
        _reference = new Reference("Doctrine and Covenants", 6, 33, 35);
        //string text = "36 Look unto me in every thought; doubt not, fear not.";
        string text = "33 Fear not to do good, my sons, for whatsoever ye sow, that shall ye also reap; therefore, if ye sow good ye shall also reap good for your reward. 34 Therefore, fear not, little flock; do good; let earth and hell combine against you, for if ye are built upon my rock, they cannot prevail. 35 Behold, I do not condemn you; go your ways and sin no more; perform with soberness the work which I have commanded you.";

        GetWordsFromText(text);
        DisplayScripture(1);
    }
    public Scripture(string fileName)
    {

    }
    public Scripture(Reference reference, string text)
    {

    }

    // --- Getters and Setters ---

    // --- Methods ---

    public void GetWordsFromText(string text)
    {
        List<Word> verse = new List<Word>();

        string[] words = text.Split(" ");

        foreach (string w in words)
        {
            Word word;
            if(int.TryParse(w, out int n))
            {
                if (verse.Count != 0)
                {
                   _scriptureText.Add(verse);
                }
                verse = new List<Word>();
            }
            word = new Word(w);
            verse.Add(word);
        }
        _scriptureText.Add(verse);
    }
    public void DisplayScripture(int numToHide)
    {
        _reference.DisplayReference();
        Console.WriteLine();
        foreach(List<Word> v in _scriptureText)
        {
            foreach(Word w in v)
            {
                w.DisplayWord();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
    private void HideRandomWords(int numToHide)
    {

    }
    private void OpenFile()
    {
       // _fileName
    }
    private bool AllHidden() // may or may not use
    {
        return false;
    }

}

