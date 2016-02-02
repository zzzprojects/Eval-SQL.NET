// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Collections;

namespace Z.Expressions
{
    /// <summary>An eval delegate used to cache delegate items.</summary>
    public class EvalDelegate
    {
        /// <summary>The key used to cache the EvalDelegate.</summary>
        public string CacheKey;

        /// <summary>The delegate to cache.</summary>
        public Func<IDictionary, object> Delegate;

        /// <summary>The last access Date/Time of the delegate.</summary>
        public DateTime LastAccess;

        /// <summary>Constructor.</summary>
        /// <param name="cacheKey">The key used to cache the EvalDelegate.</param>
        /// <param name="delegate">The delegate to cache.</param>
        public EvalDelegate(string cacheKey, Func<IDictionary, object> @delegate)
        {
            CacheKey = cacheKey;
            Delegate = @delegate;
            LastAccess = DateTime.Now;
        }
    }
}