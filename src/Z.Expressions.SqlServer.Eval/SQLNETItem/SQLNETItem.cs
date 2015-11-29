// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Collections.Generic;

namespace Z.Expressions.SqlServer.Eval
{
    /// <summary>A SQLNETItem used to compile the code or expression.</summary>
    [Serializable]
    public class SQLNETItem
    {
        /// <summary>True if the object should AutoDipose once it's has been evaluated.</summary>
        public bool AutoDispose;

        /// <summary>The cache key used to cache the SQLNETItem.</summary>
        public string CacheKey = Guid.NewGuid().ToString();

        /// <summary>The code or expression to evaluate.</summary>
        public string Code;

        /// <summary>The default context used to compile the code or expression.</summary>
        public EvalContext Context = EvalManager.DefaultContext;

        /// <summary>The compiled code or expression.</summary>
        public EvalDelegate Delegate;

        /// <summary>true if this object is cached.</summary>
        public bool IsCached;

        /// <summary>The last access Date/Time from the cache.</summary>
        public DateTime LastAccess;

        /// <summary>The parameter values used to evaluate the code or expression.</summary>
        public Dictionary<string, object> Parameters = new Dictionary<string, object>();

        /// <summary>true to use an impersonate context to evaluate the code or expression.</summary>
        public bool UseImpersonate;
    }
}