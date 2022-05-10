using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPickUp : MonoBehaviour
{
    public ItemBase item;
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (item.pickedUpByPlayer)
        {
            unlockDash();
        }
    }

    void unlockDash()
    {
        player.GetComponent<controllerControls>().dashHasBeenAcquired = true;
        Destroy(this.gameObject);
    }
}
