// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum: https://zzzprojects.uservoice.com/forums/328452-eval-sql-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Data.SqlTypes;
using System.IO;
using Microsoft.SqlServer.Server;

namespace Z.Expressions.SqlServer.Eval
{
    /// <summary>A SQLNET used to compile the code or expression.</summary>
    [SqlUserDefinedType(Format.UserDefined, MaxByteSize = -1)]
    public partial struct SQLNET : INullable, IBinarySerialize
    {
        /// <summary>Name of internal value.</summary>
        public static readonly string InternalValueName = "value";

        /// <summary>The SQLNETItem used to compile the code or expression.</summary>
        public SQLNETItem Item;

        /// <summary>The template connection when SqlClrCommand is used.</summary>
        private static readonly string TemplateConnection = @"
using (SqlConnection connection = new SqlConnection(""context connection = true""))
{
    using (SqlCommand defaultCommand = new SqlCommand()) 
	{
		defaultCommand.Connection = connection;
        connection.Open();
        [SQLNET_Code]
    }
}
";

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

        /// <summary>Get the cache delegate count.</summary>
        /// <returns>The number of items in the cache delegate.</returns>
        public static int CacheDelegateCount()
        {
            return EvalManager.CacheDelegate.Count;
        }

        /// <summary>Get the cache item count.</summary>
        /// <returns>The number of items in the cache item.</returns>
        public static int CacheItemCount()
        {
            return EvalManager.CacheItem.Count;
        }

        /// <summary>Expire caching item.</summary>
        /// <returns>true if it succeeds, false if it fails which usually means another process is already cleaning it.</returns>
        public static bool ExpireCache()
        {
            return EvalManager.ExpireCache();
        }

        /// <summary>News.</summary>
        /// <param name="code">The code.</param>
        /// <returns>A SQLNET to evaluate the code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)] // Required for static constructor
        public static SQLNET New(string code)
        {
            if (code.Contains("defaultCommand") && !code.Contains("new SqlConnection("))
            {
                code = TemplateConnection.Replace("[SQLNET_Code]", code);
            }

            var sqlnet = new SQLNET {Item = new SQLNETItem()};
            sqlnet.Item.Code = code;

            return sqlnet;
        }

        /// <summary>Releases all locks.</summary>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool ReleaseLocks()
        {
            EvalManager.CacheDelegate.ReleaseLock();
            EvalManager.CacheItem.ReleaseLock();
            SharedLock.ReleaseLock(ref EvalManager.SharedLock.ExpireCacheLock);

            return true;
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting
        ///     unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (Item.Delegate != null)
            {
                EvalDelegate evalDelegate;
                EvalManager.CacheDelegate.TryRemove(Item.Delegate.CacheKey, out evalDelegate);
            }

            EvalManager.CacheItem.TryRemove(Item.CacheKey, out Item);
        }

        /// <summary>Parses the given value to a SQLNET object from the string representation.</summary>
        /// <param name="value">The value that reprensent a SQLNET object.</param>
        /// <returns>A SQLNET object parsed from the string representation.</returns>
        [SqlMethod(OnNullCall = false)]
        public static SQLNET Parse(SqlString value)
        {
            return new SQLNET();
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
                    throw new Exception(ExceptionMessage.Unexpected_CacheItemExpired);
                }
            }
        }

        /// <summary>Convert the SQLNET object into a string representation.</summary>
        /// <returns>A string that represents a SQLNET object.</returns>
        public override string ToString()
        {
            return Item.Code;
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