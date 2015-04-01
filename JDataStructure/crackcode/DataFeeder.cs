using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JDataStructure.TreeGraphDS;

namespace JDataStructure.crackcode {
    
    /// <summary>
    /// Feed test data 
    /// </summary>
    public class DataFeeder {

        //data: 8>4>11>3; 8>5>9; 5>7>1; 7>12>2
        public BTree GetUnbalancedTree() {
            BTree tree = new BTree();
            tree.Root = new BNode(8);

            tree.Root.Left = new BNode(5);
            
            tree.Root.Left.Left = new BNode(9);
            tree.Root.Left.Right = new BNode(7);
            tree.Root.Left.Right.Left = new BNode(1);
            tree.Root.Left.Right.Right = new BNode(12);
            tree.Root.Left.Right.Right.Left = new BNode(2);

            tree.Root.Right = new BNode(4);
            tree.Root.Right.Right = new BNode(11);
            tree.Root.Right.Right.Left = new BNode(3);


            return tree;
        }

        //data: A>B>C>E>F; E>D>B
        public Graph GetSampleGraph1() {
            Graph graph = new Graph();

            List<string> nodes = new List<string>() { "A", "B", "C", "D", "E", "F" };

            graph.BuildNodes(nodes);
            graph.AddDirectedEdge("A", "B", 1);
            graph.AddDirectedEdge("B", "C", 1);
            graph.AddDirectedEdge("C", "E", 1);
            graph.AddDirectedEdge("E", "F", 1);

            graph.AddDirectedEdge("E", "D", 1);
            graph.AddDirectedEdge("D", "B", 1);


            return graph;
        }
    }
}
