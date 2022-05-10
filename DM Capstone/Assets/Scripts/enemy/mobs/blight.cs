using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blight : MonoBehaviour
{
    public walkingStates blightAI;

    public LayerMask rayLayers;

    public int movementSpeed;
    int patrolDirection;

    public Transform punchPoint;
    bool canAttack;
    bool canWalk;

    public Animator blightAnimator;
    // Start is called before the first frame update
    void Awake()
    {
        patrolDirection = 1;
        canAttack = true;
        canWalk = true;

        blightAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
        chase();
        attack();
    }

    private void FixedUpdate()
    {
        checkPatrolDirection();
    }

    void patrol()
    {
        if(blightAI.patrolling)
            transform.Translate(new Vector2(patrolDirection, 0) * movementSpeed * Time.deltaTime);
    }

    void chase()
    {
        if (blightAI.chasing && canWalk)
        {
            float direction = blightAI.Player.position.x - transform.position.x;
            patrolDirection = (int) (direction / Mathf.Abs(direction));

            if (direction > 0)
            {
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            }
            else 
            {
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y);
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            }
        }
    }

    void attack()
    {
        if (blightAI.attacking && canAttack)
        {
            blightAnimator.SetBool("hasAttacked", true);
            canAttack = false;
            canWalk = false;
            StartCoroutine(punchWindUp(.5f));
        }
    }

    IEnumerator punchWindUp(float time)
    {
        yield return new WaitForSeconds(time);

        Collider2D[] thingsHit = Physics2D.OverlapBoxAll(punchPoint.position, new Vector2(4, 3), 0, blightAI.playerLayer);
        if (thingsHit.Length != 0)
        {
            thingsHit[0].GetComponent<player>().takeDamage(new Vector2(blightAI.Player.position.x - ((punchPoint.position.x + this.transform.position.x) / 2), blightAI.Player.position.y - ((punchPoint.position.y + this.transform.position.y) / 2)));
        }
        Invoke("unlockWalking", 1f);
        Invoke("attackCooldown", 2);

        blightAnimator.SetBool("hasAttacked", false);
    }

    void attackCooldown()
    {
        canAttack = true;
    }

    void unlockWalking()
    {
        canWalk = true;
    }

    void checkPatrolDirection()
    {
        if (blightAI.patrolling)
        {
            if (Physics2D.Raycast(this.transform.position, new Vector2(patrolDirection, 0), 0.7f, rayLayers))
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                patrolDirection = -patrolDirection;
                print(patrolDirection);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (punchPoint == null)
        {
            return;
        }
        Gizmos.DrawWireCube(punchPoint.position, new Vector2(2.5f, 3));
    }
}
