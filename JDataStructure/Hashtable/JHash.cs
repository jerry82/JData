using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure {

    /// <summary>
    /// the hash interface
    /// </summary>
    public interface IHash<K, V> {
        int Count();
        void Add(K key, V obj);
        V GetValue(K key);
        void RemoveKey(K key);
        bool ContainsKey(K key);
    }

    /// <summary>
    /// implementation of the hashtable:
    /// 1. A key will be converted to index of an array idx -> Array[idx] = Value: 
    ///     idx = key.GetHashCode() % SIZE 
    ///     (SIZE is defined by user)
    /// 2. if collision occurs, then add the key, value object to the list at Array[idx] 
    /// </summary>
    public class JHash<K, V> : IHash<K, V> {

        private List<KValue<K,V>>[] _theArray;
        private int size = 0;
        private const int MAXSIZE = 100;

        public JHash(int maxSize) {
            if (maxSize <= 0)
                throw new Exception("invalid size");
            _theArray = new List<KValue<K, V>>[MAXSIZE];
        }

        public int Count() {
            return size;
        }

        public void Add(K key, V value) {

            if (ContainsKey(key))
                throw new Exception("Duplicated key found!");

            int idx = GetIdx(key);
            Console.WriteLine("add idx:{0}", idx);

            if (_theArray[idx] == null)
                _theArray[idx] = (new List<KValue<K, V>>());

            _theArray[idx].Add(new KValue<K, V>() { Key = key, Value = value });

            size++;
        }

        /// <summary>
        ///if V is integer than default(V) == 0; 
        ///V can be restricted to reference type "where V: class"
        /// </summary>
        public V GetValue(K key) {
            int idx = GetIdx(key);
            List<KValue<K, V>> objs = _theArray[idx];
            if (objs != null) {
                foreach (KValue<K, V> kv in objs) {
                    if (kv.Key.Equals(key))
                        return kv.Value;
                }
            }
            return default(V);
        }

        public void RemoveKey(K key) {

            int idx = GetIdx(key);
            List<KValue<K, V>> objs = _theArray[idx];

            if (objs != null) {
                foreach (KValue<K, V> kv in objs) {
                    if (kv.Key.Equals(key)) {
                        objs.Remove(kv);
                        size--;
                        break;
                    }
                }
            }
        }

        public bool ContainsKey(K key) {

            int idx = GetIdx(key);

            //get the List<Object> from the index
            List<KValue<K, V>> objs = _theArray[idx];

            if (objs != null) {
                foreach (KValue<K, V> kv in objs) {
                    if (kv.Key.Equals(key))
                        return true;
                }
            }

            return false;
        }

        #region helpers
        private int GetIdx(K key) {
            if (size == 0) {
                return 0;
            }
            return Math.Abs(key.GetHashCode()) % MAXSIZE;
        }
        #endregion
    }

    public class KValue<K,V> {
        public K Key { get; set; }
        public V Value { get; set; }
    }
}
