using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure.TreeGraphDS {
    
    /// <summary>
    /// Implementation of Directed Graph
    /// using adjacency list 
    /// </summary>
    public class Graph {
        public Dictionary<string, GNode> Nodes { get; set; }

        public Graph() {
            Nodes = new Dictionary<string, GNode>();
        }

        public void BuildNodes(List<String> names) {
            foreach (string name in names) {
                GNode node = new GNode(name);
                Nodes.Add(node.Name, node);
            }
        }

        public void AddDirectedEdge(string v1, string v2, int value) {
            GNode node = GetNode(v1);
            GNode destNode = GetNode(v2);

            if (node == null) {
                Nodes.Add(node.Name, node);
            }

            if (destNode == null) {
                Nodes.Add(destNode.Name, destNode);
            }

            if (node.Neighbors == null) {
                node.Neighbors = new Dictionary<string, int>();
            }

            if (!node.Neighbors.ContainsKey(v2)) {
                node.Neighbors.Add(v2, value);
            }
            else {
                throw new Exception("edge already added!");
            }
        }

        public GNode GetNode(string v) {
            return Nodes[v];
        }
    }

    public class GNode {
        public String Name { get; set; }
        public Dictionary<string, int> Neighbors { get; set; }
        public bool Visited { get; set; }

        public GNode(String name) {
            Name = name;
            Visited = false;
        }
    }
}
