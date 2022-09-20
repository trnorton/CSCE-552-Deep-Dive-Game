using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMove : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      float inputX = Input.GetAxis("Horizontal");
      float inputY = Input.GetAxis("Vertical");
      Vector3 moveVect = new Vector3(inputX, inputY, 0);
      moveVect *= speed * Time.deltaTime;
      transform.Translate(moveVect);
    }

    private void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.tag == "Treasure")
      speed *= 0.5f;
    }
}
