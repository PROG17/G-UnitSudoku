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

            //om sudoku brädet inte är löst starta bruteforce
            if (board.IsSolved() != true)
            {
                Console.WriteLine("Ingen logisk lösning kunde hittas. Startar bruteforce.");
                BruteForce(0); //starta på ruta noll, går igenom alla möjliga lösningar tills en lösning hittats
                board.PrintBoard();
            }

            if (board.IsSolved() == false)
            {
                Console.WriteLine("Det finns ingen lösning till denna bräda.");
            }

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

        private bool BruteForce(int currentSquare) //Testar alla möjliga lösningar
        {

            int row = currentSquare / 9; //vilken rad nuvarande ruta är på
            int column = currentSquare % 9; //vilken column nuvarande ruta är på
            bool isSolved = false; //blir true om en lösning hittats

            //om den nuvarande rutan redan har ett bekräftat korrekt nummer
            if (board.IsSquareSolved(row, column))
            {
                /*om det inte är sista rutan, bruteforce på nästa ruta i soduku 
                 * annars testa om en lösning hittats*/
                if (currentSquare < 80)
                {
                    isSolved = BruteForce(currentSquare + 1);
                }
                else
                {
                    isSolved = board.IsSolved();
                }
            }
            else //om nuvarande ruta inte har ett bekräftat korrekt nummer
            {
                for (int i = 1; i <= 9; i++) //lopa igenom alla möjliga nummer
                {

                    /*om raden, columnen och boxen inte innehåller nummer i,
                    testa att sätta rutan till nuvarande nummer*/
                    if (board.GetNumbersInRow(row).Contains(i) == false &&
                        board.GetNumbersInColumn(column).Contains(i) == false &&
                        board.GetNumbersInBox(row / 3, column / 3).Contains(i) == false)
                    {
                        board.SetSquareToNum(row, column, i);
                        if (currentSquare < 80)
                        {
                            isSolved = BruteForce(currentSquare + 1);
                        }
                        else
                        {
                            isSolved = board.IsSolved();
                        }
                    }

                    //om lösning hittats retunera true till förgående ruta (eller till platsen som anropade metoden)
                    if (isSolved)
                        return isSolved;
                }
            }

            //om vi inte hittat en lösning och rutan inte är bekräftat korrect, nollställ ruta
            if (isSolved == false && board.IsSquareSolved(row, column) == false)
                board.SetSquareToNum(row, column, 0);

            return isSolved;
        }
        
        //för att testa programmet
        public string GetSudokuAsString()
        {
            return board.GetBoard();
        }
    }
}
