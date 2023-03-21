using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] PlayerBattle player;
    [SerializeField] EnemyBattle enemy;

    int playMaxLife;
    int enemyMaxLife;

    public int PlayerMaxLife()
    {
        return playMaxLife;
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
    BattleStates lastBattleState = BattleStates.Intro; //combination of BS and lBS triggers action! (SEE INSPECTSTATE)
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

    void Awake()
    {
        //StartIntro
        //LoadPlayer
        playMaxLife = player.maxLifePoints;
        playerCurrentLife = player.currentLifePoints;
        //LoadEnemy
        enemyMaxLife = enemy.maxLifePoints;
        enemyCurrentLife = enemy.currentLifePoints;
    }

    // Start is called before the first frame update
    void Start()
    {        
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
        InspectLife();
        //InspectLife
        //GiveAtkRight
        //Counting
    }

    void InspectState() //looks for State Equallity
    {
        if(AreStatesEqual(battleState, lastBattleState))
        {
            Debug.Log("Equal! / " + battleState + " / " + lastBattleState);
            EqualStateSwitch();
        }
        else
        {
            Debug.Log("UnEqual! / " + battleState + " / " + lastBattleState);
            UnequalStateSwitch();
        }
    }

    void InspectLife() //looks for teh death of one fighter
    {
        playerCurrentLife = player.currentLifePoints;
        enemyCurrentLife = enemy.currentLifePoints;

        if (playerCurrentLife <= 0 || enemyCurrentLife <= 0)
        {
            if (playerCurrentLife <= 0 && enemyCurrentLife <= 0)
            {
                SetEnemyWin();
            }
            else if (playerCurrentLife >= 0 && enemyCurrentLife <= 0)
            {
                SetPlayerWin();
            }
            else if (playerCurrentLife <= 0 && enemyCurrentLife >= 0)
            {
                SetEnemyWin();
            }
        }
        else
        {
            return;
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
                    Debug.Log(battleState);
                    CheckTurnCount();
                }
            break;

            case 2: 
                {
                    Debug.Log(battleState);
                    InTurnCheck();
                }
            break;
                case 3:
                {
                    Debug.Log(battleState);
                    InTurnCheck();
                }
                break;
                case 4:
                {
                    Debug.Log(battleState);
                }
                break;
                case 5:
                {
                    Debug.Log(battleState);
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
                    player.isAttacking = true; //attac starts

                    
                    //ActivatePlayerFightOverlay
                    lastBattleState = battleState;
                }
                break;
                case 3:
                {
                    Debug.Log(battleState);
                    enemy.isAttacking = true; //attac starts


                    //ActivatePlayerFightOverlay
                    lastBattleState = battleState;
                }
                break;
                case 4:
                {
                    Debug.Log(battleState);
                    TurnEndEqualIniCheck();
                }
                break;
                case 5:
                {
                    Debug.Log(battleState);
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
        Debug.Log(battleState + " " + lastBattleState);
        lastBattleState = battleState;
        battleState = BattleStates.PlayerTurn;
        Debug.Log(battleState + " " + lastBattleState);
    }

    void SetEnemyTurn()
    {
        Debug.Log(battleState + " " + lastBattleState);
        lastBattleState = battleState;
        battleState = BattleStates.EnemyTurn;
        Debug.Log(battleState + " " + lastBattleState);
    }

    void SetPlayerWin()
    {
        lastBattleState = battleState;
        battleState = BattleStates.PlayerWin;
    } //not in use

    void SetEnemyWin()
    {
        lastBattleState = battleState;
        battleState = BattleStates.EnemyWin;
    } //not in use

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
        if (battleState == BattleStates.PlayerTurn)
        {
            if (player.finAttacking)
            {
                enemy.currentLifePoints -= 5;
                Debug.Log("Player finished Attack!");
                lastBattleState = battleState;
                player.finAttacking = false;
                player.isAttacking = false;
                battleState = BattleStates.PlayerTurnEnd;
            }
            else
            {
                lastBattleState = battleState;
            }
        }
        else if (battleState == BattleStates.EnemyTurn)
        {
            if (enemy.finAttacking) 
            {
                player.currentLifePoints -= 5;
                Debug.Log("Enemy finished Attack!");
                lastBattleState = battleState;
                enemy.finAttacking = false;
                enemy.isAttacking = false;
                battleState = BattleStates.EnemyTurnEnd;
            }
            else
            {
                lastBattleState = battleState;
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
}