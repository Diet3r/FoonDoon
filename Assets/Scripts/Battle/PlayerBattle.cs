using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    public string Name = "Blue";
    public int Level = 5;
    public int maxLifePoints = 20;
    public int currentLifePoints = 20;
    public bool isAlife = true;

    public int maxEnergyPoints = 20;
    public int currentEnergyPoints = 20;

    int normalIni = 2;
    int modifierIni = 0;

    int normalAtk = 3;
    int normalDef = 3;

    public bool finAttacking = false;

    [SerializeField] public List<SkillScriptableObjects> skillsLearned = new List<SkillScriptableObjects>();

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
        Debug.Log("Spieler macht Schaden in höhe von " + skillsLearned[skillIndex].PhysDMG * normalAtk);
        return skillsLearned[skillIndex].PhysDMG * normalAtk;
    }
}
