// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

var lines = System.IO.File.ReadLines("input.txt");

var grid = lines
    .Select(line => line
        .Select(c => int.Parse(c.ToString()))
        .ToList())
    .ToList();

var flashCountAt100 = 0;

var stepCount = 0;
var isSynchronized = false;

while (!isSynchronized)
{
    stepCount++;

    for (var i = 0; i < grid.Count; i++)
    {
        for (var j = 0; j < grid[i].Count; j++)
        {
            var initialValue = grid[i][j];
            grid[i][j]++;

            if (initialValue == 9)
                Flash(grid, new Coordinate(i, j));
        }
    }

    var roundFlashCount = 0;
    foreach (var line in grid)
    {
        for (var j = 0; j < line.Count; j++)
        {
            if (line[j] > 9)
            {
                line[j] = 0;

                if (stepCount < grid.Count * grid.Count + 1)
                    flashCountAt100++;

                roundFlashCount++;
            }
            line[j] = line[j] > 9 ? 0 : line[j];
        }
    }

    if (roundFlashCount == grid.Count * grid.Count)
        isSynchronized = true;
}

Console.WriteLine($"Result part 1: {flashCountAt100}");
Console.WriteLine($"Result part 2: {stepCount}");

void Flash(List<List<int>> grid, Coordinate c)
{
    var adjacents = GetAdjacentCoordinates(c, grid.Count);

    foreach (var adjacent in adjacents)
    {
        var initialValue = grid[adjacent.I1][adjacent.I2];
        grid[adjacent.I1][adjacent.I2]++;

        if (initialValue == 9)
            Flash(grid, adjacent);
    }
}

List<Coordinate> GetAdjacentCoordinates(Coordinate c, int gridSize)
{
    var (i1, i2) = c;
    var adjacent = new List<Coordinate>()
    {
        new(i1 - 1, i2 - 1),
        new(i1, i2 - 1),
        new(i1 + 1, i2 - 1),
        new(i1 - 1, i2),
        new(i1 + 1, i2),
        new(i1 + 1, i2 + 1),
        new(i1, i2 + 1),
        new(i1 - 1, i2 + 1),
    };

    return adjacent
        .Where(coord => coord.I1 >= 0 && coord.I1 < gridSize && coord.I2 >= 0 && coord.I2 < gridSize)
        .ToList();
}

record Coordinate(int I1, int I2);