using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private GameObject equipIcon;
    [SerializeField] Button equipButton;

    private ItemData itemData;
    private bool isEquipped;

    private void Awake()
    {
        equipButton.onClick.AddListener(OnEquipItemButton);
    }

    public void SetItem(ItemData _itemData)
    {
        itemData = _itemData;
        Debug.Log(itemData.Name);
        UpdateUI();
    }

    private void OnEquipItemButton()
    {
        if (itemData == null) return;
        UpdateUI();
        UIManager.Instance.uiItemInfo.UpdateUI(itemData);
        UIManager.Instance.uiEquipItem.Show(itemData, this);
    }

    public void UpdateUI()
    {
        if (itemData == null)
        {
            itemIcon.enabled = false;
            equipIcon.SetActive(false);
            return;
        }

        itemIcon.enabled = true;
        itemIcon.sprite = itemData.Icon;
        equipIcon.SetActive(InventoryManager.Instance.IsItemEquipped(itemData));
    }


    public ItemType GetItemType()
    {
        return itemData != null ? itemData.Type : default;
    }
    public ItemData GetItemData()
    {
        return itemData;
    }
}