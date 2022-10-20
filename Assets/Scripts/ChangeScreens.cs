using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreens : MonoBehaviour
{
    public movement mainPlayer;
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
            Debug.Log("Current Zone: " + zoneName);
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
            changeScene(tile.tag);
        }
        else if (tile.tag == "Enemy Zone")
        {
            Debug.Log("Enemy Zone entrance");
            changeScene(tile.tag);
        }
        else if (tile.tag == "Boss Zone")
        {
            Debug.Log("Boss Zone entrance");
            changeScene(tile.tag);
        }
        else if (tile.tag == "Shop")
        {
            Debug.Log("Shop entrance");
        }
        else if (tile.tag == "Battle")
        {
            Debug.Log("Chance of battle occuring");
        }
    }

    void changeScene(string sceneName)
    {
        Vector3 location = mainPlayer.targetPos;
        
        SceneManager.LoadScene(sceneName);
    }
}
