using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject bottom;
    private float bottomY;
    // Start is called before the first frame update
    void Start()
    {
      bottomY = bottom.transform.position.y+5;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > bottomY){
          transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
