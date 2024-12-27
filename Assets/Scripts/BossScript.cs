using System.Collections;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public bool handIsLeft = true;

    public GameObject leftHand;
    public GameObject rightHand;
    public Transform player; // Reference to the player transform
    private Vector3 originalLeftHandPosition;
    private Vector3 originalRightHandPosition;
    private bool returnToPosition = false;
    public bool followPlayer = false;

    private float moveSpeed = 5f; // Speed at which the left hand follows
    private float slamDelay = 1f; // Time to wait before the attack is launched
    private float slamDuration = 1f; // Time to wait before the hand returns
    private bool isSlamAttacking = false; // Whether the attack is in progress

    private void Awake()
    {
        // Cache the original position of the left hand
        
        
            originalLeftHandPosition = leftHand.transform.parent.position;
            originalRightHandPosition = rightHand.transform.parent.position;
        RandomAttack();
    }

    private void FixedUpdate() {
        if(followPlayer)
        {
            if(handIsLeft)
            {
                leftHand.transform.parent.position = Vector3.MoveTowards(leftHand.transform.parent.position, new Vector3(player.transform.position.x, 3, 0), moveSpeed * Time.deltaTime);
            }
            else
            {
                rightHand.transform.parent.position = Vector3.MoveTowards(rightHand.transform.parent.position, new Vector3(player.transform.position.x, 3, 0), moveSpeed * Time.deltaTime);
            }
        }
        if(returnToPosition)
        {
            if(handIsLeft)
            {
                leftHand.transform.parent.position = Vector3.MoveTowards(leftHand.transform.parent.position, originalLeftHandPosition, 1 * moveSpeed * Time.deltaTime);
            }
            else
            {
                rightHand.transform.parent.position = Vector3.MoveTowards(rightHand.transform.parent.position, originalRightHandPosition, 1* moveSpeed * Time.deltaTime);
            }
        }
    }

    public void RandomAttack()
    {
        int roll = Random.Range(0, 1); // Randomly pick 0 or 1 for the attack choice

        if (roll == 0)
        {
            StartCoroutine("SlamAttack");
        }
    }

    IEnumerator SlamAttack()
    {
        followPlayer = true;
        yield return new WaitForSeconds(1f);
        followPlayer = false;
        yield return new WaitForSeconds(0.7f);

        if (handIsLeft)
        {
            leftHand.GetComponent<Animator>().SetBool("isAttacking",true);
        }
        else
        {
            rightHand.GetComponent<Animator>().SetBool("isAttacking",true);
        }

        yield return new WaitForSeconds(2);
        returnToPosition = true;
        yield return new WaitForSeconds(1);
        returnToPosition = false;

        handIsLeft = !handIsLeft;

        StartCoroutine("CoolDown");
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1);
        RandomAttack();
    }
}
