// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

namespace Z.Expressions
{
    public static class ExceptionMessage
    {
        public const string InvalidDataType = "Invalid type: {0}";
        public const string InvalidResultSet = "The result could not be converted to a ResultSet. Type: {0}";
        public const string UnexpectedKeyNotFound = "Key not found. Ensure the key has been set before trying to retrieve its value. Key: {0}";
        public const string UnexpectedAliasRegistered = "The alias: '{0}' is already registered.";
        public const string UnexpectedNullResultSet = "A non-null DataSet/DataTable is required.";
        public const string UnexpectedDataType = "Unknown type: {0}";
    }
}