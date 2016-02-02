// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

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
        public static readonly SharedCache<string, SQLNETItem> CacheItem = new SharedCache<string, SQLNETItem>();

        /// <summary>The default context used to compile the code or expression.</summary>
        public static readonly EvalContext Configuration;

        /// <summary>The shared lock.</summary>
        public static readonly SharedLock SharedLock;

        static EvalManager()
        {
            // ENSURE to create lock first
            SharedLock = new SharedLock();
            Configuration = new EvalContext();
            SQLNET.LoadConfiguration();
        }

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
                        var keyToRemoves = new List<string>();

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