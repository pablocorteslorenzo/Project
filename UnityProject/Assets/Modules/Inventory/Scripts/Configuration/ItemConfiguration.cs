using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Inventory
{
    public class ItemConfiguration
    {
        public List<ItemData> ItemDataList = new List<ItemData>();

        public ItemData GetData(string _id)
        {
            for(int i=0; i<ItemDataList.Count; i++)
            {
                if(ItemDataList[i].ID == _id)
                {
                    return ItemDataList[i];
                }
            }
            return null;
        }

        public static ItemConfiguration ReadConfiguration()
        {
            TextAsset data = Resources.Load<TextAsset>("Configuration/ItemConfiguration");
            if (data != null)
            {
                return JsonConvert.DeserializeObject<ItemConfiguration>(data.text);
            }
            return new ItemConfiguration();
        }

        public static void CreateBasicConfiguration()
        {
            ItemConfiguration config = new ItemConfiguration();
            config.ItemDataList.Add(new ItemData());
            config.ItemDataList.Add(new ItemData());
            config.ItemDataList.Add(new ItemData());
            string textFile = JsonConvert.SerializeObject(config, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(Application.dataPath + "/Inventory/Resources/Configuration/ItemConfiguration.json"))
            {
                writer.Write(textFile);
                writer.Close();
#if UNITY_EDITOR
                AssetDatabase.Refresh();
#endif
            }
        }
    }
}