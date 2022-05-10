using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingStates : MonoBehaviour
{
    public Transform Player;
    public LayerMask playerLayer;

    public int maxHealth;
    int currentHealth;

    public Rigidbody2D rb;

    public bool patrolling;
    public bool chasing;
    public bool attacking;

    //needed for states
    public float aggroRange, attackRange;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("player").transform;
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(7, 7);
        currentHealth = maxHealth;
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(this.transform.position, Vector2.left, Color.red);
        if (Physics2D.Raycast(this.transform.position, Vector2.left, attackRange, playerLayer) || Physics2D.Raycast(this.transform.position, Vector2.right, attackRange, playerLayer))
        {
            Attack();
        }

        else if (Physics2D.Raycast(this.transform.position, Vector2.left, aggroRange, playerLayer) || Physics2D.Raycast(this.transform.position, Vector2.right, aggroRange, playerLayer))
        {
            Chase();
        }

        else
        {
            Patrol();
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
        if (currentHealth <= 0)
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
        rb.AddForce(new Vector2(direct, direction.y) * pushBack, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
