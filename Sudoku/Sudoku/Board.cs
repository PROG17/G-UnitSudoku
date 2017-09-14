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
            //fill all the board positions with squares
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

        //Method that prints the suduko board to the console.
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

        public List<int> GetNumberInBox(int boxRow, int boxColumn)
        {
            var numberList = new List<int>();
            for (int column = 3 * boxColumn; column < 3 * (boxColumn + 1); column++)
            {
                for (int row = 3 * boxRow; row < 3 * (boxRow + 1); row++)
                {
                    if (squares[row, column].SquareValue != 0)
                    {
                        numberList.Add(squares[row, column].SquareValue);
                    }
                }
            }

            return numberList;
        }

        public List<int> GetNumbersInRow(int row)
        {
            var numberList = new List<int>();
            for (int column = 0; column < width; column++)
            {
                if (squares[row, column].SquareValue != 0)
                {
                    numberList.Add(squares[row, column].SquareValue);
                }
                
            }
            return numberList;
        }

        public List<int> GetNumbersInColumn(int column)
        {
            var numberList = new List<int>();
            for (int row = 0; row < width; row++)
            {
                if (squares[row, column].SquareValue != 0)
                {
                    numberList.Add(squares[row, column].SquareValue);
                }

            }
            return numberList;
        }

        //skicka nummer som inte kan finnas i rutan
        public bool SendNumbersToSquare(int row, int column, List<int> numbers)
        {
            if(squares[row,column].IsSolved == false)
                return squares[row, column].RemovePossibleNum(numbers);

            return false;
        }

    }
}
