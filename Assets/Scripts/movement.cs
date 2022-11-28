using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject partyMember;
    private followMovement partyMemberScript;
    public bool isMoving;
    public Rigidbody2D playerBody;
    public Animator animator;
    public Vector3 origPos, targetPos;
    public Vector3 origPos1, targetPos1;
    public float timer = 0.25f;
    public bool up, down, left, right;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<ChangeScreens>().locationName == "Overworld")
        {
            transform.position = Location.overworldLocation;
            partyMember.transform.position = transform.position;
        }
        if (Location.menuOn){
            Location.menuOn = false;
            transform.position = Location.menuLocationGrid;
            partyMember.transform.position = transform.position;
        }
        if (Location.battleOn)
        {
            Location.battleOn = false;
            transform.position = Location.battleLocationGrid;
            partyMember.transform.position = transform.position;
        }
        
        origPos = transform.position;
        partyMemberScript = partyMember.GetComponent<followMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("up", up);
        animator.SetBool("down", down);
        animator.SetBool("left", left);
        animator.SetBool("right", right);
        if (up && !isMoving)
        {
            StartCoroutine(moveSprite(Vector3.up));
        }
        if (left && !isMoving)
        {
            StartCoroutine(moveSprite(Vector3.left));
        }
        if (down && !isMoving)
        {
            StartCoroutine(moveSprite(Vector3.down));
        }
        if (right && !isMoving)
        {
            StartCoroutine(moveSprite(Vector3.right));
        }
    }

    public void direction(string move)
    {
        if (move.Equals("up"))
        {
            up = true;
        } else if (move.Equals("down"))
        {
            down = true;
        } else if (move.Equals("left"))
        {
            left = true;
        } else if (move.Equals("right"))
        {
            right = true;
        }
    }

    public void resetDirection()
    {
        up = false;
        down = false;
        left = false;
        right = false;
    }

    private IEnumerator moveSprite(Vector3 direction)
    {
        isMoving = true;
        float timePassed = 0;
        origPos = transform.position;
        targetPos = origPos + (direction * 0.32f);
        partyMemberScript.resetMove();
        origPos1 = partyMemberScript.origPos;
        targetPos1 = partyMemberScript.targetPos;

        RaycastHit2D hit = Physics2D.Raycast(origPos, direction, 0.32f);
        if (hit.collider != null)
        {
            Debug.Log("collision " + hit.collider);
        } else
        {
            while (timePassed < timer)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, (timePassed / timer));
                partyMember.transform.position = Vector3.Lerp(origPos1, targetPos1, (timePassed / timer));
                timePassed += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;
            partyMember.transform.position = targetPos1;
            partyMemberScript.resetMove();
        }

        
        isMoving = false;
    }
}
