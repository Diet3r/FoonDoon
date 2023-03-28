using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleOverlay : MonoBehaviour
{
    BattleManager battleManager;

    [SerializeField] GameObject StandardOverlay;
    [SerializeField] GameObject TurnOverlay;

    [Header("Player")]
    [SerializeField] TextMeshProUGUI playerNameText;
    [SerializeField] TextMeshProUGUI playerLevelText;
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] Slider playerEnergySlider;

    [Header("Enemy")]
    [SerializeField] TextMeshProUGUI enemyNameText;
    [SerializeField] TextMeshProUGUI enemyLevelText;
    [SerializeField] Slider enemyHealthSlider;
    [SerializeField] Slider enemyEnergySlider;
    
    // Start is called before the first frame update
    void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();

        Invoke("LoadDataForUI", 0.001f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadDataForUI()
    {
        playerHealthSlider.maxValue = battleManager.PlayerMaxLife();
        playerHealthSlider.minValue = 0;
        playerHealthSlider.value = battleManager.PlayerCurrentLife();
        playerNameText.text = battleManager.Player().GetName();
        playerLevelText.text = "Lv. " + battleManager.Player().GetLevel().ToString();

        enemyHealthSlider.maxValue = battleManager.EnemyMaxLife();
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.value += battleManager.EnemyCurrentLife();
        enemyNameText.text = battleManager.Enemy().GetName();
        enemyLevelText.text = "Lv. " + battleManager.Enemy().GetLevel().ToString();
    }

    public void LifeUpdate()
    {
            playerHealthSlider.value = battleManager.PlayerCurrentLife();
            enemyHealthSlider.value = battleManager.EnemyCurrentLife();    
    }

    public void EnergyUpdate()
    {

    }

    public void ActivatePlayerTurnOverlay()
    {
        if (TurnOverlay.active)
        {
            return;
        }
        else
        {
            TurnOverlay.SetActive(true);
        }
    }

    public void DeactivatePlayerTurnOverlay()
    {
        if (TurnOverlay.active)
        {
            TurnOverlay.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
