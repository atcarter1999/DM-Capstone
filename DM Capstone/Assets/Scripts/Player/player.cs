using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    //new shit
    public Rigidbody2D playerBody;
    PlayerController controllerInput;
    public GameObject[] campfires;
    public int lastCampfire;
    public int campfireChecker;
    public bool retouchCampfire;
    bool touchingCampfire;

    public bossTrigger bossDoor;

    controllerControls playerControls;
    public int maxHealth;
    int currHealth;
    bool ignorePushBack;

    AudioSource audioSource;
    public AudioClip playerHit;
    public AudioClip healSound;
    public AudioClip fire;
    public AudioClip blacksmithDink;

    GameObject dashOrb;
    public GameObject weaponOre;
    public int weaponOreInInventory = 0;
    public bool talkedToBlacksmith;
    public bool talkedToSpawnNPC;

    bool iframes;
    bool touchingEnemy;
    public float iframeSeconds;

    public Canvas UI;
    public Text health;
    public Text essence;
    GameObject essenceSlider;

    GameObject NPCText;
    GameObject NPCBubble;
    public float textSpeed;
    public string[] NPCTextValues;
    public string[] NPC0;
    public string[] NPC0Repeat;
    public string[] NPC1;
    public string[] NPC2;
    public string[] NPC3;
    public string[] NPC3OreLost;
    public string[] NPC3OreFound;
    public string[] NPC4;
    bool bubbleActive;
    bool touchingNPC;
    int NPCChecker;
    int textIterator;

    pause pauseScript;

    public AudioSource deathSound;
    public GameObject mainMusicAS;

    public Image[] hearts;

    public Animator playerAnimator;
    GameObject deathFade;
    Animator deathFadeAnimator;
    
    void Awake()
    {
        print("Weapon Ore: " + weaponOreInInventory);
        playerControls = gameObject.GetComponent<controllerControls>();
        touchingEnemy = false;
        currHealth = maxHealth;
        health.text = "Health: " + currHealth;
        ignorePushBack = false;

        essence.text = "Essence: " + gameObject.GetComponent<controllerControls>().maxEssence;
        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(8, 10);

        iframes = false;

        heartDuplicate();
        //campfires = GameObject.FindGameObjectsWithTag("campfire trigger");
        campfires[0].GetComponentInChildren<CircleCollider2D>().enabled = false;
        controllerInput = new PlayerController();
        controllerInput.Gameplay.Enable();

        NPCBubble = GameObject.FindWithTag("npc bubble");
        NPCText = GameObject.FindWithTag("npc text");
        essenceSlider = GameObject.FindWithTag("essenceFill");
        touchingNPC = false;

        NPCBubble.SetActive(false);
        NPCText.SetActive(false);

        dashOrb = GameObject.Find("Dash Unlock");
        dashOrb.SetActive(false);

        //weaponOre = GameObject.Find("weaponOre");
        dashOrb.SetActive(false);

        pauseScript = gameObject.GetComponent<pause>();

        deathSound.Stop();

        audioSource = gameObject.GetComponent<AudioSource>();
        playerAnimator = gameObject.GetComponent<Animator>();
        deathFade = GameObject.FindWithTag("Fade In");
        deathFadeAnimator = deathFade.GetComponent<Animator>();
        mainMusicAS = GameObject.FindWithTag("MainCamera");

        hearts[5].GetComponent<Image>().enabled = false;
    }

    void Start()
    {
        deathFadeAnimator.Play("FadeIn", 0, 0);
    }

    void Update()
    {
        heartDuplicate();
        campfire();
        npc();
        checkPauseState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("boss"))
        {
            touchingEnemy = true;
            if(!iframes)
            {
                if (collision.gameObject.layer == 11)
                {
                    ignorePushBack = true;
                }
                takeDamage(new Vector2(  this.transform.position.x - collision.transform.position.x, this.transform.position.y - collision.transform.position.y));
            }
            
        }
        if (collision.gameObject.CompareTag("projectile"))
        {
            if (!iframes)
            {
                takeDamage(new Vector2(this.transform.position.x - collision.transform.position.x, this.transform.position.y - collision.transform.position.y));
            }
        }

        if (collision.gameObject.CompareTag("campfire trigger"))
        {
            touchingCampfire = true;

            if(lastCampfire == int.Parse(collision.gameObject.name))
                retouchCampfire = true;
            else
                retouchCampfire = false;

            campfireChecker = int.Parse(collision.gameObject.name);
        }

        if (collision.gameObject.CompareTag("npc trigger"))
        {
            touchingNPC = true;
            NPCChecker = int.Parse(collision.gameObject.name);

            print(collision.gameObject.transform.parent.name);
            if(collision.gameObject.transform.parent.name == "NPC0")
            {
                if(!talkedToSpawnNPC)
                    NPCTextValues = NPC0;
                
                else
                    NPCTextValues = NPC0Repeat;
            }
            else if(collision.gameObject.transform.parent.name == "NPC1")
                NPCTextValues = NPC1;
            else if(collision.gameObject.transform.parent.name == "NPC2")
                NPCTextValues = NPC2;
            else if(collision.gameObject.transform.parent.name == "NPC3")
            {
                if(!talkedToBlacksmith)
                    NPCTextValues = NPC3;

                else if(weaponOreInInventory == 0)
                    NPCTextValues = NPC3OreLost;

                else if(weaponOreInInventory > 0)
                    NPCTextValues = NPC3OreFound;
            }
            else if(collision.gameObject.transform.parent.name == "NPC4")
                NPCTextValues = NPC4;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("campfire trigger"))
        {
            if(lastCampfire == int.Parse(collision.gameObject.name))
                retouchCampfire = true;
            else
                retouchCampfire = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("boss"))
        {
            touchingEnemy = false;
        }

        if (collision.gameObject.CompareTag("campfire trigger"))
        {
            touchingCampfire = false;
        }

        if (collision.gameObject.CompareTag("npc trigger"))
        {
            touchingNPC = false;
            controllerInput.Gameplay.Interact.Enable();
            StopCoroutine(NPCTextDelay(NPCTextValues, textSpeed, textIterator));
            textIterator = 0;
            NPCTextValues = null;

            bubbleDeactivate();
        }
    }

    public void heal()
    {
        if(currHealth != maxHealth)
        {
            currHealth += 1;
            audioSource.PlayOneShot(healSound, 1);
            health.text = "Health: " + currHealth;
        }
    }

    public void updateEssenceText(int essenceAmount)
    {
        essence.text = "Essence: " + essenceAmount;
        essenceSlider.GetComponentInParent<Slider>().value = essenceAmount/75.0f;
    }

    public void takeDamage(Vector2 direction)
    {
        playerAnimator.SetBool("hasTakenDamage", true);

        iframes = true;
        currHealth -= 1;
        audioSource.PlayOneShot(playerHit, 0.4f);
        StartCoroutine(iframeWindow(direction));
        health.text = "Health: " + currHealth;
        if (currHealth <= 0)
        {
            Die();
        }
        else if(!ignorePushBack)
        {
            pushBack(direction);
        }
    }

    IEnumerator iframeWindow(Vector2 direction)
    {
        yield return new WaitForSeconds(.2f);
        playerAnimator.SetBool("hasTakenDamage", false);

        yield return new WaitForSeconds(iframeSeconds - .2f);
        iframes = false;
        ignorePushBack = false;
        if(touchingEnemy)
        {
            takeDamage(direction);
        }
    }

    IEnumerator metalSoundDelay(int loopNumber, float delay)
    {
        for(int i = 0; i < loopNumber; i++)
        {
            audioSource.PlayOneShot(blacksmithDink, 1);
            yield return new WaitForSecondsRealtime(delay);
        }
    }

    IEnumerator NPCTextDelay(string[] currText, float lettersPerSecond, int TI)
    {
        NPCText.GetComponent<Text>().text = "";
        controllerInput.Gameplay.Interact.Disable();

        foreach(var letter in currText[TI].ToCharArray())
        {
            NPCText.GetComponent<Text>().text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        controllerInput.Gameplay.Interact.Enable();
    }

    void pushBack(Vector2 direction)
    {
        lockMovement();
        Invoke("unlockMovement", 0.3f);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x, 0.4f) * 6, ForceMode2D.Impulse);
    }

    void lockMovement()
    {
        this.gameObject.GetComponent<controllerControls>().lockMovement = true;
    }

    void unlockMovement()
    {
        this.gameObject.GetComponent<controllerControls>().lockMovement = false;
    }

    IEnumerator deathFadeDelay()
    {
        yield return new WaitForSeconds(1.1f);
    }

    void Die()
    {
        deathFadeAnimator.Play("FadeIn", 0, 0);
        deathSound.Play();
        mainMusicAS.GetComponent<AudioSource>().Stop();
        mainMusicAS.GetComponent<AudioSource>().Play();

        playerBody.gameObject.transform.position = campfires[lastCampfire].transform.position;
        bossDoor.resetDoor();
        currHealth = maxHealth;
        health.text = "Health: " + currHealth;

        
        //print("DIS SHIT WORKED HOMIE - PLAYER RESPAWNED AT CAMPFIRE #" + lastCampfire);
    }

    void heartDuplicate()
    {
        for(int i = 0; i < maxHealth; i++)
        {
            if(i < currHealth)
                hearts[i].color = Color.white;

            else
                hearts[i].color = Color.black;
        }
    }

    void campfire()
    {
        if(touchingCampfire)
        {
            if(controllerInput.Gameplay.Interact.WasPressedThisFrame())
            {
                audioSource.PlayOneShot(fire, 0.5f);
                if(retouchCampfire)
                {
                    campfires[lastCampfire].GetComponentInParent<Animator>().Play("Null State", 0, 0);
                    lastCampfire = campfireChecker;
                    campfires[lastCampfire].GetComponentInParent<Animator>().Play("Spawn Checked", 0, 0);
                }
                else
                {
                    campfires[lastCampfire].GetComponentInParent<Animator>().Play("Null State", 0, 0);
                    lastCampfire = campfireChecker;
                    campfires[lastCampfire].GetComponentInParent<Animator>().Play("Spawn Set", 0, 0);
                }
            }
        }
    }

    void npc()
    {
        if (touchingNPC)
        {
            if(controllerInput.Gameplay.Interact.WasPressedThisFrame())
            {
                if(!bubbleActive)
                {
                    bubbleActivate();
                    //NPCText.GetComponent<Text>().text = NPCTextValues[0];
                    StartCoroutine(NPCTextDelay(NPCTextValues, textSpeed, textIterator));
                    textIterator = 1;
                }
                else if(textIterator < NPCTextValues.Length)
                {
                    //NPCText.GetComponent<Text>().text = NPCTextValues[textIterator];
                    StartCoroutine(NPCTextDelay(NPCTextValues, textSpeed, textIterator));

                    if(NPCTextValues[textIterator] == "Poof!")
                    {
                        audioSource.PlayOneShot(fire, 0.5f);
                        campfires[0].GetComponentInChildren<CircleCollider2D>().enabled = true;
                        campfires[lastCampfire].GetComponentInParent<Animator>().Play("Spawn Set", 0, 0);
                    }

                    if(NPCTextValues[textIterator] == "Stay safe out there traveler, the path ahead is dangerous!")
                        talkedToSpawnNPC = true;

                    if(NPCTextValues[textIterator] == "behind you is a magical orb that grants you the power to perform a Dash")
                        dashOrb.SetActive(true);

                    if(NPCTextValues[textIterator] == "Im getting too old to go look for the ore myself, but if you find some that would be a tremendous help")
                    {
                        weaponOre.SetActive(true);
                        talkedToBlacksmith = true;
                    }

                    if(NPCTextValues[textIterator] == "*Dink Dink Dink*")
                        StartCoroutine(metalSoundDelay(3, .4f));

                    textIterator++;
                }
                else
                {
                    bubbleDeactivate();
                    
                    if(NPCTextValues[textIterator - 1] == "Thank you again for your help, and be sure to talk with all the other villagers, I promise we dont bite!")
                    {
                        GameObject.Find("NPC3").GetComponentInChildren<CircleCollider2D>().enabled = false;
                        playerControls.weaponDamage = 20;
                    }

                    else if(NPCTextValues[textIterator - 1] == "Safe travels young one, the forest is a dangerous place...")
                        GameObject.Find("NPC4").GetComponentInChildren<CircleCollider2D>().enabled = false;

                    textIterator = 0;
                }
            }
        }
    }

    void bubbleActivate()
    {
        NPCText.SetActive(true);
        NPCBubble.SetActive(true);

        bubbleActive = true;
    }

    void bubbleDeactivate()
    {
        NPCText.SetActive(false);
        NPCBubble.SetActive(false);

        bubbleActive = false;
    }

    void checkPauseState()
    {
        if(pauseScript.gamePaused)
        {
            NPCBubble.SetActive(false);
            NPCText.SetActive(false);
        }
        else if(bubbleActive)
        {
            NPCText.SetActive(true);
            NPCBubble.SetActive(true);
        }
    }
}
