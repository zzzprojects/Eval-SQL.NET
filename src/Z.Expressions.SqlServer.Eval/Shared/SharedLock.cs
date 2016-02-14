// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System.Threading;

namespace Z.Expressions.SqlServer.Eval
{
    /// <summary>A shared lock.</summary>
    public class SharedLock
    {
        /// <summary>The counter lock.</summary>
        public int CounterLock = 0;

        /// <summary>The expire cache lock.</summary>
        public int ExpireCacheLock = 0;

        /// <summary>Acquires the lock on the specified lockValue.</summary>
        /// <param name="lockValue">[in,out] The lock value.</param>
        public static void AcquireLock(ref int lockValue)
        {
            do
            {
                // TODO: it's possible to wait 10 ticks? Thread.Sleep doesn't really support it.
            } while (0 != Interlocked.CompareExchange(ref lockValue, 1, 0));
        }

        /// <summary>Releases the lock on the specified lockValue.</summary>
        /// <param name="lockValue">[in,out] The lock value.</param>
        public static void ReleaseLock(ref int lockValue)
        {
            Interlocked.CompareExchange(ref lockValue, 0, 1);
        }

        /// <summary>Attempts to acquire lock on the specified lockvalue.</summary>
        /// <param name="lockValue">[in,out] The lock value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool TryAcquireLock(ref int lockValue)
        {
            return 0 == Interlocked.CompareExchange(ref lockValue, 1, 0);
        }
    }
}