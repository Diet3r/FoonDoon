using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnOverlay : MonoBehaviour
{

    PlayerBattle player;
    BattleManager battleManager;

    [SerializeField] GameObject TurnStart;
    [SerializeField] GameObject TurnAttack;
    [SerializeField] GameObject TurnBackpack;

    int isP = 1;

    [SerializeField] List<GameObject> attackButtons = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBattle>();
        battleManager = FindObjectOfType<BattleManager>();
        DeactivateUnusedAttackButtons();
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
        Debug.Log("Ungenutze Köppe " + unusedButtons);
        for (int i = attackButtons.Count - 1; i > attackButtons.Count - unusedButtons - 1; i--)
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

    public void SelectAttack(int buttonNumber)
    {
        Debug.Log("Attack[" + buttonNumber + "] activated!");
        battleManager.FighterChoice(isP, buttonNumber); 
    }
}
