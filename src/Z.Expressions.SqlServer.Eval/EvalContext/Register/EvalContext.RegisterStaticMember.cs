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
        /// <summary>Registers static member from specified types.</summary>
        /// <param name="types">A variable-length parameters list containing types to register static members from.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext RegisterStaticMember(params Type[] types)
        {
            foreach (var type in types)
            {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static);
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);

                RegisterStaticMember(fields);
                RegisterStaticMember(properties);
                RegisterStaticMember(methods);
            }

            return this;
        }

        /// <summary>Registers specified static members.</summary>
        /// <param name="members">A variable-length parameters list containing members to register.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext RegisterStaticMember(params MemberInfo[] members)
        {
            foreach (var member in members)
            {
                AliasStaticMembers.AddOrUpdate(member.Name, s =>
                {
#if SQLNET
                    var dict = new Dictionary<MemberInfo, byte>();
#else
                    var dict = new ConcurrentDictionary<MemberInfo, byte>();
#endif
                    dict.TryAdd(member, (byte) 1);
                    return dict;
                }, (s, list) =>
                {
                    list.TryAdd(member, (byte) 1);
                    return list;
                });
            }

            return this;
        }
    }
}