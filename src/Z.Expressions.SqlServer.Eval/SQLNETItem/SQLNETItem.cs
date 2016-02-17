// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections;

namespace Z.Expressions.SqlServer.Eval
{
    /// <summary>A SQLNETItem used to compile the code or expression.</summary>
    public class SQLNETItem
    {
        /// <summary>Gets or sets the cache key used to cache the SQLNETItem.</summary>
        public string CacheKey;

        /// <summary>Gets or sets the code or expression to evaluate.</summary>
        public string Code;

        /// <summary>The counter.</summary>
        public int Counter = int.MinValue;

        /// <summary>Gets or sets the compiled code or expression.</summary>
        public EvalDelegate Delegate;

        /// <summary>Gets or sets if the object should AutoDispose once it has been evaluated.</summary>
        public bool IsAutoDispose;

        /// <summary>Gets or sets if this object is cached.</summary>
        public bool IsCached;

        /// <summary>true if this object is root.</summary>
        public bool IsCompiled;

        /// <summary>Gets or sets if an impersonate context should be used to evaluate the code or expression.</summary>
        public bool IsImpersonate;

        /// <summary>Gets or sets the last access Date/Time from the cache.</summary>
        public DateTime LastAccess;

        /// <summary>The parallel values.</summary>
        public SharedBucketList ParallelItems;

        /// <summary>Gets or sets the parameter table used to evaluate the code or expression.</summary>
        public ListDictionary ParameterTables;

        /// <summary>Gets or sets the parameter types used to evaluate the code or expression.</summary>
        public SharedCache<string, Type> ParameterTypes;

        /// <summary>Gets or sets the parameter values used to evaluate the code or expression.</summary>
        public ListDictionary ParameterValues;

        public bool IsFirstCounter = true;

        /// <summary>Default constructor.</summary>
        public SQLNETItem()
        {
            CacheKey = Guid.NewGuid().ToString();
            ParameterTables = new ListDictionary();
            ParameterTypes = new SharedCache<string, Type>();
            ParameterValues = new ListDictionary();
            ParallelItems = new SharedBucketList();
        }

        /// <summary>Gets the next counter.</summary>
        /// <returns>The next counter.</returns>
        public int GetNextCountAndAddParallel()
        {
            try
            {
                SharedLock.AcquireLock(ref EvalManager.SharedLock.CacheItemLock);
                Counter++;

                if (Counter == 0)
                {
                    Counter++;
                }

                return Counter;
            }
            finally
            {
                SharedLock.ReleaseLock(ref EvalManager.SharedLock.CacheItemLock);
            }
        }

        public SQLNETParallelItem AddParallelValue(int parallelId)
        {
            var value = new SQLNETParallelItem
            {
                ParallelId = parallelId
            };

            ParallelItems.TryAdd(value);

            if (ParameterValues.Count > 0)
            {
                foreach (DictionaryEntry entry in ParameterValues)
                {
                    value.ParameterValues.Add(entry.Key, entry.Value);
                }
            }

            return value;
        }

        public SQLNETParallelItem GetParallelValue(int parallelId)
        {
            SQLNETParallelItem value;
            if (!ParallelItems.TryGetValue(parallelId, out value))
            {
                throw new Exception(ExceptionMessage.GeneralException);
            }

            return value;
        }
    }
}