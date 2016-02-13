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
        /// <summary>Gets the code or expression to evaluate.</summary>
        /// <returns>The code or expression to evaluate.</returns>
        public string GetCode()
        {
            return Item.Code;
        }

        /// <summary>Gets the code or expression to evaluate.</summary>
        /// <returns>The code or expression to evaluate.</returns>
        public string getcode()
        {
            return Item.Code;
        }

        /// <summary>Gets the code or expression to evaluate.</summary>
        /// <returns>The code or expression to evaluate.</returns>
        public string GETCODE()
        {
            return Item.Code;
        }
    }
}