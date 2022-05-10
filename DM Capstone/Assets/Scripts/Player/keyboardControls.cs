using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class keyboardControls : MonoBehaviour
{
    //Various variables for player, will keep organized
    PlayerController keyboardInput;

    public int movementSpeed;
    public float jumpForce;
    int timesPlayerCanJump;
    int timesJumped;

    bool isGrounded;
    bool onWall;

    float jumpTimeCounter;
    public float jumpTime;

    public Rigidbody2D playerBody;

    void Awake()
    {
        timesPlayerCanJump = 1;
        timesJumped = 0;
        jumpTimeCounter = jumpTime;
        isGrounded = true;
        onWall = false;

        keyboardInput = new PlayerController();

        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if(keyboardInput.Keyboard.MoveLeft.IsPressed())
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }

        if (keyboardInput.Keyboard.MoveRight.IsPressed())
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }

        //jumping
        if(keyboardInput.Keyboard.Jump.IsPressed() && jumpTimeCounter > 0 && timesJumped < timesPlayerCanJump && !onWall)
        {
            playerBody.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
            isGrounded = false;
        }
        else if (!isGrounded && !onWall)
        {
            timesJumped++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpTimeCounter = jumpTime;
            timesJumped = 0;
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            jumpTimeCounter = jumpTime;
            timesJumped = 0;
            onWall = true;

            playerBody.velocity = new Vector2(0, 0);
            playerBody.gravityScale = 0.2f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            playerBody.gravityScale = 4;
            onWall = false;
        }
    }

    //Input stuff
    private void OnEnable()
    {
        keyboardInput.Keyboard.Enable();
    }

    private void OnDisable()
    {
        keyboardInput.Keyboard.Disable();
    }
}
