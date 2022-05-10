using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public bool pickedUpByPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        pickedUpByPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            pickedUpByPlayer = true;
        }
        
    }
}
