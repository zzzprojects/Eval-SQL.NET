//// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
//// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
//// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
//// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
//// More projects: http://www.zzzprojects.com/
//// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

//using System.Data.SqlTypes;

//// ReSharper disable InconsistentNaming

//namespace Z.Expressions.SqlServer.Eval
//{
//    public partial struct SQLNET
//    {
//        /// <summary>Add or update a xml value associated with the specified key.</summary>
//        /// <param name="key">The key of the value to add or update.</param>
//        /// <param name="value">The xml value to add or update associated with the specified key.</param>
//        /// <returns>A fluent SQLNET object.</returns>
//        public SQLNET ValueXml(SqlString key, SqlXml value)
//        {
//            return ValueInternal(key, typeof (string), value.Value);
//        }

//        /// <summary>Add or update a xml value associated with the specified key.</summary>
//        /// <param name="key">The key of the value to add or update.</param>
//        /// <param name="value">The xml value to add or update associated with the specified key.</param>
//        /// <returns>A fluent SQLNET object.</returns>
//        public SQLNET valuexml(SqlString key, SqlXml value)
//        {
//            return ValueXml(key, value);
//        }

//        /// <summary>Add or update a xml value associated with the specified key.</summary>
//        /// <param name="key">The key of the value to add or update.</param>
//        /// <param name="value">The xml value to add or update associated with the specified key.</param>
//        /// <returns>A fluent SQLNET object.</returns>
//        public SQLNET VALUEXML(SqlString key, SqlXml value)
//        {
//            return ValueXml(key, value);
//        }
//    }
//}