using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedList<T>
    {
        private ListItem<T> first;
        private int size;

        public LinkedList()
        {
            this.first = null;
            this.size = 0;
        }

        public ListItem<T> First => this.first;

        public int Size => this.size;

        public void Add(T value)
        {
            if (this.first is null)
            {
                this.first = new ListItem<T>(value);
                this.size++;
                return;
            }

            var current = this.first;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = new ListItem<T>(value);
            this.size++;
        }

        public void InsertAfter(ListItem<T> element, T value)
        {
            var current = this.first;
            while (current != element)
            {
                current = current.Next;
            }

            var newValue = new ListItem<T>(value);
            newValue.Next = current.Next;
            current.Next = newValue;

            this.size++;
        }

        public void InsertBefore(ListItem<T> element, T value)
        {
            ListItem<T> newValue = new ListItem<T>(value);
            if (this.first == element)
            {
                newValue.Next = this.first;
                this.first = newValue;
                this.size++;
                return;
            }

            var current = this.first;
            while (current.Next != element)
            {
                current = current.Next;
            }

            newValue.Next = current.Next;
            current.Next = newValue;

            this.size++;
        }

        public void Remove(ListItem<T> element)
        {
            if (this.first == element)
            {
                this.first = first.Next;
                this.size--;
                return;
            }

            var current = this.first;
            while (current.Next != element)
            {
                current = current.Next;
            }

            var removed = current.Next;
            current.Next = removed.Next;

            size--;
        }

        public void Clear()
        {
            this.first = null;
            this.size = 0;
        }
    }
}