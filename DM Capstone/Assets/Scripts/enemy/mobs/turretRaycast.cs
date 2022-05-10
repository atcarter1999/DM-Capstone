using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretRaycast : MonoBehaviour
{
    public Transform player;
    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.left, 10, playerLayer) || Physics2D.Raycast(this.transform.position, Vector2.right, 10, playerLayer))
        {
            float direction = player.position.x - transform.position.x;
            if (direction > 0)
            {
                transform.localScale = new Vector2(-3.0f, 3.0f);
            }
            else
            {
                transform.localScale = new Vector2(3.0f, 3.0f);
            }
        }
    }
}
