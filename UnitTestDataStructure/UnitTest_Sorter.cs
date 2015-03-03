using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using JDataStructure.Sort;

namespace UnitTestDataStructure
{
    [TestClass]
    public class UnitTest_Sorter
    {
        [TestMethod]
        public void TestQuickSortAsc()
        {
            QSort sorter = new QSort();
            //List<int> arr = new List<int>() { 5, 1 };
            //List<int> sortedArr = new List<int>() { 1, 5 };
            List<int> arr = new List<int>() { 7, 2, 1, 6, 8, 5, 3, 4 };
            List<int> sortedArr = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

            sorter.Ascend(arr);
            CollectionAssert.AreEqual(sortedArr, arr);
        }

        [TestMethod]
        public void TestMergeSortAsc()
        {
            MergeSort sorter = new MergeSort();
            List<int> arr = new List<int>() { 5, 5, 3, 2, 7, 1 };
            List<int> sortedArr = new List<int>() { 1, 2, 3, 5, 5, 7 };

            sorter.Ascend(arr);
            CollectionAssert.AreEqual(sortedArr, arr);
        }
    }
}
