// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Diagnostics.CodeAnalysis;

namespace Z.Expressions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class ExceptionMessage
    {
        public const string GeneralException = "Oops! A general error has occurred. Please report the issue including the stack trace to our support team: info@zzzprojects.com";

        public const string Invalid_ValueKey = "The specified key is invalid. You must choose between 'x', 'int x' or 'int? x' format. Current key: {0}. Contact our support team for more information: info@zzzprojects.com";

        public const string Unexpected_AliasRegistered = "The alias: '{0}' is already registered, you must specifiy an unregistered alias name. Contact our support team for more information: info@zzzprojects.com";
        public const string Unexpected_CacheItemExpired = "The cached item has expired. Items automatically expire after a period of time, you can change this configuration. Contact our support team for more information: info@zzzprojects.com";
        public const string Unexpected_NullResultSet = "A non-null DataSet/DataTable is required to return the result. Contact our support team for more information: info@zzzprojects.com";
        public const string Unexpected_ParameterKeyNotFound = "The key '{0}' could not be found, you can only get value from existing keys. Contact our support team for more information: info@zzzprojects.com";

        public const string Unsupported_DataTable_ResultSet = "The result could not be converted to a ResultSet, the type '{0}' is not supported. Contact our support team for more information: info@zzzprojects.com";
        public const string Unsupported_SqlMetaData_Type = "The type '{0}' is not supported in SQL Server, make sure to convert your result to a supported type. Contact our support team for more information: info@zzzprojects.com";
        public const string Unsupported_SqlMetaData_TypeCode = "The type (TypeCode) '{0}' is not supported in SQL Server, make sure to convert your result to a supported type. Contact our support team for more information: info@zzzprojects.com";
    }
}