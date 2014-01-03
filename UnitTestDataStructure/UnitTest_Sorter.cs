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
        public void TestBubbleSort()
        {
            BubbleSort sorter = new BubbleSort();
            List<int> arr = new List<int>() { 4, 5, 3, 1, 2 };
            
            List<int> sortedArr = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> sortedArrDesc = new List<int>() { 5, 4, 3, 2, 1 };

            sorter.Ascend(arr);
            CollectionAssert.AreEqual(sortedArr, arr);

            sorter.Descend(arr);
            CollectionAssert.AreEqual(sortedArrDesc, arr);
        }

        [TestMethod]
        public void TestQuickSortAsc()
        {
            QuickSort sorter = new QuickSort();           
            List<int> arr = new List<int>() { 5, 5, 3, 2, 1 };
            List<int> sortedArr = new List<int>() { 1, 2, 3, 5, 5 };

            sorter.Ascend(arr);
            CollectionAssert.AreEqual(sortedArr, arr);
        }
    }
}
