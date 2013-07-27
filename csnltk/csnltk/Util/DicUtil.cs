using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csnltk
{
	public static class DicUtil
	{
		public static T GetValue<K, V, T>(IDictionary<K, V> dict, K key)
		{
			
		}

		public static bool HasValue<K, V>(IDictionary<K, V> dict, K key)
		{
			object t;
			return HasValue<K, V, object>(dict, key, out t);
		}

		public static bool HasValue<K, V, T>(IDictionary<K, V> dict, K key, out T value)
		{
			if (dict.ContainsKey(key))
			{
				value = (T)dict[key];
			}
		}
	}
}
