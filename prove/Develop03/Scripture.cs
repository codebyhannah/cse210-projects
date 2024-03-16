using System;

class Scripture
{
    // --- Attributes ---
    private Reference _reference;
    private List<List<Word>> _scriptureText = new List<List<Word>>();
    private string _fileName;

    // --- Constructors ---
    public Scripture() // default
    {
        _reference = new Reference("Doctrine and Covenants", 6, 36);
        //_reference = new Reference("Doctrine and Covenants", 6, 33, 35);
        string text = "36 Look unto me in every thought; doubt not, fear not.";
        //string text = "33 Fear not to do good, my sons, for whatsoever ye sow, that shall ye also reap; therefore, if ye sow good ye shall also reap good for your reward. 34 Therefore, fear not, little flock; do good; let earth and hell combine against you, for if ye are built upon my rock, they cannot prevail. 35 Behold, I do not condemn you; go your ways and sin no more; perform with soberness the work which I have commanded you.";
        GetWordsFromText(text);
    }
    public Scripture(string fileName)
    {
        if (fileName == "")
        {
            Console.Write("Enter filename to open scripture from: ");
            _fileName = Console.ReadLine();
            Console.WriteLine();
        }
        else
        {
            _fileName = fileName;
        }
        OpenFile();
    }
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        GetWordsFromText(text);
    }

    // --- Methods ---
    public void GetWordsFromText(string text)
    {
        List<Word> verse = new List<Word>();
        string[] words = text.Split(" ");
        foreach (string w in words)
        {
            Word word;
            word = new Word(w);
            if(int.TryParse(w, out int n))
            {
                word.Hide();
                if (verse.Count != 0)
                {
                   _scriptureText.Add(verse);
                }
                verse = new List<Word>();
            }
            verse.Add(word);
        }
        _scriptureText.Add(verse);
    }
    public void DisplayScripture()
    {
        _reference.DisplayReference();
        Console.WriteLine();
        foreach (List<Word> v in _scriptureText)
        {
            foreach(Word w in v)
            {
                w.DisplayWord();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
    public void HideRandomWords(int numToHide)
    {
        for (int i = 0; i < numToHide; i++)
        {
            List<Word> all = new List<Word>();
            foreach (List<Word> v in _scriptureText)
            {
                all.AddRange(v);
            }
            Word selection;
            do
            {
                Random randomGenerator = new Random();
                int randomNum = randomGenerator.Next(1, all.Count);
                selection = all[randomNum];
            }while(selection.IsHidden());
            selection.Hide();
        }
    }
    public void Memorize()
    {
        string userInput;
        bool quit = false;
        do
        {
            // This console clearing thing is required to fix that one issue where C# doesn't like to clear the entire console. 
            Console.Clear(); Console.WriteLine("\x1b[3J"); Console.Clear();
            Console.WriteLine("~*~ Scripture Memorizer ~*~");
            Console.WriteLine("Press Enter to continue, or type 'quit' to quit.");
            Console.WriteLine();
            DisplayScripture();
            userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                quit = true;
            }
            else if (AllHidden())
            {
                Console.WriteLine("All Hidden!");
                Console.WriteLine();
                quit = true;
            }
            else
            {
                HideRandomWords(1);
            }
        }while(!quit);
    }
    public void OpenFile()
    {
        // Exceeds requirements by allowing the user to load a scripture from a file.
        Document scripture =  new Document(_fileName);
        scripture.ReadFile();
        string text = "";
        foreach (List<string> item in scripture.GetContents())
        {
            foreach (string line in item)
            {
                if (line.Contains("<~REF~>"))
                {
                    string book = "";
                    int chapter = 0;
                    int verse = 0;
                    int endVerse = 0;
                    string newLine = line.Replace("<~REF~>", "");
                    string[] partsArray = newLine.Split("<~#~>");
                    List<string> parts = new List<string>();
                    foreach (string p in partsArray)
                    {
                        char[] pchar = p.ToCharArray();
                        if (p.Count() == 1 && !char.IsLetterOrDigit(pchar[0]))
                        {
                            // skip
                        }
                        else
                        {
                            parts.Add(p);
                            if (parts.IndexOf(p) == 0)
                            {
                                book = p;
                            }
                            else if (parts.IndexOf(p) == 1)
                            {
                                chapter = int.Parse(p);
                            }
                            else if (parts.IndexOf(p) == 2)
                            {
                                verse = int.Parse(p);
                            }
                            else if (parts.IndexOf(p) == 3)
                            {
                                endVerse = int.Parse(p);
                            }
                            else
                            {
                                // do nothing
                            }
                        }
                    }
                    _reference = new Reference(book, chapter, verse, endVerse);
                }
                else
                {
                    text += line;
                    text += " ";
                }      
            }
        }
        GetWordsFromText(text);
    }
    private bool AllHidden()
    {
        bool isAllHidden = true;
        foreach (List<Word> v in _scriptureText)
        {
            foreach(Word w in v)
            {
                if(!w.IsHidden())
                {
                    isAllHidden = false;
                }
            }
        }
        return isAllHidden;
    }
}

