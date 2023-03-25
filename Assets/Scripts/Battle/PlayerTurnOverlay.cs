using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnOverlay : MonoBehaviour
{
    [SerializeField] PlayerBattle player;
    [SerializeField] GameObject TurnStart;
    [SerializeField] GameObject TurnAttack;
    [SerializeField] GameObject TurnBackpack;

    [SerializeField] List<GameObject> attackButtons = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerBattle>();
        //DeactivateUnusedAttackButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        TurnStart.SetActive(true);
        TurnAttack.SetActive(false);
        TurnBackpack.SetActive(false);
        
    }

    public void DeactivateUnusedAttackButtons()
    {
        int unusedButtons = attackButtons.Count - player.skillsLearned.Count;
        for (int i = 0; i < unusedButtons; i++)
        {
            attackButtons[i].SetActive(false);
        }
    }

    public void StartAttackSelection()
    {
        TurnStart.SetActive(false);
        TurnAttack.SetActive(true);
        TurnBackpack.SetActive(false);
    }

    public void StartBackpackSelection() 
    {
        Debug.Log("Backpack not Loaded!");
    }

    public void BackToTurnStart()
    {
        TurnStart.SetActive(true);
        TurnAttack.SetActive(false);
        TurnBackpack.SetActive(false);
    }

    public void CancelBattle()
    {
        Debug.Log("Flieht ihr Narren!");
    }

    public void SelectAttack(int x)
    {
        Debug.Log("Attack[" + x + "] activated!");
                
    }
}
