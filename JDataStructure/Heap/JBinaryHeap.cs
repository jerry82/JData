using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure.Heap
{
    /// <summary>
    /// biggest value is root: This is MAX-HEAP
    /// This implementation uses an Array to implement a heap
    /// If root marked as 0 -> 1, 2 are left and right node
    /// we have relationship between parent and children
    /// => node at index: n is left node if n odd and its parent index = n - 1 / 2 -
    /// right node if n even, parent index = n - 2 / 2
    /// </summary>
    public class JBinaryHeap
    {
        private List<int> HeapArr = new List<int>();

        public void Heapify(List<int> numbers)
        {
            //clear prev data
            HeapArr.Clear();

            foreach (int i in numbers)
            {
                Insert(i);
            }
        }

        /// <summary>
        /// insert new value while maintain heap datastructure
        /// </summary>
        /// <param name="nu"></param>
        public void Insert(int nu)
        {
            //insert at the end of the list 
            HeapArr.Add(nu);

            //root node
            if (HeapArr.Count == 1)
                return;

            //swap with parent 
            int curIdx = HeapArr.Count - 1;
            int parentIdx;

            while (true)
            {
                if (curIdx % 2 == 1)
                    parentIdx = (curIdx == 1) ? 0 : (curIdx - 1) / 2;
                else
                    parentIdx = (curIdx == 2) ? 0 : (curIdx - 2) / 2;

                if (HeapArr[curIdx] > HeapArr[parentIdx])
                    Swap(curIdx, parentIdx);

                if (parentIdx == 0)
                    break;
                else
                    curIdx = parentIdx;
            }
        }

        private void Swap(int idxA, int idxB)
        {
            int tmp = HeapArr[idxA];
            HeapArr[idxA] = HeapArr[idxB];
            HeapArr[idxB] = tmp;
        }

        /// <summary>
        /// delete the root node and build a new structure 
        /// </summary>
        public int Delete()
        {
            int root = HeapArr[0];

            //build new structure
            HeapArr[0] = HeapArr[HeapArr.Count - 1];
            HeapArr.RemoveAt(HeapArr.Count - 1);

            //maintain the heap structure
            //find the bigger between 2 children
            int curIdx = 0;

            while (true)
            {
                int leftIdx = curIdx * 2 + 1;
                int rightIdx = curIdx * 2 + 2;
                
                //no child
                if (leftIdx >= HeapArr.Count) break;

                //one child
                if (rightIdx >= HeapArr.Count)
                {
                    if (HeapArr[curIdx] < HeapArr[leftIdx])
                    {
                        Swap(curIdx, leftIdx);
                        curIdx = leftIdx;
                    }
                    else break;
                }
                else
                {
                    int tmp = HeapArr[leftIdx] > HeapArr[rightIdx] ? leftIdx : rightIdx;
                    if (HeapArr[curIdx] < HeapArr[tmp])
                    {
                        Swap(curIdx, tmp);
                        curIdx = tmp;
                    }
                    else break;
                }
            }

            return root;
        }


        /// <summary>
        /// HeapSort
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public List<int> HeapSort(List<int> numbers)
        {
            List<int> list = new List<int>();

            this.Heapify(numbers);

            while (HeapArr.Count > 0)
            {
                list.Add(Delete());
            }

            return list;
        }

        /// <summary>
        /// Count number of items
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return HeapArr.Count;
        }

        /// <summary>
        /// this is for debugging purpose
        /// </summary>
        public void DisplayArr()
        {
            foreach (int i in HeapArr)
            {
                Console.Write(" {0} ", i);
            }
            Console.WriteLine();
        }
    }
}
