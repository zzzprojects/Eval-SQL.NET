// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Z.Expressions.SqlServer.Eval
{
    public static class DataTableHelper
    {
        /// <summary>Gets a DataTable built from the value.</summary>
        /// <exception cref="Exception">Thrown when an exception error condition occurs.</exception>
        /// <param name="value">The value.</param>
        /// <returns>The DataTable built from the value.</returns>
        public static DataTable GetDataTable(object value)
        {
            DataTable dt;
            if (value is DataSet)
            {
                throw new Exception(string.Format(ExceptionMessage.Unsupported_DataTable_ResultSet, value.GetType()));
            }
            if (value is DataTable)
            {
                dt = (DataTable) value;
            }
            else if (value is IEnumerable && value.GetType().IsGenericType && value.GetType().GetGenericArguments().Length == 1)
            {
                var genericType = value.GetType().GetGenericArguments()[0];

                if (genericType.IsGenericType && (
                    genericType.GetGenericTypeDefinition() == typeof (Tuple)
                    || genericType.GetGenericTypeDefinition() == typeof (Tuple<>)
                    || genericType.GetGenericTypeDefinition() == typeof (Tuple<,>)
                    || genericType.GetGenericTypeDefinition() == typeof (Tuple<,,>)
                    || genericType.GetGenericTypeDefinition() == typeof (Tuple<,,,>)
                    || genericType.GetGenericTypeDefinition() == typeof (Tuple<,,,,>)
                    || genericType.GetGenericTypeDefinition() == typeof (Tuple<,,,,,>)
                    || genericType.GetGenericTypeDefinition() == typeof (Tuple<,,,,,,>)
                    || genericType.GetGenericTypeDefinition() == typeof (Tuple<,,,,,,,>)
                    ))
                {
                    var list = (IEnumerable) value;

                    var properties = genericType.GetProperties();
                    dt = new DataTable();

                    foreach (var property in properties)
                    {
                        dt.Columns.Add(property.Name);
                    }

                    foreach (var item in list)
                    {
                        var dr = dt.NewRow();
                        dt.Rows.Add(dr);

                        foreach (var property in properties)
                        {
                            dr[property.Name] = property.GetValue(item, null);
                        }
                    }
                }
                else if (genericType.IsArray)
                {
                    var list = (IEnumerable) value;

                    dt = new DataTable();

                    foreach (var item in list)
                    {
                        var itemArray = (object[]) item;

                        if (itemArray.Length > dt.Columns.Count)
                        {
                            for (var i = dt.Columns.Count; i < itemArray.Length; i++)
                            {
                                dt.Columns.Add("Value_" + (i + 1));
                            }
                        }

                        var dr = dt.NewRow();
                        dt.Rows.Add(dr);

                        for (var i = 0; i < itemArray.Length; i++)
                        {
                            dr[i] = itemArray[i];
                        }
                    }
                }
                else
                {
                    var list = (IEnumerable) value;

                    dt = new DataTable();
                    dt.Columns.Add("value1");
                    foreach (var item in list)
                    {
                        dt.Rows.Add(item);
                    }
                }
            }
            else if (value is IEnumerable && value.GetType().IsGenericType && value.GetType().GetGenericArguments().Length > 1)
            {
                var list = (IEnumerable)value;

                bool isFirst = false;

                dt = new DataTable();
                dt.Columns.Add("value1");
                foreach (var item in list)
                {
                    dt.Rows.Add(item);
                }
            }
            else if (value is IEnumerable && value.GetType().HasElementType)
            {
                var list = (IEnumerable) value;

                dt = new DataTable();
                dt.Columns.Add("value1");
                foreach (var item in list)
                {
                    dt.Rows.Add(item);
                }
            }
            else if (value is MatchCollection)
            {
                dt = new DataTable();
                dt.Columns.Add("value1");
                foreach (Match item in (MatchCollection)value)
                {
                    dt.Rows.Add(item.Value);
                }
            }
            else
            {
                throw new Exception(string.Format(ExceptionMessage.Unsupported_DataTable_ResultSet, value.GetType()));
            }

            return dt;
        }

        /// <summary>Gets the DataRow collections built from the value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The DataRow collections built from the value.</returns>
        public static IEnumerable<DataRow> GetDataRows(object value)
        {
            var dt = GetDataTable(value);

            var rows = new DataRow[dt.Rows.Count];
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                rows[i] = dt.Rows[i];
            }

            return rows;
        }
    }
}