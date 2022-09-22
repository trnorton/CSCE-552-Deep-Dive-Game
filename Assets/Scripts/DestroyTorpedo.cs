using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTorpedo : MonoBehaviour
{
    public GameObject TorpedoDestroyEffect;
    public float deathTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name != "Player")
        {
            TorpedoDie();
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(deathTimer);
        TorpedoDie();
    }

    void TorpedoDie()
    {
        if(TorpedoDestroyEffect != null)
        {
            Instantiate(TorpedoDestroyEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
