using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BinksDisassembler.Tools
{
    class DescendingComparer<T> : IComparer<T> where T : IComparable<T> 
    {
        public int Compare(T x, T y)
        {
            Debug.Assert(y != null, nameof(y) + " != null");
            return y.CompareTo(x);
        }
    }
}