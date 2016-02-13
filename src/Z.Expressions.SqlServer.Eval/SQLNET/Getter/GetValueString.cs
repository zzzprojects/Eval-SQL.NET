// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

// ReSharper disable InconsistentNaming

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

        /// <summary>Gets the string value associated with the specified key.</summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The string value associated with the specified key.</returns>
        [return: SqlFacet(MaxSize = -1)]
        public SqlString getvaluestring(string key)
        {
            return GetValueString(key);
        }

        /// <summary>Gets the string value associated with the specified key.</summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The string value associated with the specified key.</returns>
        [return: SqlFacet(MaxSize = -1)]
        public SqlString GETVALUESTRING(string key)
        {
            return GetValueString(key);
        }
    }
}