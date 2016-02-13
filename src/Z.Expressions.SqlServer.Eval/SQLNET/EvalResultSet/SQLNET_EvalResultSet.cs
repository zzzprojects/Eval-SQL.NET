// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Data;
using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Eval the code or expression and return a result set.</summary>
        /// <exception cref="Exception">Throw an exception if the result from the code or expression is not supported.</exception>
        /// <param name="sqlnet">The SQLNET object to evaluate.</param>
        [SqlProcedure]
        public static void SQLNET_EvalResultSet(SQLNET sqlnet)
        {
            var value = sqlnet.Eval();

            if (value is DataTable)
            {
                SqlContextHelper.SendDataTable((DataTable) value);
                return;
            }

            if (value is DataSet)
            {
                var ds = (DataSet) value;
                SqlContextHelper.SendDataSet(ds);
                return;
            }

            SqlContextHelper.SendDataTable(DataTableHelper.GetDataTable(value));
        }
    }
}