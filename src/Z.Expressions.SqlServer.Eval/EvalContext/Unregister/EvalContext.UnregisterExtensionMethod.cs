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
        /// <summary>Unregisters all extension methods from the specified types.</summary>
        /// <param name="types">A variable-length parameters list containing types to unregister extension methods from.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext UnregisterExtensionMethod(params Type[] types)
        {
            foreach (var type in types)
            {
                var extensionMethods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(x => x.IsDefined(typeof(ExtensionAttribute), false)).ToArray();

                UnregisterExtensionMethod(extensionMethods);
            }


            return this;
        }

        /// <summary>Unregisters all specified extension methods.</summary>
        /// <param name="extensionMethods">A variable-length parameters list containing extension methods to unregister.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext UnregisterExtensionMethod(params MethodInfo[] extensionMethods)
        {
            foreach (var method in extensionMethods)
            {
#if SQLNET
                Dictionary<MethodInfo, byte> values;
#else
                ConcurrentDictionary<MethodInfo, byte> values;
#endif
                if (AliasExtensionMethods.TryGetValue(method.Name, out values))
                {
                    byte outByte;
                    values.TryRemove(method, out outByte);
                }
            }

            return this;
        }
    }
}