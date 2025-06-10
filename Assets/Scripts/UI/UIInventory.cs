#if UNITY_EDITOR
#endif
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [Header("슬롯 설정")] [SerializeField] private ItemSlot slotPrefab;
    [SerializeField] private Transform slotsParent;

    [Header("상단 아이템 카운트 표시 텍스트")] [SerializeField]
    private TextMeshProUGUI itemCountText;

    [Header("초기 테스트용 아이템들")] [SerializeField]
    private List<ItemData> testItems;

    [Header("최대 슬롯 수")] [SerializeField] private int maxSlotCount = 100;

    private readonly List<ItemSlot> slots = new();

    private void Start()
    {
        Init(testItems);
    }

    public void Init(List<ItemData> _items)
    {
        ClearSlots();
        foreach (var item in _items)
        {
            ItemSlot slot = Instantiate(slotPrefab, slotsParent);
            slot.SetItem(item);
            slots.Add(slot);
        }

        UpdateCountText(_items.Count, maxSlotCount);
    }

    private void ClearSlots()
    {
        foreach (Transform child in slotsParent)
        {
            Destroy(child.gameObject);
        }

        slots.Clear();
    }

    private void UpdateCountText(int _curCount, int _maxCount)
    {
        if (itemCountText != null)
        {
            itemCountText.text = $"{_curCount}/{_maxCount}";
        }
    }


#if UNITY_EDITOR
    public void AddTestItem(ItemData _item)
    {
        if (!Application.isPlaying)
        {
            Debug.LogWarning("Play 모드에서만 작동합니다.");
            return;
        }

        if (_item != null)
        {
            testItems.Add(_item);

            ItemSlot slot = Instantiate(slotPrefab, slotsParent);
            slot.SetItem(_item);
            slots.Add(slot);

            UpdateCountText(testItems.Count, maxSlotCount);

            Debug.Log($"슬롯 생성 완료: {_item.name}");
        }
    }
#endif

    public void UpdateUI(ItemData _item)
    {
        foreach (var slot in slots)
        {
            if (slot.GetItemData() == _item)
            {
                slot.UpdateUI();
                return;
            }
        }
    }
}