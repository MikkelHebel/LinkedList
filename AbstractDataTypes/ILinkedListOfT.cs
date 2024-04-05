using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDataTypes
{
    public interface ILinkedList<T>
    {
        void InsertAt(int index, T o);
        void Insert(T o);
        void Append(T o);
        void DeleteAt(int index);
        T ItemAt(int index);
        string ToString();

        int Count { get; }
        T First { get; }
        T Last { get; }
    }
}
