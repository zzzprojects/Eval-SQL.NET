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
        /// <summary>Registers a global variable.</summary>
        /// <exception cref="Exception">Throws an exception if the global variable name already exists.</exception>
        /// <param name="name">The global variable name.</param>
        /// <param name="value">The global variable value.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext RegisterGlobalVariable(string name, object value)
        {
            if (!AliasGlobalVariables.TryAdd(name, value))
            {
                throw new Exception(string.Format(ExceptionMessage.Unexpected_AliasRegistered, name));
            }
            return this;
        }
    }
}