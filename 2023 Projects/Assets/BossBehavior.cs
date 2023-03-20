using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float attackRange = 3.5f;
    public float speed = 6;
    //create a health variable called bossHealth
    public int bossHealth = 10;
    //create a series of bools to help transition us to check if boss is flipped
    public bool phase2 = false;
    public bool phase3 = false;
    public bool isDead = false;
    //create a storage for our Transform
    Transform player;
    //create a storage for our playermanager script
    PlayerManager playerManager;
    //create a storage location for a bool to check if boss is flipped
    public bool isFlipped = false;

    //create a location for our bullet to start from
    public Transform shotLocation;
    public GameObject projectile;
    public GameObject projectile2;
    //create timer system / cooldown
    public float timer;
    public float coolDown;
    //create a function for this attack
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //create a series of if else statements that will check to see if the boss
        //is below 7 and above 3, below 3 and above 1, and less than or equal to 0

        if (bossHealth < 7 && bossHealth > 3)
        {
            speed = 2f;
            attackRange = 6f;
            phase2 = true;

        }
        else if (bossHealth < 4 && bossHealth >= 1)
        {

            phase2 = false;
            speed = 1;
            attackRange = 8;
            phase3 = true;

        }
        else if (bossHealth <= 0)
        {
            phase3 = false;
            isDead = true;

        }

        timer = Time.deltaTime;
    }

    public void ProjectileShoot()
    {
        if (timer > coolDown)
        {
            GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
            timer = 0;
        }
        else if (phase3)
        {
            GameObject clone = Instantiate(projectile2, shotLocation.position, Quaternion.identity);
            timer = 0;
        }
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerManager.TakeDamage();
        }
    }
}
