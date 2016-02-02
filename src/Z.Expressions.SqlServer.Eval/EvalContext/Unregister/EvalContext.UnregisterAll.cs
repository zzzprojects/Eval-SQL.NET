// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Unregisters all kinds of alias (Extension Methods, Names, Static Members, Types and Values).</summary>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext UnregisterAll()
        {
            AliasExtensionMethods.Clear();
            AliasGlobalConstants.Clear();
            AliasGlobalVariables.Clear();
            AliasNames.Clear();
            AliasStaticMembers.Clear();
            AliasTypes.Clear();

            return this;
        }
    }
}