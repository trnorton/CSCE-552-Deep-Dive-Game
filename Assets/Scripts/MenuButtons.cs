using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OnClickQuit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit(0);
    }
}
