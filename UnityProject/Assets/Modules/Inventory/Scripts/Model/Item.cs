using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class Item
    {
        public ItemData Data { get; protected set; }

        public int Count { get; protected set; }
        public int Limit { get { return Data.Stack; } }
        public int Space { get; protected set; }

        public Item(ItemData _data, int _count = 1)
        {
            Data = _data;
            Count = _count;
            UpdateSpace();
        }

        private void UpdateSpace()
        {
            Space = Limit - Count;
        }

        public bool HasSpace()
        {
            return Space > 0;
        }

        public bool HasSpace(int _count)
        {
            return Space >= _count;
        }

        public bool HasSpace(int _count, out int _rest)
        {
            _rest = _count - Space;
            return HasSpace();
        }

        public void Set(int _count)
        {
            Count = _count;
            UpdateSpace();
        }

        public void Add(int _count)
        {
            Count += _count;
            UpdateSpace();
        }

        public void Full()
        {
            Count = Limit;
            UpdateSpace();
        }
    }
}