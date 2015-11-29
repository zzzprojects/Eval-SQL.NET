// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Gets the string value associated with the specified key.</summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The string value associated with the specified key.</returns>
        [return: SqlFacet(MaxSize = -1)]
        public SqlString GetValueString(string key)
        {
            var value = GetValue(key);
            return value == DBNull.Value ? null : new SqlString(value.ToString());
        }
    }
}