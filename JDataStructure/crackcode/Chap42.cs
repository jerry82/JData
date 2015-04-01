using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JDataStructure.TreeGraphDS;

namespace JDataStructure.crackcode {

    /// <summary>
    /// Solve problem 4.2: find out route between 2 nodes in directed graph
    /// Design an extension method to Graph Datastructure
    /// </summary>
    public class Chap42 {

        //main method
        public void Run() {
            DataFeeder feed = new DataFeeder();

            //A>B>C>E>F; E>D>B
            bool canRoute = RouteDFS("A", "D", feed.GetSampleGraph1());

            Console.WriteLine("can routed: {0}", canRoute);
        }

        public bool RouteBFS(string v1, string v2, Graph graph) {
            bool canRoute = false;

            Queue<GNode> queue = new Queue<GNode>();

            GNode root = graph.GetNode(v1);

            if (root == null)
                throw new Exception("cannot find 1st node");

            queue.Enqueue(root);

            while (queue.Count > 0) {
                GNode cur = queue.Dequeue();
                cur.Visited = false;

                Dictionary<string, int> neighbors = cur.Neighbors;
                if (neighbors != null) {
                    foreach (string name in neighbors.Keys) {
                        GNode tmpNode = graph.Nodes[name];

                        if (name.Equals(v2)) {
                            canRoute = true;
                            Console.WriteLine("found:{0}", name);
                            break;
                        }
                        else {

                            if (!tmpNode.Visited) {
                                queue.Enqueue(tmpNode);
                                tmpNode.Visited = true;
                                Console.WriteLine("enqueue:{0}", tmpNode.Name);
                            }
                        }
                    }
                }
            }

            return canRoute;
        }

        public bool RouteDFS(string v1, string v2, Graph graph) {
            bool canRoute = false;

            GNode root = graph.GetNode(v1);
            Stack<GNode> stack = new Stack<GNode>();
            List<string> vList = new List<string>();

            stack.Push(root);

            while (stack.Count > 0) {
                GNode cur = stack.Peek();

                if (!vList.Contains(cur.Name)) {
                    vList.Add(cur.Name);
                    cur.Visited = true;
                }
                
                Dictionary<string, int> neighbors = cur.Neighbors;
                if (neighbors == null) {
                    GNode tmp = stack.Pop();
                    Console.WriteLine("pop: {0}", tmp.Name);

                }
                else {
                    bool noNeighbor = true;

                    foreach (string n in neighbors.Keys) {
                        if (!graph.Nodes[n].Visited) {
                            stack.Push(graph.Nodes[n]);
                            
                            noNeighbor = false;
                            break;
                        }
                    }

                    if (noNeighbor) {
                        stack.Pop();
                    }
                }

                Console.ReadLine();

            }

            foreach (string name in vList) {
                Console.Write(" {0} ", name);
            }
            Console.WriteLine();

            return canRoute;
        }
    }
}
