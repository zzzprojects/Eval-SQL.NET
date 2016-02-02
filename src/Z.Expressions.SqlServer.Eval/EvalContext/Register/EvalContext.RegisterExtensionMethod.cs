// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Z.Expressions.SqlServer.Eval;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Registers all extension methods from specified types.</summary>
        /// <param name="types">A variable-length parameters list containing types to register extension methods from.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext RegisterExtensionMethod(params Type[] types)
        {
            foreach (var type in types)
            {
                var extensionMethods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(x => x.IsDefined(typeof(ExtensionAttribute), false)).ToArray();

                RegisterExtensionMethod(extensionMethods);
            }

            return this;
        }

        /// <summary>Registers all specified extension methods.</summary>
        /// <param name="extensionMethods">A variable-length parameters list containing extension methods to register.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext RegisterExtensionMethod(params MethodInfo[] extensionMethods)
        {
            foreach (var method in extensionMethods)
            {
                AliasExtensionMethods.AddOrUpdate(method.Name, s =>
                {
#if SQLNET
                    var dict = new Dictionary<MethodInfo, byte>();
#else
                    var dict = new ConcurrentDictionary<MethodInfo, byte>();
#endif
                    dict.TryAdd(method, (byte)1);
                    return dict;
                }, (s, list) =>
                {
                    list.TryAdd(method, (byte)1);
                    return list;
                });
            }

            return this;
        }
    }
}