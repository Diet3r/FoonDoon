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

    public bool isAttacking = false;
    public bool finAttacking = false;

    [SerializeField] List<int> attacksLearned = new List<int>();

    public string attackName = "Hau";
    public bool isDamageAttack = true;
    public int attackDamage = 10;
    public int attackEnergyCost = 5;

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

    void SetAlifeCheck()
    {
        if(currentLifePoints <= 0)
        {
            isAlife = false;
        }
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
    public int GetInitiave()
    {
        return normalIni + modifierIni;
    }
}
