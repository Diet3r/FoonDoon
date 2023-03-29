using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //funtion to search for player and save as a playerpref
    public void SavePlayerPosition()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
            PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
            Debug.Log("X: " + PlayerPrefs.GetFloat("PlayerX") + " Y: " + PlayerPrefs.GetFloat("PlayerY") + " Z: " + PlayerPrefs.GetFloat("PlayerZ"));
        }
    }

    //funtion to search for every nearworld object and save as a playerpref
    public void SaveNearWorldPosition()
    {
        GameObject[] nearWorld = GameObject.FindGameObjectsWithTag("NearWorld");
        foreach (GameObject nearWorldObject in nearWorld)
        {
            NPCFighter npcFighter = nearWorldObject.GetComponent<NPCFighter>();
            if (npcFighter != null) 
            { 
                npcFighter.SetNearWorld(true); 
            }
            PlayerPrefs.SetFloat(nearWorldObject.name + "X", nearWorldObject.transform.position.x);
            PlayerPrefs.SetFloat(nearWorldObject.name + "Y", nearWorldObject.transform.position.y);
            PlayerPrefs.SetFloat(nearWorldObject.name + "Z", nearWorldObject.transform.position.z);
        }
    }
}
