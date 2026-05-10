namespace Quadient;

public interface ISuggestionService
{
    IEnumerable<string> GetSuggestions(
        string term,
        IEnumerable<string> choices,
        int numberOfSuggestions
    );
}


public class SuggestionService : ISuggestionService
{
    public IEnumerable<string> GetSuggestions(
        string term,
        IEnumerable<string> choices,
        int numberOfSuggestions
    )
    {
        return [];
    }
}