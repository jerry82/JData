using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure.Sort {
    
    public abstract class Sorter {
        public void PrintArr(int[] A) {
            foreach (int i in A) {
                Console.Write("  {0}  ", i);
            }
            Console.WriteLine();
        }
    }

    #region quick sort
    /// <summary>
    /// 1. pick pivot (middle value of array)
    /// 2. arrange all elements < pivot to the left and > pivot to the right
    /// 3. partition logic:
    ///    pivot = A[hi]
    ///    pIdx = lo
    ///    for i: lo -> hi - 1
    ///         if A[i] <= pivot:
    ///             swap A[i] with A[pIdx]
    ///             pIdx++
    ///    swap A[hi] with A[pIdx]
    ///    
    /// 4. recursive with left and right array
    /// best | average | worst
    /// nlogn | nlogn | n^2
    /// 
    /// best/average -> normal case when partition index in the middle of the array everytime Partition() runs
    /// worst -> already sort array, partition index just move 1 unit left the hi end.
    /// 
    /// </summary>
    public class QuickSort : Sorter {

        public void Sort(int[] A) {
            Sort(A, 0, A.Length - 1);
        }

        private void Sort(int[] A, int lo, int hi) {
            if (lo >= hi)
                return;

            if (lo + 1 == hi) {
                if (A[lo] > A[hi]) {
                    int tmp = A[lo];
                    A[lo] = A[hi];
                    A[hi] = tmp;
                }
                return;
            }

            int idx = Partition(A, lo, hi);

            PrintArr(A);
            //Console.ReadLine();
            
            Sort(A, 0, idx - 1);
            Sort(A, idx + 1, hi);
        }

        private int Partition(int[]A, int lo, int hi) {
            int pivot = A[hi];
            int pIdx = lo;

            for (int i = lo; i <= hi; i++) {
                if (A[i] < pivot) {
                    //swap with pIdx
                    int tmp = A[pIdx];
                    A[pIdx] = A[i];
                    A[i] = tmp;
                    pIdx++;
                }
            }

            //swap pivot with index
            int tmp2 = A[hi];
            A[hi] = A[pIdx];
            A[pIdx] = tmp2;

            return pIdx;
        }
    }
    #endregion

    #region merge sort
    /// <summary>
    /// get the mid idx and partition the array to left and right
    /// merge left and right (left and right are already sorted array
    /// best | average | worst 
    /// nlogn | nlogn | nlogn
    /// </summary>
    /// 
    public class MergeSort : Sorter{

        public void Sort(int[] A) {
            int[] result = Sort(A, 0, A.Length - 1);
            Array.Copy(result, A, A.Length);
        } 

        private int[] Sort(int[] A, int lo, int hi) {

            List<int> tmpList = new List<int>();
            if (lo == hi) {
                tmpList.Add(A[lo]);
                return tmpList.ToArray();
            }

            if (lo == hi - 1) {
                if (A[lo] > A[hi]) {
                    int tmp = A[lo];
                    A[lo] = A[hi];
                    A[hi] = tmp;
                }
                tmpList.Add(A[lo]);
                tmpList.Add(A[hi]);

                return tmpList.ToArray();
            }

            int mid = lo + (hi - lo) / 2;

            int[] left = Sort(A, lo, mid - 1);
            int[] right = Sort(A, mid, hi);

            int[] merge = Merge(left, right);
            return merge;
        }

        public int[] Merge(int[] a, int[] b) {
            int[] c = new int[a.Length + b.Length];
            int iA = 0, iB = 0, iC = 0;

            while (iA < a.Length && iB < b.Length) {
                if (a[iA] < b[iB]) 
                    c[iC++] = a[iA++];
                else 
                    c[iC++] = b[iB++];
            }

            while (iA >= a.Length && iB < b.Length) 
                c[iC++] = b[iB++];

            while (iA < a.Length && iB >= b.Length) 
                c[iC++] = a[iA++];
            
            return c;
        }
    }

    #endregion
}
