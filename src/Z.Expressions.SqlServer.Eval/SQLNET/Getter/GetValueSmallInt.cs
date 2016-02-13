// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;

// ReSharper disable InconsistentNaming

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Gets the small int value associated with the specified key.</summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The small int value associated with the specified key.</returns>
        public short? GetValueSmallInt(string key)
        {
            var value = GetValue(key);
            return value == DBNull.Value ? (short?) null : Convert.ToInt16(value);
        }

        /// <summary>Gets the small int value associated with the specified key.</summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The small int value associated with the specified key.</returns>
        public short? getvaluesmallint(string key)
        {
            return GetValueSmallInt(key);
        }

        /// <summary>Gets the small int value associated with the specified key.</summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The small int value associated with the specified key.</returns>
        public short? GETVALUESMALLINT(string key)
        {
            return GetValueSmallInt(key);
        }
    }
}