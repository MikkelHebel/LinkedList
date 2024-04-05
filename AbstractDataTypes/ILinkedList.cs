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
        void DeleteAt(int index);
        object ItemAt(int index);
        string ToString();

        int Count { get; }
    }
}
