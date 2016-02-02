// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Eval the code or expression and return a SQLNET object value.</summary>
        /// <returns>The SQLNET object value from the evaluated code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)]
        public SQLNET EvalSQLNET()
        {
            var value = Eval();

            var sqlnet = New(InternalValueName);
            sqlnet.Item = new SQLNETItem {IsImpersonate = Item.IsImpersonate};
            sqlnet.Val(InternalValueName, value);

            return sqlnet;
        }
    }
}