using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    AudioSource audiosource;
    AudioClip collide;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        collide = audiosource.clip;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //audiosource.PlayOneShot(collide, 1F);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            audiosource.PlayOneShot(collide, 0.1F);
    }
    
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //        CharactorController.IsOnGround = false;
    //}
}
