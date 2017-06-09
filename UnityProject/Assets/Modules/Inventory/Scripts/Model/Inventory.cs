using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class Inventory
    {
        public int ItemCount { get; protected set; }
        public int ItemLimit { get; protected set; }
        public int ItemSpace { get; protected set; }

        public Item[] ItemList { get; protected set; }

        private int m_tempInt;
        
        public Inventory(int _itemLimit)
        {
            ItemList = new Item[_itemLimit];
            ItemCount = 0;
            ItemLimit = _itemLimit;
            ItemSpace = ItemLimit - ItemCount;
        }

        public void Add(Item _item)
        {
            for(int i=0; i<ItemLimit; i++)
            {
                if(_item == null || _item.Count == 0)
                {
                    _item = null;
                    break;
                }
                if(ItemList[i] == null)
                {
                    ItemList[i] = _item;
                    _item = null;
                }
                else if(ItemList[i].Data.ID == _item.Data.ID && ItemList[i].HasSpace())
                {
                    if(ItemList[i].HasSpace(_item.Count))
                    {
                        ItemList[i].Add(_item.Count);
                        _item = null;
                    }
                    else if (ItemList[i].HasSpace(_item.Count, out m_tempInt))
                    {
                        ItemList[i].Add(_item.Count - m_tempInt);
                        _item.Set(m_tempInt);
                    }
                }
            }
            if (_item == null || _item.Count == 0)
            {
                _item = null;
            }
            UpdateCount();
        }

        private void UpdateCount()
        {
            ItemCount = 0;
            for (int i = 0; i < ItemLimit; i++)
            {
                ItemCount += ItemList[i] != null ? 1 : 0;
            }
            ItemSpace = ItemLimit - ItemCount;
        }

        virtual public void Remove(int _pos)
        {
            UpdateCount();
        }
    }
}