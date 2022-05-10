using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossTrigger : MonoBehaviour
{
    public golem boss;
    public GameObject door;
    // Start is called before the first frame update
    void Awake()
    {
        door.SetActive(false);
        boss.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if(!boss.enabled)
            {
                Invoke("bossStart", 1);
            }
        }
    }

    void bossStart()
    {
        door.SetActive(true);
        boss.enabled = true;
    }

    public void resetDoor()
    {
        door.SetActive(false);
        boss.enabled = false;
    }
}
