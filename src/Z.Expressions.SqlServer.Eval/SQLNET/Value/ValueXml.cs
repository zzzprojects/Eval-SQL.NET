// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Data.SqlTypes;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Add or update a xml value associated with the specified key.</summary>
        /// <param name="key">The key of the value to add or update.</param>
        /// <param name="value">The xml value to add or update associated with the specified key.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET ValueXml(string key, SqlXml value)
        {
            Val(key, value);
            return this;
        }
    }
}