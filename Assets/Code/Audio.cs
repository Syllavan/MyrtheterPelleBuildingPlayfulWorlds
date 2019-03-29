using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioClip MusicClipOne;
    public AudioClip MusicClipTwo;
    public AudioSource MusicSourceOne;
    public AudioSource MusicSourceTwo;

    // Start is called before the first frame update
    void Start()
    {
        MusicSourceOne.clip = MusicClipOne;
        MusicSourceTwo.clip = MusicClipTwo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
            MusicSourceOne.Play();

        if (Input.GetKeyDown("2"))
            MusicSourceTwo.Play();
       
    }
}
