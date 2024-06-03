using WordsToNLP;

public class Program
{
    public static void Main(string[] args)
    {
        // Ensure you have your text file with book content
        var textFilePath = "book.txt"; // Path to your book or text file
        var outputFilePath = "training_data.txt"; // Path to save the training data

        if (!File.Exists(textFilePath))
        {
            Console.WriteLine($"The file {textFilePath} does not exist.");
            return;
        }

        var text = File.ReadAllText(textFilePath);
        var generator = new TrainingDataGenerator();
        var trainingData = generator.GenerateTrainingData(text);

        generator.SaveTrainingData(trainingData, outputFilePath);

        Console.WriteLine($"Training data has been saved to {outputFilePath}");
    }
}