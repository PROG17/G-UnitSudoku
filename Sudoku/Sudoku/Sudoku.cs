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
            board = new Board(numbers);     // Skapa upp sudokubräde.

        }
        
        public void Solve()
        {
            bool somethingChanged = true;   // Variabel som håller koll på om solvern fortafarande kan göra någongting. 
            while (somethingChanged)
            {
                somethingChanged = false;

                // Testa logik per rad.
                if (CheckRows()) somethingChanged = true;
                // Testa logik per kolumn
                if (CheckColumns()) somethingChanged = true;
                // Testa logik per "Box"
                if (CheckBoxes()) somethingChanged = true;

            }
            //Skriver ut lösta eller olösta brädet
            board.PrintBoard();
        }

        private bool CheckRows()
        {
            bool somethingChanged = false;

            // Lopar igen alla rader.
            for (int row = 0; row < 9; row++)
            {
                List<int> numbers = board.GetNumbersInRow(row);
                for (int column = 0; column < 9; column++)
                {
                    // Om raden har fått mera information så har något ändrats.
                    if (board.SendNumbersToSquare(row, column, numbers))
                    {
                        somethingChanged = true;
                    }
                }
            }

            return somethingChanged;
        }

        private bool CheckColumns() //Går igenom alla kolumner
        {
            bool somethingChanged = false;
            for (int column = 0; column < 9; column++)
            {
                List<int> numbers = board.GetNumbersInColumn(column);
                for (int row = 0; row < 9; row++)
                {
                    //om kolumnen redan fått mera information så har något ändrats
                    if (board.SendNumbersToSquare(row, column, numbers))
                    {
                        somethingChanged = true;
                    }
                }
            }

            return somethingChanged;
        }
        
        private bool CheckBoxes() //Går igenom alla "Boxar"
        {
            bool somethingChanged = false;

            for (int boxRow = 0; boxRow < 3; boxRow++) //går igenom boxrad 0-2
            {
                for (int boxColumn = 0; boxColumn < 3; boxColumn++) //går igenom boxKolumn 0-2
                {
                    List<int> numbers = board.GetNumbersInBox(boxRow, boxColumn); //Hämtar alla nummer i specifik box

                    for (int row = boxRow * 3; row < 3 * (boxRow + 1); row++) //Går igenom rader i boxen (bestäms av (boxRow + (modifier))
                    {
                        for (int column = boxColumn * 3; column < 3 * (boxColumn + 1); column++) //Går igenom kolumner i boxen
                        {
                            //send information till ruta och ses om något ändras
                            if (board.SendNumbersToSquare(row, column, numbers)) 
                            {
                                somethingChanged = true;
                            }
                        }
                    }
                }
            }

            return somethingChanged;
        }
    
    }   
}   
