using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStartBattle : MonoBehaviour
{
    [SerializeField] CreaturesScriptableObjects NPCCreature;
    [SerializeField] CreaturesScriptableObjects enemy;

    GameSave gameSave;
    NPCFighter npcFighter;

    private void Start()
    {
        npcFighter = GetComponent<NPCFighter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (npcFighter != null && !npcFighter.GetDefeated())
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("PlayerBattle started");
                SetEnemyByCreatur();

                gameSave = FindObjectOfType<GameSave>();
                gameSave.SavePlayerPosition();
                gameSave.SaveNearWorldPosition();

                if (npcFighter != null)
                {
                    npcFighter.SetDefeated();
                }

                BattleCheck battleCheck = FindObjectOfType<BattleCheck>();
                battleCheck.SetBattle(true);
            }
        }
    }

    void SetEnemyByCreatur()
    {
        enemy.Name = NPCCreature.Name;
        enemy.Level = NPCCreature.Level;

        enemy.maxLifePoints = NPCCreature.maxLifePoints;
        enemy.currentLifePoints = NPCCreature.currentLifePoints;
        enemy.isAlife = NPCCreature.isAlife;

        enemy.maxEnergyPoints = NPCCreature.maxEnergyPoints;
        enemy.currentEnergyPoints = NPCCreature.currentEnergyPoints;

        enemy.normalIni = NPCCreature.normalIni;
        enemy.modifierIni = NPCCreature.modifierIni;

        enemy.normalAtk = NPCCreature.normalAtk;
        enemy.normalDef = NPCCreature.normalDef;

        enemy.FinischAttacking(NPCCreature.finAttacking);
    }
}
