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
        public Square(int number)
        {
            SquareValue = number;
            if (SquareValue == 0)
            {
                for (int i = 0; i < canBeNumber.Length; i++)
                {
                    canBeNumber[i] = true;
                }
            }
            else
                IsSolved = true;
        }

        //ta bort möjliga nummber från ruta
        public bool RemovePossibleNum(List<int> numbers)
        {
            bool someThingChanged = false;
            foreach (var number in numbers)
            {
                if(canBeNumber[number-1] == true)
                {
                    canBeNumber[number - 1] = false;
                    someThingChanged = true;
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

            if(value != 0)
            {
                SquareValue = value;
                IsSolved = true;
            }

            return true;
        }
    }
}
