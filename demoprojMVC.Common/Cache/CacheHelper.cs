using System;
using Ninject;
using Spring.Context;
using Spring.Context.Support;

namespace demoprojMVC.Common.Cache
{
    public class CacheHelper
    {
        
         public static ICacheWriter CacheWriter { get; set; }

        static CacheHelper()
        {
            //IApplicationContext ctx = ContextRegistry.GetContext();
            CacheWriter = new MemcacheWriter(); //ctx.GetObject("CacheWriter") as ICacheWriter;
        }

        public static void AddCache(string key, object value, DateTime expDate)
        {
            CacheWriter.AddCache(key,value,expDate);
        }
        public static void AddCache(string key, object value)
        {
            CacheWriter.AddCache(key, value);
        }

        public static object GetCache(string key)
        {
            return CacheWriter.GetCache(key);
        }

        public static void SetCache(string key, object value, DateTime extTime)
        {
            CacheWriter.SetCache(key, value, extTime);
        }

        public static void SetCache(string key, object value)
        {
            CacheWriter.SetCache(key, value);
        }
    }
}