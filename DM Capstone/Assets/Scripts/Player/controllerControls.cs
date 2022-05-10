using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class controllerControls : MonoBehaviour
{
    //Various variables for player, will keep organized
    PlayerController controllerInput;
    Vector2 LeftStick;
    public Transform feet;

    AudioSource audioSource;
    public AudioClip slashSound;
    public AudioClip dashSound;
    public AudioClip jumpSound;
    bool jumpSoundPlayed;
    bool landingSoundPlayed;
    public AudioClip landing;
    public AudioClip hitSomething;

    //facingLeftRight will = 1 of player if facing right, and -1 if player facing Left
    int facingLeftRight;
    public LayerMask wall;
    public LayerMask Ground;

    public int movementSpeed;
    public bool lockMovement;
    public float jumpForce;
    int timesPlayerCanJump;
    int timesJumped;

    bool isGrounded;
    bool onWall;
    public Transform wallBox;
    bool wallJumpPressed;
    bool jumpLock;
    bool normalJumping;
    bool jumpReleased;

    public bool dashHasBeenAcquired;
    bool isDashing;
    bool hasDashed;
    bool dashedInAir;
    public float dashDistance;
    public float dashCooldown;

    int essenceAmount;
    public int maxEssence;
    float essenceTimer;
    int essenceUsed;
    public bool healing;

    public Transform attackPoint;
    public Transform LeftRight;
    public Transform Up;
    public Transform Down;

    public int weaponDamage;
    public float knockbackForce;
    bool canAttack;
    public float attackCooldown;
    public SpriteRenderer slash;
    public SpriteRenderer slashUp;
    public SpriteRenderer slashDown;

    public Vector2 attackRange = new Vector2(0.5f, 0.5f);
    public LayerMask enemyLayers;

    //public Transform feet;
    //public float checkRadius;
    //public LayerMask Ground;

    float jumpTimeCounter;
    public float jumpTime;

    public Rigidbody2D playerBody;

    public Animator playerAnimator;
    bool attackNormal;

    void Awake()
    {
        //set base variable values on Awake
        timesPlayerCanJump = 1;
        timesJumped = 0;
        jumpTimeCounter = jumpTime;
        isGrounded = true;
        onWall = false;
        dashHasBeenAcquired = false;
        isDashing = false;
        hasDashed = false;
        dashedInAir = false;
        facingLeftRight = 1;
        jumpLock = false;
        lockMovement = false;
        canAttack = true;
        slash.enabled = false;
        slashUp.enabled = false;
        slashDown.enabled = false;
        essenceAmount = maxEssence;
        audioSource = GetComponent<AudioSource>();
        jumpSoundPlayed = false;
        landingSoundPlayed = false;
        attackNormal = false;

        //Controller Input Stuff
        controllerInput = new PlayerController();
        controllerInput.Gameplay.Movement.performed += ctx => LeftStick = ctx.ReadValue<Vector2>();
        controllerInput.Gameplay.Movement.canceled += ctx => LeftStick = Vector2.zero;

        playerBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        groundCheck();
        wallCheck();
        checkRayCast();   

        if(controllerInput.Gameplay.Jump.WasReleasedThisFrame())
        {
            wallJumpPressed = false;
        }

        if(!lockMovement)
            move();
        
        jump();

        if(!normalJumping)
        {
            wallJump();
        }
        
        if(dashHasBeenAcquired)
            Dash();

        Attack(); 
        EssenceUse();
    }

    private void FixedUpdate()
    {
        
    }
    
    //movement functions
    void move()
    {
        if(!isDashing &&(LeftStick.x > 0.2 || LeftStick.x < -0.2))
            {
                transform.Translate(new Vector2(LeftStick.x, 0) * movementSpeed * Time.deltaTime);
                if (!onWall)
                {
                    //change the local scale x and y to match the scale of the player.  
                    facingLeftRight = (int)(LeftStick.x / Mathf.Abs(LeftStick.x));
                    transform.localScale = new Vector3(facingLeftRight, transform.localScale.y, 1);
                }
            }

        playerAnimator.SetFloat("isMoving", LeftStick.x);
    }
    
    //disables movement in direction of collision with wall, prevents camera jitters
    void checkRayCast()
    {
        if (isGrounded)
        {
            if (Physics2D.Raycast(feet.position, new Vector2(facingLeftRight, 0), 0.7f, Ground))
            {
                if (facingLeftRight == 1 && LeftStick.x > 0)
                {
                    //LeftStick.x = 0;
                }

                else if (facingLeftRight == -1 && LeftStick.x < 0)
                {
                    //LeftStick.x = 0;
                }
            }     
        } 

        if (!isGrounded)
        {
            if (Physics2D.Raycast(this.transform.position, new Vector2(-facingLeftRight, 0), 0.7f, Ground))
            {
                if (facingLeftRight == 1 && LeftStick.x < 0)
                {
                    LeftStick.x = 0;
                }

                else if (facingLeftRight == -1 && LeftStick.x > 0)
                {
                    LeftStick.x = 0;
                }
            }
        }
    }
    
    //Jumping Functions
    void jump()
    {
        if(jumpTimeCounter <= 0 || (controllerInput.Gameplay.Jump.WasReleasedThisFrame()))
        {
            timesJumped++;
        }

        if(controllerInput.Gameplay.Jump.WasPressedThisFrame() && jumpTimeCounter > 0 && timesJumped < timesPlayerCanJump && !onWall)
        {
            playerAnimator.SetBool("hasJumped", true);
            
        }

        if (controllerInput.Gameplay.Jump.IsPressed() && jumpTimeCounter > 0 && timesJumped < timesPlayerCanJump && !onWall)
        {
            if (isDashing)
            {
                timesJumped++;
            }
            else if(!wallJumpPressed)
            {
                if (!jumpSoundPlayed)
                {
                    jumpSoundPlayed = true;
                    audioSource.PlayOneShot(jumpSound, 0.1f);
                }

                jumpReleased = false;
                normalJumping = true;
                playerBody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;

                StartCoroutine(lockJumpButton());

                playerAnimator.SetBool("hasGrounded", false);
            }    
        }
    }

    void wallJump()
    {
        if (jumpTimeCounter <= 0 || controllerInput.Gameplay.Jump.WasReleasedThisFrame())
        {
            timesJumped++;
        }
        if (controllerInput.Gameplay.Jump.IsPressed() && jumpTimeCounter > 0 && !isGrounded && !normalJumping /**&& timesJumped < timesPlayerCanJump**/)
        {
            
            playerBody.gravityScale = 4;
            jumpTimeCounter -= Time.deltaTime;
            if (isDashing)
            {
                timesJumped++;
            }
            else if (jumpTimeCounter > jumpTime / 1.5f && !jumpLock && jumpReleased)
            {
                if (!jumpSoundPlayed)
                {
                    jumpSoundPlayed = true;
                    audioSource.PlayOneShot(jumpSound, 0.1f);
                }
                jumpReleased = false;
                lockMovement = true;
                StartCoroutine(unlockMovement());
                jumpLock = true;
                LeftStick.x = 0;

                playerBody.velocity += new Vector2(facingLeftRight, 0) * jumpForce;
                playerBody.velocity += new Vector2(0, 1) * jumpForce;
                
                wallJumpPressed = true;
                StartCoroutine(lockJumpButton());
            }
            else if(jumpTimeCounter <= jumpTime / 1.5f && !onWall)
            {
                lockMovement = false;
                playerBody.velocity = Vector2.up * jumpForce;
            }
            
        }
    }    
    
    IEnumerator unlockMovement()
    {
        yield return new WaitUntil(() => !controllerInput.Gameplay.Jump.IsPressed() == true);
        playerBody.velocity = new Vector2(0, playerBody.velocity.y);
        lockMovement = false;
    }

    IEnumerator lockJumpButton()
    {
        yield return new WaitUntil(() => !controllerInput.Gameplay.Jump.IsPressed() == true && (isGrounded || onWall));
        //Landing sound here??
        jumpReleased = true;

        timesJumped = 0;
    }

    void Dash()
    {
        if (controllerInput.Gameplay.Dash.WasPressedThisFrame() && !hasDashed)
        {
            if(isGrounded || onWall)
            {
                hasDashed = true;
                StartCoroutine(DashCoroutine(facingLeftRight));
            }
            else if(!dashedInAir)
            {
                hasDashed = true;
                dashedInAir = true;
                StartCoroutine(DashCoroutine(facingLeftRight));
            }
        }
    }

    //attack functions
    void Attack()
    {
        if (controllerInput.Gameplay.BaseAttack.WasPressedThisFrame() && canAttack)
        {
            canAttack = false;
            audioSource.PlayOneShot(slashSound, 1);
            if(LeftStick.y > 0.8)
            {
                playerAnimator.SetBool("hasAttackedUp", true);
                attackPoint.position = Up.position;
                slashUp.enabled = true;
                StartCoroutine(disableSprite(slashUp));
            }
            else if(LeftStick.y < -0.6 && !isGrounded)
            {
                playerAnimator.SetBool("hasAttackedDown", true);
                attackPoint.position = Down.position;
                slashDown.enabled = true;
                StartCoroutine(disableSprite(slashDown));
            }
            else
            {
                playerAnimator.SetBool("hasAttacked", true);
                attackNormal = true;
                attackPoint.position = LeftRight.position;
                slash.enabled = true;
                StartCoroutine(disableSprite(slash));
            }

            Collider2D[] thingsHit = Physics2D.OverlapBoxAll(attackPoint.position, attackRange, 0, enemyLayers);

            foreach (Collider2D thing in thingsHit)
            {
                if(thing.tag == "enemy")
                {
                    if(thing.GetComponent<walkingStates>() != null)
                    {
                        thing.GetComponent<walkingStates>().TakeDamage(weaponDamage);
                        thing.GetComponent<walkingStates>().PushBack(LeftStick, knockbackForce);
                    }

                    else if(thing.GetComponent<flyingStates>() != null)
                    {
                        thing.GetComponent<flyingStates>().TakeDamage(weaponDamage);
                        thing.GetComponent<flyingStates>().PushBack(LeftStick, knockbackForce);
                    }
                    increaseEssenceAmount(7);
                }

                else if(thing.tag == "boss")
                {
                    thing.GetComponent<bossStates>().TakeDamage(weaponDamage);
                    increaseEssenceAmount(7);
                }
                
            }

            if (thingsHit.Length != 0)
            {
                audioSource.PlayOneShot(hitSomething, 0.2f);
            }

            if(attackPoint.position == Down.position && thingsHit.Length != 0)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, 0);
                playerBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            //Invoke("resetAttackAnimations", attackCooldown);
            StartCoroutine(resetAttackAnimations());
            Invoke("resetAttack", attackCooldown);
        }
    }

    void increaseEssenceAmount(int amount)
    {
        essenceAmount += amount;
        if(essenceAmount > maxEssence)
        {
            essenceAmount = maxEssence;
        }
        gameObject.GetComponent<player>().updateEssenceText(essenceAmount);
    }

    IEnumerator disableSprite(SpriteRenderer sprite)
    {
        yield return new WaitForSeconds(0.15f);
        sprite.enabled = false;
    }

    void resetAttack()
    {
        canAttack = true;
    }

    IEnumerator resetAttackAnimations()
    {
        if(attackNormal)
        {
            yield return new WaitForSeconds(attackCooldown);
            playerAnimator.SetBool("hasAttacked", false);
            attackNormal = false;
        }
        else
        {
            yield return new WaitForSeconds(attackCooldown*2/3);
            playerAnimator.SetBool("hasAttackedDown", false);
            playerAnimator.SetBool("hasAttackedUp", false);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireCube(attackPoint.position, attackRange);
        Gizmos.DrawWireCube(feet.position, new Vector2(0.85f, 0.1f));
        Gizmos.DrawWireCube(wallBox.position, new Vector2(0.1f, 1.5f));
    }
    //Essence Functions
    void EssenceUse()
    {
        if(controllerInput.Gameplay.Essence.IsPressed())
        {
            lockMovement = true;
            essenceTimer += Time.deltaTime;
           
            if (essenceTimer % 0.1f <= 0.01f && essenceAmount > 0)
            {
                essenceAmount -= 1;
                essenceUsed += 1;
                gameObject.GetComponent<player>().updateEssenceText(essenceAmount);
                if(essenceUsed % 20 == 0)
                {
                    gameObject.GetComponent<player>().heal();
                    
                }
            }
        }
        else
        {
            lockMovement = false;
            essenceTimer = 0;
            essenceUsed = 0;
        }
    }
    
    void groundCheck()
    {
        isGrounded = Physics2D.OverlapBox(feet.position, new Vector2(0.85f, 0.1f), 0, Ground);
        if(isGrounded)
        {
            //if (jumpSoundPlayed && timesJumped > 0)
            if (playerBody.velocity.y < 0 && !landingSoundPlayed)
            {
                landingSoundPlayed = true;
                jumpSoundPlayed = false;
                lockMovement = false;
                audioSource.PlayOneShot(landing, 0.6f);
                Invoke("resetLandingSound", 0.05f);
            }
            if (onWall)
            {
                transform.Translate(new Vector2(facingLeftRight, 0)*0.1f);
            }
            isGrounded = true;
            dashedInAir = false;
            wallJumpPressed = false;
            jumpLock = false;
            normalJumping = false;
            jumpTimeCounter = jumpTime;

            timesJumped = 0;

            playerAnimator.SetBool("hasGrounded", true);
            playerAnimator.SetBool("hasJumped", false);
        }
    }

    void wallCheck()
    {
        onWall = Physics2D.OverlapBox(wallBox.position, new Vector2(0.1f, 1.5f), 0, Ground);
        if (onWall)
        {
            jumpSoundPlayed = false;
            jumpLock = false;
            jumpTimeCounter = jumpTime;
            playerBody.velocity = new Vector2(playerBody.velocity.x, 0);
            facingLeftRight = -facingLeftRight;
            transform.localScale = new Vector3(facingLeftRight, transform.localScale.y, 1);


            if (!isGrounded)
            {
                onWall = true;
                normalJumping = false;
                dashedInAir = false;  
            }
        }
    }

    void resetLandingSound()
    {
        landingSoundPlayed = false;    
    }


    //Coroutines for Dashing, IEnumerators have to be at botttom of script
    IEnumerator DashCoroutine(float direction)
    {
        playerAnimator.SetBool("hasPressedDash", true);

        isDashing = true;
        playerBody.velocity = new Vector2(playerBody.velocity.x , 0);
        playerBody.AddForce(new Vector2(dashDistance * direction, 0) * 1.5f, ForceMode2D.Impulse);
        playerBody.gravityScale = 0;
        audioSource.PlayOneShot(dashSound, 0.4f);
        yield return new WaitForSeconds(0.25f);
        isDashing = false;
        playerBody.gravityScale = 4;
        playerBody.velocity = new Vector2(0, 0);
        StartCoroutine(DashCooldown());
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        hasDashed = false;
        playerAnimator.SetBool("hasPressedDash", false);
    }

    //More controller stuff
    private void OnEnable()
    {
        controllerInput.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controllerInput.Gameplay.Disable();
    }
}
