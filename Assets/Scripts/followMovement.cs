using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMovement : MonoBehaviour
{
    public GameObject character;
    public Vector3 origPos, targetPos;
    public float timer = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
        targetPos = character.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (character.GetComponent<movement>().isMoving)
        {
            Vector3 target = character.GetComponent<movement>().origPos;
            StartCoroutine(follow(target));
        }
        */
    }

    public void startFollowing()
    {
        StartCoroutine(follow());
    }

    public void resetMove()
    {
        origPos = transform.position;
        targetPos = character.transform.position;
    }

    public IEnumerator follow()
    {
        
        float timePassed = 0;
        origPos = transform.position;
        targetPos = character.GetComponent<movement>().origPos;
        Debug.Log(timePassed);
        while (timePassed < timer)
        {
            Debug.Log("time");
            transform.position = Vector3.Lerp(origPos, targetPos, (timePassed / timer));
            timePassed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

    }
}
