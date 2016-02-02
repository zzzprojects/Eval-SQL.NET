//// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
//// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
//// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
//// License: http://www.zzzprojects.com/license-agreement/
//// More projects: http://www.zzzprojects.com/
//// Copyright (c) 2015 ZZZ Projects. All rights reserved.

//namespace Z.Expressions.SqlServer.Eval
//{
//    public partial struct SQLNET
//    {
//        public SQLNET Type(string key, string typeName)
//        {
//            var type = TypeHelper.GetTypeFromName(typeName);

//            object oldType;
//            if (Item.ParameterTypes.TryGetValue(key, out oldType))
//            {
//                if (!Equals(oldType, type))
//                {
//                    Item.ParameterTypes[key] = type;
//                }
//            }
//            else
//            {
//                Item.ParameterTypes.Add(key, type);
//            }

//            return this;
//        }
//    }
//}