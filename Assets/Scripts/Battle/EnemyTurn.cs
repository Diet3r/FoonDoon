using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    EnemyBattle enemy;
    BattleManager battleManager;

    int isE = 2;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyBattle>();
        battleManager = FindObjectOfType<BattleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseSkill()
    {
        int skillIndex = Random.Range(0, enemy.GetSkillsLearned().Count);
        battleManager.FighterChoice(isE, skillIndex);
    }
}
