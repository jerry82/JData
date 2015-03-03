using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure.Hashtable {

    /// <summary>
    /// the hash interface
    /// </summary>
    public interface IHash {
        int Count();
        void Add(Object key, Object obj);
        Object GetValue(Object key);
        void RemoveKey(Object key);
        bool ContainsKey(Object key);
    }

    /// <summary>
    /// implementation of the hashtable:
    /// 1. A key will be converted to index of an array: 
    ///     key.GetHashCode() % size 
    /// 2. if collision occurs then element of an array is a link list or List<int>
    /// </summary>
    public class TheHash : IHash {

        private List<KValue>[] Array = new List<KValue>[MAXSIZE];

        private int size = 0;
        private const int MAXSIZE = 100;

        public int Count() {
            return size;
        }

        public void Add(Object key, Object value) {

            if (ContainsKey(key))
                throw new Exception("Duplicated key found!");

            int idx = GetIdx(key);
            Console.WriteLine("add idx:{0}", idx);

            if (Array[idx] == null) 
                Array[idx] = (new List<KValue>());

            Array[idx].Add(new KValue() { Key = key, Value = value });


            size++;
        }

        public Object GetValue(Object key) {
            return null;
        }

        public void RemoveKey(Object key) {

        }

        public bool ContainsKey(Object key) {

            int idx = GetIdx(key);

            //get the List<Object> from the index
            List<KValue> objs = Array[idx];

            if (objs != null) {
                foreach (KValue kv in objs) {
                    if (kv.Key.Equals(key))
                        return true;
                }
            }

            return false;
        }

        #region helpers
        private int GetIdx(Object key) {

            if (size == 0) {
                return 0;
            }
            int tmp = key.GetHashCode();
            if (tmp < 0) {
                tmp *= -1;
            }
            Console.WriteLine("hash of: {0} is: {1}", key, tmp % MAXSIZE);
            return tmp % MAXSIZE;
        }
        #endregion
    }

    public class KValue {
        public Object Key { get; set; }
        public Object Value { get; set; }
    }
}
