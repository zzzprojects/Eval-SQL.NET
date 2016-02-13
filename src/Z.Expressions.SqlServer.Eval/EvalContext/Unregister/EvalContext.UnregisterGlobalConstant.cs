// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System.Linq.Expressions;
using Z.Expressions.SqlServer.Eval;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Unregisters a global constant.</summary>
        /// <param name="aliases">The global constant name.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext UnregisterGlobalConstant(params string[] aliases)
        {
            foreach (var alias in aliases)
            {
                ConstantExpression value;
                AliasGlobalConstants.TryRemove(alias, out value);
            }

            return this;
        }
    }
}