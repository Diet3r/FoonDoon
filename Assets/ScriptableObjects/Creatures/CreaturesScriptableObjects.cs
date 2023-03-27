using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureData", menuName = "ScriptableObjects/CreatureScriptableObject", order = 0)]
public class CreaturesScriptableObjects : ScriptableObject
{
    public string Name;
    public int Level;
    
    public int maxLifePoints;
    public int currentLifePoints;
    public bool isAlife;

    public int maxEnergyPoints;
    public int currentEnergyPoints;

    public int normalIni;
    public int modifierIni;

    public int normalAtk;
    public int normalDef;

    public bool finAttacking { get; private set; }

    public List<SkillScriptableObjects> skillsLearned = new List<SkillScriptableObjects>();

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

    public void FinischAttacking(bool x)
    {
        finAttacking = x;
    }
}
