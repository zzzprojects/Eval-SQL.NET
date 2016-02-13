// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using Z.Expressions.SqlServer.Eval;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Unregisters specified types using Type.Name and Type.FullName as alias.</summary>
        /// <param name="types">A variable-length parameters list containing types to unregister.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext UnregisterType(params Type[] types)
        {
            foreach (var type in types)
            {
                Type outType;

                AliasTypes.TryRemove(type.Name, out outType);
                AliasTypes.TryRemove(type.FullName, out outType);
            }
            return this;
        }
    }
}