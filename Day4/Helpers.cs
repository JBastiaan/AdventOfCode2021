using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public static class Helpers
    {
        public static List<Board> GetBoards(string[] input)
        {
            var result = new List<Board>();
            var numbers = new (int Number, bool Marked)[5,5];

            int rowcount = 0;
            for (int i = 0; i < input.Count(); i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                    continue;
        
                var numberRow = input[i]
                    .Split()
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(Int32.Parse)
                    .ToArray();

                for (int j = 0; j < numberRow.Length; j++)
                {
                    numbers[rowcount, j] = (numberRow[j], false);
                }

                if (rowcount == 4)
                {
                    result.Add(new Board() {Numbers = numbers});
                    numbers = new (int Number, bool Marked)[5, 5];
                    rowcount = 0;
                }
                else
                {
                    rowcount++;
                }
            }

            return result;
        }

        public static bool IsBingo(Board board)
        {
            return IsRowBingo(board) || IsColumnBingo(board);
        }

        public static int GetScore(Board board, int number)
        {
            var sumUnMarked = 0;
            for (int i = 0; i < board.Numbers.GetLength(0); i++)
            {
                for (int j = 0; j < board.Numbers.GetLength(1); j++)
                {
                    if (!board.Numbers[i, j].Marked)
                    {
                        sumUnMarked += board.Numbers[i, j].Number;
                    }
                }
            }

            return sumUnMarked * number;
        }

        private static bool IsRowBingo(Board board)
        {
            for (int i = 0; i < board.Numbers.GetLength(0); i++)
            {
                var rowElements = Enumerable.Range(0, board.Numbers.GetLength(0))
                    .Select(x => board.Numbers[i, x])
                    .ToArray();

                if (rowElements.All(r => r.Marked))
                    return true;
            }

            return false;
        }
        
        private static bool IsColumnBingo(Board board)
        {
            for (int i = 0; i < board.Numbers.GetLength(1); i++)
            {
                var columnElements = Enumerable.Range(0, board.Numbers.GetLength(1))
                    .Select(x => board.Numbers[x, i])
                    .ToArray();

                if (columnElements.All(r => r.Marked))
                    return true;
            }

            return false;
        }
    }
}