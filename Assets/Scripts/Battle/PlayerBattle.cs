using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{

    [SerializeField] CreaturesScriptableObjects playerStats;
    List<SkillScriptableObjects> skillsLearned = new List<SkillScriptableObjects>();

    string Name = "Blue";
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
        Name = playerStats.Name;
        Level = playerStats.Level;
        maxLifePoints = playerStats.maxLifePoints;
        currentLifePoints = playerStats.currentLifePoints;
        isAlife = playerStats.isAlife;
        maxEnergyPoints = playerStats.maxEnergyPoints;
        currentEnergyPoints = playerStats.currentEnergyPoints;
        normalIni = playerStats.normalIni;
        modifierIni = playerStats.modifierIni;
        normalAtk = playerStats.normalAtk;
        normalDef = playerStats.normalDef;
        finAttacking = playerStats.finAttacking;
        skillsLearned = playerStats.skillsLearned;
    }

    public string GetName()
    {
        return Name;
    }

    public int GetLevel()
    {
        return Level;
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
        Debug.Log("Spieler macht Schaden in höhe von " + skillsLearned[skillIndex].PhysDMG * normalAtk);
        return skillsLearned[skillIndex].PhysDMG * normalAtk;
    }
}
