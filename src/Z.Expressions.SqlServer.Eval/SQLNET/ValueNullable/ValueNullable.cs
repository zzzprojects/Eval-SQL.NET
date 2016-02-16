// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

// ReSharper disable InconsistentNaming

using System;
using System.Data.SqlTypes;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Add or update a value associated with the specified key.</summary>
        /// <param name="key">The key of the value to add or update.</param>
        /// <param name="value">The value to add or update associated with the specified key.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET ValueNullable(SqlString key, object value)
        {
            Type type;
            value = SqlTypeHelper.ConvertToType(value);

            // CHECK for key containing type: int? x
            if (key.Value.Contains(" "))
            {
                var split = key.Value.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (split.Length == 1)
                {
                    type = value.GetType();
                    key = key.Value.Trim();
                }
                else if (split.Length == 2)
                {
                    type = TypeHelper.GetTypeFromName(split[0]);
                    key = split[1];
                }
                else
                {
                    throw new Exception(string.Format(ExceptionMessage.Invalid_ValueKey, key));
                }
            }
            else
            {
                type = value.GetType();
            }

            return ValueInternal(key, type, value);
        }

        /// <summary>Add or update a value associated with the specified key.</summary>
        /// <param name="key">The key of the value to add or update.</param>
        /// <param name="value">The value to add or update associated with the specified key.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET valuenullable(SqlString key, object value)
        {
            return Value(key, value);
        }

        /// <summary>Add or update a value associated with the specified key.</summary>
        /// <param name="key">The key of the value to add or update.</param>
        /// <param name="value">The value to add or update associated with the specified key.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET VALUENULLABLE(SqlString key, object value)
        {
            return Value(key, value);
        }
    }
}