using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public walkingStates slimeAI;

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
        chase();
    }

    void chase()
    {
        if(slimeAI.chasing)
        {
            Vector2 direction = new Vector2(slimeAI.Player.position.x - transform.position.x, 0);
            transform.Translate(direction * movementSpeed * Time.deltaTime);
        }
    }

    void patrol()
    {

    }
}
