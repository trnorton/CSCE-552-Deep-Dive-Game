using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public float speed;
    private float distance;
    private GameObject sprite;
    public float distanceBetween = 7;
    private float distFromSpawn;

    void Start()
    {
        sprite = this.transform.Find("sharkUPLOADABLE").gameObject;
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

        //If player is in range, shark chases
        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, (player.transform.position), speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            if(direction[0] < 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
            if(direction[0] < 0) sprite.GetComponent<SpriteRenderer>().flipY = false;
            if(direction[0] > 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
            if(direction[0] > 0) sprite.GetComponent<SpriteRenderer>().flipY = true;
        }
        //Player out of range, shark goes back to its original spot
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, (spawnPoint.transform.position), speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angleToSpawn);
            if(directionToSpawn[0] < 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
            if(directionToSpawn[0] < 0) sprite.GetComponent<SpriteRenderer>().flipY = false;
            if(directionToSpawn[0] > 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
            if(directionToSpawn[0] > 0) sprite.GetComponent<SpriteRenderer>().flipY = true;
        }
    }

}
