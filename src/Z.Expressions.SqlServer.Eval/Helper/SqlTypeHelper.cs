// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Data.SqlTypes;

namespace Z.Expressions.SqlServer.Eval
{
    public static class SqlTypeHelper
    {
        /// <summary>Converts a SQL value to a .NET value</summary>
        /// <param name="value">The SQL Value.</param>
        /// <returns>The .NET value converted from the SQL value.</returns>
        public static object ConvertToType(object value)
        {
            var rValue = value;

            switch (value.GetType().Name)
            {
                case "SqlBinary":
                    var valueBinary = (SqlBinary) value;
                    return valueBinary.IsNull ? null : valueBinary.Value;
                case "SqlBoolean":
                    var valueBoolean = (SqlBoolean) value;
                    return valueBoolean.IsNull ? (bool?) null : valueBoolean.Value;
                case "SqlByte":
                    var valueByte = (SqlByte) value;
                    return valueByte.IsNull ? (byte?) null : valueByte.Value;
                case "SqlBytes":
                    var valueBinaries = (SqlBytes) value;
                    return valueBinaries.IsNull ? null : valueBinaries.Value;
                case "SqlChars":
                    var valueChars = (SqlChars) value;
                    return valueChars.IsNull ? null : valueChars.Value;
                case "SqlDateTime":
                    var valueDateTime = (SqlDateTime) value;
                    return valueDateTime.IsNull ? (DateTime?) null : valueDateTime.Value;
                case "SqlDecimal":
                    var valueDecimal = (SqlDecimal) value;
                    return valueDecimal.IsNull ? (decimal?) null : valueDecimal.Value;
                case "SqlDouble":
                    var valueDouble = (SqlDouble) value;
                    return valueDouble.IsNull ? (double?) null : valueDouble.Value;
                case "SqlGuid":
                    var valueGuid = (SqlGuid) value;
                    return valueGuid.IsNull ? (Guid?) null : valueGuid.Value;
                case "SqlInt16":
                    var valueInt16 = (SqlInt16) value;
                    return valueInt16.IsNull ? (short?) null : valueInt16.Value;
                case "SqlInt32":
                    var valueInt32 = (SqlInt32) value;
                    return valueInt32.IsNull ? (int?) null : valueInt32.Value;
                case "SqlInt64":
                    var valueInt64 = (SqlInt64) value;
                    return valueInt64.IsNull ? (long?) null : valueInt64.Value;
                case "SqlMoney":
                    var valueMoney = (SqlMoney) value;
                    return valueMoney.IsNull ? (decimal?) null : valueMoney.Value;
                case "SqlSingle":
                    var valueSingle = (SqlSingle) value;
                    return valueSingle.IsNull ? (float?) null : valueSingle.Value;
                case "SqlString":
                    var valueString = (SqlString) value;
                    return valueString.IsNull ? null : valueString.Value;
                case "SqlXml":
                    var valueXml = (SqlXml) value;
                    return valueXml.IsNull ? null : valueXml.Value;
                case "DBNull":
                    return null;
            }

            return rValue;
        }

        public static Type GetNullableType(object value)
        {
            switch (value.GetType().Name)
            {
                case "SqlBinary":
                    return typeof (byte[]);
                case "SqlBoolean":
                    return typeof (bool?);
                case "SqlByte":
                    return typeof (byte?);
                case "SqlBytes":
                    return typeof (byte[]);
                case "SqlChars":
                    return typeof (char[]);
                case "SqlDateTime":
                    return typeof (DateTime?);
                case "SqlDecimal":
                    return typeof (decimal?);
                case "SqlDouble":
                    return typeof (double?);
                case "SqlGuid":
                    return typeof (Guid?);
                case "SqlInt16":
                    return typeof (short?);
                case "SqlInt32":
                    return typeof (int?);
                case "SqlInt64":
                    return typeof (long?);
                case "SqlMoney":
                    return typeof (decimal?);
                case "SqlSingle":
                    return typeof (float?);
                case "SqlString":
                    return typeof (string);
                case "SqlXml":
                    return typeof (string);
                case "DBNull":
                    return null;
            }

            return typeof (object);
        }
    }
}