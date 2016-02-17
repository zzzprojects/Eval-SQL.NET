namespace Z.Expressions.SqlServer.Eval
{
    public class SharedBucketList
    {
        public SharedList[] Buckets;

        public SharedBucketList(int bucketSize = 16)
        {
            Buckets = new SharedList[bucketSize];

            for (var i = 0; i < bucketSize; i++)
            {
                Buckets[i] = new SharedList();
            }
        }

        /// <summary>Attempts to add a value in the shared cache for the specified key.</summary>
        /// <param name="value">The value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public bool TryAdd(SQLNETParallelItem value)
        {
            var bucket = value.ParallelId%Buckets.Length;
            bucket = bucket < 0 ? -bucket : bucket;
            return Buckets[bucket].TryAdd(value);
        }

        public void TryRemove(SQLNETParallelItem value)
        {
            var bucket = value.ParallelId%Buckets.Length;
            bucket = bucket < 0 ? -bucket : bucket;
            Buckets[bucket].TryRemove(value);
        }

        /// <summary>Attempts to get value from the shared cache for the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">[out] The value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public bool TryGetValue(int key, out SQLNETParallelItem value)
        {
            var bucket = key%Buckets.Length;
            bucket = bucket < 0 ? -bucket : bucket;
            return Buckets[bucket].TryGetValue(key, out value);
        }
    }
}