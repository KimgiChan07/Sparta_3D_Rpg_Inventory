using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private GameObject uiMainMenuPanel;
    [SerializeField] private GameObject uiStatusPanel;
    [SerializeField] private GameObject uiInventoryPanel;
    [SerializeField] private GameObject itemInfoPanel;
    [SerializeField] private GameObject buttonsPanel;
    
    public UIInventory uiInventory { get; private set; }
    public UIMainMenu uiMainMenu { get; private set; }
    public UIStatus uiStatus { get; private set; }
    public UIEquipItem uiEquipItem { get; private set; }
    
    public UIItemInfo uiItemInfo { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            uiMainMenu = uiMainMenuPanel.GetComponent<UIMainMenu>();
            uiStatus = uiStatusPanel.GetComponent<UIStatus>();
            uiInventory = uiInventoryPanel.GetComponent<UIInventory>();
            uiEquipItem = itemInfoPanel.GetComponent<UIEquipItem>();
            uiItemInfo = itemInfoPanel.GetComponent<UIItemInfo>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        buttonsPanel.SetActive(true);
        uiStatusPanel.SetActive(false);
        uiInventoryPanel.SetActive(false);
        uiMainMenu.UpdateUI();
    }

    public void ShowMainMenuPanel()
    {
        buttonsPanel.SetActive(true);
        uiStatusPanel.SetActive(false);
        uiInventoryPanel.SetActive(false);
        uiMainMenu.UpdateUI();
    }

    public void ShowStatusPanel()
    {
        uiStatusPanel.SetActive(true);
        uiInventoryPanel.SetActive(false);
        buttonsPanel.SetActive(false);
    }

    public void ShowInventoryPanel()
    {
        uiInventoryPanel.SetActive(true);
        uiStatusPanel.SetActive(false);
        buttonsPanel.SetActive(false);
    }
    
}
