// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Reflection;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Unregisters all types from all specified assemblies.</summary>
        /// <param name="assemblies">A variable-length parameters list containing assemblies to unregister type from.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext UnregisterAssembly(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                UnregisterType(types);
            }

            return this;
        }
    }
}