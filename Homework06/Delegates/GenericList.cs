using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class GenericList<T>
    {
        private T[] _array = new T[0];
        public int Count { get; set; }
        public void Add(T element)
        {
            Array.Resize(ref _array, _array.Length + 1);
            _array[_array.Length - 1] = element;
            Count = _array.Length;
        }

        public T Remove(int removeIndex)
        {
            T removedItem = _array[removeIndex];
            int indexToRemove = removeIndex;
            _array = _array.Where((source, index) => index != indexToRemove).ToArray();
            return removedItem;
        }

        public void DisplayValues()
        {
            if (_array.Length == 0)
            {
                Console.WriteLine("there're no values to be displayed.");
            }
            else
            {
                if(_array.Length > 0)
                {
                    for (int i = 0; i < _array.Length; i++)
                    {
                        Console.WriteLine(_array[i]);
                    }
                }
            }
        }
        public T this[int i]
        {
            get { return _array[i]; }
            set { _array[i] = value; }
        }
    }
}
