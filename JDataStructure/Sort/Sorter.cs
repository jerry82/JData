using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure.Sort
{
    public abstract class Sorter
    {
        public abstract void Ascend(List<int> arr);
        public virtual void Descend(List<int> arr)
        {
            int mid = (int)(arr.Count / 2);
            for (int i = 0; i < mid; i++)
            {
                int tmp = arr[i];
                arr[i] = arr[arr.Count - 1 - i];
                arr[arr.Count - 1 - i] = tmp;
            }
        }
    }

    #region bubble sort
    /// <summary>
    /// best | average | worst
    /// n | n^2 | n^2
    /// best when the array is sorted, no swap needed
    /// </summary>
    public class BubbleSort : Sorter
    {
        public override void Ascend(List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr.Count - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }
        }
    }
    #endregion

    #region quick sort
    /// <summary>
    /// best | average | worst
    /// nlogn | nlogn | n^2
    /// </summary>
    public class QuickSort : Sorter
    {
        public override void Ascend(List<int> arr)
        {
            Sort(arr, 0, arr.Count - 1);
        }

        private void Sort(List<int> arr, int start, int end)
        {
            int k = Partition(arr, start, end);
            if (k != -1)
            {
                Sort(arr, start, k - 1);
                Sort(arr, k, end);
            }
        }

        private int Partition(List<int> arr, int start, int end)
        {
            int L = start;
            int R = end;

            int piv = GetPivot(arr, start, end);
            if (piv == -1)
                return -1;

            while (L < R)
            {
                while (arr[L] < piv) L++;
                while (arr[R] >= piv) R--;

                if (L < R)
                {
                    int tmp = arr[L];
                    arr[L] = arr[R];
                    arr[R] = tmp;
                }
            }

            return L;
        }

        private int GetPivot(List<int> arr, int start, int end)
        {
            if (start >= end) 
                return -1;

            if (end - start == 1)
            {
                if (arr[end] == arr[start]) 
                    return -1;
                else 
                    return (arr[start] > arr[end]) ? arr[start] : arr[end];
            }

            int mid = (int)((start + end) / 2);
            return (int)((arr[start] + arr[mid] + arr[end])/3);
        }
    }
    #endregion

    #region merge sort
    /// <summary>
    /// best | average | worst 
    /// nlogn | nlogn | nlogn
    /// </summary>
    public class MergeSort : Sorter
    {
        public override void Ascend(List<int> arr)
        {
            List<int> result = DoMerge(arr, 0, arr.Count - 1);
            for (int i = 0; i < result.Count; i++)
            {
                arr[i] = result[i];
            }
        }

        private List<int> DoMerge(List<int> l, int start, int end)
        {
            List<int> result = new List<int>();
            if (start == end)
            {
                result.Add(l[start]);
                return result;
            }

            int mid = (int)((start + end) / 2);
            List<int> left = DoMerge(l, start, mid);
            List<int> right = DoMerge(l, mid + 1, end);

            result = Merge(left, right);
            return result;
        }

        private List<int> Merge(List<int> a, List<int> b)
        {
            List<int> result = new List<int>();

            int iA = 0;
            int iB = 0;

            while (result.Count < a.Count + b.Count)
            {
                if (iA >= a.Count && iB < b.Count)
                {
                    result.Add(b[iB++]);
                }
                else if (iB >= b.Count && iA < a.Count)
                {
                    result.Add(a[iA++]);
                }
                else
                {
                    if (a[iA] < b[iB])
                        result.Add(a[iA++]);
                    else
                        result.Add(b[iB++]);
                }
            }
            
            return result;
        }
    }
    #endregion  
}
