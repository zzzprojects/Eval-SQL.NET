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
        /// <summary>Gets the value if the context should use an impersonate context to evaluate the code or expression.</summary>
        /// <returns>true if the context should use an impersonate context to evaluate the code or expressions, otherwise false.</returns>
        public bool GetImpersonate()
        {
            return Item.IsImpersonate;
        }

        /// <summary>Gets the value if the context should use an impersonate context to evaluate the code or expression.</summary>
        /// <returns>true if the context should use an impersonate context to evaluate the code or expressions, otherwise false.</returns>
        public bool getimpersonate()
        {
            return Item.IsImpersonate;
        }

        /// <summary>Gets the value if the context should use an impersonate context to evaluate the code or expression.</summary>
        /// <returns>true if the context should use an impersonate context to evaluate the code or expressions, otherwise false.</returns>
        public bool GETIMPERSONATE()
        {
            return Item.IsImpersonate;
        }
    }
}