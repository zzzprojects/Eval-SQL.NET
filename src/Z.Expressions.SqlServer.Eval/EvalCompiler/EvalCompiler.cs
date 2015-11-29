// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Z.Expressions.CodeAnalysis.CSharp;
using Z.Expressions.CodeCompiler.CSharp;

namespace Z.Expressions
{
    /// <summary>An eval expression compiler used to compile the code or expression.</summary>
    internal static partial class EvalCompiler
    {
        /// <summary>Property info for the IDictionary Item indexer used in ResolveParameter methods.</summary>
        private static readonly PropertyInfo DictionaryItemPropertyInfo = typeof (IDictionary).GetProperty("Item", new[] {typeof (string)});

        /// <summary>Compile the code or expression and return a TDelegate of type Func or Action to execute.</summary>
        /// <param name="context">The eval context used to compile the code or expression.</param>
        /// <param name="code">The code or expression to compile.</param>
        /// <param name="parameterTypes">The dictionary of parameter (name / type) used in the code or expression to compile.</param>
        /// <param name="resultType">Type of the compiled code or expression result.</param>
        /// <returns>A TDelegate of type Func or Action that represents the compiled code or expression.</returns>
        internal static EvalDelegate Compile(EvalContext context, string code, IDictionary<string, Type> parameterTypes, Type resultType)
        {
            var cacheKey = ResolveCacheKey(context, typeof (Func<IDictionary, object>), code, parameterTypes);

            EvalDelegate cachedDelegate;
            if (EvalManager.CacheDelegate.TryGetValue(cacheKey, out cachedDelegate))
            {
                return cachedDelegate;
            }

            // Options
            var scope = new ExpressionScope
            {
                AliasExtensionMethods = context.AliasExtensionMethods,
                AliasNames = context.AliasNames,
                AliasStaticMembers = context.AliasStaticMembers,
                AliasTypes = context.AliasTypes,
                BindingFlags = context.BindingFlags,
                UseCaretForExponent = context.UseCaretForExponent
            };

            // ADD global constants
            if (context.AliasGlobalConstants.Count > 0)
            {
                scope.Constants = new Dictionary<string, ConstantExpression>(context.AliasGlobalConstants);
            }

            // ADD global variables
            if (context.AliasGlobalVariables.Count > 0)
            {
                foreach (var keyValue in context.AliasGlobalVariables)
                {
                    scope.CreateLazyVariable(keyValue.Key, new Lazy<Expression>(() =>
                    {
                        var innerParameter = scope.CreateVariable(keyValue.Value.GetType(), keyValue.Key);
                        var innerExpression = Expression.Assign(innerParameter, Expression.Constant(keyValue.Value));
                        scope.Expressions.Add(innerExpression);
                        return innerParameter;
                    }));
                }
            }

            // Resolve Parameter
            var parameterExpressions = ResolveParameter(scope, parameterTypes);

            // CodeAnalysis
            var syntaxRoot = SyntaxParser.ParseText(code);

            // CodeCompiler
            var expression = ExpressionParser.ParseSyntax(scope, syntaxRoot, resultType);

            // Compile the expression
            var compiled = Expression.Lambda<Func<IDictionary, object>>(expression, parameterExpressions).Compile();

            var evalDelegate = new EvalDelegate(cacheKey, compiled);
            EvalManager.CacheDelegate.TryAdd(cacheKey, evalDelegate);

            return evalDelegate;
        }
    }
}