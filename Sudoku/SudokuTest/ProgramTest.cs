﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace SudokuTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void TestNakedSingles()
        {
            Sudoku sudoku = new Sudoku("305420810487901506029056374850793041613208957074065280241309065508670192096512408");

        }
    }
}
