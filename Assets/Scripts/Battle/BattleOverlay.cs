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

    [Header("Player")]
    [SerializeField] TextMeshPro playerNameText;
    [SerializeField] TextMeshPro playerLevelText;
    [SerializeField] Slider playerHealthSlider;

    [Header("Enemy")]
    [SerializeField] TextMeshPro enemyNameText;
    [SerializeField] TextMeshPro enemyLevelText;
    [SerializeField] Slider enemyHealthSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();
        player = FindObjectOfType<PlayerBattle>();
        enemy = FindObjectOfType<EnemyBattle>();
        
        playerHealthSlider.maxValue = battleManager.PlayerMaxLife();
        playerHealthSlider.minValue = 0;
        playerHealthSlider.value = battleManager.PlayerCurrentLife();
        //playerNameText.text = player.Name;
        //playerLevelText.text = player.Level.ToString();
        
        enemyHealthSlider.maxValue = battleManager.EnemyMaxLife();
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.value += battleManager.EnemyCurrentLife();
        //enemyNameText.text = enemy.Name;
        //enemyLevelText.text = enemy.Level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthSlider.value = battleManager.PlayerCurrentLife();
        enemyHealthSlider.value += battleManager.EnemyCurrentLife();
    }
}
