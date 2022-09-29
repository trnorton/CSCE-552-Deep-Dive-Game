using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMove : MonoBehaviour
{
    public float speed = 10.0f;
    private bool hasTreasure = false;
    private GameObject sprite;
    //private float vol = 0.0f;
    public AudioClip pickupSound;
    //public AudioClip moveSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        sprite = this.transform.Find("submarineUPLOADABLE").gameObject;
        Collider2D thisCollider = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 moveVect = new Vector3(inputX, inputY, 0);
        moveVect *= speed * Time.deltaTime;
        Debug.Log(moveVect);
        if (inputX < 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
        else if (inputX > 0) sprite.GetComponent<SpriteRenderer>().flipX = true;
        transform.Translate(moveVect);

        /*
        if (moveVect != Vector3.zero && vol < 0.1f)
        {
            vol += 0.00125f;
            audioSource.PlayOneShot(moveSound, vol);
        }
        else if(moveVect != Vector3.zero && vol >= 0.1f)
        {
            audioSource.PlayOneShot(moveSound, vol);
        }

        if(moveVect == Vector3.zero && vol >= 0)
        {
            vol -= 0.05f;
        }
        */
    }

    public bool playerHasWon()
    {
        if (sprite.transform.position.y > 36 && hasTreasure)
        {
            return true;
        }
        return false;
    }

    public bool playerHasTreasure()
    {
        return hasTreasure;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        if (collision.gameObject.tag == "Treasure")
        {
            speed *= 0.5f;
            hasTreasure = true;
            audioSource.PlayOneShot(pickupSound, 1.0f);
        }
    }
}
