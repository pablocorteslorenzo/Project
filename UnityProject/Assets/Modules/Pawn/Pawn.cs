using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class Pawn : MonoBehaviour, IInventoryOwner
    {
        private InventoryController m_inventory;
        public InventoryController Inventory { get { return m_inventory; } }

        private GameObject m_gameObject;
        public GameObject GameObject { get { return m_gameObject; } }

        private void Awake()
        {
            m_gameObject = gameObject;
            InventoryManager.Instance.CreateInventory(this);
        }

        public void SetInventory(InventoryController _inventory)
        {
            m_inventory = _inventory;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha0))
            {
                m_inventory.Add(InventoryManager.Instance.CreateItem("000", 4));
            }
        }
    }
}
