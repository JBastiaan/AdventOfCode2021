using System;
using System.Collections.Generic;
using System.Linq;
using Day10;

var lines = System.IO.File.ReadLines("input.txt");

var illegal = new List<char>();
var incomplete = new List<string>();
foreach (var line in lines)
{
    var openingCharacters = new List<char>();
    for (int i = 0; i < line.Length; i++)
    {
        var @char = line[i];
        
        if (@char.IsOpeningCharacter())
            openingCharacters.Add(@char);

        if (@char.IsClosingCharacter())
        {
            var opening = @char.GetOpeningCharacter();
            if (openingCharacters.Last() == opening)
            {
                openingCharacters.RemoveAt(openingCharacters.Count - 1);
            }
            else
            {
                illegal.Add(@char);
                break;
            }
        }

        if (i == line.Length - 1 && openingCharacters.Any())
            incomplete.Add(openingCharacters.GetClosingCharacters());
    }
    
    openingCharacters.Clear();
}

var scorePart1 = illegal.Select(c => c.GetIllegalScore()).Sum();

var incompleteCount = incomplete.Count;
var scorePart2 = incomplete
    .Select(s => s
        .Select(c => c.GetIncompleteScore())
            .Aggregate((a, b) => a * 5 + b))
    .OrderByDescending(i => i)
    .ToList()[incompleteCount / 2];

Console.WriteLine($"Score for part 1: {scorePart1}");
Console.WriteLine($"Score for part 2: {scorePart2}");