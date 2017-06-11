using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public sealed class InventoryManager : MonoBehaviour
    {
        private static InventoryManager m_instance;
        public static InventoryManager Instance { get { return m_instance; } }

        public static bool IsSet { get { return m_instance != null; } }

        public ItemConfiguration ItemConfig { get; private set; }

        public static InventoryManager GetInstance()
        {
            if(!IsSet)
            {
                GameObject newManager = new GameObject();
                m_instance = newManager.AddComponent<InventoryManager>();
            }
            return m_instance;
        }

        private void Awake()
        {
            m_instance = this;
            gameObject.name = "[InventoryManager]";
            ItemConfig = ItemConfiguration.ReadConfiguration();
        }

        public InventoryController CreateInventory(IInventoryOwner _owner)
        {
            InventoryController controller = _owner.GameObject.AddComponent<InventoryController>();
            controller.Initialize(_owner);
            _owner.SetInventory(controller);
            return controller;
        }

        public Item CreateItem(string _id, int _count)
        {
            ItemData itemData = ItemConfig.GetData(_id);
            if(itemData != null)
            {
                Item item = new Item(itemData, _count);
                return item;
            }
            return null;
        }

        public void MoveItems()
        {

        }

        private void OnDestroy()
        {
            m_instance = null;
        }
    }
}
