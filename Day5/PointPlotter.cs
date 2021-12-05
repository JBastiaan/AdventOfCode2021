using System;
using System.Collections.Generic;

namespace Day5
{
    public class PointPlotter
    {
        private readonly int[,] _board = new int[1000, 1000];

        public void PlotPoints(List<(Point A, Point B)> pointPairs, bool plotDiagonal = false)
        {
            foreach (var pointPair in pointPairs)
            {
                if (pointPair.IsDiagonal() )
                {
                    if (!plotDiagonal)
                        continue;

                    if (pointPair.Is45DegreeDiagonal())
                    {
                        for (int i = 0; i <= Math.Abs(pointPair.A.X - pointPair.B.X); i++)
                        {
                            _board[
                                pointPair.A.X < pointPair.B.X ? pointPair.A.X + i : pointPair.A.X - i,
                                pointPair.A.Y < pointPair.B.Y ? pointPair.A.Y + i : pointPair.A.Y - i]++;
                        }
                    }
                    continue;
                }

                if (pointPair.IsHorizontalLine())
                {
                    for (int i = 0; i <= Math.Abs(pointPair.A.X - pointPair.B.X); i++)
                    {
                        _board[pointPair.GetMinX() + i, pointPair.A.Y]++;
                    } 
                    continue;
                }
    
                if (pointPair.IsVerticalLine())
                {
                    for (int i = 0; i <= Math.Abs(pointPair.A.Y - pointPair.B.Y); i++)
                    {
                        _board[pointPair.A.X, pointPair.GetMinY() + i]++;
                    } 
                }
            }
        }

        public int GetOverLapCount()
        {
            var overlapCount = 0;
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j] > 1)
                        overlapCount++;
                }
            }

            return overlapCount;
        }
    }
}