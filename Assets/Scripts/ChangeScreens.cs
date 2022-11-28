using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreens : MonoBehaviour
{
    public movement mainPlayer;
    public string locationName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void menuButton(string zoneName)
    {
        if (mainPlayer.isMoving == false)
        {
            Location.menuLocationName = locationName;
            Location.menuLocationGrid = mainPlayer.targetPos;
            Location.menuOn = true;
            Debug.Log("Menu accessesed from: " + Location.menuLocationName + " " + Location.menuLocationGrid);
            changeScene("menu");
        }

    }

    void OnTriggerEnter2D(Collider2D tile)
    {
        if (tile.tag == "Overworld")
        {
            Debug.Log("Overworld entrance");
            changeScene(tile.tag);
        } else if (tile.tag == "Town")
        {
            Debug.Log("Town entrance");
            Location.overworldLocation = mainPlayer.origPos;
            changeScene(tile.tag);
        }
        else if (tile.tag == "Enemy Zone")
        {
            Debug.Log("Enemy Zone entrance");
            Location.overworldLocation = mainPlayer.origPos;
            changeScene(tile.tag);
        }
        else if (tile.tag == "Boss Zone")
        {
            Debug.Log("Boss Zone entrance");
            Location.overworldLocation = mainPlayer.origPos;
            changeScene(tile.tag);
        }
        else if (tile.tag == "Shop")
        {
            Debug.Log("Shop entrance");
        }
        else if (tile.tag == "Battle")
        {
            Debug.Log("Chance of battle occuring");

            Location.battleLocationName = locationName;
            Location.battleLocationGrid = mainPlayer.targetPos;
            Location.battleOn = true;

            int chance = Random.Range(0, 10);
            if (chance <= 2){
                BattleInfo.zoneName = locationName;
                BattleInfo.isBoss = false;
                BattleInfo.enemiesTotal = 2;
                BattleInfo.enemiesLvl = 2;
                changeScene("Battle");
            }
            
        } else if (tile.tag == "BossBattle"){
            Location.battleLocationName = locationName;
            Location.battleLocationGrid = mainPlayer.origPos;
            Location.battleOn = true;

            BattleInfo.zoneName = locationName;
            BattleInfo.isBoss = true;
            BattleInfo.enemiesTotal = 1;
            BattleInfo.enemiesLvl = 5;
            changeScene("Battle");
        }
    }

    void changeScene(string sceneName)
    {
        Vector3 location = mainPlayer.targetPos;
        Debug.Log(Location.menuLocationName);
        SceneManager.LoadScene(sceneName);
    }
}
