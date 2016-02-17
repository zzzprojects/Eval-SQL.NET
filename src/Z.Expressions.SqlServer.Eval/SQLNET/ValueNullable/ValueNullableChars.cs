//// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
//// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
//// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
//// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
//// More projects: http://www.zzzprojects.com/
//// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

//// ReSharper disable InconsistentNaming

//using System.Data.SqlTypes;

//namespace Z.Expressions.SqlServer.Eval
//{
//    public partial struct SQLNET
//    {
//        /// <summary>Add or update a binary value associated with the specified key.</summary>
//        /// <param name="key">The key of the value to add or update.</param>
//        /// <param name="value">The binary value to add or update associated with the specified key.</param>
//        /// <returns>A fluent SQLNET object.</returns>
//        public SQLNET ValueChars(SqlString key, SqlChars value)
//        {
//            return ValueInternal(key, typeof (char[]), value.Value);
//        }

//        /// <summary>Add or update a binary value associated with the specified key.</summary>
//        /// <param name="key">The key of the value to add or update.</param>
//        /// <param name="value">The binary value to add or update associated with the specified key.</param>
//        /// <returns>A fluent SQLNET object.</returns>
//        public SQLNET valuechars(SqlString key, SqlChars value)
//        {
//            return ValueChars(key, value);
//        }

//        /// <summary>Add or update a binary value associated with the specified key.</summary>
//        /// <param name="key">The key of the value to add or update.</param>
//        /// <param name="value">The binary value to add or update associated with the specified key.</param>
//        /// <returns>A fluent SQLNET object.</returns>
//        public SQLNET VALUECHARS(SqlString key, SqlChars value)
//        {
//            return ValueChars(key, value);
//        }
//    }
//}