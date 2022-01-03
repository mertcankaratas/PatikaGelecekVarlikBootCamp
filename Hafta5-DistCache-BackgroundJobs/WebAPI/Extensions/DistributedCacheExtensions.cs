using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPI.Extensions
{
    public static class DistributedCacheExtensions
    {/// <summary>
    /// Redis ile ilgili işlemlerin daha kolay çağrılabilmesi için bir extension haline getirilmiştir.
    /// Burada kullanıcıyı,ürünleri redis ile tutulması için extension methodlar yazılmıştır.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="cache"></param>
    /// <param name="recordId"></param>
    /// <param name="data"></param>
    /// <param name="absoluteExpireTime"></param>
    /// <param name="unusedExpireTime"></param>
    /// <returns></returns>
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, string recordId, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(30);
            var jsonData = JsonConvert.SerializeObject(data);

            await cache.SetStringAsync(recordId, jsonData, options);
        }

        public static async Task SetListRecordAsync<T>(this IDistributedCache cache, string recordId, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(30);
            var jsonData = JsonConvert.SerializeObject(data);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
            await cache.SetAsync(recordId, bytes, options);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);
            if (jsonData == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(jsonData);


        }


        public static async Task<T> GetListRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = cache.Get(recordId);
            if (jsonData == null)
            {
                return default(T);
            }

            var bytes = Encoding.UTF8.GetString(jsonData);
            var test = JsonConvert.DeserializeObject<T>(bytes);
            return test;




        }


        public static async Task DeleteRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);
            if (jsonData == null)
            {
                return;
            }

            await cache.RemoveAsync(recordId);


        }
    }
}
