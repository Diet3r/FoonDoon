using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGame()
    {
        Debug.Log("SaveGame");
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
