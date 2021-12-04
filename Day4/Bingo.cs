using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Bingo
    {
        public int FindFirstBingoScore(List<Board> boards, IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    for (int i = 0; i < board.Numbers.GetLength(0); i++)
                    {
                        bool isFound = false;
                        for (int j = 0; j < board.Numbers.GetLength(1); j++)
                        {
                            if (board.Numbers[i, j].Number == number)
                            {
                                board.Numbers[i, j].Marked = true;
                                isFound = true;
                                break;
                            }
                        }

                        if (isFound)
                            break;
                    }

                    if (Helpers.IsBingo(board))
                        return Helpers.GetScore(board, number);
                }
            }

            return 0;
        }

        public int FindLastBingoScore(List<Board> boards, IEnumerable<int> numbers)
        {
            var neededBingoCount = boards.Count();

            var actualBingoCount = 0;
            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    if (board.IsBingo)
                        continue;

                    for (int i = 0; i < board.Numbers.GetLength(0); i++)
                    {
                        bool isFound = false;
                        for (int j = 0; j < board.Numbers.GetLength(1); j++)
                        {
                            if (board.Numbers[i, j].Number == number)
                            {
                                board.Numbers[i, j].Marked = true;
                                isFound = true;
                                break;
                            }
                        }

                        if (isFound)
                            break;
                    }

                    if (Helpers.IsBingo(board))
                    {
                        board.IsBingo = true;
                        actualBingoCount++;

                        if (actualBingoCount == neededBingoCount)
                        {
                            return Helpers.GetScore(board, number);
                        }
                    }
                        
                }
            }

            return 0;
        }
    }
}