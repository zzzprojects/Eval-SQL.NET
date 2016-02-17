// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.SqlServer.Server;

// ReSharper disable InconsistentNaming

namespace Z.Expressions.SqlServer.Eval
{
    /// <summary>A SQLNET used to compile the code or expression.</summary>
    [SqlUserDefinedType(Format.Native, IsByteOrdered = true)]
    public partial struct SQLNET : INullable
    {
        public static int AddValue(int x, int y)
        {
            return x + y;
        }
        //public static bool IsMatch(SqlString value)
        //{
        //    return Regex.IsMatch(value.Value, "toto");
        //}

        /// <summary>The value serializable.</summary>
        public int ValueSerializable;

        public int ValueParallel;

        /// <summary>Name of internal value.</summary>
        public static readonly string InternalValueName = "value";

        /// <summary>The SQLNETItem used to compile the code or expression.</summary>
        public SQLNETItem Item
        {
            get
            {
                SQLNETItem item;
                if (!EvalManager.CacheItem.TryGetValue(ValueSerializable, out item))
                {
                    throw new Exception(ExceptionMessage.GeneralException);
                }

                return item;
            }
        }

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

        /// <summary>Get the cache delegate count.</summary>
        /// <returns>The number of items in the cache delegate.</returns>
        public static int cachedelegatecount()
        {
            return CacheDelegateCount();
        }

        /// <summary>Get the cache delegate count.</summary>
        /// <returns>The number of items in the cache delegate.</returns>
        public static int CACHEDELEGATECOUNT()
        {
            return CacheDelegateCount();
        }

        /// <summary>Get the cache item count.</summary>
        /// <returns>The number of items in the cache item.</returns>
        public static int CacheItemCount()
        {
            return EvalManager.CacheItem.Count;
        }

        public SQLNET Compile()
        {
            var item = Item;

            item.Delegate = EvalManager.Configuration.CompileSQLNET(item.Code, item.ParameterTypes.InnerDictionary);
            item.IsCompiled = true;
            Root();

            return this;
        }

        public SQLNET compile()
        {
            return Compile();
        }

        public SQLNET COMPILE()
        {
            return Compile();
        }

        public static int Counter()
        {
            return EvalManager.DefaultContext.CacheItemCounter;
        }

        public int InstanceCounter()
        {
            return ValueSerializable;
        }

        /// <summary>Expire caching item.</summary>
        /// <returns>true if it succeeds, false if it fails which usually means another process is already cleaning it.</returns>
        public static bool ExpireCache()
        {
            return EvalManager.ExpireCache();
        }

        /// <summary>Expire caching item.</summary>
        /// <returns>true if it succeeds, false if it fails which usually means another process is already cleaning it.</returns>
        public static bool expirecache()
        {
            return ExpireCache();
        }

        /// <summary>Expire caching item.</summary>
        /// <returns>true if it succeeds, false if it fails which usually means another process is already cleaning it.</returns>
        public static bool EXPIRECACHE()
        {
            return ExpireCache();
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

            var sqlnet = new SQLNET {ValueSerializable = EvalManager.DefaultContext.GetNextCacheItemCounter()};
            var sqlnetitem = new SQLNETItem {Code = code};
            EvalManager.CacheItem.TryAdd(sqlnet.ValueSerializable, sqlnetitem);

            return sqlnet;
        }

        /// <summary>News.</summary>
        /// <param name="code">The code.</param>
        /// <returns>A SQLNET to evaluate the code or expression.</returns>
        [SqlMethod(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)] // Required for static constructor
        public static SQLNET NEW(string code)
        {
            return New(code);
        }

        /// <summary>Releases all locks.</summary>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool ReleaseLocks()
        {
            EvalManager.CacheDelegate.Buckets.ToList().ForEach(x => x.ReleaseLock());
            EvalManager.CacheItem.Buckets.ToList().ForEach(x => x.ReleaseLock());
            SharedLock.ReleaseLock(ref EvalManager.SharedLock.ExpireCacheLock);

            return true;
        }

        /// <summary>Releases all locks.</summary>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool releaselock()
        {
            return ReleaseLocks();
        }

        /// <summary>Releases all locks.</summary>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool RELEASELOCK()
        {
            return ReleaseLocks();
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting
        ///     unmanaged resources.
        /// </summary>
        public bool Dispose()
        {
            if (Item.Delegate != null)
            {
                EvalDelegate evalDelegate;
                EvalManager.CacheDelegate.TryRemove(Item.Delegate.CacheKey, out evalDelegate);
            }

            SQLNETItem item;
            EvalManager.CacheItem.TryRemove(ValueSerializable, out item);
            return true;
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting
        ///     unmanaged resources.
        /// </summary>
        public bool dispose()
        {
            return Dispose();
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting
        ///     unmanaged resources.
        /// </summary>
        public bool DISPOSE()
        {
            return Dispose();
        }


        /// <summary>Parses the given value to a SQLNET object from the string representation.</summary>
        /// <param name="value">The value that reprensent a SQLNET object.</param>
        /// <returns>A SQLNET object parsed from the string representation.</returns>
        [SqlMethod(OnNullCall = false)]
        public static SQLNET Parse(SqlString value)
        {
            throw new Exception(ExceptionMessage.GeneralException);
        }

        public SQLNET Root()
        {
            if (ValueParallel != 0)
            {
                var item = Item;
                var parallelValue = item.GetParallelValue(ValueParallel);
                item.ParameterValues = parallelValue.ParameterValues;
                Item.ParallelItems.TryRemove(parallelValue);
                ValueParallel = 0;
            }

            return this;
        }

        public SQLNET root()
        {
            return Root();
        }

        public SQLNET ROOT()
        {
            return Root();
        }

        /// <summary>Convert the SQLNET object into a string representation.</summary>
        /// <returns>A string that represents a SQLNET object.</returns>
        public override string ToString()
        {
            throw new Exception(ExceptionMessage.GeneralException);
        }
    }
}