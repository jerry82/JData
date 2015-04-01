using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JDataStructure.TreeGraphDS;

namespace JDataStructure.crackcode {
    
    /// <summary>
    /// Solve problem 4.1 of CrackCode: 
    /// Check if the Btree is balanced ?
    /// (MaxDepth(left) - MaxDepth(right)).abs <= 1
    /// </summary>
    public class Chap41 {

        //main method
        public void Run() {
            DataFeeder feed = new DataFeeder();
            CheckBalanced(feed.GetUnbalancedTree());
        }

        public bool CheckBalanced(BTree tree) {
            bool result = true;
            int maxDepth = GetMaxDepth(tree.Root, ref result);
            return result;
        }

        private int GetMaxDepth(BNode node, ref bool balanced) {

            int maxLeft = 0;
            int maxRight = 0;
            int maxCur = 0;

            if (node.Left == null && node.Right == null) {
                return 0;
            }

            if (node.Left != null) {
                maxLeft = GetMaxDepth(node.Left, ref balanced);
            }
            if (node.Right != null) {
                maxRight = GetMaxDepth(node.Right, ref balanced);
            }
            maxCur = (maxLeft > maxRight) ? maxLeft + 1 : maxRight + 1;


            if (Math.Abs(maxLeft - maxRight) > 1) {
                Console.WriteLine("not balanced at: {0} - {1}:{2}", node.Data, maxLeft, maxRight);
                balanced = false;
            }

            return maxCur;
        }
    }
}
