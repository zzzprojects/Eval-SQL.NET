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
        /// <summary>Set the code or expression to evaluate.</summary>
        /// <param name="code">The code or expression to evaluate.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET Code(string code)
        {
            if (code.Contains("defaultCommand") && !code.Contains("new SqlConnection("))
            {
                code = TemplateConnection.Replace("[SQLNET_Code]", code);
            }

            Item.Delegate = null;
            Item.Code = code;
            return this;
        }
    }
}