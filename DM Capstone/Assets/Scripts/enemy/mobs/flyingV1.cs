using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingV1 : MonoBehaviour
{
    public flyingStates flyingAI;
    public int movementSpeed;
    bool lockChase;

    public LayerMask ground;
    public LayerMask batWall;

    public Transform front;
    public Transform top;
    public Transform bottom;

    Vector2 patrolDirection;
    bool hasPatrolDirection;
    // Start is called before the first frame update
    void Awake()
    {
        hasPatrolDirection = false;
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
        chase();
    }

    private void FixedUpdate()
    {
        checkCollision();
    }

    void patrol()
    {
        if(flyingAI.patrolling)
        {
            if(!hasPatrolDirection)
            {
                setDirection();
            }
            else
            {
                transform.Translate(patrolDirection * movementSpeed * Time.deltaTime);
            }
        }
    }

    void chase()
    {
        if(flyingAI.chasing && !lockChase)
        {
            hasPatrolDirection = false;
            transform.position = Vector2.MoveTowards(transform.position, flyingAI.Player.position, movementSpeed * Time.deltaTime);
            if(flyingAI.Player.position.x - transform.position.x > 0)
            {
                transform.localScale = new Vector2((-4), transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2((4), transform.localScale.y);
            }
        }
    }

    void setDirection()
    {
        float x = Random.Range(-1, 1);
        float y = Random.Range(-1, 1);
        if (x != 0)
        {
            x = x / Mathf.Abs(x);
        }
        else 
        {
            x += 0.1f;
            x = x / Mathf.Abs(x);
        }

        if (y != 0)
        {
            y = y / Mathf.Abs(y);
        }
        else 
        {
            y -= 0.1f;
            y = y / Mathf.Abs(y);
        }

        patrolDirection = new Vector2(x, y);
        flipScale();
        print(patrolDirection);
        hasPatrolDirection = true;
    }

    void flipScale()
    {
        int scaleMultiplier = (int) patrolDirection.x;
        transform.localScale = new Vector2((-scaleMultiplier * 4), transform.localScale.y);
    }

    void checkCollision()
    {
        if (Physics2D.OverlapBox(front.position, new Vector2(0.1f, 1.5f), 0, ground) || Physics2D.OverlapBox(front.position, new Vector2(0.1f, 1.5f), 0, batWall))
        {
            patrolDirection = new Vector2(-patrolDirection.x, patrolDirection.y);
            flipScale();
        }

        else if (Physics2D.OverlapBox(top.position, new Vector2(0.1f, 1.5f), 0, ground) || Physics2D.OverlapBox(bottom.position, new Vector2(0.1f, 1.5f), 0, ground))
        {
            patrolDirection = new Vector2(patrolDirection.x, -patrolDirection.y);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(top.position, new Vector2(1.6f, 0.1f));
        Gizmos.DrawWireCube(front.position, new Vector2(0.1f, 1.2f));
        Gizmos.DrawWireCube(bottom.position, new Vector2(1.6f, 0.1f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("enemyWall"))
        {
            print("hit");
            
            print(patrolDirection);
            
        }
        else if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Roof"))
        {
            
        }

    }
}
