using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTreasure : MonoBehaviour
{
    public GameObject canvas;
    public GameObject treasureIcon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Picked up treasure");
            GameObject treasureIconImage = Instantiate(treasureIcon);
            treasureIconImage.transform.SetParent(canvas.transform, false);
            Destroy(this.gameObject);
        }

    }
}
