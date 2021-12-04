// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using Day4;

string[] lines = System.IO.File.ReadAllLines("input.txt");

var numbers = lines.First()
    .Split(',')
    .Select(Int32.Parse);

var boards = Helpers.GetBoards(lines.Skip(2).ToArray());

Console.WriteLine("First bingo score: " + new Bingo().FindFirstBingoScore(boards, numbers));
Console.WriteLine("Last bingo score: " + new Bingo().FindLastBingoScore(boards, numbers));

