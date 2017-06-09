using UnityEngine;

namespace Inventory
{
    public class ItemConfigurationCreator : MonoBehaviour
    {
        [ContextMenu("Create Basic Config")]
        public void CreateBasicConfig()
        {
            ItemConfiguration.CreateBasicConfiguration();
        }
    }
}