// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

// ReSharper disable InconsistentNaming

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Eval the code or expression and return a small int value.</summary>
        /// <returns>The small int value from the evaluated code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)]
        public SqlInt16 EvalReadAccessSmallInt()
        {
            return EvalSmallInt();
        }

        /// <summary>Eval the code or expression and return a small int value.</summary>
        /// <returns>The small int value from the evaluated code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)]
        public SqlInt16 evalreadaccesssmallint()
        {
            return EvalReadAccessSmallInt();
        }

        /// <summary>Eval the code or expression and return a small int value.</summary>
        /// <returns>The small int value from the evaluated code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)]
        public SqlInt16 EVALREADACCESSSMALLINT()
        {
            return EvalReadAccessSmallInt();
        }
    }
}