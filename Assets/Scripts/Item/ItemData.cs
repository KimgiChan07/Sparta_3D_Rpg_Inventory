using UnityEngine;
using UnityEngine.Serialization;

public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
}

public enum PartsType
{
    Nothing,
    Helmet,
    Clothes,
    Leggings,
    Shoes,
}

[CreateAssetMenu(fileName = "NewItem",menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    [Header("아이템 기본설정")]
    public string Name;
    public string Description;
    public Sprite Icon;
    
    [Header("아이템 타입")]
    public ItemType Type;
    
    [Header("아이템이 장착 방어구일 때.")]
    public PartsType PartsType;
    
    [Header("장착여부")]
    public bool IsEquipableType;

    [Header("아이템 스탯")] 
    public float Attack;
    public float Defence;
    public float Health;
    public float CriticalChance;
    
}
