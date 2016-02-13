// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Loads configuration from the SQL stored procedure: SQLNET_GlobalConfiguration.</summary>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)]
        public static bool LoadConfiguration()
        {
            try
            {
                using (var connection = new SqlConnection("context connection=true"))
                {
                    connection.Open();

                    using (var command = new SqlCommand("SQLNET_Configuration", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch
            {
                // Oops! it's okay, the procedure does not always exist
                return false;
            }
        }
    }
}