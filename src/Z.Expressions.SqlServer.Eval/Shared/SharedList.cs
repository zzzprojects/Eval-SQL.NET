// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections.Generic;

namespace Z.Expressions.SqlServer.Eval
{
    public class SharedList
    {
        /// <summary>The lock value.</summary>
        public int LockValue;

        /// <summary>Default constructor.</summary>
        public SharedList()
        {
            InnerList = new List<SQLNETParallelItem>();
        }

        /// <summary>Gets the number of items cached.</summary>
        /// <value>The number of items cached.</value>
        public int Count
        {
            get { return InnerList.Count; }
        }

        /// <summary>Gets or sets the inner dictionary used to cache items.</summary>
        /// <value>The inner dictionary used to cache items.</value>
        public List<SQLNETParallelItem> InnerList; 

        /// <summary>Acquires the lock on the shared cache.</summary>
        public void AcquireLock()
        {
            SharedLock.AcquireLock(ref LockValue);
        }

        /// <summary>Releases the lock on the shared cache.</summary>
        public void ReleaseLock()
        {
            SharedLock.ReleaseLock(ref LockValue);
        }

        /// <summary>Attempts to add a value in the shared cache for the specified key.</summary>
        /// <param name="value">The value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public bool TryAdd(SQLNETParallelItem value)
        {
            try
            {
                AcquireLock();

                InnerList.Add(value);

                return true;
            }
            finally
            {
                ReleaseLock();
            }
        }

        public void TryRemove(SQLNETParallelItem value)
        {
            try
            {
                AcquireLock();
                InnerList.Remove(value);
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
        public bool TryGetValue(int key, out SQLNETParallelItem value)
        {
            bool found;

            try
            {
                var count = InnerList.Count;

                for (int i = 0; i < count; i++)
                {
                    if (i < InnerList.Count)
                    {
                        value = InnerList[i];
                        if (value.ParallelId == key)
                        {
                            return true;
                        }
                    }
                }

                found = false;
                value = default(SQLNETParallelItem);
               
            }
            catch
            {
                // Happen with concurrent remove
                value = default(SQLNETParallelItem);
                found = false;
            }

            if (!found)
            {
                // May happen rarely in concurrency scenario
                // We try again but with a lock
                try
                {
                    AcquireLock();
                    value = InnerList.Find(x => x.ParallelId == key);
                    return true;
                }
                catch (Exception)
                {
                    value = default(SQLNETParallelItem);
                    return false;
                }
                finally
                {
                    ReleaseLock();
                }
            }

            return true;
        }
    }
}