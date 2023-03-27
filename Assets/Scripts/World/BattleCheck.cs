using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleCheck : MonoBehaviour
{
    bool isBattle = false;

    // Update is called once per frame
    void Update()
    {
        CheckForBattleStart();
    }

    public void SetBattle(bool battle)
    {
        isBattle = battle;
    }

    void CheckForBattleStart()
    {
        if (isBattle)
        {
            SceneManager.LoadScene("SampleBattle");
        }
    }
}
