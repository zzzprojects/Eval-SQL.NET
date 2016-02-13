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
        /// <summary>Registers an alias for a variable, constant or type name.</summary>
        /// <exception cref="Exception">Throws an exception if the alias already exists.</exception>
        /// <param name="alias">The alias to register.</param>
        /// <param name="name">The variable, constant or type name to register for the specified alias.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext RegisterAlias(string alias, string name)
        {
            if (!AliasNames.TryAdd(alias, name))
            {
                throw new Exception(string.Format(ExceptionMessage.Unexpected_AliasRegistered, alias));
            }

            return this;
        }
    }
}