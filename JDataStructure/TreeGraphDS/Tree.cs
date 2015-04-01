using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure.TreeGraphDS {
    
    /// <summary>
    /// Implementation of a general tree: tree has many children
    /// </summary>
    public class Tree {
        public Node Root { get; set; }

        //show from top to bottom: 
        //BFS
        public void Show() {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            Console.WriteLine("root> {0}", Root.Data);

            while (queue.Count > 0) {
                Node cur = queue.Dequeue();
                
                List<Node> kids = cur.Children;
                if (kids != null) {
                    foreach (Node kid in kids) {
                        Console.Write(" {0} ", kid.Data);
                        queue.Enqueue(kid);
                    }
                }                
            }
        }
    }

    public class Node {
        public int Data { get; set; }
        public List<Node> Children { get; set; }
        public Node(int data) {
            Data = data;
        }
       
    }
}
