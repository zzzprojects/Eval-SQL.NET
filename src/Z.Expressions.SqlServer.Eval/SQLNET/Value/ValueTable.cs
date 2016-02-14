// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

// ReSharper disable InconsistentNaming

using System.Data;
using System.Data.SqlTypes;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Add or update a string value associated with the specified key.</summary>
        /// <param name="key">The key of the value to add or update.</param>
        /// <param name="value">The string value to add or update associated with the specified key.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET ValueTable(SqlString key, string value)
        {
            var type = typeof (DataTable);

            object oldValue;
            if (Item.ParameterTables.TryGetValue(key, out oldValue))
            {
                if (!oldValue.Equals(value))
                {
                    Item.ParameterTables[key] = value;
                }

                Item.ParameterTypes[key] = type;
                Item.ParameterValues[key] = new DataTable();
            }
            else
            {
                Item.ParameterTables.Add(key, value);
                Item.ParameterTypes.Add(key, type);
                Item.ParameterValues.Add(key, new DataTable());
            }
            return this;


            //// 
            //object oldType;
            //if (Item.ParameterTypes.TryGetValue(key, out oldType))
            //{
            //    if (!Equals(oldType, type))
            //    {
            //        Item.ParameterTypes[key] = type;
            //        Item.Delegate = null;
            //    }

            //    Item.ParameterValues[key] = value;
            //}
            //else
            //{
            //    Item.ParameterTypes.Add(key, type);
            //    Item.ParameterValues.Add(key, value);
            //}

            //return this;


            //Val("DataTable " + key, value);

            //object oldValue;
            //if (Item.ParameterTables.TryGetValue(key, out oldValue))
            //{
            //    if (!oldValue.Equals(value))
            //    {
            //        Item.ParameterTables[key] = value;
            //    }
            //}
            //else
            //{
            //    Item.ParameterTables.Add(key, value);
            //}
            //return this;
        }

        /// <summary>Add or update a string value associated with the specified key.</summary>
        /// <param name="key">The key of the value to add or update.</param>
        /// <param name="value">The string value to add or update associated with the specified key.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET valuetable(SqlString key, string value)
        {
            return ValueTable(key, value);
        }

        /// <summary>Add or update a string value associated with the specified key.</summary>
        /// <param name="key">The key of the value to add or update.</param>
        /// <param name="value">The string value to add or update associated with the specified key.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET VALUETABLE(SqlString key, string value)
        {
            return ValueTable(key, value);
        }
    }
}