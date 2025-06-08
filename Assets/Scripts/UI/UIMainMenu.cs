
using System;
using TMPro;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public TextMeshProUGUI currentLevel;
    public TextMeshProUGUI currentGold;
    public TextMeshProUGUI currentName;
    public TextMeshProUGUI currentDescription;

    private void Start()
    {
        TestMainUI();
    }

    public void UpdateUI()
    {
        currentName.text = GameManager.Instance.characters.name;
        currentDescription.text = GameManager.Instance.characters.description;
        currentGold.text = GameManager.Instance.characters.gold.ToString("N0");
        currentLevel.text = GameManager.Instance.characters.level.ToString();
    }
    
    public void TestMainUI()
    {
        // 테스트 캐릭터 생성
        GameManager.Instance.characters = new Character("테스트", "테스트 캐릭터입니다.", 99, 99999);

        // UI 갱신
        UpdateUI();
    }
    
}
