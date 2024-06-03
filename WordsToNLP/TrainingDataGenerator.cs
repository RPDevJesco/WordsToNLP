namespace WordsToNLP;

public class TrainingDataGenerator
{
    public List<(string word, string tag)> GenerateTrainingData(string text)
    {
        var processor = new TextProcessor();
        var sentences = text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        var trainingData = new List<(string word, string tag)>();

        foreach (var sentence in sentences)
        {
            trainingData.AddRange(processor.ProcessSentence(sentence.Trim()));
        }

        return trainingData;
    }

    public void SaveTrainingData(List<(string word, string tag)> trainingData, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var (word, tag) in trainingData)
            {
                writer.WriteLine($"{word}\t{tag}");
            }
        }
    }
}