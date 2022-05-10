using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretV1 : MonoBehaviour
{
    public GameObject player;
    public Transform projectileSpawn;
    float shotTimer = 0;
    public GameObject projectile;
    AudioSource audioSource;

    GameObject flowerTurret;
    bool shotFired;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");
        audioSource = GetComponent<AudioSource>();
        flowerTurret = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameObject.GetComponent<flyingStates>().chasing)
        {

            facePlayer();

            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            projectileSpawn.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            shotTimer += Time.deltaTime;

            if(shotTimer >= 2.5f && !shotFired)
            {
                flowerTurret.GetComponent<Animator>().Play("Flower Turret Attack", 0, 0);
                shotFired = true;
            }

            if (shotTimer >= 3.0f)
            {
                audioSource.Play();
                Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
                shotTimer = 0;
                shotFired = false;
            }
        }
    }

    void facePlayer()
    {
        Vector2 playerDirection = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y);
            
        if (this.transform.rotation.z == 0)
        {
            if (playerDirection.x < 0)
            {
                this.transform.localScale = new Vector2(3, 3);
            }
            else
            {
                this.transform.localScale = new Vector2(-3, 3);
            }
        }

        else if (this.transform.rotation.z == 1)
        {
            if (playerDirection.x > 0)
            {
                this.transform.localScale = new Vector2(3, 3);
            }
            else
            {
                this.transform.localScale = new Vector2(-3, 3);
            }
        }

        else if (this.transform.rotation.z == 0.7071068f)
        {
            if (playerDirection.y < 0)
            {
                this.transform.localScale = new Vector2(3, 3);
            }
            else
            {
                this.transform.localScale = new Vector2(-3, 3);
            }
        }

        else if (this.transform.rotation.z == -0.7071068f)
        {
            if (playerDirection.y > 0)
            {
                this.transform.localScale = new Vector2(3, 3);
            }
            else
            {
                this.transform.localScale = new Vector2(-3, 3);
            }
        }
    }
}
