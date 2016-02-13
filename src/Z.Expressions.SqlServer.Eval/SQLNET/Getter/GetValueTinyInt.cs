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
        /// <summary>Gets the tiny int value associated with the specified key.</summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The tiny int value associated with the specified key.</returns>
        public byte? GetValueTinyInt(string key)
        {
            var value = GetValue(key);
            return value == DBNull.Value ? (byte?) null : Convert.ToByte(value);
        }

        /// <summary>Gets the tiny int value associated with the specified key.</summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The tiny int value associated with the specified key.</returns>
        public byte? getvaluetinyint(string key)
        {
            return GetValueTinyInt(key);
        }

        /// <summary>Gets the tiny int value associated with the specified key.</summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The tiny int value associated with the specified key.</returns>
        public byte? GETVALUETINYINT(string key)
        {
            return GetValueTinyInt(key);
        }
    }
}