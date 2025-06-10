using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI criticalChanceText;

    private void Start()
    {
        //초기 스탯 UI 설정
        attackText.text = $"{GameManager.Instance.characters.curAttack}";
        defenseText.text = $"{GameManager.Instance.characters.curDefense}";
        healthText.text = $"{GameManager.Instance.characters.curHealth}";
        criticalChanceText.text = $"{GameManager.Instance.characters.curCritical}";

    }

    public void UpdateStatusUI()
    {
        attackText.text = InventoryManager.Instance.GetAttackValue().ToString();
        defenseText.text = InventoryManager.Instance.GetDefenseValue().ToString();
        healthText.text = InventoryManager.Instance.GetHealthValue().ToString();
        criticalChanceText.text = InventoryManager.Instance.GetCriticalValue().ToString();
    }

}
