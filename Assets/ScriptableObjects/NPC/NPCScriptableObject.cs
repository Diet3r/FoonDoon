using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCData", menuName = "ScriptableObjects/NPCScriptableObject", order = 0)]
public class NPCScriptableObject : ScriptableObject
{
    public Vector3 position;
    public Vector3 rotation;

    public Vector3 tempPosition;
    public Vector3 tempRotation;

    public bool isNearWorld;

    public bool isDefeated;
}
