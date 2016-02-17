// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections.Generic;
using Z.Expressions.SqlServer.Eval;

namespace Z.Expressions
{
    /// <summary>Manager class for eval.</summary>
    public static class EvalManager
    {
        /// <summary>The cache for EvalDelegate.</summary>
        public static readonly SharedBuckedCache<string, EvalDelegate> CacheDelegate = new SharedBuckedCache<string, EvalDelegate>();

        /// <summary>The cache for SQLNETItem.</summary>
        public static readonly SharedBuckedCache<int, SQLNETItem> CacheItem = new SharedBuckedCache<int, SQLNETItem>();

        /// <summary>The default context used to compile the code or expression.</summary>
        public static readonly EvalContext Configuration;

        /// <summary>The default context.</summary>
        internal static readonly EvalContext DefaultContext;

        /// <summary>The shared lock.</summary>
        public static readonly SharedLock SharedLock;

        static EvalManager()
        {
            // ENSURE to create lock first
            SharedLock = new SharedLock();
            Configuration = new EvalContext();
            DefaultContext = Configuration;
            SQLNET.LoadConfiguration();
        }

        /// <summary>Determines if we can expire cache.</summary>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool ExpireCache()
        {
            try
            {
                if (SharedLock.TryAcquireLock(ref SharedLock.ExpireCacheLock))
                {
                    // Change the next schedule, so other threads will not try to expire the cache
                    Configuration.ExpireCacheNextScheduled = DateTime.Now.Add(Configuration.ExpireCacheDelay);

                    // EXPIRE delegate cache
                    {
                        var expireDateDelegate = DateTime.Now.Subtract(Configuration.SlidingExpirationDelegate);
                        var keyToRemoves = new List<string>();

                        foreach (var bucket in CacheDelegate.Buckets)
                        {
                            try
                            {
                                bucket.AcquireLock();

                                foreach (var keyvalue in bucket.InnerDictionary)
                                {
                                    if (keyvalue.Value.LastAccess < expireDateDelegate)
                                    {
                                        keyToRemoves.Add(keyvalue.Key);
                                    }
                                }

                                foreach (var key in keyToRemoves)
                                {
                                    bucket.InnerDictionary.Remove(key);
                                }
                            }
                            finally
                            {
                                bucket.ReleaseLock();
                            }
                        }
                    }


                    // EXPIRE item cache
                    {
                        var expireDateItem = DateTime.Now.Subtract(Configuration.SlidingExpirationItem);
                        var keyToRemoves = new List<int>();

                        foreach (var bucket in CacheItem.Buckets)
                        {
                            try
                            {
                                bucket.AcquireLock();

                                foreach (var keyvalue in bucket.InnerDictionary)
                                {
                                    if (keyvalue.Value.LastAccess < expireDateItem)
                                    {
                                        keyvalue.Value.IsCached = false;
                                        keyToRemoves.Add(keyvalue.Key);
                                    }
                                }

                                foreach (var key in keyToRemoves)
                                {
                                    bucket.InnerDictionary.Remove(key);
                                }
                            }
                            finally
                            {
                                bucket.ReleaseLock();
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
            finally
            {
                SharedLock.ReleaseLock(ref SharedLock.ExpireCacheLock);
            }
        }
    }
}