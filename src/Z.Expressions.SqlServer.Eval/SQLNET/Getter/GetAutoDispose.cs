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
        /// <summary>Gets the value if the object should AutoDispose once it has been evaluated.</summary>
        /// <returns>true if the object AutoDispose, otherwise false.</returns>
        public bool GetAutoDispose()
        {
            return Item.IsAutoDispose;
        }

        /// <summary>Gets the value if the object should AutoDispose once it has been evaluated.</summary>
        /// <returns>true if the object AutoDispose, otherwise false.</returns>
        public bool getautodispose()
        {
            return Item.IsAutoDispose;
        }

        /// <summary>Gets the value if the object should AutoDispose once it has been evaluated.</summary>
        /// <returns>true if the object AutoDispose, otherwise false.</returns>
        public bool GETAUTODISPOSE()
        {
            return Item.IsAutoDispose;
        }
    }
}