using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeV2 : MonoBehaviour
{
    public walkingStates slimeAI;
    public LayerMask Ground;
    public LayerMask rayLayers;
    public Transform groundCheck;
    bool stopCheck;

    public AudioSource slimeJump;

    Rigidbody2D slimeBody;
    public float jumpForce;
    bool isGrounded;
    bool canJump;
    int patrolDirection;

    GameObject Slime;

    // Start is called before the first frame update
    void Awake()
    {
        stopCheck = false;
        canJump = true;
        isGrounded = false;
        slimeBody = slimeAI.rb;
        patrolDirection = 1;

        Slime = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
        chase();
    }

    private void FixedUpdate()
    {
        checkGround();
        checkPatrolDirection();
    }

    void chase()
    {
        
        if (slimeAI.chasing && canJump && isGrounded)
        {
            StartCoroutine(chaseJump());
        }
    }

    void patrol()
    {
        if(slimeAI.patrolling && canJump && isGrounded)
        {
            StartCoroutine(patrolJump());
        }
        
    }

    void checkGround()
    {
        if(!stopCheck)
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, Ground);
    }

    void checkPatrolDirection()
    {
        if (slimeAI.patrolling)
        {
            if (Physics2D.Raycast(this.transform.position, new Vector2(patrolDirection, 0), 0.7f, rayLayers))
            {
                patrolDirection = -patrolDirection;
            }
        }
        
    }

    IEnumerator patrolJump()
    {
        stopCheck = true;

        Slime.GetComponent<Animator>().Play("Slime Jump", 0, 0);

        slimeBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        slimeJump.Play();
        if (patrolDirection == 1)
        {
            transform.localScale = new Vector2(-4.5f, 4.5f);
            slimeBody.AddForce(new Vector2(0.6f, 0) * jumpForce, ForceMode2D.Impulse);
            canJump = false;
            isGrounded = false;
        }
        else
        {
            transform.localScale = new Vector2(4.5f, 4.5f);
            slimeBody.AddForce(new Vector2(-0.6f, 0) * jumpForce, ForceMode2D.Impulse);
            canJump = false;
            isGrounded = false;
        }
        StartCoroutine(releaseCheck());
        yield return new WaitUntil(() => isGrounded == true);
        slimeBody.velocity = Vector2.zero;
        StartCoroutine(jumpCooldown());
    }

    IEnumerator chaseJump()
    {
        stopCheck = true;
        Slime.GetComponent<Animator>().Play("Slime Jump", 0, 0);

        float direction = slimeAI.Player.position.x - transform.position.x;
        slimeBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        slimeJump.Play();
        if(direction > 0)
        {
            transform.localScale = new Vector2(-4.5f,4.5f);
            slimeBody.AddForce(new Vector2(0.6f, 0) * jumpForce, ForceMode2D.Impulse);
            canJump = false;
            isGrounded = false;
        }
        else
        {
            transform.localScale = new Vector2(4.5f, 4.5f);
            slimeBody.AddForce(new Vector2(-0.6f, 0) * jumpForce, ForceMode2D.Impulse);
            canJump = false;
            isGrounded = false;
        }
        StartCoroutine(releaseCheck());
        yield return new WaitUntil(() => isGrounded == true);
        slimeBody.velocity = Vector2.zero;
        StartCoroutine(jumpCooldown());
    }

    IEnumerator jumpCooldown()
    {
        yield return new WaitForSeconds(0.3f);
        canJump = true;
    }

    IEnumerator releaseCheck()
    {
        yield return new WaitForSeconds(0.1f);
        stopCheck = false;
    }
}
