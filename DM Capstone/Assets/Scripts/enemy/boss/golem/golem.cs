using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golem : MonoBehaviour
{
    bossStates bossAI;
    public SpriteRenderer sprite;
    string[] Actions;

    //temp
    public SpriteRenderer text;
    public GameObject groundSpikes;

    public GameObject spike;
    public Transform feet;

    public LayerMask Ground;
    public float jumpTime;
    public float jumpHeight;
    bool isGrounded;
    bool jumping;
    
    Transform player;
    Vector2 playerDirection;
    float scaleMultiplier;
    Rigidbody2D rb;

    bool canAttack;
    public Transform punchPoint;
    public Transform punchUp;
    public Transform punchForward;

    public Animator golemAnimator;
    float temp;
    bool golemMoving;

    bool canWalk;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumping = false;
        canWalk = true;
        groundSpikes.SetActive(false);
        text.enabled = false;
        canAttack = true;
        scaleMultiplier = this.transform.localScale.x;
        bossAI = gameObject.GetComponent<bossStates>();
        player = bossAI.player;
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = new Vector2(player.position.x - this.transform.position.x, player.position.y - this.transform.position.y);
        facePlayer();
        if(this.transform.position.x - player.position.x > 5 && canWalk)
        {
            moveTowardPlayer();
        }
        if (bossAI.playerIsClose)
        {
            closeRangeBehavior();
            SetAction();
        }
        else if (bossAI.playerIsMid)
        {
            midRangeBehavior();
            SetAction();
        }
        else
        {
            longRangeBehavior();
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feet.position, 0.1f, Ground);
    }

    void SetAction()
    {
        if (canAttack)
        {
            canAttack = false;
            if (bossAI.playerIsClose && playerDirection.y > 2.4f && (playerDirection.x > -1.8 && playerDirection.x < 1.8))
            {
                Invoke("punch", 0);
                golemAnimator.SetBool("isPunching", true);
            }
            else 
            {
                int num = Random.Range(0, 2);
                Invoke(Actions[num], 0);
            }
            
        }
        
    }

    void facePlayer()
    {
        if(playerDirection.x > 0)
        {
            text.flipX = true;
            this.transform.localScale = new Vector2(-scaleMultiplier, scaleMultiplier);
        }
        else
        {
            text.flipX = false;
            this.transform.localScale = new Vector2(scaleMultiplier, scaleMultiplier);
        }
    }

    //behaviors
    void closeRangeBehavior()
    {
        Actions = new string[] { "punch", "groundSlam" };
        
    }

    void midRangeBehavior()
    {
        Actions = new string[] { "directionalSlam", "jump" };
    }

    void longRangeBehavior()
    {
        Actions = new string[] {""};
    }

    //attacks and movement
    //This bouta be hard coded as shit so some number values will 
    //need to change is the sprite size changes. Like most of the raw number values 
    //for attacks
    void punch()
    {
            golemAnimator.SetBool("isPunching", true);

            canAttack = false;
            canWalk = false;
            //text.enabled = true;
            StartCoroutine(punchWindUp(.5f));

    }

    void directionalSlam()
    {
            golemAnimator.SetBool("isSlamming", true);

            //text.enabled = true;
            canAttack = false;
            canWalk = false;
            StartCoroutine(spikeWindUp(.5f));
        
    }

    void groundSlam()
    {
            golemAnimator.SetBool("isSlamming", true);
            //text.enabled = true;
            canAttack = false;
            canWalk = false;
            StartCoroutine(slamWindUp(.5f));
       
    }

    void jump()
    {
        if(!jumping)
        {
            jumping = true;
            float distanceFromPlayer = player.position.x - transform.position.x;

            if (isGrounded)
            {
                canAttack = false;
                canWalk = false;
                rb.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
            }
        }
        
    }

    void moveTowardPlayer()
    {
        /* StartCoroutine(testDelay());
        print(transform.position.x);
        print(temp);
        print("-----------");
        if(isGrounded)
        {
        if(!golemMoving)
        {
            golemMoving = true;
            golemAnimator.SetBool("isWalking", true);
        }
        else if(transform.position.x == temp)
        {
            golemMoving = false;
        }
        } */
        transform.Translate(new Vector2(playerDirection.x/Mathf.Abs(playerDirection.x), 0) * 4 * Time.deltaTime);
    }

    IEnumerator testDelay()
    {
        temp = transform.position.x;
        yield return new WaitForSecondsRealtime(1f);
    }

    IEnumerator punchWindUp(float time)
    {
        yield return new WaitForSeconds(time);
        if (playerDirection.y > 2.4f && (playerDirection.x > -1.8 && playerDirection.x < 1.8))
        {
            punchPoint.position = punchUp.position;
        }

        else
        {
            punchPoint.position = punchForward.position;
        }

        Collider2D[] thingsHit = Physics2D.OverlapBoxAll(punchPoint.position, new Vector2(4, 3), 0, bossAI.playerLayer);
        if (thingsHit.Length != 0)
        {
            thingsHit[0].GetComponent<player>().takeDamage(new Vector2(player.position.x - ((punchPoint.position.x + this.transform.position.x)/2), player.position.y - ((punchPoint.position.y + this.transform.position.y) / 2)));
        }
        Invoke("attackCooldown", 3);
        Invoke("unlockWalking", 0.2f);
        text.enabled = false;

        golemAnimator.SetBool("isPunching", false);
    }

    IEnumerator spikeWindUp(float time)
    {
        Vector2 spot = new Vector2(player.position.x, feet.position.y - 3.1f);
        yield return new WaitForSeconds(time);
        GameObject newSpike = Instantiate(spike, spot, this.transform.rotation);
        newSpike.GetComponent<spike>().bossFeet = feet;
        Invoke("attackCooldown", 4);
        Invoke("unlockWalking", 0.2f);
        text.enabled = false;

        golemAnimator.SetBool("isSlamming", false);
    }

    IEnumerator slamWindUp(float time)
    {
        yield return new WaitForSeconds(time);
        groundSpikes.SetActive(true);
        Collider2D[] thingsHit = Physics2D.OverlapBoxAll(feet.position, new Vector2(15, 4), 0, bossAI.playerLayer);
        if (thingsHit.Length != 0)
        {
            thingsHit[0].GetComponent<player>().takeDamage(new Vector2(player.position.x - ((player.position.x + feet.position.x) / 2), player.position.y - ((player.position.y + feet.position.y) / 2)));
        }
        Invoke("disableSprite", 0.5f);
        Invoke("unlockWalking", 0.2f);
        Invoke("attackCooldown", 4);
        text.enabled = false;

        golemAnimator.SetBool("isSlamming", false);
    }
    
    //temp
    void disableSprite()
    {
        groundSpikes.SetActive(false);
    }

    void attackCooldown()
    {
        canAttack = true;
    }

    void unlockWalking()
    {
        canWalk = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (punchPoint == null)
        {
            return;
        }
        Gizmos.DrawWireCube(punchPoint.position, new Vector2(4, 3));
        Gizmos.DrawWireCube(feet.position, new Vector2(15, 4));
        Gizmos.DrawSphere(feet.position, 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = new Vector2(0, 0);
            jumping = false;
            StartCoroutine(slamWindUp(0.05f));
        }
    }
}
