using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sudoku sudoku = new Sudoku("619030040270061008000047621486302079000014580031009060005720806320106057160400030");            
            //Sudoku sudoku = new Sudoku("000030040270061008000047621486302000000014580031009060005720806320106057160400030");
            //Sudoku sudoku = new Sudoku("000000000700020006800631004050200930080703040076005080100369008900050003030002700");
            Sudoku sudoku = new Sudoku("000050003050000010721600000510062800063000720008430065000006952030000080800040000");
            sudoku.Solve();
        }
    }
}
