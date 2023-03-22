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

    public bool isAttacking = false;
    public bool finAttacking = false;

    [SerializeField] List<SkillScriptableObjects> skillsLearned = new List<SkillScriptableObjects>();

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

    public int GetInitiave()
    {
        return normalIni + modifierIni;
    }
}
