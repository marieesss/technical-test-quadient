using Quadient;

ISuggestionService suggestionService = new SuggestionService();

List<string> choices =
[
    "gros",
    "gras",
    "graisse",
    "go",
    "ros",
    "gro"
];

IEnumerable<string> suggestions = suggestionService.GetSuggestions(
    "gros",
    choices,
    2
);

Console.WriteLine("Suggestions trouvées :");
Console.WriteLine(string.Join(", ", suggestions));