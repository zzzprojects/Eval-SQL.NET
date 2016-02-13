// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

// ReSharper disable InconsistentNaming

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

        /// <summary>Add the PRO license purchased from ZZZ Projects Inc. (http://eval-sql.net/).</summary>
        /// <param name="licenseName">The license name.</param>
        /// <param name="licenseKey">The license key.</param>
        public static bool addlicense(string licenseName, string licenseKey)
        {
            return AddLicense(licenseName, licenseKey);
        }

        /// <summary>Add the PRO license purchased from ZZZ Projects Inc. (http://eval-sql.net/).</summary>
        /// <param name="licenseName">The license name.</param>
        /// <param name="licenseKey">The license key.</param>
        public static bool ADDLICENSE(string licenseName, string licenseKey)
        {
            return AddLicense(licenseName, licenseKey);
        }
    }
}