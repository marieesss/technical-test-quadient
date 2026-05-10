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
        return choices
            .Select(choice => new
            {
                Value = choice,
                Score = GetBestDifferenceScore(term, choice),
                LengthDifference = choice.Length - term.Length
            })
            .Where(item => item.Score.HasValue)
            // Sort by:
            // Best similarity score
            // Closest length
            // Alphabetical order   
            .OrderBy(item => item.Score)
            .ThenBy(item => item.LengthDifference)
            .ThenBy(item => item.Value)
            .Take(numberOfSuggestions)
            .Select(item => item.Value);

    }


    private int? GetBestDifferenceScore(string term, string choice)
    {
        // Ignore words shorter than the searched term
        if (choice.Length < term.Length)
        {
            return null;
        }

        // Keep the best score found for the word
        int bestScore = int.MaxValue;

        // Extract a substring with the same size as the searched term and compare them
        for (int i = 0; i <= choice.Length - term.Length; i++)
        {
            string substring = choice.Substring(i, term.Length);

            // Calculate the difference score and keep the best one
            int score = GetDifferenceScore(term, substring);

            if (score < bestScore)
            {
                bestScore = score;
            }
        }

        return bestScore;
    }

    private int GetDifferenceScore(string dest, string src)
    {
        int score = 0;

        // Compare each character and count the number of differences
        for (int i = 0; i < dest.Length; i++)
        {
            if (dest[i] != src[i])
            {
                score++;
            }
        }

        return score;
    }
}