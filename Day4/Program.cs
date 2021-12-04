// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using Day4;

string[] lines = System.IO.File.ReadAllLines("input.txt");

var numbers = lines.First()
    .Split(',')
    .Select(Int32.Parse);

var boards = Helpers.GetBoards(lines.Skip(2).ToArray());

var isBingo = false;
foreach (var number in numbers)
{
    foreach (var board in boards)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            bool isFound = false;
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j].Number == number)
                {
                    board[i, j].Marked = true;
                    isFound = true;
                    break;
                }
            }

            if (isFound)
                break;
        }

        if (Helpers.IsBingo(board))
        {
            isBingo = true;
            Console.WriteLine("Bingo found, score is: " + Helpers.GetScore(board, number));
            break;
        }
    }

    if (isBingo)
        break;
}

Console.WriteLine();

