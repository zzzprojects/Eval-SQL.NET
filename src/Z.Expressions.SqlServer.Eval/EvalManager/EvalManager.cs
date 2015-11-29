// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Collections.Concurrent;
using System.Threading;
using Z.Expressions.SqlServer.Eval;

namespace Z.Expressions
{
    /// <summary>Manager class for eval.</summary>
    public static class EvalManager
    {
        /// <summary>The cache for EvalDelegate.</summary>
        public static ConcurrentDictionary<string, EvalDelegate> CacheDelegate = new ConcurrentDictionary<string, EvalDelegate>();

        /// <summary>The cache for SQLNETItem.</summary>
        public static ConcurrentDictionary<string, SQLNETItem> CacheItem = new ConcurrentDictionary<string, SQLNETItem>();

        /// <summary>The default context used to compile the code or expression.</summary>
        public static EvalContext DefaultContext = new EvalContext();

        /// <summary>The sliding expiration for delegate cache.</summary>
        public static TimeSpan SlidingExpirationDelegate = TimeSpan.FromDays(1);

        /// <summary>The sliding expiration for item cache.</summary>
        public static TimeSpan SlidingExpirationItem = TimeSpan.FromMinutes(5);

        /// <summary>The thread to auto expire cached delegate and item.</summary>
        private static readonly Thread ThreadAutoExpireCache = new Thread(ExecuteThreadAutoExpireCache) {Name = "Eval SQL.NET - AutoExpire Cache", IsBackground = true};

        /// <summary>The wait lock for the ThreadAutoExpireCache.</summary>
        private static readonly object WaitLock = new object();

        /// <summary>Static constructor.</summary>
        static EvalManager()
        {
            SQLNET.LoadGlobalConfiguration();
            ThreadAutoExpireCache.Start();
        }

        /// <summary>Executes the thread to automatically expire cached delegate and item.</summary>
        private static void ExecuteThreadAutoExpireCache()
        {
            while (true)
            {
                lock (WaitLock)
                {
                    Monitor.Wait(WaitLock, TimeSpan.FromMinutes(1));

                    // EXPIRE delegate
                    var expireDateDelegate = DateTime.Now.Subtract(SlidingExpirationDelegate);
                    foreach (var keyvalue in CacheDelegate)
                    {
                        if (keyvalue.Value.LastAccess < expireDateDelegate)
                        {
                            EvalDelegate value;
                            CacheDelegate.TryRemove(keyvalue.Key, out value);
                        }
                    }

                    // EXPIRE item
                    var expireDateItem = DateTime.Now.Subtract(SlidingExpirationItem);
                    foreach (var keyvalue in CacheItem)
                    {
                        if (keyvalue.Value.LastAccess < expireDateItem)
                        {
                            SQLNETItem value;
                            CacheItem.TryRemove(keyvalue.Key, out value);
                        }
                    }
                }
            }
        }
    }
}