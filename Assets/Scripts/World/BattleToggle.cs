using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleToggle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Random.Range(1, 101) <= 50)
            {
                Debug.Log("No Battle toggled");
            }
            else
            {
                Debug.Log("Battle toggled");
            }
        }
    }
}
