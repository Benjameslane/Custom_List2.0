using System;
using System.Collections;
using System.Collections.Generic;


namespace CustomList
{
    public class CustomList<T> : IEnumerable<T>
    {
        private T[] items; // array to hold list items
        private int count; // current count of items in list
        private int capacity; // total available capacity of list

        // Default constructor for the Custom List
        public CustomList()
        {
            count = 0;
            capacity = 4;
            items = new T[capacity];
        }

        // Copy Constructor for Custom List
        public CustomList(CustomList<T> other)
        {
            count = other.count;
            capacity = other.capacity;
            items = new T[capacity];
            Array.Copy(other.items, items, count);
        }

        // property Count
        public int Count
        {
            get { return count; }
        }

        // property capacity
        public int Capacity
        {
            get { return capacity; }
        }

        // indexing for the Custom List
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
        }

        // Add method to add given item in items array
        public void Add(T item)
        {
            if (count == capacity)
            {
                capacity *= 2;
                T[] newItems = new T[capacity];
                Array.Copy(items, newItems, count);
                items = newItems;
            }

            items[count] = item;
            count++;
        }

        // Add method to remove given item in items array
        public bool Remove(T item)
        {
            int index = Array.IndexOf(items, item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        // helper method for the Remove method
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[count - 1] = default(T);
            count--;
        }

        // overriden ToString method
        public override string ToString()
        {
            return string.Join(", ", items[..count]);
        }

        // overload for + operator
        public static CustomList<T> operator +(CustomList<T> CustomList1, CustomList<T> CustomList2)
        {
            CustomList<T> result = new CustomList<T>();
            foreach (T item in CustomList1)
            {
                result.Add(item);
            }
            foreach (T item in CustomList2)
            {
                result.Add(item);
            }
            return result;
        }

        // overload for - operator
        public static CustomList<T> operator -(CustomList<T> CustomList1, CustomList<T> CustomList2)
        {
            CustomList<T> result = new CustomList<T>(CustomList1);
            foreach (T item in CustomList2)
            {
                result.Remove(item);
            }
            return result;
        }

        // Zip method implementation
        public CustomList<T> Zip(CustomList<T> other)
        {
            CustomList<T> result = new CustomList<T>();
            int maxLength = Math.Max(count, other.count);

            for (int i = 0; i < maxLength; i++)
            {
                if (i < count)
                    result.Add(items[i]);

                if (i < other.count)
                    result.Add(other.items[i]);
            }

            items = result.items;
            count = result.count;
            capacity = result.capacity;
            result.Sort();
            return result;
        }

        // enumerator for the custom list 
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        // Quick sort implemntation for Custom list
        public void Sort()
        {
            QuickSortRecursive(items, 0, count - 1);
        }

        private void QuickSortRecursive(T[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                QuickSortRecursive(arr, left, pivotIndex - 1);
                QuickSortRecursive(arr, pivotIndex + 1, right);
            }
        }

        private int Partition(T[] arr, int left, int right)
        {
            T pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (Comparer<T>.Default.Compare(arr[j], pivot) <= 0)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);
            return i + 1;
        }

        private void Swap(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}


