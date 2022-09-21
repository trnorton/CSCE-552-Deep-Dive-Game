using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    private GameObject sprite;
    public float distanceBetween = 7;

    void Start()
    {
        sprite = this.transform.Find("sharkUPLOADABLE").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance((transform.position), player.transform.position);
        Vector2 direction = (player.transform.position) - (this.transform.position);
        direction.Normalize();
        Debug.Log(distance);
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 180;
        if(direction[0] < 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
        if(direction[0] < 0) sprite.GetComponent<SpriteRenderer>().flipY = false;
        if(direction[0] > 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
        if(direction[0] > 0) sprite.GetComponent<SpriteRenderer>().flipY = true;

         if(distance < distanceBetween)
         {
            transform.position = Vector2.MoveTowards(this.transform.position, (player.transform.position), speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

}
