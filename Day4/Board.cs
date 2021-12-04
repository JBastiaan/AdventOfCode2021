using System.Collections.Generic;

namespace Day4
{
    public class Board
    {
        public bool IsBingo { get; set; } = false;

        public (int Number, bool Marked)[,] Numbers { get; init; } = new (int Number, bool Marked)[5,5];
    }
}