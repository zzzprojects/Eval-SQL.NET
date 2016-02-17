// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Z.Expressions.CodeCompiler.CSharp;

namespace Z.Expressions
{
    internal static partial class EvalCompiler
    {
        /// <summary>Resolve parameters used for the code or expression.</summary>
        /// <param name="scope">The expression scope for the code or expression to compile.</param>
        /// <param name="parameterKind">The parameter kind for the code or expression to compile.</param>
        /// <param name="parameterTypes">The dictionary of parameter (name / type) used in the code or expression to compile.</param>
        /// <returns>A ParameterExpression list used in code or expression to compile.</returns>
        private static List<ParameterExpression> ResolveParameter(ExpressionScope scope, EvalCompilerParameterKind parameterKind, IDictionary<string, Type> parameterTypes)
        {
            if (parameterTypes == null) return null;

            List<ParameterExpression> parameterExpressions;

            switch (parameterKind)
            {
                case EvalCompilerParameterKind.Dictionary:
                    parameterExpressions = ResolveParameterDictionary(scope, parameterTypes);
                    break;
                case EvalCompilerParameterKind.Enumerable:
                    parameterExpressions = ResolveParameterEnumerable(scope, parameterTypes);
                    break;
                case EvalCompilerParameterKind.SingleDictionary:
                    parameterExpressions = ResolveParameterSingleDictionary(scope, parameterTypes);
                    break;
                case EvalCompilerParameterKind.Typed:
                    parameterExpressions = ResolveParameterTyped(scope, parameterTypes);
                    break;
                case EvalCompilerParameterKind.Untyped:
                    parameterExpressions = ResolveParameterUntyped(scope, parameterTypes);
                    break;
                default:
                    parameterExpressions = new List<ParameterExpression>();
                    break;
            }

            return parameterExpressions;
        }
    }
}