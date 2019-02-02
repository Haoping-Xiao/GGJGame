using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioClip[] MotherSound;
    private AudioSource audio_source;
    static public bool HadPlayed;
    // Start is called before the first frame update
    void Start()
    {
        MotherSound = new AudioClip[] {
                                     (AudioClip)Resources.Load("Sounds/01"),
                                     (AudioClip)Resources.Load("Sounds/02"),
                                     (AudioClip)Resources.Load("Sounds/03"),
                                     (AudioClip)Resources.Load("Sounds/04"),
                                     (AudioClip)Resources.Load("Sounds/05"),
                                     (AudioClip)Resources.Load("Sounds/06"),
                                     (AudioClip)Resources.Load("Sounds/07"),
                                     (AudioClip)Resources.Load("Sounds/08"),
                                     (AudioClip)Resources.Load("Sounds/09"),
                                     (AudioClip)Resources.Load("Sounds/10"),
                                     (AudioClip)Resources.Load("Sounds/11"),
                                     (AudioClip)Resources.Load("Sounds/12"),
                                     (AudioClip)Resources.Load("Sounds/13"),
                                     (AudioClip)Resources.Load("Sounds/14"),
                                     (AudioClip)Resources.Load("Sounds/15")
                                     //(AudioClip)Resources.Load("Sounds/00-1"),
                                    // (AudioClip)Resources.Load("Sounds/00-2"),
                                    // (AudioClip)Resources.Load("Sounds/00-3")
        };
        audio_source = GetComponent<AudioSource>();
        HadPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(StartConversation.startAnswer && !HadPlayed)
        {
            HadPlayed = true;
            audio_source.PlayOneShot(MotherSound[StartConversation.LastRandomNum]);
        }

    }
}
