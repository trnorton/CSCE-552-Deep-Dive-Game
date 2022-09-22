using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void onClickQuitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
