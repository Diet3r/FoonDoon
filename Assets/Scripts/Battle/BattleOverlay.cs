using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleOverlay : MonoBehaviour
{
    BattleManager battleManager;
    PlayerBattle player;
    EnemyBattle enemy;

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

    int battleState;
    
    // Start is called before the first frame update
    void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();
        player = FindObjectOfType<PlayerBattle>();
        enemy = FindObjectOfType<EnemyBattle>();
        
        playerHealthSlider.maxValue = battleManager.PlayerMaxLife();
        playerHealthSlider.minValue = 0;
        playerHealthSlider.value = battleManager.PlayerCurrentLife();
        playerNameText.text = player.Name;
        playerLevelText.text = "Lv. " + player.Level.ToString();
        
        enemyHealthSlider.maxValue = battleManager.EnemyMaxLife();
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.value += battleManager.EnemyCurrentLife();
        enemyNameText.text = enemy.Name;
        enemyLevelText.text = "Lv. " + enemy.Level.ToString();
    }

    // Update is called once per frame
    void Update()
    {

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
}
