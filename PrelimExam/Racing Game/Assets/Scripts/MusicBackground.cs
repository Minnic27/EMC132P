using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackground : MonoBehaviour
{

    private static MusicBackground instance = null;
    public static MusicBackground Instance
    {
        get { return instance; }
    }

    void Awake() // initializes variables or states before the application starts
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else 
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject); // the music won't stop after loading another scene
    }
}
