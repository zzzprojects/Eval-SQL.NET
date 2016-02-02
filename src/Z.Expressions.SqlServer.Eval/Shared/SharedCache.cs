using System;
using System.Collections.Generic;

namespace Z.Expressions.SqlServer.Eval
{
    /// <summary>A shared cache.</summary>
    /// <typeparam name="TKey">Type of key.</typeparam>
    /// <typeparam name="TValue">Type of value.</typeparam>
    public class SharedCache<TKey, TValue>
    {
        /// <summary>The lock value.</summary>
        public int LockValue;

        /// <summary>Default constructor.</summary>
        public SharedCache()
        {
            InnerDictionary = new Dictionary<TKey, TValue>();
        }

        /// <summary>Gets the number of items cached.</summary>
        /// <value>The number of items cached.</value>
        public int Count
        {
            get { return InnerDictionary.Count; }
        }

        /// <summary>Gets or sets the inner dictionary used to cache items.</summary>
        /// <value>The inner dictionary used to cache items.</value>
        public Dictionary<TKey, TValue> InnerDictionary { get; set; }

        /// <summary>Acquires the lock on the shared cache.</summary>
        public void AcquireLock()
        {
            SharedLock.AcquireLock(ref LockValue);
        }

        /// <summary>Adds or updates a cache value for the specified key.</summary>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The cache value used to add.</param>
        /// <param name="updateValueFactory">The cache value factory used to update.</param>
        /// <returns>The value added or updated in the cache for the specified key.</returns>
        public TValue AddOrUpdate(TKey key, TValue value, Func<TKey, TValue, TValue> updateValueFactory)
        {
            try
            {
                AcquireLock();

                TValue oldValue;
                if (InnerDictionary.TryGetValue(key, out oldValue))
                {
                    value = updateValueFactory(key, oldValue);
                    InnerDictionary[key] = value;
                }
                else
                {
                    InnerDictionary.Add(key, value);
                }

                return value;
            }
            finally
            {
                ReleaseLock();
            }
        }

        /// <summary>Adds or update a cache value for the specified key.</summary>
        /// <param name="key">The cache key.</param>
        /// <param name="addValueFactory">The cache value factory used to add.</param>
        /// <param name="updateValueFactory">The cache value factory used to update.</param>
        /// <returns>The value added or updated in the cache for the specified key.</returns>
        public TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
        {
            try
            {
                AcquireLock();

                TValue value;
                TValue oldValue;

                if (InnerDictionary.TryGetValue(key, out oldValue))
                {
                    value = updateValueFactory(key, oldValue);
                    InnerDictionary[key] = value;
                }
                else
                {
                    value = addValueFactory(key);
                    InnerDictionary.Add(key, value);
                }


                return value;
            }
            finally
            {
                ReleaseLock();
            }
        }

        /// <summary>Clears all cached items.</summary>
        public void Clear()
        {
            try
            {
                AcquireLock();
                InnerDictionary.Clear();
            }
            finally
            {
                ReleaseLock();
            }
        }


        /// <summary>Releases the lock on the shared cache.</summary>
        public void ReleaseLock()
        {
            SharedLock.ReleaseLock(ref LockValue);
        }

        /// <summary>Attempts to add a value in the shared cache for the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public bool TryAdd(TKey key, TValue value)
        {
            try
            {
                AcquireLock();

                if (!InnerDictionary.ContainsKey(key))
                {
                    InnerDictionary.Add(key, value);
                }

                return true;
            }
            finally
            {
                ReleaseLock();
            }
        }

        /// <summary>Attempts to remove a key from the shared cache.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">[out] The value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public bool TryRemove(TKey key, out TValue value)
        {
            try
            {
                AcquireLock();

                var isRemoved = InnerDictionary.TryGetValue(key, out value);
                if (isRemoved)
                {
                    InnerDictionary.Remove(key);
                }

                return isRemoved;
            }
            finally
            {
                ReleaseLock();
            }
        }

        /// <summary>Attempts to get value from the shared cache for the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">[out] The value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            try
            {
                return InnerDictionary.TryGetValue(key, out value);
            }
            catch (Exception)
            {
                value = default(TValue);
                return false;
            }
        }
    }
}