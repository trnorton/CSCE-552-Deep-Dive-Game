using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTreasure : MonoBehaviour
{
    public GameObject treasure;
    public GameObject canvas;
    public GameObject treasureIcon;
    public GameObject objectiveSecondHalf;
    public bool youWin;
    private bool treasureCollected;
    private float startLocation;
    

    // Start is called before the first frame update
    void Start()
    {
        youWin = false;
        treasureCollected = false;
        startLocation = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y >= startLocation && treasureCollected == true)
        {
            youWin = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Treasure")
        {
            Debug.Log("Picked up treasure");
            GameObject treasureIconImage = Instantiate(treasureIcon);
            treasureIconImage.transform.SetParent(canvas.transform, false);
            GameObject secondObjectiveText = Instantiate(objectiveSecondHalf);
            secondObjectiveText.transform.SetParent(canvas.transform, false);
            Destroy(treasure);
            treasureCollected = true;
        }

    }
}
