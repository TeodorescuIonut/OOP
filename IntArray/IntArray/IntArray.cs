﻿using System;

namespace Arrays
{
    public class IntArray
    {
        private int[] array;
        private int currentPos;

        public IntArray()
        {
            const int size = 4;
            array = new int[size];
        }

        public void Add(int element)
            {
            if (currentPos < array.Length)
            {
                array[currentPos] = element;
                currentPos++;
            }
            else
            {
                const int sizeDouble = 2;
                Array.Resize(ref array, array.Length * sizeDouble);
            }
        }

        public int Count()
        {
            return array.Length;
        }

        public int Element(int index)
        {
            return (int)array.GetValue(index);
        }

        public void SetElement(int index, int element)
        {
            array.SetValue(element, index);
        }

        public bool Contains(int element)
        {
            return Array.Exists(array, x => x.Equals(element));
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element);
        }

        public void Insert(int index, int element)
        {
            int[] newarr = new int[array.Length + 1];
            for (int i = 0; i < array.Length + 1; i++)
            {
                if (i < index - 1)
                {
                    newarr[i] = array[i];
                }
                else if (i == index - 1)
                {
                    newarr[i] = element;
                }
                else
                {
                    newarr[i] = array[i - 1];
                }
            }

            array = newarr;
        }

        public void Clear()
        {
            array = Array.Empty<int>();
        }

        public void Remove(int element)
            {
            if (IndexOf(element) == -1)
            {
                return;
            }

            for (int j = IndexOf(element); j < Count() - 1; j++)
            {
                SetElement(j, Element(j + 1));
            }

            Array.Resize(ref array, Count() - 1);
        }

        public void RemoveAt(int index)
        {
            if (!Contains(Element(index)))
            {
                return;
            }

            for (int j = index; j < Count() - 1; j++)
            {
                SetElement(j, Element(j + 1));
            }

            Array.Resize(ref array, Count() - 1);
            }
        }
    }
