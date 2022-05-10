using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public Transform bossFeet;
    //Vector2 spot = new Vector2(player.position.x, feet.position.y + 2.25f);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y <= bossFeet.position.y + 2.25f)
        {
            transform.Translate(Vector2.up * 60 * Time.deltaTime);
        }
    }
}
