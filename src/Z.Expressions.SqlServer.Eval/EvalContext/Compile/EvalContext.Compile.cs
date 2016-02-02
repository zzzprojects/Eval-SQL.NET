// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Collections.Generic;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Compile the code or expression and return a delegate of type Func to execute.</summary>
        /// <param name="code">The code or expression to compile.</param>
        /// <param name="parameterTypes">Parameter types used to compile the code or expression.</param>
        /// <returns>A delegate of type Func that represents the compiled code or expression.</returns>
        public EvalDelegate Compile(string code, ListDictionary parameterTypes)
        {
            return EvalCompiler.Compile(this, code, parameterTypes, typeof (object));
        }
    }
}