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
        /// <summary>Gets the value associated with the specified key.</summary>
        /// <exception cref="Exception">Throws an exception if no value is associated with the specified key.</exception>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public object GetValue(string key)
        {
            object value;

            if (Item.ParameterValues.TryGetValue(key, out value))
            {
                return value;
            }

            throw new Exception(string.Format(ExceptionMessage.Unexpected_ParameterKeyNotFound, key));
        }

        /// <summary>Gets the value associated with the specified key.</summary>
        /// <exception cref="Exception">Throws an exception if no value is associated with the specified key.</exception>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public object getvalue(string key)
        {
            return GetValue(key);
        }

        /// <summary>Gets the value associated with the specified key.</summary>
        /// <exception cref="Exception">Throws an exception if no value is associated with the specified key.</exception>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public object GETVALUE(string key)
        {
            return GetValue(key);
        }
    }
}