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
            QuickSort sorter = new QuickSort();
            int[] arr = new int[] { 7, 2, 1, 6, 8, 5, 3, 4 };
            int[] sortedArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            sorter.Sort(arr);
            CollectionAssert.AreEqual(sortedArr, arr);
        }

        [TestMethod]
        public void TestMergeSortAsc()
        {
            MergeSort sorter = new MergeSort();
            int[] arr = new int[] { 5, 5, 3, 2, 7, 1 };
            int[] sortedArr = new int[] { 1, 2, 3, 5, 5, 7 };
            sorter.Sort(arr);
            CollectionAssert.AreEqual(sortedArr, arr);
        }
    }
}
