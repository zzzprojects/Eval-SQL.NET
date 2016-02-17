// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections;
using System.Threading;

namespace Z.Expressions
{
    /// <devdoc>
    ///     <para>
    ///         This is a simple implementation of IDictionary using a singly linked list. This
    ///         will be smaller and faster than a Hashtable if the number of elements is 10 or less.
    ///         This should not be used if performance is important for large numbers of elements.
    ///     </para>
    /// </devdoc>
    [Serializable]
    public class ListDictionary : IDictionary
    {
        // todo: Do we still really need a list dictionary?
        private readonly IComparer comparer;

        [NonSerialized] private object _syncRoot;


        private DictionaryNode head;

        /// <summary>The lock value.</summary>
        public int LockValue;

        private int version;

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public ListDictionary()
        {
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public ListDictionary(IComparer comparer)
        {
            this.comparer = comparer;
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public object this[object key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key", "error");
                }
                var node = head;
                if (comparer == null)
                {
                    while (node != null)
                    {
                        var oldKey = node.key;
                        if (oldKey != null && oldKey.Equals(key))
                        {
                            return node.value;
                        }
                        node = node.next;
                    }
                }
                else
                {
                    while (node != null)
                    {
                        var oldKey = node.key;
                        if (oldKey != null && comparer.Compare(oldKey, key) == 0)
                        {
                            return node.value;
                        }
                        node = node.next;
                    }
                }
                return null;
            }
            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key", "error");
                }
                version++;
                DictionaryNode last = null;
                DictionaryNode node;
                for (node = head; node != null; node = node.next)
                {
                    var oldKey = node.key;
                    if ((comparer == null) ? oldKey.Equals(key) : comparer.Compare(oldKey, key) == 0)
                    {
                        break;
                    }
                    last = node;
                }
                if (node != null)
                {
                    // Found it
                    node.value = value;
                    return;
                }
                // Not found, so add a new one
                var newNode = new DictionaryNode();
                newNode.key = key;
                newNode.value = value;
                if (last != null)
                {
                    last.next = newNode;
                }
                else
                {
                    head = newNode;
                }
                Count++;
            }
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public int Count { get; private set; }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public ICollection Keys
        {
            get { return new NodeKeyValueCollection(this, true); }
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public bool IsFixedSize
        {
            get { return false; }
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public object SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                }
                return _syncRoot;
            }
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public ICollection Values
        {
            get { return new NodeKeyValueCollection(this, false); }
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public void Add(object key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Argument cannot be null", "key");
            }
            version++;
            DictionaryNode last = null;
            DictionaryNode node;
            for (node = head; node != null; node = node.next)
            {
                var oldKey = node.key;
                if ((comparer == null) ? oldKey.Equals(key) : comparer.Compare(oldKey, key) == 0)
                {
                    throw new ArgumentException(string.Format("Duplicate keys: new key: {0}, old value: {1}, new value: {2}", key, this[oldKey], value));
                }
                last = node;
            }

            // Not found, so add a new one
            var newNode = new DictionaryNode();
            newNode.key = key;
            newNode.value = value;
            if (last != null)
            {
                last.next = newNode;
            }
            else
            {
                head = newNode;
            }
            Count++;
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public void Clear()
        {
            Count = 0;
            head = null;
            version++;
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public bool Contains(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "error");
            }
            for (var node = head; node != null; node = node.next)
            {
                var oldKey = node.key;
                if ((comparer == null) ? oldKey.Equals(key) : comparer.Compare(oldKey, key) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (index < 0)
                throw new ArgumentOutOfRangeException("index", "error");

            if (array.Length - index < Count)
                throw new ArgumentException("error");

            for (var node = head; node != null; node = node.next)
            {
                array.SetValue(new DictionaryEntry(node.key, node.value), index);
                index++;
            }
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public IDictionaryEnumerator GetEnumerator()
        {
            return new NodeEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NodeEnumerator(this);
        }

        /// <devdoc>
        ///     <para>[To be supplied.]</para>
        /// </devdoc>
        public void Remove(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "error");
            }
            version++;
            DictionaryNode last = null;
            DictionaryNode node;
            for (node = head; node != null; node = node.next)
            {
                var oldKey = node.key;
                if ((comparer == null) ? oldKey.Equals(key) : comparer.Compare(oldKey, key) == 0)
                {
                    break;
                }
                last = node;
            }
            if (node == null)
            {
                return;
            }
            if (node == head)
            {
                head = node.next;
            }
            else
            {
                last.next = node.next;
            }
            Count--;
        }

        public bool TryGetValue(object key, out object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "error");
            }
            var node = head;
            if (comparer == null)
            {
                while (node != null)
                {
                    var oldKey = node.key;
                    if (oldKey != null && oldKey.Equals(key))
                    {
                        value = node.value;
                        return true;
                    }
                    node = node.next;
                }
            }
            else
            {
                while (node != null)
                {
                    var oldKey = node.key;
                    if (oldKey != null && comparer.Compare(oldKey, key) == 0)
                    {
                        value = node.value;
                        return true;
                    }
                    node = node.next;
                }
            }

            value = null;
            return false;
        }

        private class NodeEnumerator : IDictionaryEnumerator
        {
            private readonly ListDictionary list;
            private readonly int version;
            private DictionaryNode current;
            private bool start;


            public NodeEnumerator(ListDictionary list)
            {
                this.list = list;
                version = list.version;
                start = true;
                current = null;
            }

            public object Current
            {
                get { return Entry; }
            }

            public DictionaryEntry Entry
            {
                get
                {
                    if (current == null)
                    {
                        throw new InvalidOperationException("error");
                    }
                    return new DictionaryEntry(current.key, current.value);
                }
            }

            public object Key
            {
                get
                {
                    if (current == null)
                    {
                        throw new InvalidOperationException("error");
                    }
                    return current.key;
                }
            }

            public object Value
            {
                get
                {
                    if (current == null)
                    {
                        throw new InvalidOperationException("error");
                    }
                    return current.value;
                }
            }

            public bool MoveNext()
            {
                if (version != list.version)
                {
                    throw new InvalidOperationException("error");
                }
                if (start)
                {
                    current = list.head;
                    start = false;
                }
                else if (current != null)
                {
                    current = current.next;
                }
                return (current != null);
            }

            public void Reset()
            {
                if (version != list.version)
                {
                    throw new InvalidOperationException("error");
                }
                start = true;
                current = null;
            }
        }


        private class NodeKeyValueCollection : ICollection
        {
            private readonly bool isKeys;
            private readonly ListDictionary list;

            public NodeKeyValueCollection(ListDictionary list, bool isKeys)
            {
                this.list = list;
                this.isKeys = isKeys;
            }

            void ICollection.CopyTo(Array array, int index)
            {
                if (array == null)
                    throw new ArgumentNullException("array");
                if (index < 0)
                    throw new ArgumentOutOfRangeException("index", "error");
                for (var node = list.head; node != null; node = node.next)
                {
                    array.SetValue(isKeys ? node.key : node.value, index);
                    index++;
                }
            }

            int ICollection.Count
            {
                get
                {
                    var count = 0;
                    for (var node = list.head; node != null; node = node.next)
                    {
                        count++;
                    }
                    return count;
                }
            }

            bool ICollection.IsSynchronized
            {
                get { return false; }
            }

            object ICollection.SyncRoot
            {
                get { return list.SyncRoot; }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new NodeKeyValueEnumerator(list, isKeys);
            }


            private class NodeKeyValueEnumerator : IEnumerator
            {
                private readonly bool isKeys;
                private readonly ListDictionary list;
                private readonly int version;
                private DictionaryNode current;
                private bool start;

                public NodeKeyValueEnumerator(ListDictionary list, bool isKeys)
                {
                    this.list = list;
                    this.isKeys = isKeys;
                    version = list.version;
                    start = true;
                    current = null;
                }

                public object Current
                {
                    get
                    {
                        if (current == null)
                        {
                            throw new InvalidOperationException("error");
                        }
                        return isKeys ? current.key : current.value;
                    }
                }

                public bool MoveNext()
                {
                    if (version != list.version)
                    {
                        throw new InvalidOperationException("error");
                    }
                    if (start)
                    {
                        current = list.head;
                        start = false;
                    }
                    else if (current != null)
                    {
                        current = current.next;
                    }
                    return (current != null);
                }

                public void Reset()
                {
                    if (version != list.version)
                    {
                        throw new InvalidOperationException("error");
                    }
                    start = true;
                    current = null;
                }
            }
        }

        [Serializable]
        private class DictionaryNode
        {
            public object key;
            public DictionaryNode next;
            public object value;
        }
    }
}