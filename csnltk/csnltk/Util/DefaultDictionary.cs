using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace csnltk.Util
{
	//UNDONE
	public class DefaultDictionaryItem<K, V>
	{
		public K Key { set; get; }

		public List<V> Values { private set; get; }

		public DefaultDictionaryItem(K key, ICollection<V> values)
		{
			this.Key = key;
			this.Values = new List<V>(values);
		}
	}

	public class DefaultDictionary<K, V> : KeyedCollection<K, DefaultDictionaryItem<K, V>>
	{
		public DefaultDictionary()
			: base()
		{
		}

		public DefaultDictionary(IEqualityComparer<K> comparer)
			: base(comparer)
		{
		}

		public DefaultDictionary(IEqualityComparer<K> comparer, int dictionaryCreationThreshold)
			: base(comparer, dictionaryCreationThreshold)
		{
		}

		protected override K GetKeyForItem(DefaultDictionaryItem<K, V> item)
		{
			return item.Key;
		}

		public void Add(K key, V value)
		{
			
		}

		public void Add(K Key, params V[] values)
		{

		}

		public void Add(K Key, ICollection<V> values)
		{

		}

		protected override void InsertItem(int index, DefaultDictionaryItem<K, V> item)
		{
			base.InsertItem(index, item);
		}

	}
}
