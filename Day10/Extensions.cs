using System;
using System.Linq;

namespace Day10
{
    public static class Extensions
    {
        private static readonly char[] OpeningCharacters = {'(', '{', '[', '<'};

        private static readonly char[] ClosingCharacters = {')', '}', ']', '>'};
        
        public static bool IsOpeningCharacter(this char @char)
        {
            return OpeningCharacters.Contains(@char);
        }
        
        public static bool IsClosingCharacter(this char @char)
        {
            return ClosingCharacters.Contains(@char);
        }

        public static char GetOpeningCharacter(this char closingCharacter)
        {
            return closingCharacter switch
            {
                ')' => '(',
                '}' => '{',
                ']' => '[',
                '>' => '<',
                _ => throw new Exception("Unknown closingCharacter")
            };
        }

        public static int GetScore(this char closingCharacter)
        {
            return closingCharacter switch
            {
                ')' => 3,
                '}' => 1197,
                ']' => 57,
                '>' => 25137,
                _ => throw new Exception("Unknown closingCharacter")
            };
        }
    }
}