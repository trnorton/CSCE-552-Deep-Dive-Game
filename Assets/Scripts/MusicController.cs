using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public SubmarineMove subMove;
    public CollectTreasure ColTres;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(subMove.playerHasTreasure())
        {
            audioSource.pitch = 1.25f;
        }
        if(subMove.playerHasWon())
        {
            audioSource.Pause();
        }
        
    }

    public void playMusic()
    {
        audioSource.Play(1);
    }

    public void pauseMusic()
    {
        audioSource.Pause();
    }
}
