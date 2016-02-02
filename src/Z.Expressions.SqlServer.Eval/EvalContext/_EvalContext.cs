// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Z.Expressions
{
    /// <summary>The eval context used to compile the code or expression.</summary>
    public partial class EvalContext
    {
#if SQLNET
        public EvalContext()
        {
            AliasExtensionMethods = new Dictionary<string, Dictionary<MethodInfo, byte>>();
            AliasGlobalConstants = new Dictionary<string, ConstantExpression>();
            AliasGlobalVariables = new Dictionary<string, object>();
            AliasNames = new Dictionary<string, string>();
            AliasStaticMembers = new Dictionary<string, Dictionary<MemberInfo, byte>>();
            AliasTypes = new Dictionary<string, Type>();
            BindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
            CacheKeyPrefix = GetType().FullName;
            UseCaretForExponent = false;

            RegisterDefaultAlias();

            ExpireCacheNextScheduled = DateTime.Now.Add(ExpireCacheDelay);
        }

        /// <summary>The delay between expire cache call.</summary>
        public TimeSpan ExpireCacheDelay = TimeSpan.FromMinutes(5);

        /// <summary>The sliding expiration for delegate cache.</summary>
        public TimeSpan SlidingExpirationDelegate = TimeSpan.FromHours(2);

        /// <summary>The sliding expiration for item cache.</summary>
        public TimeSpan SlidingExpirationItem = TimeSpan.FromMinutes(3);

        /// <summary>The expire cache next scheduled Date/Time.</summary>
        public DateTime ExpireCacheNextScheduled;

        /// <summary>Gets or sets the alias list for extension methods.</summary>
        /// <value>The alias list for extension methods.</value>
        public Dictionary<string, Dictionary<MethodInfo, byte>> AliasExtensionMethods { get; set; }

        /// <summary>Gets or sets the alias list for global constants.</summary>
        /// <value>The alias list for global constants.</value>
        public Dictionary<string, ConstantExpression> AliasGlobalConstants { get; set; }

        /// <summary>Gets or sets the alias list for global variables.</summary>
        /// <value>The alias list for global variables.</value>
        public Dictionary<string, object> AliasGlobalVariables { get; set; }

        /// <summary>Gets or sets the alias list for names.</summary>
        /// <value>The alias list for names.</value>
        public Dictionary<string, string> AliasNames { get; set; }

        /// <summary>Gets or sets the alias list for static members.</summary>
        /// <value>The alias list for static members.</value>
        public Dictionary<string, Dictionary<MemberInfo, byte>> AliasStaticMembers { get; set; }

        /// <summary>Gets or sets the alias list for types.</summary>
        /// <value>The alias list for types.</value>
        public Dictionary<string, Type> AliasTypes { get; set; }
#else
           public EvalContext()
        {
            AliasExtensionMethods = new ConcurrentDictionary<string, ConcurrentDictionary<MethodInfo, byte>>();
            AliasGlobalConstants = new ConcurrentDictionary<string, ConstantExpression>();
            AliasGlobalVariables = new ConcurrentDictionary<string, object>();
            AliasNames = new ConcurrentDictionary<string, string>();
            AliasStaticMembers = new ConcurrentDictionary<string, ConcurrentDictionary<MemberInfo, byte>>();
            AliasTypes = new ConcurrentDictionary<string, Type>();
            BindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
            CacheKeyPrefix = GetType().FullName;
            UseCaretForExponent = false;

            RegisterDefaultAlias();
        }

        /// <summary>Gets or sets the alias list for extension methods.</summary>
        /// <value>The alias list for extension methods.</value>
        public ConcurrentDictionary<string, ConcurrentDictionary<MethodInfo, byte>> AliasExtensionMethods { get; set; }

        /// <summary>Gets or sets the alias list for global constants.</summary>
        /// <value>The alias list for global constants.</value>
        public ConcurrentDictionary<string, ConstantExpression> AliasGlobalConstants { get; set; }

        /// <summary>Gets or sets the alias list for global variables.</summary>
        /// <value>The alias list for global variables.</value>
        public ConcurrentDictionary<string, object> AliasGlobalVariables { get; set; }

        /// <summary>Gets or sets the alias list for names.</summary>
        /// <value>The alias list for names.</value>
        public ConcurrentDictionary<string, string> AliasNames { get; set; }

        /// <summary>Gets or sets the alias list for static members.</summary>
        /// <value>The alias list for static members.</value>
        public ConcurrentDictionary<string, ConcurrentDictionary<MemberInfo, byte>> AliasStaticMembers { get; set; }

        /// <summary>Gets or sets the alias list for types.</summary>
        /// <value>The alias list for types.</value>
        public ConcurrentDictionary<string, Type> AliasTypes { get; set; }
#endif

        /// <summary>Gets or sets the binding flags used to resolve members in the compiler.</summary>
        /// <value>The binding flags used to resolve members in the compiler.</value>
        public BindingFlags BindingFlags { get; set; }

        /// <summary>Gets or sets the cache key prefix used for the compiled code or expression cache.</summary>
        /// <value>The cache key prefix used for the compiled code or expression cache.</value>
        public string CacheKeyPrefix { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the compiler should use caret for exponent expression instead of XOR
        ///     expression.
        /// </summary>
        /// <value>true if the caret should be used for exponent, false if not.</value>
        public bool UseCaretForExponent { get; set; }
    }
}