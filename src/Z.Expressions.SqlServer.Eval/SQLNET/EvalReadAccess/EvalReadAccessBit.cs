// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using Microsoft.SqlServer.Server;

// ReSharper disable InconsistentNaming

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Eval the code or expression and return a bit value.</summary>
        /// <returns>The bit value from the evaluated code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)]
        public bool? EvalReadAccessBit()
        {
            var value = Eval();

            return value == null || value == DBNull.Value ? (bool?) null : Convert.ToBoolean(value);
        }

        /// <summary>Eval the code or expression and return a bit value.</summary>
        /// <returns>The bit value from the evaluated code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)]
        public bool? evalreadaccessbit()

        {
            return EvalBit();
        }

        /// <summary>Eval the code or expression and return a bit value.</summary>
        /// <returns>The bit value from the evaluated code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)]
        public bool? EVALREADACCESSBIT()
        {
            return EvalBit();
        }
    }
}