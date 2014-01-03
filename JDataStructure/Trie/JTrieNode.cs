using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure
{
    /// JTrieNode store NodeKey as a character and it can be change to integer.
    /// We use NodeKey as Dictionary Key
    /// You can add a whatever type NodeValue if you intend to store whatever within JTrieNode
    public class JTrieNode
    {
        public char NodeKey { get; set; }
        public int NoOfPrefix { get; set; }
        public Dictionary<int, JTrieNode> Children { get; set; }
        public bool IsWord { get; set; }
    }
}
