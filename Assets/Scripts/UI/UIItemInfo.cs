using System;
using TMPro;
using UnityEngine;

public class UIItemInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemStat;

    public void UpdateUI(ItemData _item)
    {
        if (_item == null)
        {
            itemStat.text = "";
            description.text = "";
            itemName.text = "";
            return;
        }
        
        itemName.text = _item.ItemName;
        description.text = _item.Description;
        itemStat.text = $"<color=red>+ATK {_item.Attack}</color> " +
                        $"/ <color=blue>+DEF {_item.Defence}</color> " +
                        $"/ <color=green>+HP {_item.Health}</color> " +
                        $"/ <color=yellow>+CRI {_item.CriticalChance}</color>";
        
    }
}
