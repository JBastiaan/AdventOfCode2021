using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public static class Helpers
    {
        public static List<(int Number, bool Marked)[,]> GetBoards(string[] input)
        {
            var result = new List<(int Number, bool Marked)[,]>();
            var board = new (int Number, bool Marked)[5,5];

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
                    board[rowcount, j] = (numberRow[j], false);
                }

                if (rowcount == 4)
                {
                    result.Add(board);
                    board = new (int Number, bool Marked)[5, 5];
                    rowcount = 0;
                }
                else
                {
                    rowcount++;
                }
            }

            return result;
        }

        public static bool IsBingo((int Number, bool Marked)[,] board)
        {
            return IsRowBingo(board) || IsColumnBingo(board);
        }

        public static int GetScore((int Number, bool Marked)[,] board, int number)
        {
            var sumUnMarked = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (!board[i, j].Marked)
                    {
                        sumUnMarked += board[i, j].Number;
                    }
                }
            }

            return sumUnMarked * number;
        }

        private static bool IsRowBingo((int Number, bool Marked)[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                var rowElements = Enumerable.Range(0, board.GetLength(0))
                    .Select(x => board[i, x])
                    .ToArray();

                if (rowElements.All(r => r.Marked))
                    return true;
            }

            return false;
        }
        
        private static bool IsColumnBingo((int Number, bool Marked)[,] board)
        {
            for (int i = 0; i < board.GetLength(1); i++)
            {
                var columnElements = Enumerable.Range(0, board.GetLength(1))
                    .Select(x => board[x, i])
                    .ToArray();

                if (columnElements.All(r => r.Marked))
                    return true;
            }

            return false;
        }
    }
}