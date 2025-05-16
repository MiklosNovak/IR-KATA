namespace DiamondKata.Core;

public class DiamondGenerator
{
    public string Generate(char input)
    {
        EnsureValidLetter(input);

        var letters = GetLetters(input).ToArray();

        return string.Join(Environment.NewLine, letters);
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