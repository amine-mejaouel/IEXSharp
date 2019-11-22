﻿using System.Collections.Specialized;
using System.Web;

namespace VSLee.IEXSharp.Helper
{
	/// <summary>
	/// Simple query string builder
	/// Usage:
	/// var qsb = new QueryStringBuilder();
	/// qsb.Add("name", "value");
	/// qsb.Add("name1", "value1");
	/// qsb.Build(); // returns "?name=value&name1=value1"
	/// </summary>
	public class QueryStringBuilder
	{
		private readonly NameValueCollection nvc;

		public QueryStringBuilder()
		{
			nvc = HttpUtility.ParseQueryString(string.Empty);
		}

		public void Add(string key, object value)
		{
			var val = value.ToString().Trim();
			if (!string.IsNullOrEmpty(key))
			{
				nvc.Add(key, val);
			}
		}

		public bool TryAdd(string key, object value)
		{
			if (!string.IsNullOrWhiteSpace(key))
			{
				var val = value.ToString().Trim();
				if (!string.IsNullOrEmpty(val))
				{
					nvc.Add(key, val);
					return true;
				}
			}

			return false;
		}

		public string Get(string key)
		{
			return nvc[key];
		}

		public bool Exist(string key)
		{
			return nvc[key] == null;
		}

		public void Remove(string key)
		{
			nvc.Remove(key);
		}

		public int Count()
		{
			return nvc.Count;
		}

		public string Build()
		{
			return "?" + nvc;
		}
	}
}