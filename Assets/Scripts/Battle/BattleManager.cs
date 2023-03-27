using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    PlayerBattle player;
    EnemyBattle enemy;
    BattleOverlay overlay;

    int playerMaxLife;
    int enemyMaxLife;

    public int PlayerMaxLife()
    {
        return playerMaxLife;
    }

    public int EnemyMaxLife()
    {
        return enemyMaxLife;
    }

    int playerCurrentLife;
    int enemyCurrentLife;

    public int PlayerCurrentLife()
    {
        return playerCurrentLife;
    }

    public int EnemyCurrentLife()
    {
        return enemyCurrentLife;
    }
        
    int playerIni;
    int enemyIni;
    public bool isPlayerFaster = true;

    int counter = 0;
    int lastCounter = 0;
    BattleStates battleState = BattleStates.Intro; // 0 Intro, 1 CountNextTurn, 2 PlayerTurn, 3 EnemyTurn, 4 PlayerTurnEnd, 5 EnemyTurnEnd, 6 PlayerWin, 7 EnemyWin, 8 End;
    BattleStates lastBattleState = BattleStates.Intro; //state before this

    public int GetBattleStates() => (int)battleState;
    enum BattleStates
    {
        Intro,
        CountNextTurn,
        PlayerTurn,
        EnemyTurn,
        PlayerTurnEnd,
        EnemyTurnEnd,
        PlayerWin,
        EnemyWin,
        End
    }

    private void Awake()
    {
        player = FindObjectOfType<PlayerBattle>();
        enemy = FindObjectOfType<EnemyBattle>();
        overlay = FindObjectOfType<BattleOverlay>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartIntro
        //LoadPlayer
        playerMaxLife = player.GetMaxLifepoints();
        playerCurrentLife = player.GetCurrentLifepoints();
        //LoadEnemy
        enemyMaxLife = enemy.GetMaxLifepoints();
        enemyCurrentLife = enemy.GetCurrentLifepoints();

        //LoadStatsForCounter
        playerIni = player.GetInitiave();
        enemyIni = enemy.GetInitiave();
        //Count and BattleState Start
        counter = 1;
        lastCounter = 0;
        battleState = BattleStates.CountNextTurn;
        lastBattleState = BattleStates.Intro;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogWarning(counter + " / " + lastCounter);
        InspectState();
        //InspectLife
        //GiveAtkRight
        //Counting
    }

    void InspectState() //looks for State Equallity
    {
        if(AreStatesEqual(battleState, lastBattleState))
        {
            EqualStateSwitch();
        }
        else
        {
            UnequalStateSwitch();
        }
    }

    bool AreStatesEqual(BattleStates S, BattleStates LS) //State Equal test
    {
        if(S == LS)
        {
            return true;
        }
        else
        {
            return false;
        }
    } 

    void EqualStateSwitch() //switch if states equal, waiting for updates
    {
        switch ((int)battleState) 
        {
            case 1:
                {
                    CheckTurnCount();
                }
            break;

            case 2: 
                {
                    overlay.ActivatePlayerTurnOverlay();
                    InTurnCheck();
                }
            break;
            case 3:
                {
                    InTurnCheck();
                }
            break;
            case 4:
                {
                }
            break;
            case 5:
                {
                }
            break;
            case 6:
                {
                }
            break;
            case 7: 
                {
                }
            break;
            case 8:
                {                
                }
            break;
            default: 
                {
                    Debug.Log("Falscher BattleState wiederholt!!!!");
                }
            break;
        }
        
    } 

    void UnequalStateSwitch() //switch if states unequal, checking if something is new
    {
        switch ((int)battleState)
        {
            case 1:
                {
                    Debug.Log(battleState);
                    CheckTurnCount();
                }
            break;
            case 2:
                {
                    Debug.Log(battleState);
                    overlay.ActivatePlayerTurnOverlay();                    
                    lastBattleState = battleState;
                }
            break;
            case 3:
                {
                    Debug.Log(battleState);
                    enemy.IsTurn();

                    lastBattleState = battleState;
                }
            break;
            case 4:
                {
                    Debug.Log(battleState);
                    InspectLife();
                    overlay.LifeUpdate();
                    overlay.DeactivatePlayerTurnOverlay();
                    TurnEndEqualIniCheck();
                }
            break;
            case 5:
                {
                    Debug.Log(battleState);
                    InspectLife();
                    overlay.LifeUpdate();
                    TurnEndEqualIniCheck();
                }
            break;
            case 6:
                {
                    Debug.Log(battleState);
                }
            break;
            case 7:
                {
                    Debug.Log(battleState);
                }
            break;
            case 8: 
                {
                    Debug.Log(battleState);
                }
            break;
            default:
                {
                    Debug.LogError("Falscher BattleState!!!!");
                }
            break;
        }

    }

    void InspectLife() //looks for teh death of one fighter
    {
        playerCurrentLife = player.GetCurrentLifepoints();
        enemyCurrentLife = enemy.GetCurrentLifepoints();

        if (playerCurrentLife <= 0 || enemyCurrentLife <= 0)
        {
            if (playerCurrentLife <= 0)
            {
                SetEnemyWin();
            }
            else if (playerCurrentLife >= 0 && enemyCurrentLife <= 0)
            {
                SetPlayerWin();
            }
        }
        else
        {
            return;
        }
    }

    void SetCounterNext()
    {
        lastBattleState = battleState;
        lastCounter = counter;
        counter++;

        if (battleState != BattleStates.CountNextTurn)
        {
            battleState = BattleStates.CountNextTurn;
        }
    }

    void SetPlayerTurn()
    {
        lastBattleState = battleState;
        battleState = BattleStates.PlayerTurn;
    }

    void SetEnemyTurn()
    {
        lastBattleState = battleState;
        battleState = BattleStates.EnemyTurn;
    }

    void SetPlayerWin()
    {
        lastBattleState = battleState;
        battleState = BattleStates.PlayerWin;
    }

    void SetEnemyWin()
    {
        lastBattleState = battleState;
        battleState = BattleStates.EnemyWin;
    }

    void SetEnd()
    {
        lastBattleState = battleState;
        battleState = BattleStates.End;
    } //not in use

    void CheckTurnCount() //Check if Counter is right for someones turn
    {
        if (counter % playerIni == 0 || counter % enemyIni == 0)
        {
            if (counter % enemyIni == 0 && counter % playerIni == 0)
            {
                if (isPlayerFaster)
                {
                    SetPlayerTurn();
                }
                else
                {
                    SetEnemyTurn();
                }
            }
            else if (counter % playerIni == 0)
            {
                SetPlayerTurn();
            }
            else if (counter % enemyIni == 0)
            {
                SetEnemyTurn();
            }
        }
        else
        {
            Debug.Log("Counter without hit " + counter + " " + lastCounter);
            SetCounterNext();
        }
    }

    void InTurnCheck() //Check in turn if enemy/player finished their attack
    {
        lastBattleState = battleState;
        if (battleState == BattleStates.PlayerTurn)
        {
            if (player.GetFinAttack())
            {
                player.SetFinAttack(false);
                battleState = BattleStates.PlayerTurnEnd;
            }
        }
        else if (battleState == BattleStates.EnemyTurn)
        {
            if (enemy.GetFinAttack()) 
            {
                enemy.SetFinAttack(false);
                battleState = BattleStates.EnemyTurnEnd;
            }
        }
    } 

    void TurnEndEqualIniCheck() //Check if both fighters got a turn this counter
    {
        if (battleState == BattleStates.PlayerTurnEnd)
        {
            if (counter % enemyIni == 0 && isPlayerFaster) 
            {
                SetEnemyTurn();
            }
            else
            {
                SetCounterNext();
            }
        }
        else if (battleState == BattleStates.EnemyTurnEnd)
        {
            if (counter % playerIni == 0 && !isPlayerFaster)
            {
                SetPlayerTurn();
            }
            else
            {
                SetCounterNext();
            }
        }
    } 

    public void FighterChoice(int PE, int skillIndex)
    {
        if (PE == 1)
        {
            switch (player.UseSkill(skillIndex))
            {                
                case 1:
                {
                        enemy.DamageTaken(player.UseAttack(skillIndex));
                }
                    break;
                case 2:
                {
                        player.HealTaken(player.UseAttack(skillIndex));
                }
                    break;
                default:
                {
                    Debug.Log("Attacke kann nichts!");
                }
                    break;
            }
            player.SetFinAttack(true);
        }
        else if (PE == 2)
        {
            switch (enemy.UseSkill(skillIndex))
            {
                case 1:
                    {
                        player.DamageTaken(enemy.UseAttack(skillIndex));
                    }
                    break;
                case 2:
                    {
                        enemy.HealTaken(enemy.UseAttack(skillIndex));
                    }
                    break;
                default:
                    {
                        Debug.Log("Attacke kann nichts!");
                    }
                    break;
            }
            enemy.SetFinAttack(true);
        }
        else
        {
            Debug.Log("FightersChoice von keinem?!");
        }
    }
}