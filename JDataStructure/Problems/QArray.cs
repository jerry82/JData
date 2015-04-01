using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure {
    
    /// <summary>
    /// answer all array related questions
    /// </summary>
    public class QArray {
        
        //1. find number in sorted array
        public int FindNumber(List<int> sorted, int number) {

            int lo = 0;
            int hi = sorted.Count - 1;

            while(true) {

                if (lo == hi) {
                    if (sorted[lo] == number) {
                        return lo;
                    }
                }
                else if (hi - lo == 1) {
                    if (sorted[lo] == number) return lo;
                    else if (sorted[hi] == number) return hi;
                    else return -1;
                }

                int m = lo + (hi - lo) / 2;
                int mV = sorted[m];

                //found
                if (mV == number) {
                    return m;
                }

                if (mV <= sorted[hi]) {
                    //right
                    if (number <= sorted[hi] && number >= mV) {
                        lo = m;
                    }
                    else {
                        hi = m;
                    }
                }
                else if (mV >= sorted[lo]) {
                    //left
                    if (number <= mV && number >= sorted[lo]) {
                        hi = m;
                    }
                    else
                        lo = m;
                }
                else
                    return -1;
            }

        }

        //run
        public void Test() {
            List<int> sorted = new List<int>() { 7, 8, 1, 2, 3, 4, 5 };
            foreach (int number in sorted) {
                Console.WriteLine("find {0} at index: {1}", number, FindNumber(sorted, number));
            }

            Console.WriteLine("find {0} at index: {1}", 6, FindNumber(sorted, 6));

        }
    }
}
