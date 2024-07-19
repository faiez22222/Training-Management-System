﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public interface IStack<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        bool IsEmpty { get; }
        int Count { get; }
    }

}
