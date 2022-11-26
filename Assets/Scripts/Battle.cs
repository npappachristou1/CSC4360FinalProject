using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int targetId;
    // Start is called before the first frame update
    void Start()
    {
        zoneName = BattleInfo.zoneName;
        isBoss = BattleInfo.isBoss;
        enemiesTotal = BattleInfo.enemiesTotal;
        enemiesLvl =  BattleInfo.enemiesLvl;

        player1 = Party.player1;
        player2 = Party.player2;
        allActions = Party.allActions;

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

    void setBattle()
    {
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
        
    }

    public void setTarget(int targetNumber)
    {
        Debug.Log(targetNumber);
        targetArrow.position = enemySpriteRenderers[targetNumber].gameObject.transform.position + targetArrowOffSet;
    }

}
