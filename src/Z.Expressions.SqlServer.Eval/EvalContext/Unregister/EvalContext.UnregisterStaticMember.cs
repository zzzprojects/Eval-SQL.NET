// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections.Generic;
using System.Reflection;
using Z.Expressions.SqlServer.Eval;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Unregisters static member from specified types.</summary>
        /// <param name="types">A variable-length parameters list containing types to unregister static members from.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext UnregisterStaticMember(params Type[] types)
        {
            foreach (var type in types)
            {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static);
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);

                UnregisterStaticMember(fields);
                UnregisterStaticMember(properties);
                UnregisterStaticMember(methods);
            }

            return this;
        }

        /// <summary>Unregisters static member from specified types.</summary>
        /// <param name="members">A variable-length parameters list containing members.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext UnregisterStaticMember(params MemberInfo[] members)
        {
            foreach (var member in members)
            {
#if SQLNET
                Dictionary<MemberInfo, byte> values;
#else
                ConcurrentDictionary<MemberInfo, byte> values;
#endif
                if (AliasStaticMembers.TryGetValue(member.Name, out values))
                {
                    byte outByte;
                    values.TryRemove(member, out outByte);
                }
            }

            return this;
        }
    }
}