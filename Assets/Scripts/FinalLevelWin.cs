using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelWin : MonoBehaviour
{
    public GameObject sub;
    public GameObject WinUI;
    

    // Start is called before the first frame update
    void Start()
    {
        
        WinUI = GameObject.Find("WinUI");
        WinUI.SetActive(false);
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(sub.GetComponent<CollectTreasure>().youWin);

        if(sub.GetComponent<CollectTreasure>().youWin == true)
        {
            SceneManager.LoadScene("WinScene");

        }
    }
}
