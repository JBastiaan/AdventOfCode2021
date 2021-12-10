using System;
using System.Collections.Generic;
using System.Linq;
using Day10;

var lines = System.IO.File.ReadLines("input.txt");

var illegal = new List<char>();
foreach (var line in lines)
{
    var openingCharacters = new List<char>();
    
    foreach (var @char in line)
    {
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
    }
    
    openingCharacters.Clear();
}

var scorePart1 = illegal.Select(c => c.GetScore()).Sum();

Console.WriteLine($"Score for part 1: {scorePart1}");