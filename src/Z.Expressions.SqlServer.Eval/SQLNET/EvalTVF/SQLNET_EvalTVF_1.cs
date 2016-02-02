// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Collections;
using System.Data;
using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        [SqlFunction(DataAccess = DataAccessKind.Read, FillRowMethodName = "Fill_SQLNET_EvalTVF_1", TableDefinition = "Value_1 sql_variant")]
        public static IEnumerable SQLNET_EvalTVF_1(SQLNET sqlnet)
        {
            var obj = sqlnet.Eval();
            return DataTableHelper.GetDataRows(obj);
        }

        public static void Fill_SQLNET_EvalTVF_1(object obj, out object value1)
        {
            var row = (DataRow) obj;
            value1 = row[0];
        }
    }
}