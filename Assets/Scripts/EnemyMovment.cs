using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public float speed = 5.0f;
    private GameObject sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = this.transform.Find("sharkUPLOADABLE").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
