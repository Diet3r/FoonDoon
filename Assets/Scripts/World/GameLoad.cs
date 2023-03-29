using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoad : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("running")) 
        { 
            PlayerPrefs.DeleteKey("PlayerX");
            PlayerPrefs.DeleteKey("PlayerY");
            PlayerPrefs.DeleteKey("PlayerZ");
        
            PlayerPrefs.SetInt("running", 1);
        }
        LoadPlayerPosition();
        LoadNearWorld();
        PlayerPrefs.DeleteAll();
        Debug.Log("Call Gameload");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to search for playerprefs and load into player object
    void LoadPlayerPosition()
    {
        GameObject player = GameObject.Find("Player");
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        {
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        }
    }

    //funtion to search for every playerpref and load into corresponding object
    void LoadNearWorld()
    {
        GameObject[] nearWorld = GameObject.FindGameObjectsWithTag("NearWorld");
        foreach (GameObject nearWorldObject in nearWorld)
        {
            if (PlayerPrefs.HasKey(nearWorldObject.name + "X") && PlayerPrefs.HasKey(nearWorldObject.name + "Y") && PlayerPrefs.HasKey(nearWorldObject.name + "Z"))
            {
                nearWorldObject.transform.position = new Vector3(PlayerPrefs.GetFloat(nearWorldObject.name + "X"), PlayerPrefs.GetFloat(nearWorldObject.name + "Y"), PlayerPrefs.GetFloat(nearWorldObject.name + "Z"));
            }
        }
    }
}
