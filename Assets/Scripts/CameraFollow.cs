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
    private float sideXpositive;
    private float sideXnegative;

    // Start is called before the first frame update
    void Start()
    {
      bottomY = bottom.transform.position.y+5;
      sideXpositive = sideLeft.transform.position.x+9;
      sideXnegative = sideRight.transform.position.x-9;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > bottomY){
          transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        if(player.transform.position.x > sideXpositive)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        if(player.transform.position.x < sideXnegative)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
