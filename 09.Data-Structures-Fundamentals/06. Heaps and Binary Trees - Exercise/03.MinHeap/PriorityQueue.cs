using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    public class PriorityQueue<T> : MinHeap<T> where T : IComparable<T>
    {
        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public void Enqueue(T element)
        {
            elements.Add(element);

            this.HeapifyUp(element);
        }
        private void HeapifyUp(T element)
        {
            int parentIndex = (this.elements.Count - 1) / 2;
            int currentIndex = (this.elements.Count - 1);
            while (this.IsValidParentIndex(parentIndex) && this.elements[parentIndex].CompareTo(this.elements[currentIndex]) > 0)
            {
                this.Swap(parentIndex, currentIndex);
                currentIndex = parentIndex;
                parentIndex = currentIndex / 2;
            }
        }

        private bool IsValidParentIndex(int parentIndex)
        {
            if (parentIndex >= 0)
            {
                return true;
            }
            return false;
        }

        private void Swap(int parentIndex, int currentIndex)
        {
            T temp = elements[currentIndex];
            elements[currentIndex] = elements[parentIndex];
            elements[parentIndex] = temp;
        }
        public T Dequeue()
        {
            IsEmptyCollection();
            T element = elements[0];
            this.elements[0] = this.elements[this.Count - 1];
            this.elements.RemoveAt(this.Count - 1);
            this.HeapifyDown(0);
            return element;
        }
        private void HeapifyDown(int index)
        {
            int smallest = index;
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if (leftChildIndex < this.elements.Count && this.elements[leftChildIndex].CompareTo(this.elements[smallest]) < 0)
            {
                smallest = leftChildIndex;
            }

            if (rightChildIndex < this.elements.Count && this.elements[rightChildIndex].CompareTo(this.elements[smallest]) < 0)
            {
                smallest = rightChildIndex;
            }

            if (smallest != index)
            {
                this.Swap(index, smallest);
                this.HeapifyDown(smallest);
            }
        }
        void IsEmptyCollection()
        {
            if (this.elements.Count is 0)
            {
                throw new InvalidOperationException();
            }
        }
        public void DecreaseKey(T key)
        {
            this.HeapifyUp(key);
        }
    }
}
