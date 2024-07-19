using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomStack
{
    internal class SimpleStack<T>:IStack<T> 
    {
        private T[] elements;
        private int size;
        private int capacity;

        private const int DefaultCapacity = 4;

        public SimpleStack()
        {
            elements = new T[DefaultCapacity];
            size = 0;
            capacity = DefaultCapacity;
        }

        public void Push(T item)
        {
            if (size == capacity)
            {
                Resize(capacity * 2);
            }
            elements[size++] = item;
        }

        public T Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T item = elements[--size];
            elements[size] = default(T); 

            if (size > 0 && size == capacity / 4)
            {
                Resize(capacity / 2);
            }

            return item;
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return elements[size - 1];
        }

        public bool IsEmpty
        {
            get { return size == 0; }
        }

        public int Count
        {
            get { return size; }
        }

        private void Resize(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            Array.Copy(elements, 0, newArray, 0, size);
            elements = newArray;
            capacity = newCapacity;
        }
    }
}
