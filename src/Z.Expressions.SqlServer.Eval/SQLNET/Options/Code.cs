// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

// ReSharper disable InconsistentNaming

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

            if (code != Item.Code)
            {
                Item.Delegate = null;
                Item.Code = code;
            }

            return this;
        }

        /// <summary>Set the code or expression to evaluate.</summary>
        /// <param name="code">The code or expression to evaluate.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET code(string code)
        {
            return Code(code);
        }

        /// <summary>Set the code or expression to evaluate.</summary>
        /// <param name="code">The code or expression to evaluate.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET CODE(string code)
        {
            return Code(code);
        }
    }
}