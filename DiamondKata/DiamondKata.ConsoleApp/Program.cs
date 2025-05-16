using DiamondKata.Core;

if (args.Length == 0 || args[0].Length > 1)
{
    Console.WriteLine("Argument must be a single uppercase targetLetter!");
    return;
}

var letter = args[0].First();

var diamond = new DiamondGenerator().Generate(letter);

// This transformation is only for display purposes to help visualize whitespace more clearly.
// It is not part of the core diamond generation logic.
var diamondWithUnderscore = diamond.Replace(" ", "_");
var lines = diamondWithUnderscore.Split(Environment.NewLine);
var spacedLines = lines.Select(line => string.Join(" ", line.ToCharArray()));
var spacedDiamond = string.Join(Environment.NewLine, spacedLines);

Console.WriteLine(spacedDiamond);
