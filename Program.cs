using Quadient;

ISuggestionService suggestionService = new SuggestionService();


// Validate arguments
if (args.Length < 3)
{
    Console.WriteLine("How to run:");
    Console.WriteLine("dotnet run <term> <numberOfSuggestions> <choice1> <choice2> <choice3> ...");
    Console.WriteLine();
    Console.WriteLine("Example:");
    Console.WriteLine("dotnet run gros 2 gros gras graisse go ros gro");
    return;
}

// Get the term to compare
string term = args[0];

// Get the number of suggestions to return
if (!int.TryParse(args[1], out int numberOfSuggestions))
{
    Console.WriteLine("The number of suggestions must be a valid number.");
    return;
}

// Retrieve list of choices
List<string> choices = args
    .Skip(2)
    .ToList();

IEnumerable<string> suggestions = suggestionService.GetSuggestions(
    term,
    choices,
    numberOfSuggestions
);

Console.WriteLine("Suggestions trouvées :");
Console.WriteLine(string.Join(", ", suggestions));