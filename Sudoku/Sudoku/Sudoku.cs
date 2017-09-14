using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Sudoku
    {
        Board board;

        public Sudoku(string numbers)
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
                
                
                for (int boxRow = 0; boxRow < 3; boxRow++)
                {
                    for (int boxColumn = 0; boxColumn < 3; boxColumn++)
                    {
                        List<int> numbers = board.GetNumberInBox(boxRow, boxColumn);

                        for (int row = boxRow * 3; row < 3 * (boxRow + 1); row++)
                        {
                            for (int column = boxColumn * 3; column < 3 * (boxColumn + 1); column++)
                            {

                                if (board.SendNumbersToSquare(row, column, numbers))
                                {
                                    somethingChanged = true;
                                }
                            }
                        }
                    }
                }
            }

            board.PrintBoard();
        }
    }   
}   
