namespace WordsToNLP;

public class TextProcessor
{
    private Dictionary<string, string> posDictionary;

    public TextProcessor()
    {
        posDictionary = new Dictionary<string, string>();
        LoadWordLists();
    }

    private void LoadWordLists()
    {
        // Load your word lists into the dictionary
        foreach (var word in File.ReadAllLines("nouns.txt"))
        {
            posDictionary[word] = "Noun";
        }
        foreach (var word in File.ReadAllLines("verbs.txt"))
        {
            posDictionary[word] = "Verb";
        }
        foreach (var word in File.ReadAllLines("adjectives.txt"))
        {
            posDictionary[word] = "Adjective";
        }
        foreach (var word in File.ReadAllLines("prepositions.txt"))
        {
            posDictionary[word] = "Preposition";
        }
        foreach (var word in File.ReadAllLines("determiners.txt"))
        {
            posDictionary[word] = "Determiner";
        }
        foreach (var word in File.ReadAllLines("conjunctions.txt"))
        {
            posDictionary[word] = "Conjunction";
        }
    }

    public List<(string word, string tag)> ProcessSentence(string sentence)
    {
        var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var taggedSentence = new List<(string word, string tag)>();

        foreach (var word in words)
        {
            var cleanedWord = word.Trim(new char[] { '.', ',', ';', '!', '?' }).ToLower();
            if (posDictionary.ContainsKey(cleanedWord))
            {
                taggedSentence.Add((word, posDictionary[cleanedWord]));
            }
        }

        return taggedSentence;
    }
}