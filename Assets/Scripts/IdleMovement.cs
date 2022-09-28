using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMovement : MonoBehaviour
{
    public GameObject shark;
    private Vector3 spawn;
    public GameObject player;
    public float speed;
    private bool moveRight;
    public AudioSource damageSound;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D thisCollider = GetComponent<Collider2D>();
        spawn = transform.position;
        moveRight = true;
        speed = 5.0f;
        damageSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight == true)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
  
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shark") || collision.gameObject.CompareTag("Jellyfish"))
        {
             Physics.IgnoreCollision(shark.GetComponent<Collider>(), GetComponent<Collider>());
        }
        if (collision.gameObject.CompareTag("Player"))
        {
             var healthComponent = player.GetComponent<Health>();
             if(healthComponent != null)
             {
                damageSound.Play();
                healthComponent.TakeDamage(1);
             }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.tag == "Border")
        {
            if(moveRight == false)
            {
                moveRight = true;
            }
            else
            { 
                moveRight = false;
            }
        }
        if(collisionGameObject.tag == "Torpedo")
        {
            Destroy(this.gameObject);
        }
    }
}
