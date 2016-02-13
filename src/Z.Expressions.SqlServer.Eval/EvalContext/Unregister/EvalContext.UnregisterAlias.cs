// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using Z.Expressions.SqlServer.Eval;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Unregisters all alias for a variable, constant or type name.</summary>
        /// <param name="aliases">A variable-length parameters list containing alias to unregister.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext UnregisterAlias(params string[] aliases)
        {
            foreach (var alias in aliases)
            {
                string value;
                AliasNames.TryRemove(alias, out value);
            }

            return this;
        }
    }
}