using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldOverlay : MonoBehaviour
{
    public GameObject mainMenu;
    // Update is called once per frame
    void Update()
    {
        CheckForMenu();
    }

    void CheckForMenu()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(mainMenu.active)
            {
                mainMenu.SetActive(false);
            }
            else
            {
                mainMenu.SetActive(true);
            }
        }
    }
}
