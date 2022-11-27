using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Party
{
    //format: name, hp, mp, strength, magic, defense
    public static StatSheet player1 = new StatSheet("warrior", 100, 30, 50, 20, 50);
    public static StatSheet player2 = new StatSheet("mage", 70, 100, 15, 80, 20);
    public static int exp = 0, expMax = 100;

    //format: action name, character name, hp boost, mp cost, strength multiplier, magic multiplier, defense multiplier
    public static Actions[] allActions =
        {
            new Actions("Nothing", "all", 0, 0, 0f, 0f, 0f),
            new Actions("Normal Slash", "warrior", 0, 0, 1f, 0f, 0f),
            new Actions("Hard Slash", "warrior", 0, 5, 2.5f, 0f, 0f),
            new Actions("Magic Slash", "warrior", 0, 10, 0f, 4f, 0f),
            new Actions("Normal Blast", "mage", 0, 0, 0f, 1f, 0f),
            new Actions("Fire", "mage", 0, 10, 0f, 5f, 0f),
            new Actions("Heal", "mage", 50, 10, 0f, 0f, 0f),
        };
}
