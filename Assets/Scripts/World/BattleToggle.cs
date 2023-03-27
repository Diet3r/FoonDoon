using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleToggle : MonoBehaviour
{
    [SerializeField]List<CreaturesScriptableObjects> creatures = new List<CreaturesScriptableObjects>();
    [SerializeField]CreaturesScriptableObjects enemy;
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
                int i = Random.Range(0, creatures.Count);
                enemy = creatures[i];
                BattleCheck battleCheck = FindObjectOfType<BattleCheck>();
                battleCheck.SetBattle(true);
            }
            else
            {
                Debug.Log("Battle not toggled");
            }
        }
    }
}
