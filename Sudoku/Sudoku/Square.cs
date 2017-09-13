using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Square
    {
        public int SquareValue { get; set; }
        public Square(int number)
        {
            SquareValue = number;
        } 
    }
}
