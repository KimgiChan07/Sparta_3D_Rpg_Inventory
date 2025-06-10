using UnityEngine;
using UnityEngine.UI;

public class UIEquipItem : MonoBehaviour
{
    [SerializeField] private Button equipButton;
    [SerializeField] private Button unEquipButton;
    [SerializeField] private Button backButton;

    private ItemData curItem;
    private ItemSlot curSlot;

    private void Start()
    {
        gameObject.SetActive(false);
        equipButton.onClick.AddListener(EquipItem);
        unEquipButton.onClick.AddListener(UnEquipItem);
        backButton.onClick.AddListener(HidePanel);
    }

    public void Show(ItemData _itemData, ItemSlot _curSlot)
    {
        if (_itemData == null) return;
        curSlot=_curSlot;
        curItem = _itemData;
        gameObject.SetActive(true);
    }

    public void EquipItem()
    {
        if (curItem == null) return;
        InventoryManager.Instance.EquipItem(curItem);
        curSlot?.UpdateUI();
        UIManager.Instance.uiStatus.UpdateStatusUI();
    }

    public void UnEquipItem()
    {
        if (curItem == null) return;
        InventoryManager.Instance.UnequipItem(curItem);
        curSlot?.UpdateUI();
        UIManager.Instance.uiStatus.UpdateStatusUI();
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
        curItem = null;
    }
}