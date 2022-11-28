using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Party
{
    //format: name, hp, mp, strength, magic, defense
    public static StatSheet player1 = new StatSheet("warrior", 100, 30, 50, 20, 50);
    public static StatSheet player2 = new StatSheet("mage", 70, 100, 15, 50, 20);
    public static int exp = 0, expMax = 100;



    //format: action name, character name, hp boost, mp cost, strength multiplier, magic multiplier, defense multiplier
    public static Actions[] allActions =
        {
            new Actions("Nothing", "all", 0, 0, 0f, 0f, 0f),
            new Actions("Normal Slash", "warrior", 0, 0, 1f, 0f, 0f),
            new Actions("Hard Slash", "warrior", 0, 5, 2.5f, 0f, 0f),
            new Actions("Magic Slash", "warrior", 0, 10, 0f, 3.5f, 0f),
            new Actions("Normal Blast", "mage", 0, 0, 0f, 1f, 0f),
            new Actions("Fire", "mage", 0, 10, 0f, 2f, 0f),
            new Actions("Heal", "mage", 50, 10, 0f, 0f, 0f),
        };

    public static void expUp(int expGained)
    {
        exp = exp + expGained;
        if (exp >= expMax)
        {
            
            int hp1 = (int) (player1.hpMax * 1.15f);
            int mp1 = (int) (player1.mpMax * 1.15f);
            int strength1 = (int) (player1.strength * 1.15f);
            int magic1 = (int) (player1.magic * 1.15f);
            int defense1 = (int) (player1.defense * 1.15f);

            int hp2 = (int)(player2.hpMax * 1.15f);
            int mp2 = (int)(player2.mpMax * 1.15f);
            int strength2 = (int)(player2.strength * 1.15f);
            int magic2 = (int)(player2.magic * 1.15f);
            int defense2 = (int)(player2.defense * 1.15f);

            player1 = new StatSheet("warrior", hp1, mp1, strength1, magic1, defense1);
            player2 = new StatSheet("mage", hp2, mp2, strength2, magic2, defense2);

            exp = 0;
            expMax = (int) (expMax * 1.15f);
        }
    }
}
