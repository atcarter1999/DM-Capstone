using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUpgrade : MonoBehaviour
{
    public ItemBase heartPickUp;
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (heartPickUp.pickedUpByPlayer)
        {
            player.GetComponent<player>().maxHealth++;
            player.GetComponent<player>().hearts[5].GetComponent<Image>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
