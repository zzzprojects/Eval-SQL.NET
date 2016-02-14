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
        public static readonly SharedCache<string, EvalDelegate> CacheDelegate = new SharedCache<string, EvalDelegate>();

        /// <summary>The cache for SQLNETItem.</summary>
        public static readonly SharedCache<int, SQLNETItem> CacheItem = new SharedCache<int, SQLNETItem>();

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

                        try
                        {
                            CacheDelegate.AcquireLock();

                            foreach (var keyvalue in CacheDelegate.InnerDictionary)
                            {
                                if (keyvalue.Value.LastAccess < expireDateDelegate)
                                {
                                    keyToRemoves.Add(keyvalue.Key);
                                }
                            }

                            foreach (var key in keyToRemoves)
                            {
                                CacheDelegate.InnerDictionary.Remove(key);
                            }
                        }
                        finally
                        {
                            CacheDelegate.ReleaseLock();
                        }
                    }


                    // EXPIRE item cache
                    {
                        var expireDateItem = DateTime.Now.Subtract(Configuration.SlidingExpirationItem);
                        var keyToRemoves = new List<int>();

                        try
                        {
                            CacheItem.AcquireLock();

                            foreach (var keyvalue in CacheItem.InnerDictionary)
                            {
                                if (keyvalue.Value.LastAccess < expireDateItem)
                                {
                                    keyvalue.Value.IsCached = false;
                                    keyToRemoves.Add(keyvalue.Key);
                                }
                            }

                            foreach (var key in keyToRemoves)
                            {
                                CacheItem.InnerDictionary.Remove(key);
                            }
                        }
                        finally
                        {
                            CacheItem.ReleaseLock();
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