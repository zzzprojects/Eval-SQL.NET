// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System.Linq;
using System.Reflection;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Registers all types from all specified assemblies.</summary>
        /// <param name="assemblies">A variable-length parameters list containing assemblies to register type from.</param>
        /// <returns>A Fluent EvalContext.</returns>
        public EvalContext RegisterAssembly(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes()
                    // REMOVE some conflicted namespace
                    .Where(x => x.FullName != "System.Deployment.Application.Manifest.File"
                                && x.FullName != "System.Net.WebRequestMethods+File"
                                && !x.FullName.StartsWith("System.Dynamic.Utils.CollectionExtensions")).ToArray();

                RegisterType(types);
            }

            return this;
        }
    }
}