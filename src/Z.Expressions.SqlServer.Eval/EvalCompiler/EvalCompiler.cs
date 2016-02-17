// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

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
        internal static EvalDelegate CompileSQLNET(EvalContext context, string code, IDictionary<string, Type> parameterTypes, Type resultType)
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
#if SQLNET
                    scope.CreateLazyVariable(keyValue.Key, new LazySingleThread<Expression>(() =>
#else
                    scope.CreateLazyVariable(keyValue.Key, new Lazy<Expression>(() =>
#endif
                    {
                        var innerParameter = scope.CreateVariable(keyValue.Value.GetType(), keyValue.Key);
                        var innerExpression = Expression.Assign(innerParameter, Expression.Constant(keyValue.Value));
                        scope.Expressions.Add(innerExpression);
                        return innerParameter;
                    }));
                }
            }

            // Resolve Parameter
            var parameterExpressions = ResolveParameter(scope, EvalCompilerParameterKind.Dictionary, parameterTypes);

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

        /// <summary>Compile the code or expression and return a TDelegate of type Func or Action to execute.</summary>
        /// <typeparam name="TDelegate">Type of the delegate (Func or Action) to use to compile the code or expression.</typeparam>
        /// <param name="context">The eval context used to compile the code or expression.</param>
        /// <param name="code">The code or expression to compile.</param>
        /// <param name="parameterTypes">The dictionary of parameter (name / type) used in the code or expression to compile.</param>
        /// <param name="resultType">Type of the compiled code or expression result.</param>
        /// <param name="parameterKind">The parameter kind for the code or expression to compile.</param>
        /// <returns>A TDelegate of type Func or Action that represents the compiled code or expression.</returns>
        internal static TDelegate Compile<TDelegate>(EvalContext context, string code, IDictionary<string, Type> parameterTypes, Type resultType, EvalCompilerParameterKind parameterKind)
        {
            var cacheKey = ResolveCacheKey(context, typeof (Func<IDictionary, object>), code, parameterTypes);

            EvalDelegate cachedDelegate;
            if (EvalManager.CacheDelegate.TryGetValue(cacheKey, out cachedDelegate))
            {
                return (TDelegate) cachedDelegate.InnerDelegate;
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

            // Resolve Parameter
            var parameterExpressions = ResolveParameter(scope, parameterKind, parameterTypes);

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
                    scope.CreateLazyVariable(keyValue.Key, new LazySingleThread<Expression>(() =>
                    {
                        var innerParameter = scope.CreateVariable(keyValue.Value.GetType(), keyValue.Key);
                        var innerExpression = Expression.Assign(innerParameter, Expression.Constant(keyValue.Value));
                        scope.Expressions.Add(innerExpression);
                        return innerParameter;
                    }));
                }
            }

            // CodeAnalysis
            var syntaxRoot = SyntaxParser.ParseText(code);

            // CodeCompiler
            var expression = ExpressionParser.ParseSyntax(scope, syntaxRoot, resultType);

            // Compile the expression
            var compiled = Expression.Lambda<TDelegate>(expression, parameterExpressions).Compile();

            var evalDelegate = new EvalDelegate(cacheKey, null);
            evalDelegate.InnerDelegate = compiled;

            EvalManager.CacheDelegate.TryAdd(cacheKey, evalDelegate);

            return compiled;
        }
    }
}