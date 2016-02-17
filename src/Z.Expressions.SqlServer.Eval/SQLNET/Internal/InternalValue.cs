// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

// ReSharper disable InconsistentNaming

using System;
using System.Data.SqlTypes;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        public SQLNET InternalValue(SqlString keyString, Type type, object value)
        {
            var key = keyString.Value;
            var item = Item;
            var sqlnet = this;

            SQLNETParallelItem parallelValue;

            // CREATE a new SQLNET from the root
            if (ValueParallel == 0)
            {
                sqlnet = new SQLNET {ValueSerializable = ValueSerializable, ValueParallel = item.GetNextCountAndAddParallel()};
                parallelValue = item.AddParallelValue(sqlnet.ValueParallel);
            }
            else
            {
                parallelValue = item.GetParallelValue(sqlnet.ValueParallel);
            }

            if (!item.IsCompiled)
            {
                //parallelValue.ParameterValues[key] = value;
                parallelValue.ParameterValues.Add(key, value);

                // Try to add type only if it's not compiled yet
                item.ParameterTypes.TryAdd(key, type);
            }
            else
            {
                // AddOrUpdate value
                parallelValue.ParameterValues[key] = value;
            }

            return sqlnet;
        }
    }
}