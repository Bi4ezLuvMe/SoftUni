namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new IndexOutOfRangeException();
            }
            items = new T[capacity];
        }

        public T this[int index] 
        {
            get 
            {
                ValidateIndex(index);
                return items[index];
            }
            set 
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            Grow();

            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            Grow();

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i-1];
            }
            this.items[index] = item;
            this.Count++;
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
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();
        private void Grow()
        {
            if (this.Count == this.items.Length)
            {
                T[] newItems = new T[this.items.Length * 2];
                int index = 0;
                foreach (T item in this.items)
                {
                    newItems[index++] = item;
                }
                this.items = newItems;
            }
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid Index!");
            }
        }
    }
}