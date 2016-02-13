// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

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