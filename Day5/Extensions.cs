using System;

namespace Day5
{
    public static class Extensions
    {
        public static bool IsDiagonal(this (Point A, Point B) pointPair)
        {
            return pointPair.A.X != pointPair.B.X && pointPair.A.Y != pointPair.B.Y;
        }
        
        public static bool IsHorizontalLine(this (Point A, Point B) pointPair)
        {
            return pointPair.A.X != pointPair.B.X && pointPair.A.Y == pointPair.B.Y;
        }
        
        public static bool IsVerticalLine(this (Point A, Point B) pointPair)
        {
            return pointPair.A.Y != pointPair.B.Y && pointPair.A.X == pointPair.B.X;
        }

        public static int GetMinX(this (Point A, Point B) pointPair)
        {
            return Math.Min(pointPair.A.X, pointPair.B.X);
        }
        
        public static int GetMinY(this (Point A, Point B) pointPair)
        {
            return Math.Min(pointPair.A.Y, pointPair.B.Y);
        }
    }
}