using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Mvc;
using System.Web.Routing;

namespace TwitterBootstrapMVC.Patch
{
    public static class TypeExtensions
    {
        public static RouteValueDictionary ToRouteValues(this NameValueCollection queryString)
        {
            return queryString == null || !queryString.HasKeys() ? new RouteValueDictionary() : new RouteValueDictionary(queryString);
        }

        public static IDictionary<string, object> AddOrMergeCssClass(this IDictionary<string, object> data, string key, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return data;
            }
            var keyValueString = data[key] as string;
            if (!string.IsNullOrEmpty(keyValueString))
            {
                if (!keyValueString.Contains(value))
                {
                    keyValueString += value;
                }
            }
            else
            {
                keyValueString = value;
            }
            data[key] = keyValueString;
            return data;
        }

        public static void MergeHtmlAttributes(this IDictionary<string, object> source, IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null)
            {
                return;
            }
            foreach (var pair in htmlAttributes)
            {
                var key = pair.Key.ToLower();
                var valueString = pair.Value as string;
                var sourceValueString = source[key] as string;
                if (string.IsNullOrEmpty(valueString))
                {
                    continue;
                }
                foreach (var value in valueString.Split(' '))
                {
                    if (string.IsNullOrEmpty(sourceValueString) || !sourceValueString.Contains(value))
                    {
                        sourceValueString = string.Format("{0} {1}", sourceValueString, value);
                    }
                }
                source[key] = sourceValueString;
            }
        }

        public static IDictionary<string, object> ToHtmlDataAttributes(this object data)
        {
            if (data == null)
            {
                return new Dictionary<string, object>();
            }
            var dataDictionary = new RouteValueDictionary();
            foreach (var pair in data.ToDictionary())
            {
                var dataKey = string.Format("data-{0}", pair.Key.ToLower());
                var dataValue = pair.Value as string;
                if (!string.IsNullOrEmpty(dataValue))
                {
                    dataDictionary[dataKey] = dataValue;
                }
            }
            return dataDictionary;
        }

        public static IDictionary<string, object> ToDictionary(this object data)
        {
            if (data == null)
            {
                return new Dictionary<string, object>();
            }
            if (data.GetType().IsDictionary<string, object>())
            {
                return data as IDictionary<string, object>;
            }
            return HtmlHelper.AnonymousObjectToHtmlAttributes(data);
        }

        public static bool IsDictionary<TKey, TValue>(this Type type)
        {
            return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IDictionary<TKey, TValue>)) || type.Name.Equals("RouteValueDictionary");
        }

        public static IDictionary<string, object> AddOrReplaceAttribute(this IDictionary<string, object> data, string key, string value)
        {
            data[key] = value;
            return data;
        }
    }
}
