using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiamondKata.Core.Tests;

[TestClass]
public class DiamondGeneratorTests
{
    private readonly DiamondGenerator _diamondGenerator = new();

    [DataRow('0')]
    [DataRow('?')]
    [DataRow('ó')]
    [TestMethod]
    public void Generate_ShouldThrowException_WhenInputIsNotUppercaseLetter(char input)
    {
        // Act
        var action = () => _diamondGenerator.Generate(input);

        // Assert
        action.Should().Throw<ArgumentOutOfRangeException>().Which.Message.Should()
            .Contain("Input must be a single uppercase letter (A-Z).");
    }

    [TestMethod]
    public void Generate_ShouldReturnSingleA_WhenInputIsA()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = _diamondGenerator.Generate(input);

        // Assert
        result.Should().Be("A");
    }

    [TestMethod]
    public void Generate_ShouldPlaceCharactersInExpectedOrderInEachRow()
    {
        // Arrange
        var input = 'D';

        // Act
        var result = _diamondGenerator.Generate(input);

        // Assert
        var expectedCharacters = new[]
        {
            'A', 'B', 'C', 'D', 'C', 'B', 'A'
        };

        var actualCharacters = result
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.FirstOrDefault(char.IsLetter))
            .ToArray();

        actualCharacters.Should().BeEquivalentTo(expectedCharacters);
    }
}