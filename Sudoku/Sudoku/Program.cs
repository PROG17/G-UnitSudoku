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
            Suduko suduko = new Suduko("619030040270061008000047621486302079000014580031009060005720806320106057160400030");            
            //Suduko suduko = new Suduko("000030040270061008000047621486302000000014580031009060005720806320106057160400030");
            //Suduko suduko = new Suduko("004500090700020006800631004050200930080703040076005080100369008900050003030002700");
            suduko.Solved();
        }
    }
}
