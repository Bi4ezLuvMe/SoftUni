namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[this.Count - 1 - index];
            }
            set
            {
                ValidateIndex(index);
                items[this.Count - 1 - index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == items.Length)
            {
                Grow();
            }
            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[this.Count - 1 - i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (Count == items.Length)
            {
                Grow();
            }
            for (int i = Count; i > Count - index; i--)
            {
                items[i] = items[i - 1];
            }
            items[Count - index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            for (int i = Count - 1 - index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[Count - 1] = default;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Grow()
        {
            T[] newItems = new T[items.Length * 2];
            Array.Copy(items, newItems, items.Length);
            items = newItems;
        }
    }
}
