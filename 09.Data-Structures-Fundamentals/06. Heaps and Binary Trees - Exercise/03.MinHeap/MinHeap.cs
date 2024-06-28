using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Count => elements.Count;

        public void Add(T element)
        {
            elements.Add(element);

            this.HeapifyUp(element);
        }

        private void HeapifyUp(T element)
        {
            int parentIndex =(this.elements.Count - 1) / 2;
            int currentIndex = (this.elements.Count - 1);
            while (this.IsValidParentIndex(parentIndex)&&this.elements[parentIndex].CompareTo(this.elements[currentIndex])>0)
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

        private void Swap(int parentIndex,int currentIndex)
        {
            T temp = elements[currentIndex];
            elements[currentIndex] = elements[parentIndex];
            elements[parentIndex] = temp;
        }

        public T ExtractMin()
        {
            IsEmptyCollection();
            T element = this.Peek();
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
        public T Peek()
        {
            IsEmptyCollection();
           return elements[0];
        }
        public 
        void IsEmptyCollection()
        {
            if(this.elements.Count is 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
