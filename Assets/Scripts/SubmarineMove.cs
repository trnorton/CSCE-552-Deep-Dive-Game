using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMove : MonoBehaviour
{
    public float speed = 10.0f;
    private bool hasTreasure = false;
    private GameObject sprite;
    public AudioClip pickupSound;
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
      if(inputX < 0) sprite.GetComponent<SpriteRenderer>().flipX = false;
      else if(inputX > 0) sprite.GetComponent<SpriteRenderer>().flipX = true;
      transform.Translate(moveVect);

      //Debug.Log(sprite.transform.position.y > 35 && hasTreasure);
      if (sprite.transform.position.y > 35 && hasTreasure)
      {
         //TODO win text displays
      }
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
