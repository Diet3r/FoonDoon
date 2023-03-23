using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle: MonoBehaviour
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

    public bool finAttacking = false;

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
}
