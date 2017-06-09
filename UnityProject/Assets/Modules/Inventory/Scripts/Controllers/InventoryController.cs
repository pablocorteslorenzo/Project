using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        private IInventoryOwner m_owner;
        private Inventory m_inventory;

        public IInventoryOwner Owner { get { return m_owner; } }
        public Inventory Inventory { get { return m_inventory; } }

        public void Initialize(IInventoryOwner _owner)
        {
            m_inventory = new Inventory(10);
            m_inventory.Add(InventoryManager.Instance.CreateItem("000", 4));
            m_inventory.Add(InventoryManager.Instance.CreateItem("001", 1));
            m_inventory.Add(InventoryManager.Instance.CreateItem("002", 1));
        }

        public void Add(Item _item)
        {
            m_inventory.Add(_item);
        }
    }
}