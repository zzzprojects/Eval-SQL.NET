// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Principal;
using Microsoft.SqlServer.Server;

// ReSharper disable InconsistentNaming

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Eval the code or expression and return an object value.</summary>
        /// <returns>The object value from the evaluated code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.None)]
        public object Eval()
        {
          

            var item = Item;
            var now = DateTime.Now;

            // Overwrite last access
            item.LastAccess = now;
            if (item.Delegate != null)
            {
                item.Delegate.LastAccess = now;
            }

            if (now > EvalManager.Configuration.ExpireCacheNextScheduled)
            {
                EvalManager.ExpireCache();
            }

            object result;
            var code = item.Code;

            if (item.ParameterTables.Count > 0)
            {
                var s = @"
using (SqlConnection connection = new SqlConnection(""context connection = true""))
{
    using (SqlCommand command = new SqlCommand()) 
	{
		command.Connection = connection;
        connection.Open();
        [SQLNET_Code]
    }
}
";
                var list = new List<string>();
                foreach (DictionaryEntry parameterTable in item.ParameterTables)
                {
                    list.Add(string.Concat("command.CommandText = 'SELECT * FROM ", parameterTable.Value, "';"));
                    list.Add(string.Concat(parameterTable.Key, " = command.ExecuteDataTable();"));
                    list.Add(parameterTable.Key + ".ExtendedProperties['ZZZ_Select'] = command.CommandText");
                }

                code = s.Replace("[SQLNET_Code]", string.Join(Environment.NewLine, list)) + code;

                //throw new Exception(code);
            }

            if (item.IsImpersonate)
            {
                WindowsImpersonationContext impersonatedIdentity = null;

                if (SqlContext.WindowsIdentity != null)
                {
                    var currentIdentity = SqlContext.WindowsIdentity;
                    impersonatedIdentity = currentIdentity.Impersonate();
                }

                try
                {
                    if (item.Delegate == null)
                    {
                        item.Delegate = EvalManager.Configuration.Compile(code, item.ParameterTypes);
                    }

                    result = item.Delegate.Delegate(item.ParameterValues);
                }
                finally
                {
                    if (impersonatedIdentity != null)
                    {
                        impersonatedIdentity.Undo();
                    }
                }
            }
            else
            {
                if (item.Delegate == null)
                {
                    item.Delegate = EvalManager.Configuration.Compile(code, item.ParameterTypes);
                }

                result = item.Delegate.Delegate(item.ParameterValues);
            }

            if (Item.IsAutoDispose)
            {
                Dispose();
            }

            return result;
        }

        /// <summary>Eval the code or expression and return an object value.</summary>
        /// <returns>The object value from the evaluated code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.None, SystemDataAccess = SystemDataAccessKind.None)]
        public object eval()
        {
            return Eval();
        }

        /// <summary>Eval the code or expression and return an object value.</summary>
        /// <returns>The object value from the evaluated code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.None, SystemDataAccess = SystemDataAccessKind.None)]
        public object EVAL()

        {
            return Eval();
        }
    }
}