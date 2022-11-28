using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Battle : MonoBehaviour
{
    string zoneName;
    bool isBoss;
    int enemiesTotal;
    int enemiesLvl;
    StatSheet player1;
    StatSheet player2;
    Actions[] allActions;

    public Sprite enemyZone, bossZone, finalBossZone;
    public SpriteRenderer background;
    public Sprite enemySprite1, enemySprite2, enemyBossSprite;
    public SpriteRenderer[] enemySpriteRenderers;
    public Transform targetArrow;
    Vector3 targetArrowOffSet;

    public TMP_Text player1Hp_UI, player1Mp_UI, player2Hp_UI, player2Mp_UI;
    public TMP_Text enemy1Hp_UI, enemy2Hp_UI, enemy3Hp_UI;
    public GameObject[] enemyList;
    public Dropdown player1Actions;
    public Dropdown player2Actions;
    
    string player1Action;
    string player2Action;
    bool canAttack;

    int player1Hp, player1HpMax, player1Mp, player1MpMax, player1Strength, player1Magic, player1Defense;
    int player2Hp, player2HpMax, player2Mp, player2MpMax, player2Strength, player2Magic, player2Defense;
    bool player1IsAlive = true, player2IsAlive = true;


    int targetId = 0;
    int[] enemyHp, enemyHpMax, enemyStrength;
    bool[] enemiesAlive;
    // Start is called before the first frame update
    void Start()
    {
        zoneName = BattleInfo.zoneName;
        isBoss = BattleInfo.isBoss;
        enemiesTotal = BattleInfo.enemiesTotal;
        enemiesLvl =  BattleInfo.enemiesLvl;

        enemyHp = new int[enemiesTotal];
        enemyHpMax = new int[enemiesTotal];
        enemyStrength = new int[enemiesTotal];
        enemiesAlive = new bool[enemiesTotal];
        for (int i = 0; i < enemiesTotal; i++)
        {
            enemyHp[i] = 400;
            enemyHpMax[i] = 400;
            enemyStrength[i] = 25;
            enemiesAlive[i] = true;
        }

        player1 = Party.player1;
        player2 = Party.player2;
        allActions = Party.allActions;
        canAttack = true;

        if (isBoss)
        {
            targetArrowOffSet = Vector3.up * 1.5f;
            targetArrow.position = enemySpriteRenderers[0].gameObject.transform.position + targetArrowOffSet;
        } else
        {
            targetArrowOffSet = Vector3.up;
        }

        setBattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerActions()
    {
        if (!canAttack)
        {
            return;
        }
        canAttack = false;

        setPlayer1Action();
        setPlayer2Action();
        Actions action1 = findAction(player1Action);
        Actions action2 = findAction(player2Action);

        // checks if character can make the attack based on its mp cost or if the character is alive
        if (player1Mp < action1.mpCost || player1Hp <= 0)
        {
            action1 = findAction("Nothing");
        }
        if (player2Mp < action2.mpCost || player2Hp <= 0)
        {
            action2 = findAction("Nothing");
        }

        Debug.Log("action1: " + action1.actionName + " action2: " + action2.actionName);

        // calculates damage values of the chosen actions and heal value if it is selected
        int attack1 = (int) ((player1Strength * action1.strengthMultiplier) + (player1Magic * action1.magicMultiplier));
        int attack2 = (int)((player2Strength * action2.strengthMultiplier) + (player2Magic * action2.magicMultiplier));
        int heal = 0;
        if (action2.actionName == "Heal")
        {
            heal = (int)(player2Magic + action2.hpBoost);
        }

        // actions take effect and stats are updated
        player1Mp -= action1.mpCost;
        player2Mp -= action2.mpCost;
        player1Hp += heal;
        player2Hp += heal;
        if (player1Hp > player1HpMax)
        {
            player1Hp = player1HpMax;
        }
        if (player2Hp > player2HpMax)
        {
            player2Hp = player2HpMax;
        }

        enemyHp[targetId] -= (attack1 + attack2);
        if (enemyHp[targetId] < 0)
        {
            enemyHp[targetId] = 0;
        }

        setUIStats();
        checkBattle();
        enemyResponse();
    }

    void enemyResponse()
    {
        // selects whish player the enemies will target
        string enemyTarget = "";
        if (player1Hp >= 0 && player2Hp >= 0)
        {
            int chance = Random.Range(0, 2);
            if (chance == 0)
            {
                enemyTarget = "warrior";
            } else
            {
                enemyTarget = "mage";
            }
        } else if (player1Hp >= 0)
        {
            enemyTarget = "warrior";
        } else
        {
            enemyTarget = "mage";
        }
        Debug.Log(enemyTarget);

        for (int i = 0; i < enemiesTotal; i++)
        {
            if (enemiesAlive[i])
            {
                int damage = enemyStrength[i];
                if (enemyTarget == "warrior")
                {
                    damage -= player1Defense;
                    player1Hp -= damage;

                    if (player1Hp < 0)
                    {
                        player1Hp = 0;
                    }
                } else
                {
                    damage -= player2Defense;
                    player2Hp -= damage;

                    if (player2Hp < 0)
                    {
                        player2Hp = 0;
                    }
                }
            }
        }

        setUIStats();
        checkBattle();
        canAttack = true;
    }

    void checkBattle()
    {
        bool allEnemiesDefeated = true;
        for (int i = 0; i < enemiesTotal; i++)
        {
            if (enemyHp[i] <= 0)
            {
                enemiesAlive[i] = false;
            }
            if (enemiesAlive[i])
            {
                allEnemiesDefeated = false;
            }
        }

        // check for win / loss conditions
        if (allEnemiesDefeated)
        {
            win();
        }
        if (player1Hp <= 0 && player2Hp <= 0)
        {
            lose();
        }

        // if current target is dead, target will be changed
        if (!enemiesAlive[targetId])
        {
            for (int i = 0; i < enemiesTotal; i++)
            {
                if (enemiesAlive[i])
                {
                    setTarget(i);
                    return;
                }
            }
        }
    }

    void win()
    {
        Debug.Log("win");
        if (isBoss)
        {
            SceneManager.LoadScene("Overworld");
        } else
        {
            SceneManager.LoadScene(zoneName);
            Party.expUp(20);
        }
        
    }

    void lose()
    {
        Debug.Log("lose");
        SceneManager.LoadScene("Start");
    }

    public void setPlayer1Action()
    {
        player1Action = player1Actions.options[player1Actions.value].text;
    }

    public void setPlayer2Action()
    {
        player2Action = player2Actions.options[player2Actions.value].text;
    }

    Actions findAction(string actionName)
    {
        for (int i = 0; i < allActions.Length; i++)
        {
            if (allActions[i].actionName == actionName)
            {
                return allActions[i];
            }
        }
        return allActions[0];
    }

    void setBattle()
    {
        // sets the background
        if (isBoss)
        {
            background.sprite = finalBossZone;
        } else if (zoneName == "Boss Zone")
        {
            background.sprite = bossZone;
        } else
        {
            background.sprite = enemyZone;
        }
        
        // sets enemy sprites
        for (int i = 0; i < enemiesTotal; i++)
        {
            if (isBoss)
            {
                enemySpriteRenderers[i].sprite = enemyBossSprite;
                
            } else if (zoneName == "Boss Zone")
            {
                enemySpriteRenderers[i].sprite = enemySprite2;
            } else if (zoneName == "Enemy Zone")
            {
                enemySpriteRenderers[i].sprite = enemySprite1;
            }
        }

        for (int i = 0; i < enemyList.Length; i++)
        {
            if (i >= enemiesTotal)
            {
                enemyList[i].SetActive(false);
            }
        }
        
        // adds actions to UI
        for (int i = 0; i < allActions.Length; i++)
        {
            string currentAction = allActions[i].actionName;
            string characterName = allActions[i].characterName;
            if (characterName == "warrior")
            {
                player1Actions.AddOptions(new List<string> { currentAction });
            } else if (characterName == "mage")
            {
                player2Actions.AddOptions(new List<string> { currentAction });
            }
        }

        // sets player stats
        player1Hp = player1.hpMax;
        player1HpMax = player1.hpMax;
        player1Mp = player1.mpMax;
        player1MpMax = player1.mpMax;
        player1Strength = player1.strength;
        player1Magic = player1.magic;
        player1Defense = player1.defense;

        player2Hp = player2.hpMax;
        player2HpMax = player2.hpMax;
        player2Mp = player2.mpMax;
        player2MpMax = player2.mpMax;
        player2Strength = player2.strength;
        player2Magic = player2.magic;
        player2Defense = player2.defense;

        // updates enemy stats if needed
        if (isBoss)
        {
            enemyHp[0] = 1000;
            enemyHpMax[0] = 1000;
            enemyStrength[0] = 40;
        }

        setUIStats();
    }

    void setUIStats()
    {
        player1Hp_UI.text = "" + player1Hp + "/" + player1HpMax;
        player1Mp_UI.text = "" + player1Mp + "/" + player1MpMax;
        player2Hp_UI.text = "" + player2Hp + "/" + player2HpMax;
        player2Mp_UI.text = "" + player2Mp + "/" + player2MpMax;

        TMP_Text[] enemyHp_UI = { enemy1Hp_UI, enemy2Hp_UI, enemy3Hp_UI };
        for (int i = 0; i < enemiesTotal; i++)
        {
            enemyHp_UI[i].text = "" + enemyHp[i] + "/" + enemyHpMax[i];
        }
    }

    public void setTarget(int targetNumber)
    {
        Debug.Log(targetNumber);
        if (targetNumber < enemiesTotal && enemiesAlive[targetNumber]) {
            targetId = targetNumber;
            targetArrow.position = enemySpriteRenderers[targetNumber].gameObject.transform.position + targetArrowOffSet;
        }
        
    }

}
