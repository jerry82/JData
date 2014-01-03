using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JDataStructure.Problems;

namespace UnitTestDataStructure
{
    [TestClass]
    public class UnitTest_Sudoku
    {
        string _inputfile = @"text/sudoku.data";
        int[,] _grid = new int[9, 9];
        int SIZE = 9;

        [TestInitialize]
        public void InitGrid()
        {
            string tmp = String.Empty;
            int row = 0;
            using (StreamReader sr = new StreamReader(_inputfile, System.Text.Encoding.ASCII))
            {
                while ((tmp = sr.ReadLine()) != null)
                {
                    string[] lines = tmp.Split(' ');
                    for (int i = 0; i < lines.Length; i++)
                    {
                        _grid[row, i] = Convert.ToInt16(lines[i]);
                    }
                    row++;
                }
            }
        }

        [TestMethod]
        public void TestSudoku()
        {
            Sudoku sk = new Sudoku();
            int[,] result = sk.Solve(_grid);
            Assert.AreEqual(true, CheckResult(result));
        }

        private bool CheckResult(int[,] result)
        {
            //check horizontal
            for (int row = 0; row < SIZE; row++)
            {
                List<int> tmp = GetList();
                for (int col = 0; col < SIZE; col++)
                {
                    if (tmp.Contains(result[row, col]))
                        tmp.Remove(result[row, col]);
                    else
                        return false;
                }
            }

            //check vertical 
            for (int col = 0; col < SIZE; col++)
            {
                List<int> tmp = GetList();
                for (int row = 0; row < SIZE; row++)
                {
                    if (tmp.Contains(result[row, col]))
                        tmp.Remove(result[row, col]);
                    else
                        return false;
                }
            }

            return true; ;
        }

        private List<int> GetList()
        {
            List<int> l = new List<int>();
            for (int i = 1; i <= SIZE; i++)
                l.Add(i);

            return l;
        }
    }
}
