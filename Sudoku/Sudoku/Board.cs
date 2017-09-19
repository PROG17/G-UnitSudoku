using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Board
    {
        private const int height = 9;
        private const int width = 9;

        Square[,] squares = new Square[height, width];

        public Board(string inputNumbers)
        {
            //Fyller alla brädceller med squares(rutor) och nummer
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    int index = column + row * width;
                    int number = int.Parse(inputNumbers[index].ToString());
                    Square square = new Square(number);
                    squares[row, column] = square;
                }
            }
        }

        //Metod som printar hela sudokubrädet till konsolen
        public void PrintBoard()
        {
            for (int row = 0; row < height; row++)
            {
                if (row % 3 == 0)
                {
                    Console.WriteLine("-------------------------");
                }

                Console.Write("| ");
                for (int column = 0; column < width; column++)
                {
                    int squareNumber = squares[row, column].SquareValue;

                    if (squareNumber != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(squareNumber + " ");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    if (column % 3 == 2)
                    {
                        Console.Write("| ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("-------------------------");
        }

        // Hittar alla befintliga nummer i box
        public List<int> GetNumbersInBox(int boxRow, int boxColumn)
        {
            var numberList = new List<int>();
            for (int column = 3 * boxColumn; column < 3 * (boxColumn + 1); column++)
            {
                for (int row = 3 * boxRow; row < 3 * (boxRow + 1); row++)
                {
                    if (squares[row, column].SquareValue != 0)
                    {
                        numberList.Add(squares[row, column].SquareValue); // Lägger till befintliga nummer i lista av upptagna nummer
                    }
                }
            }

            return numberList;
        }

        //Hittar alla befintliga nummer i rad
        public List<int> GetNumbersInRow(int row)
        {
            var numberList = new List<int>();
            for (int column = 0; column < width; column++)
            {
                if (squares[row, column].SquareValue != 0)
                {
                    numberList.Add(squares[row, column].SquareValue); // Lägger till befintliga nummer i lista av upptagna nummer
                }

            }
            return numberList;
        }

        //Hittar alla befintliga nummer i kolumn
        public List<int> GetNumbersInColumn(int column)
        {
            var numberList = new List<int>();
            for (int row = 0; row < width; row++)
            {
                if (squares[row, column].SquareValue != 0)
                {
                    numberList.Add(squares[row, column].SquareValue); // Lägger till befintliga nummer i lista av upptagna nummer
                }

            }
            return numberList;
        }

        //skicka nummer som inte kan finnas i rutan
        public bool SendNumbersToSquare(int row, int column, List<int> numbers)
        {
            if (squares[row, column].IsSolved == false)
                return squares[row, column].RemovePossibleNum(numbers);

            return false;
        }
        
        //kollar om hela spelbrädet är löst
        public bool IsSolved()
        {
            //kollar om nummer 1-9 finns i varje rad, retunerar false om det inte stämmer
            for (int row = 0; row < height; row++)
            {
                List<int> rowNumbers = GetNumbersInRow(row);
                if (rowNumbers.Count != 9) return false;
                rowNumbers.Sort();
                for (int i = 0; i < width; i++)
                {
                    if (rowNumbers[i] != i + 1)
                    {
                        return false;
                    }
                }
            }

            //kollar om nummer 1-9 finns i varje column, retunerar false om det inte stämmer
            for (int column = 0; column < width; column++)
            {
                List<int> columnNumbers = GetNumbersInColumn(column);
                if (columnNumbers.Count != 9) return false;
                columnNumbers.Sort();
                for (int i = 0; i < height; i++)
                {
                    if (columnNumbers[i] != i + 1)
                    {
                        return false;
                    }
                }
            }

            //kollar om nummer 1-9 finns i varje box, retunerar false om det inte stämmer
            for (int boxRow = 0; boxRow < 3; boxRow++)
            {
                for (int boxColumn = 0; boxColumn < 3; boxColumn++)
                {
                    List<int> boxNumbers = GetNumbersInBox(boxRow, boxColumn);
                    if (boxNumbers.Count != 9) return false;
                    boxNumbers.Sort();
                    for (int i = 0; i < 9; i++)
                    {
                        if (boxNumbers[i] != i + 1)
                        {
                            return false;
                        }
                    }
                }
            }

            //pusslet har en korrekt lösning
            return true;
        }

        //Sätter en ruta till ett specifikt värde
        public void SetSquareToNum(int row, int column, int value)
        {
            squares[row, column].SquareValue = value;
        }

        //Kollar om en ruta redan är löst
        public bool IsSquareSolved(int row, int column)
        {
            return squares[row, column].IsSolved;
        }
    }
}
