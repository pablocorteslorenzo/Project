using UnityEngine;

namespace Inventory
{
    public interface IInventoryOwner
    {
        InventoryController Inventory { get; }
        GameObject GameObject { get; }

        void SetInventory(InventoryController _inventory);
    }
}
