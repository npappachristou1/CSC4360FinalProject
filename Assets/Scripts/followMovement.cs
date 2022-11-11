using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMovement : MonoBehaviour
{
    public GameObject character;
    public Vector3 origPos, targetPos;
    public float timer = 0.25f;
    public movement mainPlayer;
    public Animator animator;
    public bool up, down, left, right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("up", up);
        animator.SetBool("down", down);
        animator.SetBool("left", left);
        animator.SetBool("right", right);
        if (mainPlayer.isMoving){
            Vector3 direction = Vector3.Normalize(targetPos - origPos);
            if (direction == Vector3.up){
                up = true;
            } else if (direction == Vector3.down){
                down = true;
            } else if (direction == Vector3.left){
                left = true;
            } else if (direction == Vector3.right){
                right = true;
            }
        } else {
            up = false;
            down = false;
            left = false;
            right = false;
        }
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
