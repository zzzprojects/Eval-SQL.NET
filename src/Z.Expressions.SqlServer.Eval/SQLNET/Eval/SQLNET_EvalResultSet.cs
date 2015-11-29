// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Collections;
using System.Data;
using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Eval the code or expression and return a result set.</summary>
        /// <exception cref="Exception">Throw an exception if the result from the code or expression is unsupported.</exception>
        /// <param name="sqlnet">The SQLNET object to evaluate.</param>
        [SqlProcedure]
        public static void SQLNET_EvalResultSet(SQLNET sqlnet)
        {
            var value = sqlnet.Eval();

            if (value is DataSet)
            {
                var ds = (DataSet) value;
                SqlContextHelper.SendDataSet(ds);
            }
            else if (value is DataTable)
            {
                var dt = (DataTable) value;
                SqlContextHelper.SendDataTable(dt);
            }
            else if (value is IEnumerable && value.GetType().IsGenericType && value.GetType().GetGenericArguments().Length == 1)
            {
                var list = (IEnumerable) value;

                var dt = new DataTable();
                dt.Columns.Add("value");
                foreach (var item in list)
                {
                    dt.Rows.Add(item);
                }

                SqlContextHelper.SendDataTable(dt);
            }
            else
            {
                throw new Exception(string.Format(ExceptionMessage.InvalidResultSet, value.GetType()));
            }
        }
    }
}