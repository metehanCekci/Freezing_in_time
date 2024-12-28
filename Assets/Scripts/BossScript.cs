using System.Collections;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public bool handIsLeft = true;

    public GameObject leftHand;
    public Sprite closedHand;
    public Sprite openedHand;
    public GameObject rightHand;
    public Transform player; // Reference to the player transform
    public Transform originalLeftHandPosition;
    public Transform originalRightHandPosition;
    private bool returnToPosition = false;
    public bool followPlayer = false;
    public GameObject laser;
    private Animator animator;


    private float moveSpeed = 8f; // Speed at which the left hand follows
    private float slamDelay = 1f; // Time to wait before the attack is launched
    private float slamDuration = 1f; // Time to wait before the hand returns
    private bool isSlamAttacking = false; // Whether the attack is in progress

    private void Awake()
    {
        // Cache the original position of the left hand
        animator = GetComponent<Animator>();
        

        
    }
    public void animationEnded()
    {
        RandomAttack();
        animator.enabled = false;
    }

    private void FixedUpdate() {
        if(followPlayer)
        {
            if(handIsLeft)
            {
                leftHand.transform.parent.position = Vector3.MoveTowards(leftHand.transform.parent.position, new Vector3(player.transform.position.x, 4, 0), moveSpeed * Time.deltaTime);
            }
            else
            {
                rightHand.transform.parent.position = Vector3.MoveTowards(rightHand.transform.parent.position, new Vector3(player.transform.position.x, 4, 0), moveSpeed * Time.deltaTime);
            }
        }
        if(returnToPosition)
        {
            if(handIsLeft)
            {
                leftHand.transform.parent.position = Vector3.MoveTowards(leftHand.transform.parent.position, originalLeftHandPosition.transform.position, 1 * moveSpeed * Time.deltaTime);
            }
            else
            {
                rightHand.transform.parent.position = Vector3.MoveTowards(rightHand.transform.parent.position, originalRightHandPosition.transform.position, 1* moveSpeed * Time.deltaTime);
            }
        }
    }

    public void RandomAttack()
    {
        int roll = Random.Range(0, 2); // Randomly pick 0 or 1 for the attack choice

        if (roll == 0)
        {
            StartCoroutine("SlamAttack");
        }
        if (roll == 1)
        {
            StartCoroutine("LaserAttack");
        }
    }

    IEnumerator SlamAttack()
    {


        followPlayer = true;
        yield return new WaitForSeconds(0.7f);
        followPlayer = false;
        yield return new WaitForSeconds(0.6f);

        if (handIsLeft)
        {
            leftHand.GetComponent<CircleCollider2D>().enabled = true;
            leftHand.GetComponent<Animator>().SetBool("isAttacking",true);
            leftHand.GetComponent<SpriteRenderer>().sprite = closedHand;
        }
        else
        {
            rightHand.GetComponent<CircleCollider2D>().enabled = true;
            rightHand.GetComponent<Animator>().SetBool("isAttacking",true);
            rightHand.GetComponent<SpriteRenderer>().sprite = closedHand;
        }

        yield return new WaitForSeconds(1.5f);
        
        leftHand.GetComponent<CircleCollider2D>().enabled = false;
        rightHand.GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(0.5f);
        returnToPosition = true;

        yield return new WaitForSeconds(1);
        returnToPosition = false;

        handIsLeft = !handIsLeft;

        leftHand.GetComponent<SpriteRenderer>().sprite = openedHand;
        rightHand.GetComponent<SpriteRenderer>().sprite = openedHand;



        StartCoroutine("CoolDown");
    }

    IEnumerator LaserAttack()
    {
        GameObject clone = Instantiate(laser);
        clone.transform.position = laser.transform.position;
        clone.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        GameObject clone2 = Instantiate(laser);
        clone2.transform.position = laser.transform.position;
        clone2.SetActive(true);
        
        yield return new WaitForSeconds(0.2f);

        GameObject clone3 = Instantiate(laser);
        clone3.transform.position = laser.transform.position;
        clone3.SetActive(true);
        
        Destroy(clone,3);
        Destroy(clone2,3);
        Destroy(clone3,3);

        StartCoroutine("CoolDown");
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1);
        RandomAttack();
    }
}
