using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using JDataStructure;


namespace UnitTestDataStructure {

    [TestClass]
    public class UnitTest_Hash {
        private JHash<string, string> _hash;

        [TestInitialize]
        public void InitTrie() {
            _hash = new JHash<string, string>(100);
            for (int i = 0; i < 10; i++) {
                _hash.Add(i.ToString(), i.ToString());
            }
        }

        [TestMethod]
        public void TestHash() {
            Assert.AreEqual(10, _hash.Count());
            Assert.AreEqual(false, _hash.ContainsKey("11"));
            Assert.AreEqual(true, _hash.ContainsKey("2"));
            Assert.AreEqual("3", _hash.GetValue("3"));

            _hash.RemoveKey("11");
            Assert.AreEqual(10, _hash.Count());
            _hash.RemoveKey("5");
            Assert.AreEqual(9, _hash.Count());

            //this will fail if the value is integer
            Assert.IsNull(_hash.GetValue("5"));
        }
    }
}
