using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Inventory
{
    public class InventoryControllerView : MonoBehaviour
    {
        private InventoryController m_controller;

        private void Awake()
        {
            m_controller = GetComponent<InventoryController>();
        }

        private void Update()
        {
            if(m_controller == null)
            {
                m_controller = GetComponent<InventoryController>();
            }
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(InventoryControllerView))]
        public class InventoryControllerViewEditor : Editor
        {
            private InventoryControllerView m_instance;
            private Inventory m_inventory;

            void OnEnable()
            {
                m_instance = target as InventoryControllerView;
                m_inventory = m_instance.m_controller.Inventory;
            }
            public override void OnInspectorGUI()
            {
                EditorGUILayout.LabelField("Inventory Count " + m_inventory.ItemCount + "/" + m_inventory.ItemLimit);
                if (m_inventory.ItemCount > 0)
                {
                    for (int i = 0; i < m_inventory.ItemLimit; i++)
                    {
                        if(m_inventory.ItemList[i] != null)
                        {

                            EditorGUILayout.LabelField("Item " + i + " " + m_inventory.ItemList[i].Data.Name + " - " + m_inventory.ItemList[i].Count);
                        }
                        else
                        {
                            EditorGUILayout.LabelField("Item " + i + " Empty");
                        }
                    }
                }
            }
        }
#endif
    }
}