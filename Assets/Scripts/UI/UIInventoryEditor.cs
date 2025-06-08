using System;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(UIInventory))]
public class UIInventoryEditor : Editor
{
    private UIInventory inventory;
    private ItemData testItemData;

    private void OnEnable()
    {
        inventory = (UIInventory)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        EditorGUILayout.Space(10);
        
        EditorGUILayout.LabelField(" 테스트 아이템 추가", EditorStyles.boldLabel);

        testItemData = (ItemData)EditorGUILayout.ObjectField("추가할 아이템", testItemData, typeof(ItemData), false);

        
        if (GUILayout.Button("테스트 아이템"))
        {
            if (testItemData != null)
            {
                inventory.AddTestItem(testItemData);
                EditorUtility.SetDirty(inventory);
            }
        }
    }
}
