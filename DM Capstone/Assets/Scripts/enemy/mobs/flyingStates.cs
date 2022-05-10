using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingStates : MonoBehaviour
{
    public Transform Player;
    public LayerMask rayLayer;

    public int maxHealth;
    int currentHealth;

    public Rigidbody2D rb;

    public bool patrolling;
    public bool chasing;
    public bool attacking;

    bool lockUpdate;

    //needed for states
    public float aggroRange, attackRange;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("player").transform;
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(7, 7);

        currentHealth = maxHealth;
        lockUpdate = false;
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lockUpdate)
        {
            if(Vector2.Distance(this.transform.position, Player.position) < attackRange)
            {
                Attack();
            }
        
            else if(Vector2.Distance(Player.position, this.transform.position) < aggroRange)
            {
                RaycastHit2D hit = Physics2D.Linecast(this.transform.position, Player.position, rayLayer);
                if(hit.transform == null)
                {
                    Chase();
                }
                else
                {
                    Patrol();
                }
            }

            else
            {
                Patrol();
            }
        }
        
    }

    void Attack()
    {
        attacking = true;
    }

    void Chase()
    {
        chasing = true;
        attacking = false;
        patrolling = false;
    }

    void Patrol()
    {
        patrolling = true;
        chasing = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void PushBack(Vector2 direction, float pushBack)
    {
        rb.velocity = new Vector2(0, 0);
        float direct = Player.position.x - transform.position.x;
        direct = -direct / Mathf.Abs(direct);
        print(direction);
        lockMovement();
        rb.AddForce(new Vector2(direct, direction.y) * pushBack, ForceMode2D.Impulse);
        Invoke("pushFrames", 0.1f);
    }

    void lockMovement()
    {
        lockUpdate = true;
        chasing = false;
        attacking = false;
        patrolling = false;
    }

    void pushFrames()
    {
        rb.velocity = Vector2.zero;
        lockUpdate = false;
        chasing = true;
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
