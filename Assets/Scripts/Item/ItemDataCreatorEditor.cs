using System.IO;
using UnityEditor;
using UnityEngine;


[System.Serializable]
public class ItemDataToJson
{
    public string iconPath;
    
    public string name;
    public ItemType type;
    public bool isEquipable;
    public float attack;
    public float defence;
    public float health;
    public float criticalChance;
}

public class ItemDataCreatorEditor : EditorWindow
{
    private string itemName="New item";
    private Sprite icon;
    private bool isEquipable;
    private ItemType itemType;

    private float attack;
    private float defence;
    private float health;
    private float criticalChance;

    [MenuItem("Tools/ItemData 생성기")]
    public static void ShowWindow()
    {
        GetWindow<ItemDataCreatorEditor>("ItemData 생성기");
    }
    
    private void OnGUI()
    {
        GUILayout.Label("아이템 데이터 생성", EditorStyles.boldLabel);

        itemName = EditorGUILayout.TextField("아이템 이름", itemName);
        icon = (Sprite)EditorGUILayout.ObjectField("아이콘", icon, typeof(Sprite), false);
        attack = EditorGUILayout.FloatField("공격력", attack);
        defence = EditorGUILayout.FloatField("방어력", defence);
        health = EditorGUILayout.FloatField("체력", health);
        criticalChance = EditorGUILayout.FloatField("크리티컬 찬스(%)", criticalChance);      
        
        isEquipable = EditorGUILayout.Toggle("장착 아이템", isEquipable);
        itemType= (ItemType)EditorGUILayout.EnumPopup("아이템 타입", itemType);

        if (GUILayout.Button("ItemData 생성"))
        {
            CreateItemData();
        }
    }
    
    private void CreateItemData()
    {
        ItemData newItem = CreateInstance<ItemData>();
        newItem.name = itemName;
        newItem.Name = itemName;
        newItem.Icon = icon;
        newItem.Type = itemType;
        
        newItem.IsEquipableType = isEquipable;
        newItem.Attack = attack;
        newItem.Defence = defence;
        newItem.Health = health;
        newItem.CriticalChance = criticalChance;

        string folderPath = "Assets/ItemsData";
        string path = $"Assets/ItemsData/{itemName}.asset";
        
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            string[] split = folderPath.Split('/');
            string currentPath = split[0];
            for (int i = 1; i < split.Length; i++)
            {
                string nextPath = $"{currentPath}/{split[i]}";
                if (!AssetDatabase.IsValidFolder(nextPath))
                    AssetDatabase.CreateFolder(currentPath, split[i]);
                currentPath = nextPath;
            }
        }
        
        AssetDatabase.CreateAsset(newItem, path);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newItem;

        Debug.Log($"ItemData 생성 완료: {path}");
        
        SaveItemDataToJson(newItem);
    }

    private void SaveItemDataToJson(ItemData _itemData)
    {
        if (_itemData == null) return;
        if (_itemData.Icon == null)
        {
            Debug.Log("not found icon");
            _itemData.Icon = null;
        }
        
        ItemDataToJson jonData = new ItemDataToJson
        {
            name = _itemData.name,
            iconPath = AssetDatabase.GetAssetPath(_itemData.Icon).
                Replace("Assets/Resources/", "").
                Replace(".png", ""),
            isEquipable = _itemData.IsEquipableType,
            type = _itemData.Type,
            attack = _itemData.Attack,
            defence = _itemData.Defence,
            health = _itemData.Health,
            criticalChance = _itemData.CriticalChance,
        };
        
        string json = JsonUtility.ToJson(jonData,true);
        
        string jsonFolderPath = Application.persistentDataPath + "/ItemJson";

        if (!Directory.Exists(jsonFolderPath))
        {
            Directory.CreateDirectory(jsonFolderPath);
        }
        
        File.WriteAllText($"{jsonFolderPath}/{_itemData.Name}.json", json);
        
        AssetDatabase.Refresh();
    }
}
