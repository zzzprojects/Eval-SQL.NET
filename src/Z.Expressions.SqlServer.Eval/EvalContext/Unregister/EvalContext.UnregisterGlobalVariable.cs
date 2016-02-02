// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using Z.Expressions.SqlServer.Eval;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Unregisters a global variable.</summary>
        /// <param name="aliases">The global variable name.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext UnregisterGlobalVariable(params string[] aliases)
        {
            foreach (var alias in aliases)
            {
                object value;
                AliasGlobalVariables.TryRemove(alias, out value);
            }

            return this;
        }
    }
}