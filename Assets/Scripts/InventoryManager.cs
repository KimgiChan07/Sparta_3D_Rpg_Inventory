using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    
    private Dictionary<PartsType, ItemData> equipParts = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsItemEquipped(ItemData _item)
    {
        if (_item == null ) return false;

        if (_item.Type == ItemType.Armor)
        {
            if (_item.PartsType == PartsType.Nothing)
            {
                return false;
            }
        }

        return equipParts.TryGetValue(_item.PartsType, out var equipped) && equipped == _item;
    }

    public void EquipItem(ItemData _item)
    {
        if (!_item.IsEquipableType) return;
        if (_item.Type == ItemType.Armor)
        {
            if (_item.PartsType == PartsType.Nothing) return;
        }

        if (equipParts.TryGetValue(_item.PartsType,  out var oldEquippedItem))
        {
            equipParts[_item.PartsType] = _item;
            
            UIManager.Instance.uiInventory.UpdateUI(oldEquippedItem);
        }
        else
        {
            equipParts.Add(_item.PartsType, _item);
        }
        
        UIManager.Instance.uiInventory.UpdateUI(_item);
        UIManager.Instance.uiStatus.UpdateStatusUI();
    }

    public void UnequipItem(ItemData _item)
    {
        if (_item == null) return;
        
        if (_item.Type == ItemType.Armor)
        {
            if (_item.PartsType == PartsType.Nothing) return;
        }
        
        if (equipParts.ContainsKey(_item.PartsType) && equipParts[_item.PartsType] == _item)
        {
            equipParts.Remove(_item.PartsType);
        }
    }


    public float GetAttackValue()
    {
        float totalAtk = GameManager.Instance.characters.curAttack;
        foreach (var item in equipParts.Values)
        {
            totalAtk += item.Attack;
        }

        return totalAtk;
    }

    public float GetDefenseValue()
    {
        float totalDef = GameManager.Instance.characters.curDefense;
        foreach (var item in equipParts.Values)
        {
            totalDef += item.Defence;
        }

        return totalDef;
    }

    public float GetHealthValue()
    {
        float totalHealth = GameManager.Instance.characters.curHealth;
        foreach (var item in equipParts.Values)
        {
            totalHealth += item.Health;
        }

        return totalHealth;
    }

    public float GetCriticalValue()
    {
        float totalCritical = GameManager.Instance.characters.curCritical;
        foreach (var item in equipParts.Values)
        {
            totalCritical += item.CriticalChance;
        }

        return totalCritical;
    }
}