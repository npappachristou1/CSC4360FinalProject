using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions
{
    public string actionName, characterName;
    public int hpBoost, mpCost;
    public float strengthMultiplier, magicMultiplier, defenseMultiplier;

    public Actions(string actionName, 
                    string characterName, 
                    int hpBoost, 
                    int mpCost, 
                    float strengthMultiplier, 
                    float magicMultiplier, 
                    float defenseMultiplier)
    {
        this.actionName = actionName;
        this.characterName = characterName;
        this.hpBoost = hpBoost;
        this.mpCost = mpCost;
        this.strengthMultiplier = strengthMultiplier;
        this.magicMultiplier = magicMultiplier;
        this.defenseMultiplier = defenseMultiplier;
    }
}
