// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.
// 
namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Add the PRO license purchased from ZZZ Projects Inc. (http://eval-sql.net/).</summary>
        /// <param name="licenseName">The license name.</param>
        /// <param name="licenseKey">The license key.</param>
        public static bool AddLicense(string licenseName, string licenseKey)
        {
            CompilerManager.AddLicense(licenseName, licenseKey);
            return true;
        }
    }
}