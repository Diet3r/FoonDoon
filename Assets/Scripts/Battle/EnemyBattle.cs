using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
    [SerializeField] CreaturesScriptableObjects enemyStats;
    EnemyTurn enemyTurn;
    List<SkillScriptableObjects> skillsLearned = new List<SkillScriptableObjects>();

    string Name;
    int Level;
    int maxLifePoints;
    int currentLifePoints;
    bool isAlife = true;

    int maxEnergyPoints;
    int currentEnergyPoints;

    int normalIni;
    int modifierIni;

    int normalAtk;
    int normalDef;

    bool finAttacking = false;

    private void Awake()
    {
        Name = enemyStats.Name;
        Level = enemyStats.Level;
        maxLifePoints = enemyStats.maxLifePoints;
        currentLifePoints = enemyStats.currentLifePoints;
        isAlife = enemyStats.isAlife;
        maxEnergyPoints = enemyStats.maxEnergyPoints;
        currentEnergyPoints = enemyStats.currentEnergyPoints;
        normalIni = enemyStats.normalIni;
        modifierIni = enemyStats.modifierIni;
        normalAtk = enemyStats.normalAtk;
        normalDef = enemyStats.normalDef;
        finAttacking = enemyStats.finAttacking;
        skillsLearned = enemyStats.skillsLearned;
    }

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
        Debug.Log("Enemy is turn");
        enemyTurn.UseSkill();
    }

    public string GetName()
    {
        return Name;
    }

    public int GetLevel()
    {
        return Level;
    }

    public int GetNormalIni()
    {
        return normalIni;
    }

    public int GetInitiave()
    {
        return normalIni + modifierIni;
    }

    public int GetMaxLifepoints()
    {
        return maxLifePoints;
    }

    public int GetCurrentLifepoints()
    {
        return currentLifePoints;
    }

    public bool GetIsAlife()
    {
        return isAlife;
    }

    public bool GetFinAttack()
    {
        return finAttacking;
    }

    public void SetFinAttack(bool b)
    {
        finAttacking = b;
    }
    public List<SkillScriptableObjects> GetSkillsLearned()
    {
        return skillsLearned;
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
