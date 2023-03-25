using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
    public string Name = "Red";
    public int Level = 2;
    public int maxLifePoints = 20;
    public int currentLifePoints = 20;
    public bool isAlife = true;

    public int maxEnergyPoints = 20;
    public int currentEnergyPoints = 20;

    int normalIni = 2;
    int modifierIni = 3;

    public bool finAttacking = false;

    public List<SkillScriptableObjects> skillsLearned = new List<SkillScriptableObjects>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
