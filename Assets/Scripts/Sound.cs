using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource[] sources;
    int k = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            int k = Random.RandomRange(0, 2);
                sources[1].clip = sounds[k];
                sources[1].Play();
             
           
           
           
        }

       
    }



    public void volmusic(float val)
    { sources[0].volume = val; }
    public void volsound(float val)
    { sources[1].volume = val; }
}
