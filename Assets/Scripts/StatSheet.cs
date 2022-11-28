using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSheet
{
    public string name;
    public int lvl;
    public int hpMax;
    public int mpMax;
    public int strength;
    public int magic;
    public int defense;

    public StatSheet(string name, int hpMax, int mpMax, int strength, int magic, int defense){
        this.name = name;
        this.lvl = 1;
        this.hpMax = hpMax;
        this.mpMax = mpMax;
        this.strength = strength;
        this.magic = magic;
        this.defense = defense;
    }

}
    
