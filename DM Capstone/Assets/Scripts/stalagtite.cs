using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stalagtite : MonoBehaviour
{
    public LayerMask playerLayer;
    public LayerMask ground;

    AudioSource audioSource;
    public AudioClip breaking;

    bool isGrounded;

    public Transform groundCheck;
    public Transform ray;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        isGrounded = false;
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics2D.Raycast(ray.position, Vector2.down, 20, playerLayer))
        {
            rb.gravityScale = 4;
        }

        if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground) && !isGrounded)
        {
            isGrounded = true;
            rb.gravityScale = 0;
            //audioSource.PlayOneShot(breaking, 0.5f);
            audioSource.Play();
            Destroy(this.gameObject, 0.4f);
        }
    }
}
