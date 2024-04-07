using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDataTypes
{
    public interface ILinkedList
    {
        void InsertAt(int index, object o);
        void Insert(object o);
        void Append(object o);
        void DeleteAt(int index);
        object ItemAt(int index);
        void Swap(int index);
        string ToString();

        int Count { get; }
        object First { get; }
        object Last { get; }
    }
}
