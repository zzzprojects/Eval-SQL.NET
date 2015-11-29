// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Linq;
using System.Security.Principal;
using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Eval the code or expression and return an object value.</summary>
        /// <returns>The object value from the evaluated code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)]
        public object Eval()
        {
            object result;

            if (Item.UseImpersonate)
            {
                WindowsImpersonationContext impersonatedIdentity = null;

                if (SqlContext.WindowsIdentity != null)
                {
                    var currentIdentity = SqlContext.WindowsIdentity;
                    impersonatedIdentity = currentIdentity.Impersonate();
                }

                try
                {
                    if (Item.Delegate == null)
                    {
                        Item.Delegate = Item.Context.Compile(Item.Code, Item.Parameters.ToDictionary(x => x.Key, x => x.Value.GetType()));
                    }

                    result = Item.Delegate.Delegate(Item.Parameters);
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
                if (Item.Delegate == null)
                {
                    Item.Delegate = Item.Context.Compile(Item.Code, Item.Parameters.ToDictionary(x => x.Key, x => x.Value.GetType()));
                }

                result = Item.Delegate.Delegate(Item.Parameters);
            }

            // Overwrite last access
            Item.LastAccess = DateTime.Now;
            Item.Delegate.LastAccess = DateTime.Now;
            
            if (Item.AutoDispose)
            {
                Dispose();
            }

            return result;
        }
    }
}