// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Data.SqlTypes;
using System.IO;
using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    /// <summary>A SQLNET used to compile the code or expression.</summary>
    [SqlUserDefinedType(Format.UserDefined, MaxByteSize = -1)]
    public partial struct SQLNET : INullable, IBinarySerialize
    {
        public static int CacheCount()
        {
            return EvalManager.CacheDelegate.Count;
        }

        /// <summary>The SQLNETItem used to compile the code or expression.</summary>
        public SQLNETItem Item;

        /// <summary>Gets a value indicating whether this object is null.</summary>
        /// <value>true if this object is null, false if not.</value>
        public bool IsNull
        {
            get { return false; }
        }

        /// <summary>Gets the null value for the SQLNET object.</summary>
        /// <value>The null value for the SQLNET object.</value>
        public static SQLNET Null
        {
            get { return new SQLNET(); }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting
        ///     unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (Item.Delegate != null)
            {
                EvalDelegate @delegate;
                EvalManager.CacheDelegate.TryRemove(Item.Delegate.CacheKey, out @delegate);
            }

            EvalManager.CacheItem.TryRemove(Item.CacheKey, out Item);
        }

        /// <summary>News.</summary>
        /// <param name="code">The code.</param>
        /// <returns>A SQLNET to evaluate the code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)]
        public static SQLNET New(string code)
        {
            var sqlnet = new SQLNET {Item = new SQLNETItem()};
            sqlnet.Item.Code = code;
            return sqlnet;
        }

        /// <summary>Parses the given value to a SQLNET object from the string representation.</summary>
        /// <param name="value">The value that reprensent a SQLNET object.</param>
        /// <returns>A SQLNET object parsed from the string representation.</returns>
        [SqlMethod(OnNullCall = false)]
        public static SQLNET Parse(SqlString value)
        {
            return new SQLNET();
        }

        /// <summary>Convert the SQLNET object into a string representation.</summary>
        /// <returns>A string that reprensent a SQLNET object.</returns>
        public override string ToString()
        {
            return Item.Code;
        }

        /// <summary>Reads the given reader to retrieve the SQLNETItem from the cache.</summary>
        /// <param name="reader">The reader to read.</param>
        public void Read(BinaryReader reader)
        {
            if (reader.BaseStream.Length > 0)
            {
                var cacheKey = reader.ReadString();

                if (!EvalManager.CacheItem.TryGetValue(cacheKey, out Item))
                {
                    Item = new SQLNETItem();
                }
            }
        }

        /// <summary>Writes the given writer to store the SQLNETItem in the cache.</summary>
        /// <param name="writer">The writer to write.</param>
        public void Write(BinaryWriter writer)
        {
            if (Item != null)
            {
                if (!Item.IsCached)
                {
                    EvalManager.CacheItem.TryAdd(Item.CacheKey, Item);
                    Item.IsCached = true;
                }

                writer.Write(Item.CacheKey);
            }
        }
    }
}