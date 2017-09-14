using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Suduko
    {
        Board board;

        public Suduko(string numbers)
        {
            board = new Board(numbers);

        }
        public void Solved()
        {
            bool somethingChanged = true;
            while (somethingChanged)
            {
                somethingChanged = false;

                for (int row = 0; row < 9; row++)
                {
                    List<int> numbers = board.GetNumbersInRow(row);
                    for (int column = 0; column < 9; column++)
                    {
                        //om något ändrats kör loopen igen
                        if (board.SendNumbersToSquare(row, column, numbers))
                        {
                            somethingChanged = true;
                        }
                    }
                }
                
                for (int column = 0; column < 9; column++)
                {
                    List<int> numbers = board.GetNumbersInColumn(column);
                    for (int row = 0; row < 9; row++)
                    {
                        //om något ändrats kör loopen igen
                        if (board.SendNumbersToSquare(row, column, numbers))
                        {
                            somethingChanged = true;
                        }
                    }
                }
                for (int row = 0; row < 3; row++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        List<int> numbers = board.GetNumberInBox(row, column);
                        for (int i = 0; i < 9; i++)
                        {
                            int r = row/3;
                            int c = column % 3;
                            if (board.SendNumbersToSquare(r, c, numbers))
                            {
                                somethingChanged = true;
                            }
                        }

                    }
                }
            }

            board.PrintBoard();
        }
    }   
}   
