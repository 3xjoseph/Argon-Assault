using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //Singleton Pattern for Music Player
    void Awake() 
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (numMusicPlayers > 1) 
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
