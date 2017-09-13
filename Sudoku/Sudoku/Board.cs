using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Board
    {
        private const int height = 9;
        private const int width = 9;

        Square[,] squares = new Square[height,width];

        public Board(string inputNumbers)
        {
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    int index = column + row * 9;
                    int number = int.Parse( inputNumbers[index].ToString() );

                    Square square = new Square(number);
                    squares[row, column] = square;
                }
            }
        }
    }
}
