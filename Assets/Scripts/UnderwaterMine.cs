using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterMine : MonoBehaviour
{
    
    public GameObject player;
    public GameObject TorpedoDestroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D thisCollider = GetComponent<Collider2D>();
        Physics2D.IgnoreLayerCollision(9, 10, true);
        Physics2D.IgnoreLayerCollision(8, 10, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             var healthComponent = player.GetComponent<Health>();
             if(healthComponent != null)
             {
                Instantiate(TorpedoDestroyEffect, transform.position, Quaternion.identity);
                healthComponent.TakeDamage(1);
                Destroy(this.gameObject);
                
             }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.tag == "Torpedo")
        {
            Instantiate(TorpedoDestroyEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
