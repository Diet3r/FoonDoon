using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFighter : MonoBehaviour
{
    [SerializeField] NPCScriptableObject npcData;


    // Start is called before the first frame update
    void Start()
    {
        SetPositionAndRotation();
        SetNearWorld(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetNewPosAndRot();
    }

    void SetPositionAndRotation()
    {
        if (npcData != null) 
        {
            if (npcData.isNearWorld)
            {
                transform.position = npcData.tempPosition;
                transform.rotation = Quaternion.Euler(npcData.tempRotation);
            }
            else
            {
                transform.position = npcData.position;
                transform.rotation = Quaternion.Euler(npcData.rotation);
            }
        }
    }

    void SetNewPosAndRot()
    {
        if (npcData != null && ((transform.position != npcData.tempPosition) || (transform.rotation != Quaternion.Euler(npcData.tempRotation))))
        {
            npcData.tempPosition = transform.position;
            npcData.tempRotation = transform.rotation.eulerAngles;
        }
    }

    public void SetNearWorld(bool state)
    {
        npcData.isNearWorld = state;
    }

    public bool GetDefeated()
    {
        return npcData.isDefeated;
    }

    public void SetDefeated()
    {
        npcData.isDefeated = true;
    }
}
