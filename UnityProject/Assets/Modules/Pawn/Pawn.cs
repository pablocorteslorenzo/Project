using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;

namespace Game
{
    public class Pawn : TileElement, IInventoryOwner
    {
        public Attribute Health;
        public Attribute Mana;

        private InventoryController m_inventory;
        public InventoryController Inventory { get { return m_inventory; } }

        private GameObject m_gameObject;
        public GameObject GameObject { get { return m_gameObject; } }

        private void Awake()
        {
            m_gameObject = gameObject;
            InventoryManager.Instance.CreateInventory(this);
        }

        public void Initialize()
        {
            Health = new Attribute(220, 220, this, AttributeType.Health);
            Mana = new Attribute(100, 100, this, AttributeType.Mana);
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
