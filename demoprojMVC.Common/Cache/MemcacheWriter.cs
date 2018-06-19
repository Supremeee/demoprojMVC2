using System;
using Memcached.ClientLibrary;

namespace demoprojMVC.Common.Cache
{
    public class MemcacheWriter : ICacheWriter
    {
        private MemcachedClient memcachedClient;

        public MemcacheWriter()
        {
            string strAppMemcachedServer = System.Configuration.ConfigurationManager.AppSettings["MemcachedServerList"];
            string[] servers = strAppMemcachedServer.Split(',');

            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(servers);
            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep = 30;
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize();
            //客户端实例
            MemcachedClient mc = new MemcachedClient();
            mc.EnableCompression = false;
            memcachedClient = mc;
        }
        public void AddCache(string key, object value)
        {
            memcachedClient.Add(key, value);
        }

        public void AddCache(string key, object value, DateTime expDate)
        {
            memcachedClient.Add(key, value, expDate);
        }

        public object GetCache(string key)
        {
            return memcachedClient.Get(key);
        }

        public T GetCache<T>(string key)
        {
            return (T) memcachedClient.Get(key);
        }

        public void SetCache(string key, object value)
        {
            memcachedClient.Set(key, value);
        }

        public void SetCache(string key, object value, DateTime extDate)
        {
            memcachedClient.Set(key, value, extDate);
        }
    }
}