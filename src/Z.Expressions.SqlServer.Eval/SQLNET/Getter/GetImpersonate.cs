// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Gets the value if the context should use an impersonate context to evaluate the code or expression.</summary>
        /// <returns>true if the context should use an impersonate context to evaluate the code or expressions, otherwise false.</returns>
        public bool GetImpersonate()
        {
            return Item.IsImpersonate;
        }
    }
}