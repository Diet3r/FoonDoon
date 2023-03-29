using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleToggle : MonoBehaviour
{
    [SerializeField]List<CreaturesScriptableObjects> creatures = new List<CreaturesScriptableObjects>();
    [SerializeField]CreaturesScriptableObjects enemy;
    
    GameSave gameSave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Random.Range(1, 101) <= 10)
            {
                int i = Random.Range(0, creatures.Count);
                SetEnemyByCreatur(i);

                gameSave = FindObjectOfType<GameSave>();
                gameSave.SavePlayerPosition();
                gameSave.SaveNearWorldPosition();

                BattleCheck battleCheck = FindObjectOfType<BattleCheck>();
                battleCheck.SetBattle(true);
            }
            else
            {
                Debug.Log("Battle not toggled");
            }
        }
    }

    void SetEnemyByCreatur( int i)
    {
        enemy.Name = creatures[i].Name;
        enemy.Level = creatures[i].Level;

        enemy.maxLifePoints = creatures[i].maxLifePoints;
        enemy.currentLifePoints = creatures[i].currentLifePoints;
        enemy.isAlife = creatures[i].isAlife;

        enemy.maxEnergyPoints = creatures[i].maxEnergyPoints;
        enemy.currentEnergyPoints = creatures[i].currentEnergyPoints;

        enemy.normalIni = creatures[i].normalIni;
        enemy.modifierIni = creatures[i].modifierIni;

        enemy.normalAtk = creatures[i].normalAtk;
        enemy.normalDef = creatures[i].normalDef;

        enemy.FinischAttacking(creatures[i].finAttacking);
    }
}
