namespace DiamondKata.Core;

public class DiamondGenerator
{
    public string Generate(char targetLetter)
    {
        EnsureValidLetter(targetLetter);

        var diamondLines = BuildLines(targetLetter);

        return string.Join(Environment.NewLine, diamondLines);
    }

    private static IEnumerable<string> BuildLines(char targetLetter)
    {
        var letters = GetDiamondCharacterSequence(targetLetter);

        foreach (var letter in letters)
        {
            yield return BuildLine(targetLetter, letter);
        }
    }

    private static string BuildLine(char targetLetter, char currentLetter)
    {
        var rowWidth = (targetLetter - 'A') * 2 + 1;
        var padding = targetLetter - currentLetter;

        var diamondRow = Enumerable.Repeat(' ', rowWidth).ToArray();
        diamondRow[padding] = currentLetter;
        diamondRow[rowWidth - padding - 1] = currentLetter;

        return new string(diamondRow);
    }

    private static IEnumerable<char> GetDiamondCharacterSequence(char targetLetter)
    {
        for (var ch = 'A'; ch < targetLetter; ch++)
            yield return ch;

        for (var ch = targetLetter; ch >= 'A'; ch--)
            yield return ch;
    }

    private static void EnsureValidLetter(char targetLetter)
    {
        var isUppercaseLetter = targetLetter is >= 'A' and <= 'Z';

        if (!isUppercaseLetter)
        {
            throw new ArgumentOutOfRangeException(nameof(targetLetter), "Input must be a single uppercase letter (A-Z).");
        }
    }
}