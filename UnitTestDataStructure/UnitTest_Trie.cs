using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using JDataStructure;

namespace UnitTestDataStructure
{
    [TestClass]
    public class UnitTest_Trie
    {
        JTrie _dict;

        [TestInitialize]
        public void InitTrie()
        {
            string[] paths = { "dict/web2", "dict/web2a" };
            _dict = new JTrie();
            string tmp = String.Empty;

            foreach (string path in paths)
            {
                using (StreamReader sr = new StreamReader(path, Encoding.ASCII))
                {
                    while ((tmp = sr.ReadLine()) != null)
                    {
                        _dict.Add(tmp);
                    }
                }
            }
        }

        [TestMethod]
        public void TestTrie()
        {
            List<string> result = _dict.SearchPrefix("a", 10);
            Assert.AreEqual(10, result.Count);
        }
    }
}
