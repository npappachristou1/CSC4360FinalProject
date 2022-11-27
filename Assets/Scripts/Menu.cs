using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TMP_Text warriorHp, warriorMp, warriorStrength, warriorMagic, warriorDefense;
    public TMP_Text mageHp, mageMp, mageStrength, mageMagic, mageDefense;
    public TMP_Text exp, expMax;
    // Start is called before the first frame update
    void Start()
    {
        warriorHp.text = "" + Party.player1.hpMax;
        warriorMp.text = "" + Party.player1.mpMax;
        warriorStrength.text = "" + Party.player1.strength;
        warriorMagic.text = "" + Party.player1.magic;
        warriorDefense.text = "" + Party.player1.defense;

        mageHp.text = "" + Party.player2.hpMax;
        mageMp.text = "" + Party.player2.mpMax;
        mageStrength.text = "" + Party.player2.strength;
        mageMagic.text = "" + Party.player2.magic;
        mageDefense.text = "" + Party.player2.defense;

        exp.text = "" + Party.exp;
        expMax.text = "" + Party.expMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeMenu()
    {
        SceneManager.LoadScene(Location.menuLocationName);
    }
}
