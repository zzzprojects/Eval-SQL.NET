// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    internal static class SqlContextHelper
    {
        /// <summary>Send a DataSet to a SqlContext.</summary>
        /// <exception cref="Exception">Throw an exception if the DataSet is null.</exception>
        /// <param name="ds">The DataSet to send to the SqlContext.</param>
        internal static void SendDataSet(DataSet ds)
        {
            if (ds == null)
            {
                throw new Exception(ExceptionMessage.UnexpectedNullResultSet);
            }

            foreach (DataTable dt in ds.Tables)
            {
                SendDataTable(dt);
            }
        }

        /// <summary>Send a DataTable to a SqlContext.</summary>
        /// <exception cref="Exception">Throw an exception if the DataTable is null.</exception>
        /// <param name="dt">The DataTable to send to the SqlContext.</param>
        internal static void SendDataTable(DataTable dt)
        {
            if (dt == null)
            {
                throw new Exception(ExceptionMessage.UnexpectedNullResultSet);
            }

            bool[] useToString;
            var metaData = ExtractDataTableColumnMetaData(dt, out useToString);

            var record = new SqlDataRecord(metaData);
            var pipe = SqlContext.Pipe;

            pipe.SendResultsStart(record);

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    for (var index = 0; index < record.FieldCount; index++)
                    {
                        var value = row[index];
                        if (value != null && useToString[index])
                        {
                            value = value.ToString();
                        }

                        record.SetValue(index, value);
                    }

                    pipe.SendResultsRow(record);
                }
            }
            finally
            {
                pipe.SendResultsEnd();
            }
        }

        /// <summary>Extracts the data table column meta data.</summary>
        /// <param name="dt">The dt.</param>
        /// <param name="useToString">[out] The coerce to string.</param>
        /// <returns>The extracted data table column meta data.</returns>
        private static SqlMetaData[] ExtractDataTableColumnMetaData(DataTable dt, out bool[] useToString)
        {
            var metaDataResult = new SqlMetaData[dt.Columns.Count];
            useToString = new bool[dt.Columns.Count];
            for (var index = 0; index < dt.Columns.Count; index++)
            {
                var column = dt.Columns[index];
                metaDataResult[index] = SqlMetaDataFromColumn(column, out useToString[index]);
            }

            return metaDataResult;
        }

        /// <summary>SQL meta data from column.</summary>
        /// <exception cref="Exception">Throw an exception when an invalid or unsupported type is found.</exception>
        /// <param name="column">The column.</param>
        /// <param name="useToString">[out] The coerce to string.</param>
        /// <returns>A SqlMetaData.</returns>
        private static SqlMetaData SqlMetaDataFromColumn(DataColumn column, out bool useToString)
        {
            useToString = false;
            SqlMetaData sqlMetaData;
            var clrType = column.DataType;
            var typeCode = Type.GetTypeCode(clrType);
            var name = column.ColumnName;
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    sqlMetaData = new SqlMetaData(name, SqlDbType.Bit);
                    break;
                case TypeCode.Byte:
                    sqlMetaData = new SqlMetaData(name, SqlDbType.TinyInt);
                    break;
                case TypeCode.Char:
                    sqlMetaData = new SqlMetaData(name, SqlDbType.NVarChar, 1);
                    break;
                case TypeCode.DateTime:
                    sqlMetaData = new SqlMetaData(name, SqlDbType.DateTime);
                    break;
                case TypeCode.Decimal:
                    sqlMetaData = new SqlMetaData(name, SqlDbType.Decimal, 18, 0);
                    break;
                case TypeCode.Double:
                    sqlMetaData = new SqlMetaData(name, SqlDbType.Float);
                    break;
                case TypeCode.Int16:
                    sqlMetaData = new SqlMetaData(name, SqlDbType.SmallInt);
                    break;
                case TypeCode.Int32:
                    sqlMetaData = new SqlMetaData(name, SqlDbType.Int);
                    break;
                case TypeCode.Int64:
                    sqlMetaData = new SqlMetaData(name, SqlDbType.BigInt);
                    break;
                case TypeCode.Single:
                    sqlMetaData = new SqlMetaData(name, SqlDbType.Real);
                    break;
                case TypeCode.String:
                    sqlMetaData = new SqlMetaData(name, SqlDbType.NVarChar, column.MaxLength);
                    break;
                case TypeCode.Object:
                    sqlMetaData = SqlMetaDataFromObjectColumn(name, column, clrType);
                    if (sqlMetaData == null)
                    {
                        sqlMetaData = new SqlMetaData(name, SqlDbType.NVarChar, column.MaxLength);
                        useToString = true;
                    }
                    break;
                case TypeCode.DBNull:
                case TypeCode.Empty:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    throw new Exception(string.Format(ExceptionMessage.InvalidDataType, typeCode));
                default:
                    throw new Exception(string.Format(ExceptionMessage.UnexpectedDataType, clrType));
            }

            return sqlMetaData;
        }

        /// <summary>SQL meta data from object column.</summary>
        /// <param name="name">The name.</param>
        /// <param name="column">The column.</param>
        /// <param name="clrType">Type of the colour.</param>
        /// <returns>A SqlMetaData.</returns>
        private static SqlMetaData SqlMetaDataFromObjectColumn(string name, DataColumn column, Type clrType)
        {
            SqlMetaData sqlMetaData;
            if (clrType == typeof (byte[])
                || clrType == typeof (SqlBinary)
                || clrType == typeof (SqlBytes)
                || clrType == typeof (char[])
                || clrType == typeof (SqlString)
                || clrType == typeof (SqlChars))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.VarBinary, column.MaxLength);
            }
            else if (clrType == typeof (Guid))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.UniqueIdentifier);
            }

            else if (clrType == typeof (object))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.Variant);
            }
            else if (clrType == typeof (SqlBoolean))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.Bit);
            }
            else if (clrType == typeof (SqlByte))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.TinyInt);
            }
            else if (clrType == typeof (SqlDateTime))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.DateTime);
            }
            else if (clrType == typeof (SqlDouble))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.Float);
            }
            else if (clrType == typeof (SqlGuid))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.UniqueIdentifier);
            }
            else if (clrType == typeof (SqlInt16))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.SmallInt);
            }
            else if (clrType == typeof (SqlInt32))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.Int);
            }
            else if (clrType == typeof (SqlInt64))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.BigInt);
            }
            else if (clrType == typeof (SqlMoney))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.Money);
            }
            else if (clrType == typeof (SqlDecimal))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.Decimal, SqlDecimal.MaxPrecision, 0);
            }
            else if (clrType == typeof (SqlSingle))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.Real);
            }
            else if (clrType == typeof (SqlXml))
            {
                sqlMetaData = new SqlMetaData(name, SqlDbType.Xml);
            }
            else
            {
                sqlMetaData = null;
            }

            return sqlMetaData;
        }
    }
}