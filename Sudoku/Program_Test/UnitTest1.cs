using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace Program_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NakedSingles()
        {
            Sudoku.Sudoku sudoku = new Sudoku.Sudoku("305420810487901506029056374850793041613208957074065280241309065508670192096512408");
            sudoku.Solve();

            string expectedResult = "365427819487931526129856374852793641613248957974165283241389765538674192796512438";

            Assert.AreEqual(expectedResult, sudoku.GetSudokuAsString());
        }

        [TestMethod]
        public void HidenSingles()
        {
            Sudoku.Sudoku sudoku = new Sudoku.Sudoku("002030008000008000031020000060050270010000050204060031000080605000000013005310400");
            sudoku.Solve();

            string expectedResult = "672435198549178362831629547368951274917243856254867931193784625486592713725316489";

            Assert.AreEqual(expectedResult, sudoku.GetSudokuAsString());
        }

        [TestMethod]
        public void UnsolvableBox()
        {
            Sudoku.Sudoku sudoku = new Sudoku.Sudoku("090300001000080046000000800405060030003275600060010904001000000580020000200007060");
            sudoku.Solve();
            
            Assert.IsFalse(sudoku.IsSolved());
        }

    }
}
