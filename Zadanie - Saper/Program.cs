

using System;
using System.Collections.Generic;
using System.Linq;


namespace Saperinka
{
    class Saper
    {
        static void Main(string[] args)
        {


            // Wczytaj wymiary planszy
            string input = Console.ReadLine();
            int[] size = Array.ConvertAll<string, int>(input.Split(" "), int.Parse);

            int rows = size[0];
            int columns = size[1];




            // Stwórz planszę z kropek
            var board = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }


            // Dla każdej komórki oblicz liczbę przylegających min
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (board[i][j] != '*')
                    {
                        int count = CounterOfMines(board, i, j);
                        board[i][j] = count > 0 ? count.ToString()[0] : '.';
                    }
                }
            }


            //Efekt
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(board[i]);
            }



        }



        static int CounterOfMines(char[][] board, int row, int column)
        {
            int count = 0;
            int[][] offsets =
            {
                new[] { -1, -1 },
                new[] { -1, 0 },
                new[] { -1, 1 },
                new[] { 0, -1 },
                new[] { 0, 1 },
                new[] { 1, -1 },
                new[] { 1, 0 },
                new[] { 1, 1 }
            };


            foreach (var offset in offsets)
            {
                int r = row + offset[0];
                int c = column + offset[1];
                if (r >= 0 && r < board.Length && c >= 0 && c < board[0].Length && board[r][c] == '*')
                {
                    count++;
                }
            }

            return count;


        }

    }
}
