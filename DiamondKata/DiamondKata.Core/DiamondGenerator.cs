namespace DiamondKata.Core;

public class DiamondGenerator
{
    public string Generate(char input)
    {
        EnsureValidLetter(input);

        var rows = BuildRows(input);

        return string.Join(Environment.NewLine, rows);
    }

    private static IEnumerable<string> BuildRows(char input)
    {
        var letters = GetLetters(input);

        foreach (var letter in letters)
        {
            yield return BuildRow(input, letter);
        }
    }

    private static string BuildRow(char targetLetter, char currentLetter)
    {
        var rowWidth = (targetLetter - 'A') * 2 + 1;
        var padding = targetLetter - currentLetter;

        var diamondRow = Enumerable.Repeat(' ', rowWidth).ToArray();
        diamondRow[padding] = currentLetter;
        diamondRow[rowWidth - padding - 1] = currentLetter;

        return new string(diamondRow);
    }

    private static IEnumerable<char> GetLetters(char targetLetter)
    {
        for (var ch = 'A'; ch < targetLetter; ch++)
            yield return ch;

        for (var ch = targetLetter; ch >= 'A'; ch--)
            yield return ch;
    }

    private static void EnsureValidLetter(char input)
    {
        var isUppercaseLetter = input is >= 'A' and <= 'Z';

        if (!isUppercaseLetter)
        {
            throw new ArgumentOutOfRangeException(nameof(input), "Input must be a single uppercase letter (A-Z).");
        }
    }
}