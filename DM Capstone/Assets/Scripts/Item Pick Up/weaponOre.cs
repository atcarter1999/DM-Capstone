using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponOre : MonoBehaviour
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
            addToInventory();
        }
    }

    void addToInventory()
    {
        player.GetComponent<player>().weaponOreInInventory += 1;
        print("Weapon Ore: " + player.GetComponent<player>().weaponOreInInventory);
        Destroy(this.gameObject);
    }
}
