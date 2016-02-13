// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Linq;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Registers all types from all domain assemblies.</summary>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext RegisterDomainAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var types = assemblies.SelectMany(x => x.GetTypes())
                // REMOVE some conflicted namespace
                .Where(x => x.FullName != "System.Deployment.Application.Manifest.File"
                            && x.FullName != "System.Net.WebRequestMethods+File"
                            && !x.FullName.StartsWith("System.Dynamic.Utils.CollectionExtensions")).ToArray();

            RegisterType(types);

            return this;
        }
    }
}