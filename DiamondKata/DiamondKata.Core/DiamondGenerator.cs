namespace DiamondKata.Core;

public class DiamondGenerator
{
    public void Generate(char input)
    {
        EnsureValidLetter(input);
    }

    private static void EnsureValidLetter(char input)
    {
        var isUppercaseLetter = input is >= 'A' and <= 'Z';

        if (!isUppercaseLetter)
        {
            throw new ArgumentOutOfRangeException(nameof(input), $"Input must be a single uppercase letter (A-Z).");
        }
    }
}