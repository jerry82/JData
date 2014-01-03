using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure
{
    /// Interface for trie data structure
    /// 
    public interface IJTrie
    {
        /// add word to trie structure
        /// 
        void Add(string str);

        /// search prefix return items with 'str' prefix
        /// 
        List<string> SearchPrefix(string str, int top = -1);

        /// return how many items with prefix: 'str'
        /// 
        int GetPrefixCount(string str);

        /// check whether full word 'str' is stored in the trie
        /// 
        bool Contains(string str);
    }
}
