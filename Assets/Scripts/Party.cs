using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Party
{
    public static StatSheet player1 = new StatSheet("warrior", 100, 30, 50, 20, 50);
    public static StatSheet player2 = new StatSheet("mage", 70, 100, 15, 80, 20);
    public static int lvl = 1;
    public static int expCurrent = 0;
    public static int expMax = 100;
}
