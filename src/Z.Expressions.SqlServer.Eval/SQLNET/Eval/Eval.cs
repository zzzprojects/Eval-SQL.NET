// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
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
            var now = DateTime.Now;

            // Overwrite last access
            Item.LastAccess = now;
            if (Item.Delegate != null)
            {
                Item.Delegate.LastAccess = now;
            }

            if (now > EvalManager.Configuration.ExpireCacheNextScheduled)
            {
                EvalManager.ExpireCache();
            }

            object result;

            if (Item.IsImpersonate)
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
                        Item.Delegate = EvalManager.Configuration.Compile(Item.Code, Item.ParameterTypes);
                    }

                    result = Item.Delegate.Delegate(Item.ParameterValues);
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
                    Item.Delegate = EvalManager.Configuration.Compile(Item.Code, Item.ParameterTypes);
                }

                result = Item.Delegate.Delegate(Item.ParameterValues);
            }

            if (Item.IsAutoDispose)
            {
                Dispose();
            }

            return result;
        }
    }
}