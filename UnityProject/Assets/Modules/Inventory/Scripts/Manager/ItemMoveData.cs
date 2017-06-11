using System.Collections.Generic;

namespace Inventory
{
    public class ItemMoveData
    {
        public Inventory InventoryStart;
        public Inventory InventoryEnd;

        public List<Item> ItemList;

        public ItemMoveData(Inventory _inventoryStart, Inventory _inventoryEnd, List<Item> _itemList)
        {
            InventoryStart = _inventoryStart;
            InventoryEnd = _inventoryEnd;
            ItemList = _itemList;
        }

        public void MoveItems()
        {

        }
    }
}