using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossStates : MonoBehaviour
{
    public Transform player;
    public LayerMask playerLayer;
    public LineRenderer circleRenderer;

    public GameObject bossTrigger;

    public int maxHealth;
    int currentHealth;

    public float closeRangeDistance;
    public float midRangeDistance;

    public bool playerIsClose;
    public bool playerIsMid;
    public bool playerIsLong;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        Physics2D.IgnoreLayerCollision(8, 8);
        currentHealth = maxHealth;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.position, this.gameObject.transform.position) <= closeRangeDistance)
        {
            playerCloseRange();
            DrawCircle(100, closeRangeDistance);
        }
        
        else if (Vector2.Distance(player.position, this.gameObject.transform.position) <= midRangeDistance && Vector2.Distance(player.position, this.gameObject.transform.position) > closeRangeDistance)
        {
            playerMidRange();
            DrawCircle(100, midRangeDistance);
        }
        
        else 
        {
            playerLongRange();
        }
        
    }

    void playerCloseRange()
    {
        playerIsClose = true;
        playerIsMid = false;
        playerIsLong = false;
    }

    void playerMidRange()
    {
        playerIsMid = true;
        playerIsClose = false;
        playerIsLong = false;
    }

    void playerLongRange()
    {
        playerIsLong = true;
        playerIsClose = false;
        playerIsMid = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(bossTrigger);
        Destroy(this.gameObject);
    }

    private void DrawCircle(int steps, float Radius)
    {
        circleRenderer.positionCount = steps;
        for (int i = 0; i < steps; i++)
        {
            float circumferenceProgress = (float)i / steps;

            float currRadian = circumferenceProgress * 2 * Mathf.PI;

            float x = Mathf.Cos(currRadian);
            float y = Mathf.Sin(currRadian);

            x *= Radius;
            y *= Radius;

            Vector2 currPosition = new Vector2(this.transform.position.x+x, this.transform.position.y+y);
            circleRenderer.SetPosition(i, currPosition);
        }
    }
}
