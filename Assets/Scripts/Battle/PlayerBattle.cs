using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle: MonoBehaviour
{
    int maxLifePoints = 20;
    int currentLifePoints = 20;
    bool isAlife = true;

    int maxEnergyPoints = 20;
    int currentEnergyPoints = 20;

    List<int> attacksLearned = new List<int>();

    string attackName = "Hau";
    bool isDamageAttack = true;
    int attackDamage = 10;
    int attackEnergyCost = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int GetMaxLifePoints()
    {
        return maxLifePoints;
    }

    int GetCurrentLifePoints() 
    {
        return currentLifePoints;
    }

    void SetCurrentLifePoints(int change)
    {
        currentLifePoints += change;
    }

    bool IsDamageAttack()
    {
        return isDamageAttack; 
    }

    int AttackOne()
    {
        return 5;
    }
}
