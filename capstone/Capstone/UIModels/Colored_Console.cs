using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppUI
{
    public static  class Colored_Console
    {
        public static void PrintLine(string _string, ConsoleColor _color)
        {
            ConsoleColor CurrentColor = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.WriteLine(_string);
            Console.ForegroundColor = CurrentColor;
        }
        public static void Print(string _string, ConsoleColor _color)
        {
            ConsoleColor CurrentColor = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.Write(_string);
            Console.ForegroundColor = CurrentColor;
        }
        public static void PrintLine(string _string, ConsoleColor _color, int _top, int _left)
        {
            ConsoleColor CurrentColor = Console.ForegroundColor;
            Console.CursorTop = _top;
            Console.CursorLeft = _left;
            Console.ForegroundColor = _color;
            Console.WriteLine(_string);
            Console.ForegroundColor = CurrentColor;
        }
        public static void Print(string _string, ConsoleColor _color, int _top, int _left)
        {
            ConsoleColor CurrentColor = Console.ForegroundColor;
            Console.CursorTop = _top;
            Console.CursorLeft = _left;
            Console.ForegroundColor = _color;
            Console.Write(_string);
            Console.ForegroundColor = CurrentColor;
        }
        /// <summary>
        ///  Print a specific letter in a string in a different color with no newLine at the end
        /// </summary>
        /// <param name="_string">The string to print</param>
        /// <param name="_color">The Color  </param>
        /// <param name="_index">The index of the string to be printed in given color </param>
        public static void PrintColoredList(string _string, ConsoleColor _color, int _index)
        {
            ConsoleColor CurrentColor = Console.ForegroundColor;
            for (int i = 0; i < _string.Length; i++)
            {
                if (i == _index)
                {
                    Print(_string[i].ToString(), _color);
                    continue;
                }
                Print(_string[i].ToString(), CurrentColor);
            }
        }

        public static void PrintCenter(string[] _str)
        {
            int[] height = Heights(_str.Length);
            for (int i = 0; i < _str.Length; i++)
            {
            Console.SetCursorPosition((Console.WindowWidth - _str[i].Length) / 2, (Console.WindowHeight / 2) + height[i]);
                Console.WriteLine(_str[i]);
            }
        }
        /// <summary>
        /// Print  ONE colores line in the center screen 
        /// </summary>
        /// <param name="_str"></param>
        /// <param name="_color"></param>
        public static void PrintCenter(string _str,ConsoleColor _color)
        {
            Console.SetCursorPosition((Console.WindowWidth - _str.Length) / 2, Console.WindowHeight / 2);
            PrintLine(_str,_color);
        }
        private static int[] Heights (int _number)
        {
            int[] Heights = new int[_number];
            int start = _number / 2 * (-1);
            for (int i = 0; i < _number; i++)
            {
                Heights[i] = start + i;
            }
            return Heights;
        }

        public static void PrintColoredList(string _string, ConsoleColor _color, int[]  _indexes)
        {
            ConsoleColor CurrentColor = Console.ForegroundColor;
          
            for (int i = 0; i < _string.Length; i++)
            {
                if (Array.IndexOf(_indexes,i) != -1)
                {
                    Print(_string[i].ToString(), _color);
                    continue;
                }
                Print(_string[i].ToString(), CurrentColor);
            }
        }

    }
}
