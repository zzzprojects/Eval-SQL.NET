// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

// ReSharper disable InconsistentNaming

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Set the IsAutoDispose value to true.</summary>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET AutoDispose()
        {
            Item.IsAutoDispose = true;
            return this;
        }

        /// <summary>Set the IsAutoDispose value to true.</summary>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET autodispose()
        {
            return AutoDispose();
        }

        /// <summary>Set the IsAutoDispose value to true.</summary>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET AUTODISPOSE()
        {
            return AutoDispose();
        }
    }
}