

using System;
using System.Linq;


namespace ZadanieSudoku
{
    class Sudoku
    {
        static void Main()
        {
            
            int[,] finalSudoku = CreateSudokuArray();
            bool effect = CheckIfCorrect(finalSudoku);

            if (effect)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            


        }




        //Tworzy tablicę Sudoku na podstawie wprowadzonych danych i zwraca ją jako tablice wielowymiarową
        static int[,] CreateSudokuArray()
        {

            int arraySize = 9;
            int[,] sudoku = new int[arraySize, arraySize];


            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                string inputLoop = Console.ReadLine();
                int[] rowArray = Array.ConvertAll<string, int>(inputLoop.Split(" "), int.Parse);

                for (int j = 0; j < rowArray.Length; j++)
                {
                    sudoku[i, j] = rowArray[j];
                }

            }

            return sudoku;
        }


        static bool CheckIfCorrect(int[,] finalSudoku)
        {

         
            //Sprawdznie po wierszach
            for (int i = 0; i < finalSudoku.GetLength(0); i++)
            {
                bool[] usedNumbers = new bool[9];
                for (int j = 0; j < finalSudoku.GetLength(1); j++)
                {
                    int number = finalSudoku[i, j] - 1;
                    if (usedNumbers[number])
                    {
                        return false;
                    }
                    usedNumbers[number] = true;
                }
                
            }


            //Sprawdzanie po kolumnach
            for ( int i = 0; i < finalSudoku.GetLength(1); i++)
            {

                bool[] usedNumbers = new bool[9];
                for (int j = 0; j < finalSudoku.GetLength(0); j++)
                {
                    int number = finalSudoku[j, i] - 1;
                    if (usedNumbers[number])
                    {
                        return false;
                    }
                    usedNumbers[number] = true;
                }
                
              
            }


            //Sprawdzenie w kwadratach

            int[][,] sudokuPieces = new int[9][,];

            for (int i = 0; i < 9;i++)
            {
                sudokuPieces[i] = new int[3, 3];
                for (int j = 0; j < 3;j++)
                {
                    for (int k = 0; k < 3; k++) 
                    {
                        sudokuPieces[i][j, k] = finalSudoku[j + (i / 3) * 3, k + (i % 3) * 3];
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                bool[] usedNumbers = new bool[9];
                for (int j = 0; j < 3;j++)
                {
                    for (int k = 0; k < 3;k++)
                    {
                        int number = sudokuPieces[i][j, k] - 1;
                        if (usedNumbers[number])
                        {
                            return false;
                        }
                        usedNumbers[number] = true;
                    }
                }
            }

            return true;


            
        }










    }
}