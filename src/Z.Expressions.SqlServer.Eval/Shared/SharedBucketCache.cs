// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Linq;

namespace Z.Expressions.SqlServer.Eval
{
    // todo: Improve this cache by using the dictionary bucket instead? or at least an algorith based on the length.
    public class SharedBuckedCache<TKey, TValue>
    {
        public SharedCache<TKey, TValue>[] Buckets;

        public SharedBuckedCache(int bucketSize = 100)
        {
            Buckets = new SharedCache<TKey, TValue>[bucketSize];

            for (var i = 0; i < bucketSize; i++)
            {
                Buckets[i] = new SharedCache<TKey, TValue>();
            }
        }

        /// <summary>Gets the number of items cached.</summary>
        /// <value>The number of items cached.</value>
        public int Count
        {
            get { return Buckets.Sum(x => x.Count); }
        }

        /// <summary>Adds or updates a cache value for the specified key.</summary>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The cache value used to add.</param>
        /// <param name="updateValueFactory">The cache value factory used to update.</param>
        /// <returns>The value added or updated in the cache for the specified key.</returns>
        public TValue AddOrUpdate(TKey key, TValue value, Func<TKey, TValue, TValue> updateValueFactory)
        {
            var bucket = key.GetHashCode()%Buckets.Length;
            bucket = bucket < 0 ? -bucket : bucket;

            return Buckets[bucket].AddOrUpdate(key, value, updateValueFactory);
        }

        /// <summary>Adds or update a cache value for the specified key.</summary>
        /// <param name="key">The cache key.</param>
        /// <param name="addValueFactory">The cache value factory used to add.</param>
        /// <param name="updateValueFactory">The cache value factory used to update.</param>
        /// <returns>The value added or updated in the cache for the specified key.</returns>
        public TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
        {
            var bucket = key.GetHashCode()%Buckets.Length;
            bucket = bucket < 0 ? -bucket : bucket;

            return Buckets[bucket].AddOrUpdate(key, addValueFactory, updateValueFactory);
        }

        /// <summary>Attempts to add a value in the shared cache for the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public bool TryAdd(TKey key, TValue value)
        {
            var bucket = key.GetHashCode()%Buckets.Length;
            bucket = bucket < 0 ? -bucket : bucket;

            return Buckets[bucket].TryAdd(key, value);
        }

        /// <summary>Attempts to remove a key from the shared cache.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">[out] The value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public bool TryRemove(TKey key, out TValue value)
        {
            var bucket = key.GetHashCode()%Buckets.Length;
            bucket = bucket < 0 ? -bucket : bucket;

            return Buckets[bucket].TryRemove(key, out value);
        }

        /// <summary>Attempts to get value from the shared cache for the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">[out] The value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            var bucket = key.GetHashCode()%Buckets.Length;
            bucket = bucket < 0 ? -bucket : bucket;

            return Buckets[bucket].TryGetValue(key, out value);
        }
    }
}