// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

namespace Z.Expressions
{
    /// <summary>Values that represent the ParameterKind for the EvalCompiler.</summary>
    public enum EvalCompilerParameterKind
    {
        None,
        Dictionary,
        Enumerable,
        SingleDictionary,
        SingleObject,
        Typed,
        Untyped
    }
}