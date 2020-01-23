using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{

    /// <summary>
    /// Custom Data structure to hold in an array the last x strings pushed.
    /// </summary>
    public struct CustomStringStack
    {
        public readonly string[] items;
        public readonly bool[] status;
        public readonly int size;

        /// <summary>
        /// Initialize the data structure.
        /// </summary>
        /// <param name="Size">Determines the size of the custom stack</param>
        public CustomStringStack(int Size)
        {
            if (Size <= 0) Size = 1;
            size = Size;
            items = new string[Size];
            status = new bool[Size];

            for (int i = 0; i < Size; i++)
            {
                items[i] = "";
                status[i] = true;
            }
        }

        /// <summary>
        /// Adds an item and drops the oldest item
        /// </summary>
        /// <param name="s">String to be stacked</param>
        /// <param name="b">State of the string being pushed</param>
        public void push(string s, bool b = true)
        {
            // Pull everything "down", dropping the oldest item
            for (int i = size - 1; i > 0; i--)
            {
                items[i] = items[i - 1];
                status[i] = status[i - 1];
            }

            // Put the string on position 0
            items[0] = s;
            status[0] = b;
        }

        public string ToSerializedUnverified() 
        {
            string serial = "[";
            foreach(string s in items)
            {
                serial += s + ",";
            }
            serial += "]";
            return serial;
        }
    }
}
