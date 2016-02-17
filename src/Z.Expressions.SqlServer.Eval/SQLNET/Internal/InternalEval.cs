// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

// ReSharper disable InconsistentNaming

using System;
using System.Security.Principal;
using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        public object InternalEval()
        {
            var item = Item;
            var lastAccess = DateTime.Now;

            // Overwrite last access
            item.LastAccess = lastAccess;
            if (item.Delegate != null)
            {
                item.Delegate.LastAccess = lastAccess;
            }

            // CHECK if the garbage collection should be invoked
            if (lastAccess > EvalManager.Configuration.ExpireCacheNextScheduled)
            {
                EvalManager.ExpireCache();
            }

            var code = item.Code;

            SQLNETParallelItem parallelValue;
            if (ValueParallel != 0)
            {
                parallelValue = item.GetParallelValue(ValueParallel);
            }
            else
            {
                parallelValue = new SQLNETParallelItem();
            }

            //var parallelValue = item;
            object result;

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
                        item.Delegate = EvalManager.Configuration.CompileSQLNET(code, item.ParameterTypes.InnerDictionary);
                        item.IsCompiled = true;
                    }

                    result = item.Delegate.Delegate(parallelValue.ParameterValues);
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
                    item.Delegate = EvalManager.Configuration.CompileSQLNET(code, item.ParameterTypes.InnerDictionary);
                    item.IsCompiled = true;
                }

                result = item.Delegate.Delegate(parallelValue.ParameterValues);
            }

            // RELEASE parallel item once resolved
            if (ValueParallel != 0)
            {
                Item.ParallelItems.TryRemove(parallelValue);
            }
   

            if (Item.IsAutoDispose)
            {
                Dispose();
            }

            return result;


            //            if (item.ParameterTables.Count > 0)
            //            {
            //                var s = @"
            //using (SqlConnection connection = new SqlConnection(""context connection = true""))
            //{
            //    using (SqlCommand command = new SqlCommand()) 
            //	{
            //		command.Connection = connection;
            //        connection.Open();
            //        [SQLNET_Code]
            //    }
            //}
            //";
            //                //var list = new List<string>();
            //                //foreach (DictionaryEntry parameterTable in item.ParameterTables)
            //                //{
            //                //    list.Add(string.Concat("command.CommandText = 'SELECT * FROM ", parameterTable.Value, "';"));
            //                //    list.Add(string.Concat(parameterTable.Key, " = command.ExecuteDataTable();"));
            //                //    list.Add(parameterTable.Key + ".ExtendedProperties['ZZZ_Select'] = command.CommandText");
            //                //}

            //                //code = s.Replace("[SQLNET_Code]", string.Join(Environment.NewLine, list)) + code;

            //                //throw new Exception(code);
            //            }
        }
    }
}