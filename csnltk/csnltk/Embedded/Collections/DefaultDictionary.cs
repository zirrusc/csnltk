/*
 * collections.defaultdict
 * 
 * created: 2013-07-28
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace csnltk
{
	public class DefaultDictionary<K, V> : IDictionary<K, List<V>>
	{
		Dictionary<K, List<V>> items;

		void Init()
		{
			items = new Dictionary<K, List<V>>();
		}

		public DefaultDictionary()
		{
			Init();
		}

		public DefaultDictionary(IDictionary<K, V> values)
		{
			Init();
			Add(values);
		}

		public void Add(IDictionary<K, V> values)
		{
			if (values == null)
				throw new ArgumentNullException("values");

			foreach (var item in values)
				Add(item.Key, item.Value);
		}

		public void Add(K key, V value)
		{
			if (key == null)
				throw new ArgumentNullException("key");
			
			if (items.ContainsKey(key))
				items[key].Add(value);
			else
				items.Add(key, new List<V>(new V[] { value }));
		}

		public void Add(K key, params V[] values)
		{
			if (key == null)
				throw new ArgumentNullException("key");
			if (values == null)
				throw new ArgumentNullException("values");
		
			if (!items.ContainsKey(key))
				items.Add(key, new List<V>());

			items[key].AddRange(values);
			
		}

		public void Add(K key, List<V> value)
		{
			if (key == null)
				throw new ArgumentNullException("key");
			if (value == null)
				throw new ArgumentNullException("value");

			if (items.ContainsKey(key))
				items[key].AddRange(value);
			else
				items.Add(key, value);
		}

		public void Add(KeyValuePair<K, List<V>> item)
		{
			Add(item.Key, item.Value);
		}

		public bool Remove(K key)
		{
			if (key == null)
				throw new ArgumentNullException("key");

			return items.Remove(key);
		}

		public bool Remove(K key, V value)
		{
			if (key == null)
				throw new ArgumentNullException("key");

			return items[key].Remove(value);
		}

		public void Clear()
		{
			items.Clear();
		}

		public bool ContainsKey(K key)
		{
			return items.ContainsKey(key);
		}

		public bool Contains(K key, V value)
		{
			return items.ContainsKey(key) && items[key].Contains(value);
		}

		public ICollection<K> Keys
		{
			get { return items.Keys; }
		}

		public bool TryGetValue(K key, out List<V> value)
		{
			if (items.ContainsKey(key))
			{
				value = items[key];
				return true;
			}
			else
			{
				value = default(List<V>);
				return false;
			}
		}

		public ICollection<List<V>> Values
		{
			get { return items.Values; }
		}

		public List<V> this[K key]
		{
			get
			{
				return items[key];
			}
			set
			{
				items[key] = value;
			}
		}

		public bool Contains(KeyValuePair<K, List<V>> item)
		{
			if (items.ContainsKey(item.Key))
			{
				var a = items[item.Key].Intersect(item.Value);
				return a.Equals(items[item.Key]);
			}
			else
				return false;
		}

		public void CopyTo(KeyValuePair<K, List<V>>[] array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException("array");
			if (arrayIndex < 0)
				throw new ArgumentOutOfRangeException("arrayIndex");
			if (arrayIndex + items.Count >= array.Length)
				throw new ArgumentException("arrayIndex");

			int i = 0;
			foreach (var item in items)
				array[arrayIndex + i++] = new KeyValuePair<K, List<V>>(item.Key, item.Value);
		}

		public int Count
		{
			get { return items.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove(KeyValuePair<K, List<V>> item)
		{
			return Contains(item) & items.Remove(item.Key);
		}


		public IEnumerator<KeyValuePair<K, List<V>>> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return items.GetEnumerator();
		}
	}
}
