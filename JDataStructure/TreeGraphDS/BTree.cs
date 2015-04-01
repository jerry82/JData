using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure.TreeGraphDS {

    /// <summary>
    /// Implementation of a Binary tree
    /// </summary>
    public class BTree {

        public BNode Root { get; set; }

        public void InOrder(BNode node) {
            if (node == null)
                return;

            InOrder(node.Left);
            Console.Write(" {0} ", node.Data);
            InOrder(node.Right);
        }

        public void PreOrder(BNode node) {
            if (node == null)
                return;
            Console.WriteLine(" {0} ", node.Data);
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        public void PostOrder(BNode node) {
            if (node == null)
                return;
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.WriteLine(" {0} ", node.Data);
        }
    }

    public class BNode {
        public int Data { get; set; }
        public BNode Left { get; set; }
        public BNode Right { get; set; }
        public BNode(int data) {
            Data = data;
        }
    }

}
