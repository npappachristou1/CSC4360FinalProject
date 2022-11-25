using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSheet
{
    public string name;
    public int lvl;
    public int exp;
    public int expMax;
    public int hpMax;
    public int mpMax;
    public int strength;
    public int magic;
    public int defense;

    public StatSheet(string name, int hpMax, int mpMax, int strength, int magic, int defense){
        this.name = name;
        this.lvl = 1;
        this.exp = 0;
        this.expMax = 100;
        this.hpMax = hpMax;
        this.mpMax = mpMax;
        this.strength = strength;
        this.magic = magic;
        this.defense = defense;
    }

    public void lvlup()
    {
        int[] stats = {hpMax, mpMax, strength, magic, defense};
        for(int i = 0; i < stats.Length; i++){
            stats[i] = (int) (stats[i] * 1.1f);
        }
        lvl++;
        exp = 0;
        expMax = (int) (expMax * 1.2f);
    }

}
    
