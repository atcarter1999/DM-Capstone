using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretProjectile : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(this.gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(this.gameObject);
    }
}
