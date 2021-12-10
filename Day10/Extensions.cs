using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
        public static char GetClosingCharacter(this char closingCharacter)
        {
            return closingCharacter switch
            {
                '(' => ')',
                '{' => '}',
                '[' => ']',
                '<' => '>',
                _ => throw new Exception("Unknown closingCharacter")
            };
        }

        public static string GetClosingCharacters(this List<char> openingCharacters)
        {
            var result = new StringBuilder();
            for (var i = openingCharacters.Count - 1; i >= 0; i--)
            {
                result.Append(openingCharacters[i].GetClosingCharacter());
            }

            return result.ToString();
        }

        public static int GetIllegalScore(this char closingCharacter)
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

        public static long GetIncompleteScore(this char closingCharacter)
        {
            return closingCharacter switch
            {
                ')' => 1,
                '}' => 3,
                ']' => 2,
                '>' => 4,
                _ => throw new Exception("Unknown closingCharacter")
            };
        }
    }
}