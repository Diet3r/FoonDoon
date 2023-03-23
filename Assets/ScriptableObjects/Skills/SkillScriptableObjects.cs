using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SkillData",menuName = "ScriptableObjects/SkillScriptableObject", order = 1)]
public class SkillScriptableObjects : ScriptableObject
{
    public int skillID;
    public int skillAnimationID;
    public string skillName;
    
    public bool useableOnWorld;
    public bool isAttack;
    public bool isDebuff;
    public bool isBuff;
    public bool isOverTime;
     
    public int physDMG;
    public int magicDMG;
    public int eleDMG;
    public enum EleTypes
    {
        Fire,
        Water,
        Lightning,
        Wind,
        Earth,
        Toxic,
        Dragon,
        Light,
        Darkness
    }
    public EleTypes eleType;
    public int overTimeDMG;
    public int overTimeRounds;    
}
