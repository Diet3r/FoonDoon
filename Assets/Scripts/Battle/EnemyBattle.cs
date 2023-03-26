using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
    EnemyTurn enemyTurn;

    public string Name = "Red";
    public int Level = 2;
    public int maxLifePoints = 20;
    public int currentLifePoints = 20;
    public bool isAlife = true;

    public int maxEnergyPoints = 20;
    public int currentEnergyPoints = 20;

    int normalIni = 2;
    int modifierIni = 3;

    int normalAtk = 3;
    int normalDef = 3;

    public bool finAttacking = false;

    public List<SkillScriptableObjects> skillsLearned = new List<SkillScriptableObjects>();


    // Start is called before the first frame update
    void Start()
    {
        enemyTurn = GetComponent<EnemyTurn>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsTurn()
    {
        enemyTurn.UseSkill();
    }

    public int GetInitiave()
    {
        return normalIni + modifierIni;
    }

    public void DamageTaken(int damage)
    {
        currentLifePoints -= damage;
    }

    public void HealTaken(int heal)
    {
        currentLifePoints += heal;
    }

    public int UseSkill(int skillIndex)
    {
        if (skillsLearned[skillIndex].isAttack)
        {
            return 1;
        }
        else if (skillsLearned[skillIndex].isBuff)
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }

    public int UseAttack(int skillIndex)
    {
        Debug.Log("Gegner macht Schaden in höhe von" + skillsLearned[skillIndex].PhysDMG * normalAtk);
        return skillsLearned[skillIndex].PhysDMG * normalAtk;
    }
}
