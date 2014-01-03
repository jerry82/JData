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

        }
    }

    public class BubbleSort : Sorter
    {
        public override void Ascend(List<int> arr)
        {
            throw new NotImplementedException();
        }
    }

    public class QuickSort : Sorter
    {
        public override void Ascend(List<int> arr)
        {
            throw new NotImplementedException();
        }
    }

    public class MergeSort : Sorter
    {
        public override void Ascend(List<int> arr)
        {
            throw new NotImplementedException();
        }
    }
}
