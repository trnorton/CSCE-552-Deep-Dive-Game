using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTorpedo : MonoBehaviour
{
    public Transform firePoint;
    public GameObject player;
    public GameObject torpedoPrefab;
    public float fireSpeed;
    public float fireTimer;
    private bool isFiring;
    public Transform firePointRight;
    // Start is called before the first frame update
    void Start()
    {
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isFiring)
        {
            StartCoroutine(Fire());
            Physics2D.IgnoreLayerCollision(6, 7);
        }
    }

    IEnumerator Fire()
    {
        GameObject sprite = this.transform.Find("submarineUPLOADABLE").gameObject;
        if(sprite.GetComponent<SpriteRenderer>().flipX == false)
        {
            torpedoPrefab.GetComponent<SpriteRenderer>().flipX = false;
            isFiring = true;
            GameObject newTorpedo = Instantiate(torpedoPrefab, firePoint.position, Quaternion.identity);
            newTorpedo.GetComponent<Rigidbody2D>().velocity = new Vector2(fireSpeed * -1 * Time.fixedDeltaTime, 0f);
            newTorpedo.transform.localScale = new Vector2(newTorpedo.transform.localScale.x * -1, newTorpedo.transform.localScale.y);

            yield return new WaitForSeconds(fireTimer);
            isFiring = false;
        }
        else if(sprite.GetComponent<SpriteRenderer>().flipX == true)
        {
            torpedoPrefab.GetComponent<SpriteRenderer>().flipX = false;
            isFiring = true;
            GameObject newTorpedo = Instantiate(torpedoPrefab, firePointRight.position, Quaternion.identity);
            newTorpedo.GetComponent<Rigidbody2D>().velocity = new Vector2(fireSpeed * 1 * Time.fixedDeltaTime, 0f);
            newTorpedo.transform.localScale = new Vector2(newTorpedo.transform.localScale.x * 1, newTorpedo.transform.localScale.y);

            yield return new WaitForSeconds(fireTimer);
            isFiring = false;
        }

    }
}
