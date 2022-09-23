using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public GameObject SharkDestroyEffect;
    public float speed;
    private float distance;
    private GameObject sprite;
    public float distanceBetween = 7;
    private float distFromSpawn;
    private Vector3 target;
    private float startX;
    private float startY;
    public float idleEndPoint;
    private float distIdle;
    public AudioSource sharkSound;


    void Start()
    {
        sprite = this.transform.Find("sharkUPLOADABLE").gameObject;
        target = transform.position;
        startX = transform.position.x;
        startY = transform.position.y;
        Collider2D thisCollider = GetComponent<Collider2D>();
        sharkSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.GetComponent<SpriteRenderer>().flipY = true;
        //From shark to player
        distance = Vector2.Distance((transform.position), player.transform.position);
        Vector2 direction = (player.transform.position) - (this.transform.position);
        direction.Normalize();
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 180;

        //From shark back to spawn
        distFromSpawn = Vector2.Distance((transform.position), spawnPoint.transform.position);
        Vector2 directionToSpawn = (spawnPoint.transform.position) - (this.transform.position);
        directionToSpawn.Normalize();
        float angleToSpawn = (Mathf.Atan2(directionToSpawn.y, directionToSpawn.x) * Mathf.Rad2Deg) + 180;
        
        //For Idle movement
        Vector2 directionIdle = target - this.transform.position;
        float angleToIdle = (Mathf.Atan2(directionIdle.y, directionIdle.x) * Mathf.Rad2Deg) + 180;

        //If player is in range, shark chases
        if(distance < distanceBetween)
        {
            target.x = startX;
            transform.position = Vector2.MoveTowards(this.transform.position, (player.transform.position), speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            if(direction[0] < 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
            if(direction[0] < 0) sprite.GetComponent<SpriteRenderer>().flipY = false;
            if(direction[0] > 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
            if(direction[0] > 0) sprite.GetComponent<SpriteRenderer>().flipY = true;
        }
        //Player out of range, shark goes back to its original spot to go idle
        else if (transform.position.y != startY)
        {
            target.x = startX;
            transform.position = Vector2.MoveTowards(this.transform.position, (spawnPoint.transform.position), speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angleToSpawn);
            if(directionToSpawn[0] < 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
            if(directionToSpawn[0] < 0) sprite.GetComponent<SpriteRenderer>().flipY = false;
            if(directionToSpawn[0] > 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
            if(directionToSpawn[0] > 0) sprite.GetComponent<SpriteRenderer>().flipY = true;
        }
        //Idle
        if (transform.position.y == startY)
        {

            if(transform.position.x == startX)
            {
                target.x = idleEndPoint;
            }
            else if(transform.position.x == idleEndPoint)
            {
                target.x = startX;
            }
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angleToIdle);
            if(directionIdle[0] < 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
            if(directionIdle[0] < 0) sprite.GetComponent<SpriteRenderer>().flipY = false;
            if(directionIdle[0] > 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
            if(directionIdle[0] > 0) sprite.GetComponent<SpriteRenderer>().flipY = true;
        }
    }

    //Damage to player while they are colliding
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sharkSound.Play();
            var healthComponent = player.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.tag == "Torpedo")
        {
            SharkDie();
        }
    }
    void SharkDie()
    {
        if(SharkDestroyEffect != null)
        {
            Instantiate(SharkDestroyEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

}
