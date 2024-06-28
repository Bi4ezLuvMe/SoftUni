namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;
        public MaxHeap()
        {
            elements = new List<T>();
        }

        public int Size => this.elements.Count;
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        public void Add(T element)
        {
           this.elements.Add(element);
           this.HeapifyUp(this.elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = this.GetParentIndex(index);

            while (index > 0 && this.IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = GetParentIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            T temp = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            if (this.elements[index].CompareTo(this.elements[parentIndex])>0)
            {
                return true;
            }

            return false;
        }

        public T ExtractMax()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T element = this.Peek();
            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HeapifyDown(0);
            return element;
        }

        private void HeapifyDown(int index)
        {
            int biggerChildIndex = this.GetBiggerChildIndex(index);
            while (ValidateIndex(biggerChildIndex)&&this.elements[biggerChildIndex].CompareTo(this.elements[index]) > 0)
            {
                this.Swap(biggerChildIndex, index);
                biggerChildIndex = GetBiggerChildIndex(index);
            }
        }

        private bool ValidateIndex(int index)
        {
            if (index >= 0 && index < this.elements.Count)
            {
                return true;
            }
            return false;
        }

        private int GetBiggerChildIndex(int index)
        {
            int firstChildIndex = index * 2 + 1;
            int secondChildIndex = index * 2 + 2;
            if (this.elements.Count == 1)
            {
                return -1;
            }
            if (this.elements.Count <= 2)
            {
                return firstChildIndex;
            }
            if (this.elements[firstChildIndex].CompareTo(this.elements[secondChildIndex]) > 0)
            {
                return firstChildIndex;
            }
            return secondChildIndex;
        }

        public T Peek()
        {
            return elements[0];
        }
    }
}
