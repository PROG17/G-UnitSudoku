using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Square
    {
        private bool[] canBeNumber = new bool[9];
        public int SquareValue { get; set; }
        public bool IsSolved { get; private set; }

        //Skapar varje ruta
        public Square(int number)
        {
            SquareValue = number;
            if (SquareValue == 0) //om rutan är tom så är alla nummer "möjliga" att stoppas in
            {
                for (int i = 0; i < canBeNumber.Length; i++)
                {
                    canBeNumber[i] = true;
                }
            }
            else // annars är rutan löst
                IsSolved = true;
        }

        //ta bort möjliga nummber från ruta
        public bool RemovePossibleNum(List<int> numbers)
        {
            bool somethingChanged = false;
            foreach (var number in numbers)
            {
                if(canBeNumber[number-1] == true)
                {
                    canBeNumber[number - 1] = false;
                    somethingChanged = true;
                }
            }

            //Testa om rutan hart lösning
            int value = 0;
            for (int i = 0; i < canBeNumber.Length; i++)
            {
                if (canBeNumber[i] == true)
                {
                    if (value == 0)
                    {
                        value = i + 1;
                    }
                    else
                    {
                        value = 0;
                        break;
                    }
                }
            }

            //Om det finns en lösning, ger vi rutan ett värde och sätter rutan som löst
            if(value != 0)
            {
                SquareValue = value;
                IsSolved = true;
            }

            return somethingChanged; //om något har ändrats flaggas det
        }
    }
}
