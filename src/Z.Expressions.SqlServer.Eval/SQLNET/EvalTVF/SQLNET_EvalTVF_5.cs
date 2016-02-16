// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System.Collections;
using System.Data;
using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        [SqlFunction(DataAccess = DataAccessKind.None, SystemDataAccess = SystemDataAccessKind.None, FillRowMethodName = "Fill_SQLNET_EvalTVF_5", TableDefinition = "Value_1 sql_variant, Value_2 sql_variant, Value_3 sql_variant, Value_4 sql_variant, Value_5 sql_variant")]
        public static IEnumerable SQLNET_EvalTVF_5(SQLNET sqlnet)
        {
            var obj = sqlnet.Eval();
            return DataTableHelper.GetDataRows(obj);
        }

        public static void Fill_SQLNET_EvalTVF_5(object obj, out object value1, out object value2, out object value3, out object value4, out object value5)
        {
            var row = (DataRow) obj;
            value1 = row[0];
            value2 = row[1];
            value3 = row[2];
            value4 = row[3];
            value5 = row[4];
        }
    }
}