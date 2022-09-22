using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject bottom;
    public GameObject sideLeft;
    public GameObject sideRight;
    private float bottomY;
    private float leftX;
    private float rightX;

    // Start is called before the first frame update
    void Start()
    {
      bottomY = bottom.transform.position.y+5;
      leftX = sideLeft.transform.position.x+12;
      rightX = sideRight.transform.position.x-12;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > bottomY){
          transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        if(player.transform.position.x > leftX && player.transform.position.x < rightX)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
