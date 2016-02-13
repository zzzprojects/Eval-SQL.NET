// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;

namespace Z.Expressions.SqlServer.Eval
{
    public static class TypeHelper
    {
        /// <summary>Gets type from name.</summary>
        /// <exception cref="Exception">Thrown when an exception error condition occurs.</exception>
        /// <param name="name">The name.</param>
        /// <returns>The type from name.</returns>
        public static Type GetTypeFromName(string name)
        {
            Type type;

            switch (name)
            {
                case "bool?":
                case "Boolean?":
                    type = typeof (bool?);
                    break;
                case "byte?":
                case "Byte?":
                    type = typeof (byte?);
                    break;
                case "short?":
                case "Int16?":
                    type = typeof (short?);
                    break;
                case "int?":
                case "Int32?":
                    type = typeof (int?);
                    break;
                case "long?":
                case "Int64?":
                    type = typeof (long?);
                    break;
                case "float?":
                case "Single?":
                    type = typeof (float?);
                    break;
                case "double?":
                case "Double?":
                    type = typeof (double?);
                    break;
                case "decimal?":
                case "Decimal?":
                    type = typeof (decimal?);
                    break;
                case "DateTime?":
                    type = typeof (DateTime?);
                    break;
                default:
                    throw new Exception("Unsupported");
            }

            return type;
        }
    }
}