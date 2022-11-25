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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
